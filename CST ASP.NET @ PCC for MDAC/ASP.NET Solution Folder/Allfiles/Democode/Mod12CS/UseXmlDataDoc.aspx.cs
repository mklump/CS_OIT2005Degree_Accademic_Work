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
using System.Xml;

namespace Mod12CS
{
	/// <summary>
	/// Summary description for WebForm7.
	/// </summary>
	public class UseXmlDataDoc : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtOutput;
		protected System.Web.UI.WebControls.Button cmdReadXML;
		protected System.Web.UI.WebControls.TextBox txtRow;
	
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
		private DataSet CreateDataSet()
		{
			SqlConnection conn;
			SqlDataAdapter daTitles;

			//create a connection to the Pubs database    
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");

			//create a dataset with information from the authors table
			daTitles = new SqlDataAdapter("select title_id, title, price, pub_id from Titles", conn);
			DataSet myDataSet = new DataSet();
			daTitles.Fill(myDataSet, "Titles");
			return myDataSet;
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
			this.cmdReadXML.Click += new System.EventHandler(this.cmdReadXML_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdReadXML_Click(object sender, System.EventArgs e)
		{
			DataSet ds;
			XmlDataDocument dd;
			XmlElement el;

			ds = CreateDataSet();
			dd = new XmlDataDocument(ds);

			el = dd.GetElementFromRow(ds.Tables[0].Rows[Convert.ToInt32(txtRow.Text)]);
			txtOutput.Text = el.OuterXml;
		}
	}
}
