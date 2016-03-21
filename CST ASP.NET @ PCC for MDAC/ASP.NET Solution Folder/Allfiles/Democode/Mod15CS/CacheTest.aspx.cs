using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Caching;

namespace Mod15CS
{
	/// <summary>
	/// Summary description for CacheTest.
	/// </summary>
	public class CacheTest : System.Web.UI.Page
	{
		protected System.Data.DataSet dsXML;
		protected System.Web.UI.WebControls.DataGrid dgXML;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			dsXML.ReadXml(Server.MapPath("pubs.xml"));

			dgXML.DataSource = dsXML; //comment this line for caching
			dgXML.DataBind(); //comment this line for caching

//			if (!Page.IsPostBack)
//			{
//				Cache.Insert("dsCache", dsXML, null, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);
//				dgXML.DataSource = Cache["dsCache"];
//				dgXML.DataBind();
//			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dsXML = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dsXML)).BeginInit();
			this.dgXML.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgXML_PageIndexChanged);
			this.dgXML.SelectedIndexChanged += new System.EventHandler(this.dgXML_SelectedIndexChanged);
			// 
			// dsXML
			// 
			this.dsXML.DataSetName = "NewDataSet";
			this.dsXML.Locale = new System.Globalization.CultureInfo("en-GB");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsXML)).EndInit();

		}
		#endregion

		
		protected void dgXML_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgXML.CurrentPageIndex = e.NewPageIndex;

			dgXML.DataSource = dsXML; //comment this line for caching
			dgXML.DataBind(); //comment this line for caching

//						if (Cache["dsCache"] == null)
//						{
//							Cache.Insert("dsCache", dsXML, null, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);
//						}
//						dgXML.DataSource = Cache["dsCache"];
//						dgXML.DataBind();	
		}

		private void dgXML_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
