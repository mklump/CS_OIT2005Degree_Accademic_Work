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
	/// Summary description for UseDataSet.
	/// </summary>
	public class UseDataSet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdRows;
		protected System.Web.UI.WebControls.Label lblRows;
		protected System.Web.UI.WebControls.Button cmdGetValues;
		protected System.Web.UI.WebControls.Label lblNames;
		protected System.Web.UI.WebControls.DropDownList lstItems;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private DataSet ds;

		private void Page_Load(object sender, System.EventArgs e)
		{
			SqlConnection conn;
			SqlDataAdapter daAuthors;

			//create a connection to the Pubs database    
			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");
			//create a dataset with information from the authors table
			daAuthors = new SqlDataAdapter("select * from Authors", conn);
			ds = new DataSet();
			daAuthors.Fill(ds, "Authors");

			if (!Page.IsPostBack)
			{
				//bind the column names to the listbox
				foreach(DataColumn col in ds.Tables[0].Columns)
				{
					lstItems.Items.Add(col.ColumnName);
				}
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
			this.cmdRows.Click += new System.EventHandler(this.cmdRows_Click);
			this.cmdGetValues.Click += new System.EventHandler(this.cmdGetValues_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdRows_Click(object sender, System.EventArgs e)
		{
	        lblRows.Text = ds.Tables[0].Rows.Count.ToString();
		}

		private void cmdGetValues_Click(object sender, System.EventArgs e)
		{
			lblNames.Text = "";
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				//get the column selected in the lstItems listbox
				lblNames.Text += r[lstItems.SelectedItem.Value] + " ";
			}
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
