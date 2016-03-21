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
	/// Summary description for UseGrid.
	/// </summary>
	public class UseGrid : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgAuthors;
		protected System.Web.UI.WebControls.DataGrid dgCAAuthors;
		protected string strSort;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				DisplayData();
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
			this.dgCAAuthors.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgCAAuthors_SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DisplayData()
		{
			DataSet ds;
			SqlConnection conn;
			SqlDataAdapter daAuthors;
			DataView dv;

			//create aa connection to the Pubs database
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");

			//create a dataset with information from the authors table
			daAuthors = new SqlDataAdapter("select * from Authors", conn);
			ds = new DataSet();
			daAuthors.Fill(ds, "Authors");

			//bind the first datagrid to the DefaultView of the dataset
			dgAuthors.DataSource = ds;
			dgAuthors.DataMember = "Authors";
			dgAuthors.DataBind();

	        //create a new DataView that is authors from California
		    //and bind the second datagrid to it
			dv = new DataView(ds.Tables["Authors"]);
			dv.RowFilter = "state = 'CA'";
			dv.Sort = strSort;
			dgCAAuthors.DataSource = dv;
			dgCAAuthors.DataBind();
		}
		
		private void dgCAAuthors_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			strSort = e.SortExpression.ToString();
			DisplayData();
		}

	}
}
