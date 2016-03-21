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
	/// Summary description for WebForm4.
	/// </summary>
	public class Transform : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Button cmdTransform;
		private DataSet myDataSet;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			myDataSet = CreateCustOrdersDataset();

			//save data into XmlDataDocument 
			XmlDataDocument xmlDoc = new XmlDataDocument(myDataSet);

			//apply stylesheet and save into new XML file
			XslTransform xslTran = new XslTransform();
			xslTran.Load(Server.MapPath("CustomerOrders.xslt"));
			XmlTextWriter writer = new XmlTextWriter(Server.MapPath("CustOrders_output.html"), System.Text.Encoding.UTF8);
			xslTran.Transform(xmlDoc, null, writer);
			writer.Close();
			//attach hyperlink to the new file
			HyperLink1.NavigateUrl = "CustOrders_output.html";
		}

		private DataSet CreateCustOrdersDataset()
		{
			SqlConnection nwindConn = new SqlConnection("Data Source=localhost;Initial Catalog=northwind;Integrated Security=SSPI");
			SqlDataAdapter custDA = new SqlDataAdapter("SELECT * FROM Customers", nwindConn);
			myDataSet = new DataSet();
			custDA.Fill(myDataSet, "Customers");
			SqlDataAdapter ordersDA = new SqlDataAdapter("SELECT * FROM Orders", nwindConn);
			ordersDA.Fill(myDataSet, "Orders");

			//create and add relation between Customers and Orders tables
			myDataSet.Relations.Add("CustOrders",myDataSet.Tables["Customers"].Columns["CustomerID"], myDataSet.Tables["Orders"].Columns["CustomerID"]).Nested = true;
			return myDataSet;
		}															
	}
}
