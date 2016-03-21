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
	/// Summary description for WebForm3.
	/// </summary>
	public class SaveNestedXML : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkNestedXML;
		protected System.Web.UI.WebControls.Button cmdSaveNested;
		protected System.Web.UI.WebControls.HyperLink lnkXML;
		protected System.Web.UI.WebControls.Button cmdSave;
		DataSet myDataSet;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		private void CreateDataSet()
		{
			SqlConnection conn;
			SqlDataAdapter daTitles;
			SqlDataAdapter daPublishers;

			//create a connection to the Pubs database    
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");

			//create a dataset with information from the authors table
			daTitles = new SqlDataAdapter("select title_id, title, price, pub_id from Titles", conn);
			myDataSet = new DataSet();
			daTitles.Fill(myDataSet, "Titles");
			
			//create the second DataTable
			daPublishers = new SqlDataAdapter("select pub_id, pub_name from Publishers", conn);
			daPublishers.Fill(myDataSet, "Publishers");
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
			this.cmdSaveNested.Click += new System.EventHandler(this.cmdSaveNested_Click);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void MakeDataRelation(Boolean bNest)
		{
			//DataRelation requires two DataColumn (parent and child) and a name.
			DataRelation myDataRelation;
			DataColumn parentColumn;
			DataColumn childColumn;
			            
			//relationship: each publisher publishes many titles

			parentColumn =  myDataSet.Tables["Publishers"].Columns["pub_id"];
			childColumn = myDataSet.Tables["Titles"].Columns["pub_id"];
			myDataRelation = new DataRelation("TitlePublishers", parentColumn, childColumn);
		
			//mark the dataRelation as nested so the XML looks correct
			myDataRelation.Nested = bNest;
			myDataSet.Relations.Add(myDataRelation);
		}

		private void cmdSaveNested_Click(object sender, System.EventArgs e)
		{
			CreateDataSet();
			MakeDataRelation(true);
			myDataSet.WriteXml(Server.MapPath("PubTitlesNested.xml"), XmlWriteMode.IgnoreSchema);
			lnkNestedXML.NavigateUrl = "PubTitlesNested.xml";
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			CreateDataSet();
			MakeDataRelation(false);
			myDataSet.WriteXml(Server.MapPath("PubTitlesNotNested.xml"), XmlWriteMode.IgnoreSchema);
			lnkXML.NavigateUrl = "PubTitlesNotNested.xml";
		}
	}
}
