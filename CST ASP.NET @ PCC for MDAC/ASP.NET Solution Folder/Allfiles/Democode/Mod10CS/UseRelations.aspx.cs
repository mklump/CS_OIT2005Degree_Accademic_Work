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

namespace Mod10CS
{
	/// <summary>
	/// Summary description for UseRelations.
	/// </summary>
	public class UseRelations : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgParent;
		protected System.Web.UI.WebControls.DataGrid dgChild;
	
		private DataSet ds;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
	        CreateDataSet();
		    MakeDataRelation();
			BindToDataGrid();
		}

		private void CreateDataSet()
		{
			SqlConnection conn;
			SqlDataAdapter daCustomers;
			SqlDataAdapter daOrders;
			
			//create a connection to the Pubs database    
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=northwind");

			//create first datatable
			daCustomers = new SqlDataAdapter("select CustomerID, CompanyName from Customers", conn);
	        ds = new DataSet();
	        daCustomers.Fill(ds, "Customers");

	        //create the second DataTable
			daOrders = new SqlDataAdapter("select CustomerID, OrderID, OrderDate, ShippedDate from Orders", conn);
	        daOrders.Fill(ds, "Orders");
		}

		private void MakeDataRelation()
		{
	        //DataRelation requires two DataColumn (parent and child) and a name.
		    DataRelation dr;
			DataColumn parentCol;
			DataColumn childCol;
			//relationship: each Customer has many orders;
			parentCol = ds.Tables["Customers"].Columns["customerid"];
			childCol = ds.Tables["Orders"].Columns["customerid"];
			dr = new DataRelation("CustOrders", parentCol, childCol);
			ds.Relations.Add(dr);
		}

		private void BindToDataGrid()
		{
	        //Instruct the DataGrid to bind to the DataSet, with the 
		    //Publishers table as the topmost DataTable.
			dgParent.DataSource = ds;
			dgParent.DataMember = "Customers";
			dgParent.DataBind();
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
			this.dgParent.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgParent_PageIndexChanged);
			this.dgParent.SelectedIndexChanged += new System.EventHandler(this.dgParent_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgParent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
	        //when you select a customer, display the order numbers
			//get the row and call GetParentRows
			Label1.Text = "Order Numbers: ";

			//use relationship programmatically
			DataRow currentParentRow;
	        int iCurrentRowIndex;

			iCurrentRowIndex = dgParent.SelectedIndex + (dgParent.CurrentPageIndex * dgParent.PageSize);
			currentParentRow = ds.Tables["Customers"].Rows[iCurrentRowIndex];
			foreach(DataRow r in currentParentRow.GetChildRows("CustOrders"))
			{
				Label1.Text += r["OrderID"] + ", ";
			}

			//use relationship visually
			DataView parentTableView = new DataView(ds.Tables["Customers"]);
			DataRowView currentRowView = parentTableView[iCurrentRowIndex];
		    dgChild.DataSource = currentRowView.CreateChildView("CustOrders");
	        dgChild.DataBind();
		}

		private void dgParent_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
	        dgParent.CurrentPageIndex = e.NewPageIndex;
		    CreateDataSet();
			MakeDataRelation();
			BindToDataGrid();
		}
	}
}
