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
using System.Xml.Xsl;

namespace Mod12CS
{
	/// <summary>
	/// Summary description for WebForm5.
	/// </summary>
	public class TransformPubTitles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Button cmdTransform;
		private DataSet myDataSet;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				CreateDataSet();
				MakeDataRelation(true);

				DataGrid1.DataSource = myDataSet;
				DataGrid1.DataMember = "Publishers";
				DataGrid1.DataBind();
				DataGrid2.DataSource = myDataSet;
				DataGrid2.DataMember = "Titles";
				DataGrid2.DataBind();
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
			this.cmdTransform.Click += new System.EventHandler(this.cmdTransform_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdTransform_Click(object sender, System.EventArgs e)
		{
			//create and fill dataset
			CreateDataSet();
			MakeDataRelation(true);

			//save data into XmlDataDocument 
			XmlDataDocument xmlDoc= new XmlDataDocument(myDataSet);

			//apply stylesheet and save into new XML file
			XslTransform xslTran = new XslTransform();
			xslTran.Load(Server.MapPath("PubTitles.xsl"));
			XmlTextWriter writer = new XmlTextWriter(Server.MapPath("PubTitles_output.html"), System.Text.Encoding.UTF8);
			xslTran.Transform(xmlDoc, null, writer);
			writer.Close();
			//attach hyperlink to the new file
			HyperLink1.NavigateUrl = "PubTitles_output.html";
		}

		private void CreateDataSet()
		{
			SqlConnection conn;
			SqlDataAdapter daTitles;
			SqlDataAdapter daPublishers;

			//create a connection to the Pubs database    
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");
        
			//create the second DataTable
			daPublishers = new SqlDataAdapter("select pub_id, pub_name from Publishers", conn);
			myDataSet = new DataSet();
			daPublishers.Fill(myDataSet, "Publishers");
			
			//create a dataset with information from the authors table
			daTitles = new SqlDataAdapter("select title_id, title, price, pub_id from Titles", conn);
			daTitles.Fill(myDataSet, "Titles");
		}

		private void MakeDataRelation(Boolean bNest)
		{
			// DataRelation requires two DataColumn (parent and child) and a name.
			DataRelation myDataRelation;
			DataColumn parentColumn;
			DataColumn childColumn;
			// relationship: each publisher publishes many titles
			parentColumn = myDataSet.Tables["Publishers"].Columns["pub_id"];
			childColumn = myDataSet.Tables["Titles"].Columns["pub_id"];
			myDataRelation = new DataRelation("TitlePublishers", parentColumn, childColumn);
			//mark the dataRelation as nested so the XML looks correct
			myDataRelation.Nested = bNest;
			myDataSet.Relations.Add(myDataRelation);
		}
	}
}
