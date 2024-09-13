/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-12
 * Time: 17:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Threading;
using System.Timers;

using Solarium.Config;
using Solarium.Frame;
using Solarium.Settings;
using Solarium.Utils;
using Solarium.Bios;
using Microsoft.Data.Sqlite;

namespace Solarium.Db
{
	/// <summary>
	/// Description of DataBase.
	/// </summary>
	public class DataBase
	{
		private IMainFrame mf = null;
		
		private Bios.Bios bios = null;
		public Bios.Bios Bios {
			get { return bios; }
		}
		
		//private string md5Key = "chrumchrum";
		
		private string 	localConnUrl 	= "localhost";
		private int 	localConnPort 	= 5432;
		private string 	localConnBase 	= "localbase";
		private string 	localConnUser 	= "localuser";
		private string 	localConnPass 	= "123qwe";
		
		private string 	remoteConnUrl 	= "s91.superhost.pl";
		private int 	remoteConnPort 	= 3306;
		private string 	remoteConnBase 	= "solarium_baza";
		private string 	remoteConnUser 	= "solarium_admin";
		private string 	remoteConnPass 	= "123qwe";
		
		private OdbcConnection remoteConnection = null;
		private string remoteConnectionString = "";
		private Thread connectionKeeperThread = null;
		private System.Timers.Timer connectionKeeperTimer = null;
		private System.Timers.Timer connectionCheckerTimer = null;
		
		private SqliteConnection localConnection = null;
		private string localConnectionString = "";
		
		private DBConfigSettings dbConfigSettings;
		public DBConfigSettings DbConfigSettings {
			get { return dbConfigSettings; }
		}
		
		public ConnectionState RemoteConnectionState {
			get { return remoteConnection.State; }
		}
		
		/// <summary>
		/// Database connection/querying class.
		/// TODO:
		/// dodać kodowanie md5 do parametrów w konfigu. + stały klucz (md5Key).
		/// dodać mozliwosc zmiany tych paramsow w prefsach gdzies... moze dodatkowy plugin pt. AdminPrefs?
		/// </summary>
		/// <param name="mf">main frame</param>
		public DataBase(IMainFrame mf)
		{
			this.mf = mf;
			
			dbConfigSettings = DBConfigSettings.GetSection(ConfigurationUserLevel.None);

			this.localConnBase = dbConfigSettings.LocalBase;
			this.localConnUrl = dbConfigSettings.LocalUrl;
			this.localConnPass = dbConfigSettings.LocalPass;
			this.localConnUser = dbConfigSettings.LocalUser;
			this.localConnPort = dbConfigSettings.LocalPort;
		
			this.remoteConnBase = dbConfigSettings.RemoteBase;
			this.remoteConnUrl = dbConfigSettings.RemoteUrl;
			this.remoteConnPass = dbConfigSettings.RemotePass;
			this.remoteConnUser = dbConfigSettings.RemoteUser;
			this.remoteConnPort = dbConfigSettings.RemotePort;
		}
		
		#region _Events

		/// <summary>
		/// Datbase request sent event
		/// </summary>
		public event DatabaseEventHandler RequestSent;
		protected virtual void FireRequestSent(DatabaseEventArgs e){
			if(RequestSent!=null){
				RequestSent(this, e);
			}
		}
		
		/// <summary>
		/// Datbase connection lost
		/// </summary>
		public event DatabaseEventHandler ConnectionLost;
		protected virtual void FireConnectionLost(DatabaseEventArgs e){
			if(ConnectionLost!=null){
				ConnectionLost(this, e);
			}
		}
		
		/// <summary>
		/// Datbase connection lost
		/// </summary>
		public event DatabaseEventHandler ConnectionRestored;
		protected virtual void FireConnectionRestored(DatabaseEventArgs e){
			if(ConnectionRestored!=null){
				ConnectionRestored(this, e);
			}
		}

		#endregion
		
		#region _private_methods

		/// <summary>
		/// start remote connection
		/// </summary>
		private void startRemoteConnection(){
			#if (DEBUG)
			log4net.LogManager.GetLogger("Database").Info("Initializing remote connection...");
			#endif
			
			dbConfigSettings.Md5test = "chrum chrum chrum";
			dbConfigSettings.Save();
			
			try{
				remoteConnectionString =
					"DRIVER={MySQL ODBC 3.51 Driver};" 	+
					"SERVER="		+	remoteConnUrl	+	"; "	+
					"DATABASE="		+	remoteConnBase	+	"; "	+
					//"PORT="		+	remoteConnPort	+	"; "	+
					"UID="			+	remoteConnUser	+	"; "	+
					"PASSWORD="		+	remoteConnPass	+	"; ";
				remoteConnection = new OdbcConnection(remoteConnectionString);
				remoteConnection.StateChange += new StateChangeEventHandler(OnRemoteConnectionStateChange);

				remoteConnection.Open();

				//jesli w konfigu mamy true to odpalamy keeper threada
				if(dbConfigSettings.KeeperThread){
					connectionKeeperThread = new Thread(new ThreadStart(connectionKeeper));
					connectionKeeperThread.Start();
				}
			}catch (TimeoutException){
				#if (DEBUG)
				log4net.LogManager.GetLogger("Database").Fatal("Timeout while initialising remote connection...");
				#endif
				FireConnectionLost(new DatabaseEventArgs(this, "Remote database connection timeout!"));
				Utils.DialogUtils.ShowError(mf, "Błąd", "Wystąpił błąd podczas próby nawiązania połączenia z bazą danych.\r\n" +
				                            "Serwer " + remoteConnUrl + " nie odpowiada.");
			}catch (Exception ex){
				#if (DEBUG)
				log4net.LogManager.GetLogger("Database").Fatal("Error initialising remote connection:",ex);
				#endif
				Utils.DialogUtils.ShowError(mf, "Error while initializing remote connecion",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
				                                                        this.GetType().FullName,
				                                                        System.Reflection.MethodBase.GetCurrentMethod().ToString()),
				                                          ex));
			}
			
			#if (DEBUG)
			log4net.LogManager.GetLogger("Database").Info("Remote connection initialized!");
			#endif
		}
		
		/// <summary>
		/// start local connection
		/// </summary>
		private void __startLocalConnection(){
			#if (DEBUG)
			log4net.LogManager.GetLogger("Database").Info("Initializing local connection...");
			#endif
			
			try{
				localConnectionString =
					"DRIVER={MySQL ODBC 3.51 Driver}; "	+
					"SERVER="		+	localConnUrl	+	"; " +
					"DATABASE="		+	localConnBase	+	"; " +
					"PORT="			+	localConnPort	+	"; " +
					"UID="			+	localConnUser	+	"; " +
					"PASSWORD="		+	localConnPass	+	"; ";
				//localConnection = new OdbcConnection(localConnectionString);
				//localConnection.Open();
			}catch (TimeoutException){
				#if (DEBUG)
				log4net.LogManager.GetLogger("Database").Fatal("Timeout while initialising remote connection...");
				#endif
				Utils.DialogUtils.ShowError(mf, "Błąd", "Wystąpił błąd podczas próby nawiązania połączenia z bazą danych.\r\n" +
				                            "Serwer " + localConnUrl + " nie odpowiada.");
			}catch(Exception ex){
				#if (DEBUG)
				log4net.LogManager.GetLogger("Database").Fatal("Error initialising local connection:",ex);
				#endif
				Utils.DialogUtils.ShowError(mf, "Error while initializing local connecion",
				                            new Exception(string.Format("Class: {0}\nMethod: {1}",
				                                                        this.GetType().FullName,
				                                                        System.Reflection.MethodBase.GetCurrentMethod().ToString()),
				                                          ex));
			}
			#if (DEBUG)
			log4net.LogManager.GetLogger("Database").Info("Local connection initialized!");
			#endif
		}

		/// <summary>
		/// 
		/// </summary>
		private void startLocalConnection()
		{
			using (localConnection = new SqliteConnection("Data Source=multisolar.db"))
			{
				localConnection.Open();
			}
        }
		
		/// <summary>
		/// Start remote connection keeper timer
		/// </summary>
		private void connectionKeeper(){
			connectionKeeperTimer = new System.Timers.Timer();
			connectionKeeperTimer.Interval = 5000;
			connectionKeeperTimer.Elapsed += new ElapsedEventHandler(KeepConnection);
			connectionKeeperTimer.Start();
		}
		
		/// <summary>
		/// Keep remote connection callback.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void KeepConnection(object sender, EventArgs e){
			OdbcCommand c = new OdbcCommand("show tables", remoteConnection);
			long then = Stopwatch.GetTimestamp();
			c.ExecuteNonQuery();
			long now = Stopwatch.GetTimestamp();
			FireRequestSent(new DatabaseEventArgs(this, String.Format("[Keeper :{0}ms]({1}): {2}",
			                                                          TimeSpan.FromTicks(now-then).Milliseconds,
			                                                          DateTime.Now,
			                                                          c.CommandText)));
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		private void connectionChecker(){
			connectionCheckerTimer = new System.Timers.Timer();
			connectionCheckerTimer.Interval = 15000;
			connectionCheckerTimer.Elapsed += new ElapsedEventHandler(CheckConnection);
			connectionCheckerTimer.Start();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckConnection(object sender, EventArgs e){
			try{
				if(remoteConnection == null){
					startRemoteConnection();
				}else{
					remoteConnection.Open();
				}
			}catch(TimeoutException){
			}catch(Exception){
			}finally{
			}

		}

		/// <summary>
		/// Fill sql query with parameters.
		/// Simple replace the '?' character with values
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="sqlParams"></param>
		/// <returns></returns>
		private string FillQuery(string sql, List<OdbcParameter> sqlParams){
			int pos = 0;
			foreach(OdbcParameter param in sqlParams){
				pos = sql.IndexOf('?', pos);
				sql = sql.Remove(pos, 1);
				sql = sql.Insert(pos, string.Format("{0}", param.Value));
			}
			return sql;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void OnRemoteConnectionStateChange(object sender, StateChangeEventArgs eventArgs){
			switch(eventArgs.CurrentState){
				case ConnectionState.Connecting:
					mf.MFStatusStrip.StatusMessage.Text = "Database connecting...";
					break;
				case ConnectionState.Broken:
					mf.MFStatusStrip.StatusMessage.Text = "Database DISCONNECTED!";
					FireConnectionLost(new DatabaseEventArgs(this, "Database disconnected!"));
					//mf.MFStatusStrip.ProgressBar.ProgressBar.BackColor = System.Drawing.Color.Red;
					break;
				case ConnectionState.Executing:
					mf.MFStatusStrip.FreeMessage.Text = "Database - executing command...";
					break;
				case ConnectionState.Fetching:
					mf.MFStatusStrip.FreeMessage.Text = "Database - retreiving results...";
					break;
				case ConnectionState.Open:
					mf.MFStatusStrip.StatusMessage.Text = "Database connected!";
					mf.MFStatusStrip.FreeMessage.Text = "Trying to (re)initialize BIOS...";
					FireConnectionRestored(new DatabaseEventArgs(this, "Database connection opened!"));
					InitBios(false);
					//mf.MFStatusStrip.ProgressBar.ProgressBar.c= System.Drawing.Color.Green;
					break;
				case ConnectionState.Closed:
					mf.MFStatusStrip.StatusMessage.Text = "Database connection closed!";
					FireConnectionLost(new DatabaseEventArgs(this, "Database connection closed!"));
					break;
				default:
					break;
			}
		}

		#endregion

		#region _public_methods

		/// <summary>
		/// Initialize bios
		/// </summary>
		/// <param name="force">forece re-initialize</param>
		public void InitBios(bool force){
			if(this.bios == null){
				this.bios = new Bios.Bios(this, mf);
			}else if(force){
				this.bios = new Bios.Bios(this, mf);
			}
		}
		
		/// <summary>
		/// connect
		/// </summary>
		public void connect(){
			startRemoteConnection();
			connectionChecker();
		}
		
		/// <summary>
		/// Simple sql query to the remote database
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public OdbcDataReader RemoteQuery(string sql){
			OdbcCommand c = null;
			OdbcDataReader odr = null;
			try {
				c = new OdbcCommand(sql, remoteConnection);
				long then = Stopwatch.GetTimestamp();
				odr = c.ExecuteReader();
				long now = Stopwatch.GetTimestamp();
				FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}",
				                                                          DateTime.Now,
				                                                          TimeSpan.FromTicks(now-then).Milliseconds,
				                                                          c.CommandText)));
			} catch (OdbcException) {
				//tutaj przewaznie wpadamy w wypadku błedu z polaczeniem... wiec disonnect + connect...
				remoteConnection.Close();
				remoteConnection.Open();
			} catch (Exception ex) {
				throw new Exception(string.Format("Class: {0}\nMethod: {1}", this.GetType().FullName,
				                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()), ex);
			}
			return odr;
		}
		
		/// <summary>
		/// Simple sql query to the local database
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public OdbcDataReader LocalQuery(string sql){
			OdbcCommand c = null;
			OdbcDataReader odr = null;
			try {
				c = new OdbcCommand(sql,localConnection);
				long then = Stopwatch.GetTimestamp();
				odr = c.ExecuteReader();
				long now = Stopwatch.GetTimestamp();
				FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}",
				                                                          DateTime.Now,
				                                                          TimeSpan.FromTicks(now-then).Milliseconds,
				                                                          c.CommandText)));
			} catch (Exception ex) {
				throw new Exception(string.Format("Class: {0}\nMethod: {1}", this.GetType().FullName,
				                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()), ex);
			}
			return odr;
		}
		
		/// <summary>
		/// Concurent query - ask remote database first, and if timeout exception
		/// happens ask a local database....
		/// hm... tylko trzeba przewidziec, ze lokalnie jak cos to trzymamy table_ws...
		/// w wiekszosci.. chyba?:)
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public OdbcDataReader ConcurentQuery(string sql){
			OdbcDataReader dr = null;
			OdbcCommand c = new OdbcCommand(sql,remoteConnection);
			c.CommandTimeout = 5;//5 sec
			try{
				long then = Stopwatch.GetTimestamp();
				dr = c.ExecuteReader();
				long now = Stopwatch.GetTimestamp();
				FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}",
				                                                          DateTime.Now,
				                                                          TimeSpan.FromTicks(now-then).Milliseconds,
				                                                          c.CommandText)));
			}catch(TimeoutException){
				c = new OdbcCommand(sql,localConnection);
				try{
					long then = Stopwatch.GetTimestamp();
					dr = c.ExecuteReader();
					long now = Stopwatch.GetTimestamp();
					FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}",
					                                                          DateTime.Now,
					                                                          TimeSpan.FromTicks(now-then).Milliseconds,
					                                                          c.CommandText)));
				}catch(TimeoutException tex2){
					DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
					                                                      this.GetType().FullName,
					                                                      System.Reflection.MethodBase.GetCurrentMethod().ToString()),
					                                        tex2));
					return null;
				}
			}catch(OdbcException oex){
				throw new Exception(string.Format("Class: {0}\nMethod: {1}", this.GetType().FullName,
				                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()), oex);
			}
			return dr;
		}
		
		/// <summary>
		/// Parametrized concurent sql query
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="sqlParams"></param>
		/// <returns></returns>
		public OdbcDataReader ConcurentQuery(string sql, List<OdbcParameter> sqlParams){
			OdbcDataReader dr = null;
			OdbcCommand c = new OdbcCommand(sql,remoteConnection);
			c.Parameters.AddRange(sqlParams.ToArray());
			try{
				long then = Stopwatch.GetTimestamp();
				dr = c.ExecuteReader();
				long now = Stopwatch.GetTimestamp();
				FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}\r\n\t{3}",
				                                                          DateTime.Now,
				                                                          TimeSpan.FromTicks(now-then).Milliseconds,
				                                                          c.CommandText,
				                                                          FillQuery(sql, sqlParams))));
			}catch(TimeoutException){
				c = new OdbcCommand(sql,localConnection);
				try{
					long then = Stopwatch.GetTimestamp();
					dr = c.ExecuteReader();
					long now = Stopwatch.GetTimestamp();
					FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}\r\n\t{3}",
					                                                          DateTime.Now,
					                                                          TimeSpan.FromTicks(now-then).Milliseconds,
					                                                          c.CommandText,
					                                                          FillQuery(sql, sqlParams))));
				}catch(TimeoutException tex2){
					DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
					                                                      this.GetType().FullName,
					                                                      System.Reflection.MethodBase.GetCurrentMethod().ToString()),
					                                        tex2));
					return null;
				}
			}catch(OdbcException oex){
				throw new Exception(string.Format("Class: {0}\nMethod: {1}", this.GetType().FullName,
				                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()), oex);
			}
			return dr;
		}

		/// <summary>
		/// To send queries with updates etc. - without response.
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="sqlParams"></param>
		/// <returns>number of affected rows or -1 if error</returns>
		public int ConcurentNoRsQuery(string sql, List<OdbcParameter> sqlParams){
			int result = 0;
			OdbcCommand c = new OdbcCommand(sql,remoteConnection);
			c.Parameters.AddRange(sqlParams.ToArray());
			try{
				long then = Stopwatch.GetTimestamp();
				result = c.ExecuteNonQuery();
				long now = Stopwatch.GetTimestamp();
				FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}\r\n\t{3}",
				                                                          DateTime.Now,
				                                                          TimeSpan.FromTicks(now-then).Milliseconds,
				                                                          c.CommandText,
				                                                          FillQuery(sql, sqlParams))));
			}catch(TimeoutException){
				c = new OdbcCommand(sql,localConnection);
				try{
					long then = Stopwatch.GetTimestamp();
					result = c.ExecuteNonQuery();
					long now = Stopwatch.GetTimestamp();
					FireRequestSent(new DatabaseEventArgs(this, String.Format("({0}) [{1}ms]: {2}\r\n\t{3}",
					                                                          DateTime.Now,
					                                                          TimeSpan.FromTicks(now-then).Milliseconds,
					                                                          c.CommandText,
					                                                          FillQuery(sql, sqlParams))));
				}catch(TimeoutException tex2){
					DialogUtils.ShowError(mf, new Exception(string.Format("Class: {0}\nMethod: {1}",
					                                                      this.GetType().FullName,
					                                                      System.Reflection.MethodBase.GetCurrentMethod().ToString()),
					                                        tex2));
					return -1;
				}
			}catch(OdbcException oex){
				throw new Exception(string.Format("Class: {0}\nMethod: {1}", this.GetType().FullName,
				                                  System.Reflection.MethodBase.GetCurrentMethod().ToString()), oex);
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public DataTable getTableInfo(String table) {
			return remoteConnection.GetSchema(table);
		}
		
		#endregion

	}
}
