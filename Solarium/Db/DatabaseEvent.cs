/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-09-17
 * Time: 22:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

using Solarium.Plugin;

namespace Solarium.Db
{
	public delegate void DatabaseEventHandler ( object sender, DatabaseEventArgs e );
	
	public class DatabaseEventArgs : EventArgs
	{
		private string message = null;
		public string Message {
			get { return message; }
			set { message = value; }
		}
		
		private DataBase database = null;
		public DataBase Database {
			get { return database; }
			set { database = value; }
		}
		
		public DatabaseEventArgs(DataBase database, string message)
		{
			this.database = database;
			this.message = message;
		}
	}
}
