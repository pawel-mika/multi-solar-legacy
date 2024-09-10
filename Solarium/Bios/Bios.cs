/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2007-10-01
 * Time: 20:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Data.Odbc;

using Solarium.Bios.Model;
using Solarium.Db;
using Solarium.Db.QueryTools;
using Solarium.Frame;
using Solarium.Utils;

namespace Solarium.Bios
{
	/// <summary>
	/// This is one of the main classes. It represents bios objects and components and allow to
	/// manipulate them.
	/// It gets the bios_* tables from the database. Parse them and store in appropriate objects/lists.
	/// Depend of the lists content, allow to create/modify/delete objects/components.
	/// </summary>
	public class Bios
	{
		#region _properties

		/// <summary>
		/// This is the bios version got from database.
		/// </summary>
		private static decimal biosVersion = 1.01M;
		public decimal BiosVersion {
			get { return biosVersion; }
		}

		private DataBase dataBase = null;
		private IMainFrame mf = null;
		
		/// <summary>
		/// List of the all object types available in database's bios (table bios_objtypes).
		/// </summary>
		private List<BiosObjectType> biosObjectTypes = new List<BiosObjectType>();
		
		/// <summary>
		/// List of the all component types available in database's bios (table bios_comptypes).
		/// </summary>
		private List<BiosComponentType> biosComponentTypes = new List<BiosComponentType>();
		
		/// <summary>
		/// Dictionary of objects available in database's bios (table bios_components).
		/// The key is object type (BiosObjectType) and the value is list of components (bios_components)
		/// with their properties (for example min/max count).
		/// </summary>
		private Dictionary<BiosObjectType, LinkedList<BiosComponent>> biosObjects
			= new Dictionary<BiosObjectType, LinkedList<BiosComponent>>();
		public Dictionary<BiosObjectType, LinkedList<BiosComponent>> BiosObjects {
			get { return biosObjects; }
		}

		/// <summary>
		/// Bios codelist entries to codelist entries mapping.
		/// </summary>
//		private Dictionary<BiosCodelistEntry, LinkedList<CodelistEntry>> codelists
//			= new Dictionary<BiosCodelistEntry, LinkedList<CodelistEntry>>();
		private static BiosCodelist biosCodelist = new BiosCodelist();
		public static BiosCodelist Codelists{
			get {
				if(biosCodelist != null && biosCodelist.Count > 0){
					return biosCodelist;
				} 
				throw new BiosException("Codelists not initialized or empty!");
			}
		}
		#endregion

		#region _bios_events

		public event BiosEventHandler BiosInitializationComplete;
		protected virtual void OnBiosInitializationComplete(BiosEvent be)
		{
			if (BiosInitializationComplete != null) {
				BiosInitializationComplete(this, be);
			}
		}
		
		public event BiosEventHandler ComponentCreated;
		protected virtual void OnComponentCreated(BiosEvent be)
		{
			if (ComponentCreated != null) {
				be.AffectedObject = GetObject(be.AffectedObjectId);
				//TODO: poprawic pobieranie komponentu na ten z RcObject zeby zoptymalizowac operacje na bazie
				be.AffectedComponent = GetComponent(be.AffectedComponentId);
				ComponentCreated(this, be);
			}
		}
		
		public event BiosEventHandler ComponentModified;
		protected virtual void OnComponentModified(BiosEvent be)
		{
			if (ComponentModified != null) {
				be.AffectedObject = GetObject(be.AffectedObjectId);
				//TODO: poprawic pobieranie komponentu na ten z RcObject zeby zoptymalizowac operacje na bazie
				be.AffectedComponent = GetComponent(be.AffectedComponentId);
				ComponentModified(this, be);
			}
		}
		
		public event BiosEventHandler ComponentDeleted;
		protected virtual void OnComponentDeleted(BiosEvent be)
		{
			if (ComponentDeleted != null) {
				ComponentDeleted(this, be);
			}
		}
		
		public event BiosEventHandler ObjectCreated;
		protected virtual void OnObjectCreated(BiosEvent be)
		{
			if (ObjectCreated != null) {
				be.AffectedObject = GetObject(be.AffectedObjectId);
				ObjectCreated(this, be);
			}
		}
		
		public event BiosEventHandler ObjectModified;
		protected virtual void OnObjectModified(BiosEvent be)
		{
			if (ObjectModified != null) {
				be.AffectedObject = GetObject(be.AffectedObjectId);
				ObjectModified(this, be);
			}
		}
		
		public event BiosEventHandler ObjectDeleted;
		protected virtual void OnObjectDeleted(BiosEvent be)
		{
			if (ObjectDeleted != null) {
				ObjectDeleted(this, be);
			}
		}

		#endregion
		
		#region _constructors

		public Bios(DataBase dataBase, IMainFrame mf)
		{
			#if (DEBUG)
			log4net.LogManager.GetLogger("Bios").Info("Initializing bios...");
			#endif

			this.dataBase = dataBase;
			this.mf = mf;
			InitializeBios();
			
			#if (DEBUG)
			log4net.LogManager.GetLogger("Bios").Info("Bios initialization complete:");
			log4net.LogManager.GetLogger("Bios").Info(string.Format("{0} object types,",biosObjectTypes.Count));
			log4net.LogManager.GetLogger("Bios").Info(string.Format("{0} component types,",biosComponentTypes.Count));
			log4net.LogManager.GetLogger("Bios").Info(string.Format("{0} objects,",biosObjects.Count));
			log4net.LogManager.GetLogger("Bios").Info(string.Format("{0} codelists",biosCodelist.Count));
			#endif
		}

		#endregion
		
		#region _private_methods

		private void InitializeBios()
		{
			try{
				//check version
				GetBiosVersion();
				//get bios_objtypes
				GetBiosObjTypes();
				//get bios_comptypes
				GetBiosCompTypes();
				//get bios_components (for objects)
				GetBiosComponents();
				//get bios_codelist(s)...
				GetBiosCodelist();
			}catch(Exception ex){
				#if (DEBUG)
				log4net.LogManager.GetLogger("Bios").Fatal("Error initializion Bios:", ex);
				#endif
				//DialogUtils.ShowError(dataBase.,"Critical error during the Bios initialization!", ex);
			}finally{
				OnBiosInitializationComplete(new BiosEvent(null, null));
			}
		}
		
		/// <summary>
		/// Get the current database bios version
		/// </summary>
		private void GetBiosVersion()
		{
			string sql = "select * from bios_version";
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			
			if(qr.Rows.Count>0 &&
			   qr.Rows[0].GetObject("version_id")!=null){
				string s = qr.Rows[0].GetObject("version_id").ToString();
				decimal dbBiosVersion = Convert.ToDecimal(s);
				if(biosVersion!=dbBiosVersion){
					throw new BiosException(string.Format(
						"Application vs database bios different versions!\n" +
						"App: {0}, Database: {1}", biosVersion, Convert.ToDecimal(qr.Rows[0].GetObject("version_id"))));
				}
			}
		}
		
		/// <summary>
		/// Get bios_objtypes table from database
		/// </summary>
		private void GetBiosObjTypes()
		{
			string sql = "select * from bios_objtypes";
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			
			foreach(QueryResultRow qrr in qr){
				int rcOtype = Convert.ToInt32(qrr.GetObject("rc_otype"));
				int mainComponent = Convert.ToInt32(qrr.GetObject("main_component"));
				string name = Convert.ToString(qrr.GetObject("name"));
				biosObjectTypes.Add(new BiosObjectType(rcOtype, mainComponent, name));
			}
		}
		
		/// <summary>
		/// Get bios_comptypes table from database
		/// </summary>
		private void GetBiosCompTypes()
		{
			string sql = "select * from bios_comptypes";
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			
			foreach(QueryResultRow qrr in qr){
				int rcCtype = Convert.ToInt32(qrr.GetObject("rc_ctype"));
				string name = Convert.ToString(qrr.GetObject("name"));
				string ctable = Convert.ToString(qrr.GetObject("ctable"));
				bool active = Convert.ToBoolean(qrr.GetObject("active"));
				biosComponentTypes.Add(new BiosComponentType(rcCtype,name,ctable,active));
			}
		}
		
		/// <summary>
		/// Get the bios_components table from database.
		/// </summary>
		private void GetBiosComponents()
		{
			string sql = "select * from bios_components";
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			
			foreach(QueryResultRow qrr in qr){
				int rcOtype = Convert.ToInt32(qrr.GetObject("rc_otype"));
				int rcCtype = Convert.ToInt32(qrr.GetObject("rc_ctype"));
				bool required = Convert.ToBoolean(qrr.GetObject("required")==DBNull.Value?false:qrr.GetObject("required"));
				bool active = Convert.ToBoolean(qrr.GetObject("active")==DBNull.Value?false:qrr.GetObject("active"));
				int minCount = Convert.ToInt32(qrr.GetObject("min_count")==DBNull.Value?0:qrr.GetObject("min_count"));
				int maxCount = Convert.ToInt32(qrr.GetObject("max_count")==DBNull.Value?0:qrr.GetObject("max_count"));
				
				BiosObjectType bot = GetBiosObjectType(rcOtype);
				BiosComponentType bct = GetBiosComponentType(rcCtype);
				if(bot==null){
					#if (DEBUG)
					log4net.LogManager.GetLogger("Bios").Error("Object " + rcOtype + " form bios_components " +
					                                           "not found in bios_objtypes.");
					#endif
					throw new BiosException("Error while initializing bios objects!\n" +
					                        "Object " + rcOtype + " form bios_components " +
					                        "not found in bios_objtypes.");
				}
				if(bct==null){
					#if (DEBUG)
					log4net.LogManager.GetLogger("Bios").Error("Component " + rcCtype + " form bios_components " +
					                                           "not found in bios_comptypes.");
					#endif
					throw new BiosException("Error while initializing bios objects!\n" +
					                        "Component " + rcCtype + " form bios_components " +
					                        "not found in bios_comptypes.");
				}
				if(biosObjects.ContainsKey(bot)){
					biosObjects[bot].AddLast(new BiosComponent(bct,required,active,minCount,maxCount));
				} else {
					LinkedList<BiosComponent> biosComponents = new LinkedList<BiosComponent>();
					biosComponents.AddLast(new BiosComponent(bct,required,active,minCount,maxCount));
					biosObjects.Add(bot,biosComponents);
				}
			}
		}

		/// <summary>
		/// Get a list of codelists, their cTypes, tables, fields etc.
		/// Then get specific codelist and add an entry to dictionary of codelists.
		/// </summary>
		private void GetBiosCodelist(){
			string sql = "select * from bios_codelist";
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			
			foreach(QueryResultRow qrr in qr){
				int rcCtype = Convert.ToInt32(qrr.GetObject("rc_ctype"));
				string fieldName = Convert.ToString(qrr.GetObject("field_name"));
				string clTable = Convert.ToString(qrr.GetObject("cl_table"));
				string clKey = Convert.ToString(qrr.GetObject("cl_key"));
				string clField = Convert.ToString(qrr.GetObject("cl_field"));
				BiosCodelistEntry bce = new BiosCodelistEntry(rcCtype, fieldName, clTable, clKey, clField);
				biosCodelist.Add(bce, GetCodelist(bce));
			}
		}

		/// <summary>
		/// Get a specific codelist 
		/// </summary>
		/// <param name="bce"></param>
		private Codelist GetCodelist(BiosCodelistEntry bce){
			Codelist cl = new Codelist();
			string sql = string.Format("select * from {0}", bce.ClTable);
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			
			try {
				foreach(QueryResultRow qrr in qr){
					int codenum = Convert.ToInt32(qrr.GetObject("codenum"));
					int langCodenum = Convert.ToInt32(qrr.GetObject("lang_codenum"));
					string name = Convert.ToString(qrr.GetObject("name"));
					CodelistEntry cle = new CodelistEntry(codenum, langCodenum, name);
					foreach(QueryResultField qrf in qrr){
						if(string.Compare(qrf.FieldName, "codenum", true) != 0 &&
						   string.Compare(qrf.FieldName, "lang_codenum", true) != 0 &&
						   string.Compare(qrf.FieldName, "name", true) != 0){
							cle.AdditionalFields.AddLast(qrf);
						}
					}
					cl.Add(cle);
				}
			} catch (Exception ex) {
				throw new BiosException("Error while initializing codelist: \r\n " + sql, ex);
			}
			
			return cl;
		}
		
		/// <summary>
		/// Get the current oid and update bios_oid_seq with next value
		/// </summary>
		/// <returns>Current oid</returns>
		private int GetNextOid()
		{
			int oid = 0;
			string sql = "select * from bios_oid_seq";
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql));
			QueryResultRow qrr = qr.Rows[0];
			oid = Convert.ToInt32(qrr.GetObject("actual_oid"));
			
			//hmm...
			//TODO: w momencie przejscia na prace  kilku aplikacji na raz
			//na jednej bazie, albo blokowac tabele bios-oid_seq (jesli mysql 
			//takie cos udostepnia), albo jakos inaczej ta blokate zrobic aby
			//nie bylo przypadku ze kilka aplikacji dostanie ten sam OID!!!
			OdbcParameter op = null;
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			sql = "update bios_oid_seq set actual_oid=?, generate_date=? where actual_oid=?";
			
			op = new OdbcParameter("@new_oid", OdbcType.Int, 10);
			op.Value = oid + 1;
			sqlParams.Add(op);
			op = new OdbcParameter("@gen_date", OdbcType.DateTime);
			op.Value = DateTime.Now;
			sqlParams.Add(op);
			op = new OdbcParameter("@old_oid", OdbcType.Int, 10);
			op.Value = oid;
			sqlParams.Add(op);
			int result = dataBase.ConcurentNoRsQuery(sql,sqlParams);

			return oid;
		}

		/// <summary>
		/// Check the occurence of the component in owner object
		/// </summary>
		/// <param name="cid"></param>
		/// <returns></returns>
		private int GetOccurence(ComponentID cid){
			int occurence = 0;
			OdbcParameter op = null;
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			
			string sql = "select max(rc_occ) from " + GetBiosComponentType(cid.RcCtype).CTable  +
				" where rc_oid=? and rc_otype=? and rc_ctype=?";
			
			op = new OdbcParameter("@rcOid", OdbcType.Int, 10);
			op.Value = cid.RcOid;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcOtype", OdbcType.Int, 10);
			op.Value = cid.RcOtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcCtype", OdbcType.Int, 10);
			op.Value = cid.RcCtype;
			sqlParams.Add(op);
			
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql,sqlParams));
			QueryResultRow qrr = qr.Rows[0];
			occurence = Convert.ToInt32(qrr.GetObject("max(rc_occ)")==DBNull.Value?0:qrr.GetObject("max(rc_occ)"));
			
			return occurence;
		}
		
		
		private int GetComponentCount(ComponentID cid){
			return GetOccurence(cid);
		}
		#endregion
		
		#region _public_methods

		/// <summary>
		/// Get BiosObjectType by rcOtype (object type) or throw BiosException if no such object in bios.
		/// </summary>
		/// <param name="rcOtype">rcOtype of required BiosObiectType</param>
		/// <returns>BiosObjectType</returns>
		public BiosObjectType GetBiosObjectType(int rcOtype)
		{
			foreach(BiosObjectType bot in biosObjectTypes){
				if(rcOtype == bot.RcOtype){
					return bot;
				}
			}
			throw new BiosException(String.Format("No such object: {0}",rcOtype));
		}

		/// <summary>
		/// Get BiosComponentType by rcCtype (component type) or throw BiosException if no such component in bios.
		/// </summary>
		/// <param name="rcCtype">rcCtype of required BiosComponentType</param>
		/// <returns>BiosComponentType</returns>
		public BiosComponentType GetBiosComponentType(int rcCtype)
		{
			foreach(BiosComponentType bct in biosComponentTypes){
				if(rcCtype == bct.RcCtype){
					return bct;
				}
			}
			throw new BiosException(String.Format("No such component: {0}",rcCtype));
		}

		/// <summary>
		/// According to BiosObjectType and BiosComponentType get the BiosComponent.
		/// </summary>
		/// <param name="bot">BiosObjectType</param>
		/// <param name="bct">BiosComponentType</param>
		/// <returns>BiosComponent</returns>
		public BiosComponent GetBiosComponent(BiosObjectType bot, BiosComponentType bct){
			if(biosObjects[bot] != null){
				foreach(BiosComponent bc in biosObjects[bot]){
					if(bc.BiosComponentType == bct){
						return bc;
					}
				}
			}
			throw new BiosException(string.Format("Definition of object {0} does not contain component " +
			                                      "{1} or there is no object {2} at all.",
			                                      bot.RcOtype, bct.RcCtype, bot.RcOtype));
		}
		/// <summary>
		/// Create object and return it's ObjectID
		/// 
		/// hmm... trzeba sie zastanowić czy dodac do paramsów rcStore - bo to mozna z automata dodawac w sumie...chyba
		/// dodać tez automatyczne uzupełanianie innych paramsów!!
		/// </summary>
		/// <param name="rcOtype">object type</param>
		/// <returns></returns>
		public ObjectID CreateObject(int rcOtype){
			BiosObjectType bot = GetBiosObjectType(rcOtype);
			BiosComponentType bct = GetBiosComponentType(bot.MainComponent);
			
			OdbcParameter op = null;
			int oid = GetNextOid();
			
			string sql = "insert into " + bct.CTable + " (rc_oid, rc_otype, rc_ctype, rc_store, rc_occ, rc_sign, rc_mod, rc_lock)" +
				" values (?,?,?,?,?,?,?,?)";
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			op = new OdbcParameter("@oid", OdbcType.Int, 10);
			op.Value = oid;
			sqlParams.Add(op);
			op = new OdbcParameter("@otype", OdbcType.Int, 10);
			op.Value = rcOtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@ctype", OdbcType.Int, 10);
			op.Value = bot.MainComponent;
			sqlParams.Add(op);
			op = new OdbcParameter("@store", OdbcType.Int, 10);		//to brać skads z automata!!!!
			op.Value = mf.MainFrameUI.CurrentUser.RcStore;
			sqlParams.Add(op);
			op = new OdbcParameter("@occ", OdbcType.Int, 10);
			op.Value = 1;
			sqlParams.Add(op);
			op = new OdbcParameter("@sign", OdbcType.Int, 10);		//to brać skads z automata!!!!
			op.Value = mf.MainFrameUI.CurrentUser.WorkerOid;
			sqlParams.Add(op);
			op = new OdbcParameter("@moddate", OdbcType.DateTime);
			op.Value = DateTime.Now;
			sqlParams.Add(op);
			op = new OdbcParameter("@lock", OdbcType.Int, 10);		//????czy to ustawiać automatycznie na usera czy przy tworzeniu pomijac????
			op.Value = 0;
			sqlParams.Add(op);

			int result = 0;
			try{
				result = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			}catch(BiosException bex){
				throw bex;
			}catch(OdbcException oex){
				throw oex;
			}
			
			if(result!=1){
				throw new BiosException(String.Format("Error while creating object {0}!",rcOtype));
			}
			
			ObjectID objectId = new ObjectID(oid,rcOtype);
			
			OnObjectCreated(new BiosEvent(objectId, null));
			
			return objectId;
		}
		
		/// <summary>
		/// Creates specified component in given object.
		/// 
		/// TODO: Dodać sprawdzanie rc_occurence nie w sposob max(rc_occ) ale w taki zeby w wypadku
		/// gdy po drodze był usuniety ktorys z wystepujacych komponentów, utworzyc nowy z pierwszym wolnym.
		/// </summary>
		/// <param name="oid">ObjectID of the object we want to create component in</param>
		/// <param name="rcCtype">rcCtype of the wanted component</param>
		/// <returns>ComponentID of the created component</returns>
		public ComponentID CreateComponent(ObjectID objectId, int rcCtype){
			BiosObjectType bot = GetBiosObjectType(objectId.Otype);
			BiosComponentType bct = GetBiosComponentType(rcCtype);
			BiosComponent bc = GetBiosComponent(bot, bct);

			//pobieramy liczbe wystapien danego komponentu (parametr ComponentID tworzymy jako lekkiego fake'a z occurence
			//na 0 - i tak chcemy otrzymać nowy rcOcc, a w GetOccurence() nie jest on do niczego potrzebny) i zwiekszamy o 1
			int occurence = GetOccurence(new ComponentID(objectId.Oid, objectId.Otype, rcCtype, 0)) + 1;

			//porownujemy liczbe wystapien z mozliwa iloscia wystapien danego komponentu w biosie
			if(occurence<bc.MinCount && bc.MinCount!=0){
				throw new BiosException(string.Format("Wrong occurence - wanted to create {0} but {1} allowed.", occurence, bc.MinCount));
			}else if(occurence>bc.MaxCount && bc.MaxCount!=0){
				throw new BiosException(string.Format("Wrong occurence - wanted to create {0} but {1} allowed.", occurence, bc.MaxCount));
			}

			//if evetything's fine, create the component...
			OdbcParameter op = null;
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			
			string sql = "insert into " + bct.CTable + " (rc_oid, rc_otype, rc_ctype, rc_store, rc_occ, rc_sign, rc_mod, rc_lock)" +
				" values (?,?,?,?,?,?,?,?)";
			op = new OdbcParameter("@oid", OdbcType.Int, 10);
			op.Value = objectId.Oid;
			sqlParams.Add(op);
			op = new OdbcParameter("@otype", OdbcType.Int, 10);
			op.Value = objectId.Otype;
			sqlParams.Add(op);
			op = new OdbcParameter("@ctype", OdbcType.Int, 10);
			op.Value = rcCtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@store", OdbcType.Int, 10);		//to brać skads z automata!!!!
			op.Value = mf.MainFrameUI.CurrentUser.RcStore;
			sqlParams.Add(op);
			op = new OdbcParameter("@occ", OdbcType.Int, 10);		//to bierzemy z automata na postawie innego sql'a
			op.Value = 	occurence;
			sqlParams.Add(op);
			op = new OdbcParameter("@sign", OdbcType.Int, 10);		//to brać skads z automata!!!!
			op.Value = mf.MainFrameUI.CurrentUser.WorkerOid;
			sqlParams.Add(op);
			op = new OdbcParameter("@moddate", OdbcType.DateTime);
			op.Value = DateTime.Now;
			sqlParams.Add(op);
			op = new OdbcParameter("@lock", OdbcType.Int, 10);		//lockowac czy nie lockowac oto jest pytanie?
			op.Value = 0;											//0 - brak locka, lub X - oid pracownika
			sqlParams.Add(op);

			int result = 0;
			try{
				result = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			}catch(BiosException bex){
				throw bex;
			}catch(OdbcException oex){
				throw oex;
			}
			
			if(result!=1){
				throw new BiosException(String.Format("Error while creating component {0} for object {1}!",rcCtype, objectId.ToString()));
			}
			
			ComponentID cid = new ComponentID(objectId.Oid, objectId.Otype, rcCtype, occurence);
			
			OnComponentCreated(new BiosEvent(objectId, cid));
			
			return cid;
		}
		
		/// <summary>
		/// Get whole object - main component + all existent components
		/// </summary>
		/// <param name="oid">ObjectID of required object</param>
		/// <returns></returns>
		public RcObject GetObject(ObjectID oid){
			return new RcObject(oid, GetMainComponentForObject(oid), GetComponentsForObject(oid));
		}
		
		/// <summary>
		/// Get a list of objects WHOSE MAIN COMPONENT FULFILLS CLAUSE!
		/// If clause = null there's no condition so be carefull because
		/// there can be many, maaaany objects...
		/// </summary>
		/// <param name="otype">otype number</param>
		/// <param name="clause">SQL clause (without first AND)</param>
		/// <returns></returns>
		public LinkedList<RcObject> GetObjectsWithClause(int otype, string clause){
			LinkedList<RcObject> returnList = new LinkedList<RcObject>();
			BiosObjectType bot = GetBiosObjectType(otype);
			BiosComponentType bct = GetBiosComponentType(bot.MainComponent);

			OdbcParameter op = null;
			string sql = clause != null ? 
				"select * from " + bct.CTable + " where rc_otype=? and " + clause :
				"select * from " + bct.CTable + " where rc_otype=?";
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			op = new OdbcParameter("@otype", OdbcType.Int, 10);
			op.Value = otype;
			sqlParams.Add(op);
			
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql,sqlParams));
			RcComponent comp = null;
//			if(qr.Rows.Count >= 1){
			foreach(QueryResultRow qrr in qr.Rows){
//				QueryResultRow qrr = qr.Rows[0];
				comp = new RcComponent(qrr);
				ObjectID oid = comp.ComponentId.ObjectId;
				returnList.AddLast(new RcObject(oid, GetMainComponentForObject(oid), GetComponentsForObject(oid)));
			}

			return returnList;
		}

		/// <summary>
		/// Get main rcComponent for specified ObjectID
		/// </summary>
		/// <param name="oid">ObjectID of the object we want the main component for</param>
		/// <returns>Main component of the specified object</returns>
		public RcComponent GetMainComponentForObject(ObjectID oid){
			BiosObjectType bot = GetBiosObjectType(oid.Otype);
			BiosComponentType bct = GetBiosComponentType(bot.MainComponent);

			OdbcParameter op = null;
			string sql = "select * from "+bct.CTable+" where rc_oid=? and rc_otype=?";
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			op = new OdbcParameter("@oid", OdbcType.Int, 10);
			op.Value = oid.Oid;
			sqlParams.Add(op);
			op = new OdbcParameter("@otype", OdbcType.Int, 10);
			op.Value = oid.Otype;
			sqlParams.Add(op);
			
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql,sqlParams));
			RcComponent returnComponent = null;
			if(qr.Rows.Count==1){
				QueryResultRow qrr = qr.Rows[0];
				returnComponent = new RcComponent(qrr);
			}else{
				throw new BiosException("Error while trying to get main component for object "+oid.ToString());
			}

			return returnComponent;
		}

		/// <summary>
		/// Get the specified component.
		/// </summary>
		/// <param name="cid">ComponentID of the required component</param>
		/// <returns>RcComponent</returns>
		public RcComponent GetComponent(ComponentID cid){
			BiosObjectType bot = GetBiosObjectType(cid.RcOtype);
			BiosComponentType bct = GetBiosComponentType(cid.RcCtype);

			OdbcParameter op = null;
			string sql = "select * from "+bct.CTable+" where rc_oid=? and rc_otype=? and rc_ctype=? and rc_occ=?";
			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			op = new OdbcParameter("@oid", OdbcType.Int, 10);
			op.Value = cid.RcOid;
			sqlParams.Add(op);
			op = new OdbcParameter("@otype", OdbcType.Int, 10);
			op.Value = cid.RcOtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@ctype", OdbcType.Int, 10);
			op.Value = cid.RcCtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@occ", OdbcType.Int, 10);
			op.Value = cid.RcOcc;
			sqlParams.Add(op);
			
			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql,sqlParams));
			RcComponent returnComponent = null;
			if(qr.Rows.Count==1){
				QueryResultRow qrr = qr.Rows[0];
				returnComponent = new RcComponent(qrr);
			}else{
				throw new BiosException("Error while trying to get component: " + cid.ToString());
			}

			return returnComponent;
		}
		
//		public RcComponent GetComponentWithClause(int ctype, string clause){
//			BiosObjectType bot = GetBiosObjectType(cid.RcOtype);
//			BiosComponentType bct = GetBiosComponentType(cid.RcCtype);
//
//			OdbcParameter op = null;
//			string sql = "select * from "+bct.CTable+" where rc_oid=? and rc_otype=? and rc_ctype=? and rc_occ=?";
//			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
//			op = new OdbcParameter("@oid", OdbcType.Int, 10);
//			op.Value = cid.RcOid;
//			sqlParams.Add(op);
//			op = new OdbcParameter("@otype", OdbcType.Int, 10);
//			op.Value = cid.RcOtype;
//			sqlParams.Add(op);
//			op = new OdbcParameter("@ctype", OdbcType.Int, 10);
//			op.Value = cid.RcCtype;
//			sqlParams.Add(op);
//			op = new OdbcParameter("@occ", OdbcType.Int, 10);
//			op.Value = cid.RcOcc;
//			sqlParams.Add(op);
//			
//			QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql,sqlParams));
//			RcComponent returnComponent = null;
//			if(qr.Rows.Count==1){
//				QueryResultRow qrr = qr.Rows[0];
//				returnComponent = new RcComponent(qrr);
//			}else{
//				throw new BiosException("Error while trying to get component: " + cid.ToString());
//			}
//
//			return returnComponent;
//		}
		
		/// <summary>
		/// Get components for given object WITHOUT MAIN COMPONENT
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public LinkedList<IRcComponent> GetComponentsForObject(ObjectID oid){
			LinkedList<IRcComponent> components = new LinkedList<IRcComponent>();
			foreach(BiosComponent bc in biosObjects[GetBiosObjectType(oid.Otype)]){
				//get without main component!
				if(bc.BiosComponentType.RcCtype != GetBiosObjectType(oid.Otype).MainComponent){
					OdbcParameter op = null;
					string sql = "select * from "+bc.BiosComponentType.CTable+" where rc_oid=? and rc_otype=? and rc_ctype=?";
					List<OdbcParameter> sqlParams = new List<OdbcParameter>();
					op = new OdbcParameter("@oid", OdbcType.Int, 10);
					op.Value = oid.Oid;
					sqlParams.Add(op);
					op = new OdbcParameter("@otype", OdbcType.Int, 10);
					op.Value = oid.Otype;
					sqlParams.Add(op);
					op = new OdbcParameter("@ctype", OdbcType.Int, 10);
					op.Value = bc.BiosComponentType.RcCtype;
					sqlParams.Add(op);
					
					QueryResult qr = new QueryResult(dataBase.ConcurentQuery(sql,sqlParams));
					foreach(QueryResultRow qrr in qr.Rows){
						components.AddLast(new RcComponent(qrr));
					}
				}
			}
			return components;
		}

		/// <summary>
		/// narazie obsługuje tylko parametry w changeset typu:
		/// int, string, datetime, float, decimal - jak bedzie potrzebne dodac inne
		/// TODO: dodać obczajanie rc_lock np.
		/// </summary>
		/// <param name="changes"></param>
		public void ModifyComponent(ChangeSet changes){
			BiosComponentType bct = GetBiosComponentType(changes.RcCtype);

			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			OdbcParameter op = null;

			string sql = "update " + bct.CTable + " set rc_store=?, rc_sign=?, rc_mod=?, ";
			op = new OdbcParameter("@rcStore", OdbcType.Int, 10);
			op.Value = changes.RcStore;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcSign", OdbcType.Int, 10);
			op.Value = changes.RcSign;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcMod", OdbcType.DateTime);
			op.Value = changes.RcMod;
			sqlParams.Add(op);
			foreach(string key in changes.Changes.Keys){
				object val = changes.Changes[key];
				sql += String.Format("{0}=?, ", key);
				op = new OdbcParameter();
				if(val is int){
					op.OdbcType = OdbcType.Int;
				}else if(val is DateTime){
					op.OdbcType = OdbcType.DateTime;
				}else if(val is String){
					op.OdbcType = OdbcType.VarChar;
				}else if(val is float){
					op.OdbcType = OdbcType.Decimal;
				}else if(val is decimal){
					op.OdbcType = OdbcType.Decimal;
				}
				op.Value = val;
				sqlParams.Add(op);
			}
			//remove the ", "
			sql = sql.Remove(sql.Length-2,2);
			
			sql += " where rc_oid=? and rc_otype=? and rc_ctype=? and rc_occ=?";
			op = new OdbcParameter("@rcOid", OdbcType.Int, 10);
			op.Value = changes.RcOid;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcOtype", OdbcType.Int, 10);
			op.Value = changes.RcOtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcCtype", OdbcType.Int, 10);
			op.Value = changes.RcCtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcOcc", OdbcType.Int, 10);
			op.Value = changes.RcOcc;
			sqlParams.Add(op);
			
			int result = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			
			OnComponentModified(new BiosEvent(changes.ComponentId.ObjectId, changes.ComponentId));
			
			OnObjectModified(new BiosEvent(changes.ComponentId.ObjectId, null));
		}

		/// <summary>
		/// Delete a specified component. If the component is locked then delete operation is only allowed
		/// for the owner or superuser (admin)
		/// </summary>
		/// <param name="cid">ComponentID of component to delete.</param>
		public void DeleteComponent(ComponentID cid){
			BiosComponentType bct = GetBiosComponentType(cid.RcCtype);

			List<OdbcParameter> sqlParams = new List<OdbcParameter>();
			OdbcParameter op = null;

			string sql = "delete from " + bct.CTable + " where rc_oid=? and rc_otype=? and rc_ctype=? and rc_occ=?";
			op = new OdbcParameter("@rcOid", OdbcType.Int, 10);
			op.Value = cid.RcOid;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcOtype", OdbcType.Int, 10);
			op.Value = cid.RcOtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcCtype", OdbcType.Int, 10);
			op.Value = cid.RcCtype;
			sqlParams.Add(op);
			op = new OdbcParameter("@rcOcc", OdbcType.Int, 10);
			op.Value = cid.RcOcc;
			sqlParams.Add(op);

			int result = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			
			OnComponentDeleted(new BiosEvent(cid.ObjectId, cid));
		}

		/// <summary>
		/// Delete a object with all its components from database. Perform rc_lock first and if there is none
		/// then delete. Else throw BiosException.
		/// </summary>
		/// <param name="oid">ObjectID of the object to be deleted.</param>
		public void DeleteObject(ObjectID oid){
			foreach(BiosComponent bc in biosObjects[GetBiosObjectType(oid.Otype)]){
				OdbcParameter op = null;
				string sql = "delete from " + bc.BiosComponentType.CTable + " where rc_oid=? and rc_otype=?";
				List<OdbcParameter> sqlParams = new List<OdbcParameter>();
				op = new OdbcParameter("@oid", OdbcType.Int, 10);
				op.Value = oid.Oid;
				sqlParams.Add(op);
				op = new OdbcParameter("@otype", OdbcType.Int, 10);
				op.Value = oid.Otype;
				sqlParams.Add(op);

				int i = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			}
			
			OnObjectDeleted(new BiosEvent(oid, null));
		}

		/// <summary>
		/// Lock object in database so no one else but the rc_lock user id could modify/unlock it back.
		/// Rc_lock in all exist components of this object is filled with the user_id number of currently working user.
		/// </summary>
		/// <param name="oid">ObjectID of the object to lock.</param>
		public void LockObject(ObjectID oid){
			foreach(BiosComponent bc in biosObjects[GetBiosObjectType(oid.Otype)]){
				OdbcParameter op = null;
				string sql = "update " + bc.BiosComponentType.CTable + " set rc_lock=? where rc_oid=? and rc_otype=?";
				List<OdbcParameter> sqlParams = new List<OdbcParameter>();
				op = new OdbcParameter("@lock", OdbcType.Int, 10);
				op.Value = mf.MainFrameUI.CurrentUser.WorkerOid;
				sqlParams.Add(op);
				op = new OdbcParameter("@oid", OdbcType.Int, 10);
				op.Value = oid.Oid;
				sqlParams.Add(op);
				op = new OdbcParameter("@otype", OdbcType.Int, 10);
				op.Value = oid.Otype;
				sqlParams.Add(op);

				int i = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			}
		}

		/// <summary>
		/// Unlock the locked object. Allowed only for lock owner or superuser (admin).
		/// </summary>
		/// <param name="oid">ObjectID of the locked object to unlock.</param>
		public void UnlockObject(ObjectID oid){
			foreach(BiosComponent bc in biosObjects[GetBiosObjectType(oid.Otype)]){
				OdbcParameter op = null;
				string sql = "update " + bc.BiosComponentType.CTable + " set rc_lock=0 where rc_oid=? and rc_otype=?";
				List<OdbcParameter> sqlParams = new List<OdbcParameter>();
				op = new OdbcParameter("@oid", OdbcType.Int, 10);
				op.Value = oid.Oid;
				sqlParams.Add(op);
				op = new OdbcParameter("@otype", OdbcType.Int, 10);
				op.Value = oid.Otype;
				sqlParams.Add(op);

				int i = dataBase.ConcurentNoRsQuery(sql,sqlParams);
			}
		}

		#endregion

	}
}
