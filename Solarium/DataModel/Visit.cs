/*
 * Created by SharpDevelop.
 * User: Pablo
 * Date: 2008-04-03
 * Time: 18:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

using Solarium;
using Solarium.Bios;
using Solarium.Frame;

namespace Solarium.DataModel
{
	/// <summary>
	/// Description of Visit.
	/// </summary>
	public class Visit
	{
		private IMainFrame mf = null;
		
		public static int VISIT_OTYPE = 1;
		public static int VISIT_CTYPE = 1001;
		public static int VISIT_SERVICE_CTYPE = 1002;
		public static int VISIT_PRODUCT_CTYPE = 1003;
		
		private LinkedList<Service> servicesBought = new LinkedList<Service>();
		public LinkedList<Service> ServicesBought {
			get { return servicesBought; }
		}
		
		private LinkedList<Product> productsBought = new LinkedList<Product>();
		public LinkedList<Product> ProductsBought {
			get { return productsBought; }
		}
		
		private int customerOid = 0;
		
		public int CustomerOid {
			get { return customerOid; }
			set { customerOid = value; }
		}
		private int customerOtype = 0;
		
		public int CustomerOtype {
			get { return customerOtype; }
			set { customerOtype = value; }
		}
		private int workerOid = 0;
		
		public int WorkerOid {
			get { return workerOid; }
			set { workerOid = value; }
		}
		private int workerOtype = 0;
		
		public int WorkerOtype {
			get { return workerOtype; }
			set { workerOtype = value; }
		}
		private int shiftOid = 0;
		
		public int ShiftOid {
			get { return shiftOid; }
			set { shiftOid = value; }
		}
		private int shiftOtype = 0;
		
		public int ShiftOtype {
			get { return shiftOtype; }
			set { shiftOtype = value; }
		}
		
		public Visit(IMainFrame mf)
		{
			this.mf = mf;
		}

		public Visit(IMainFrame mf, ObjectID visitOid)
		{
			this.mf = mf;
			//pobrac i przypisac dane z komponentów do odpowiednich rzeczy...
		}
		
		public Visit(IMainFrame mf, int customerOid, int customerOtype, int workerOid, int workerOtype, int shiftOid, int shiftOtype)
		{
			this.mf = mf;
			this.customerOid = customerOid;
			this.customerOtype = customerOtype;
			this.workerOid = workerOid;
			this.workerOtype = workerOtype;
			this.shiftOid = shiftOid;
			this.shiftOtype = shiftOtype;
		}
		
		public void SaveVisit(){
			ObjectID visitOid = mf.Database.Bios.CreateObject(VISIT_OTYPE);
			ChangeSet visitChangeset = mf.Database.Bios.GetMainComponentForObject(visitOid).GetChangeSet();
			visitChangeset.AddChange("customer_oid", customerOid);
			visitChangeset.AddChange("customer_otype", customerOtype);
			visitChangeset.AddChange("worker_oid", workerOid);
			visitChangeset.AddChange("worker_otype", workerOtype);
			visitChangeset.AddChange("shift_oid", shiftOid);
			visitChangeset.AddChange("shift_otype", shiftOtype);
			mf.Database.Bios.ModifyComponent(visitChangeset);
			
			foreach(Service serv in servicesBought){
				ComponentID cid = mf.Database.Bios.CreateComponent(visitOid, VISIT_SERVICE_CTYPE);
				ChangeSet cs = mf.Database.Bios.GetComponent(cid).GetChangeSet();
				cs.AddChange("service_oid", serv.ServiceOid);
				cs.AddChange("service_otype", serv.ServiceOtype);
				mf.Database.Bios.ModifyComponent(cs);
			}
			
			foreach(Product prod in productsBought){
				ComponentID cid = mf.Database.Bios.CreateComponent(visitOid, VISIT_PRODUCT_CTYPE);
				ChangeSet cs = mf.Database.Bios.GetComponent(cid).GetChangeSet();
				cs.AddChange("product_oid", prod.ProductOid);
				cs.AddChange("product_otype", prod.ProductOtype);
				mf.Database.Bios.ModifyComponent(cs);
			}
		}
		
		public void LoadVisit(){
			
		}

		public class Service{
			private int serviceOid = 0;
			
			public int ServiceOid {
				get { return serviceOid; }
			}
			private int serviceOtype = 0;
			
			public int ServiceOtype {
				get { return serviceOtype; }
			}
			public Service(int serviceOid, int serviceOtype)
			{
				this.serviceOid = serviceOid;
				this.serviceOtype = serviceOtype;
			}
		}
		
		public class Product{
			private int productOid = 0;
			
			public int ProductOid {
				get { return productOid; }
			}
			private int productOtype = 0;
			
			public int ProductOtype {
				get { return productOtype; }
			}
			public Product(int productOid, int productOtype)
			{
				this.productOid = productOid;
				this.productOtype = productOtype;
			}
			
		}
		
		//TODO: Dorobić tutaj cos sensownego...
		public override string ToString()
		{
			return base.ToString();
		}
		
	}
}
