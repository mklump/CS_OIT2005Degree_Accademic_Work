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
using System.Data.SqlClient;

namespace Mod12CS
{
	/// <summary>
	/// Summary description for WebForm2.
	/// </summary>
	public class SaveAsXML : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.HyperLink lnkSchema;
		protected System.Web.UI.WebControls.HyperLink lnkXml;
		protected System.Web.UI.WebControls.Button cmdSchema;
		protected System.Web.UI.WebControls.Button cmdSave;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				DataSet ds;
				ds = CreateDataSet();
				DataGrid1.DataSource = ds;
				DataGrid1.DataBind();
			}
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
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.cmdSchema.Click += new System.EventHandler(this.cmdSchema_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private DataSet CreateDataSet()
		{
			SqlConnection conn;
			SqlDataAdapter daTitles;
			DataSet myDataSet = new DataSet();
			//create a connection to the Pubs database    
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");

			//create a dataset with information from the authors table
			daTitles = new SqlDataAdapter("select title_id, title, price, pub_id from Titles", conn);
			myDataSet = new DataSet();
			daTitles.Fill(myDataSet, "Titles");
			return myDataSet;
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			DataSet ds;
			ds = CreateDataSet();
			ds.WriteXml(Server.MapPath("Titles.xml"), XmlWriteMode.IgnoreSchema);
			lnkXml.NavigateUrl = "Titles.xml";
							   }
		private void cmdSchema_Click(object sender, System.EventArgs e)
		{
			DataSet ds;
			ds = CreateDataSet();
			ds.WriteXmlSchema(Server.MapPath("Titles.xsd"));
			lnkSchema.NavigateUrl = "Titles.xsd";
		}
	}
}
