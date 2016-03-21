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

namespace Mod09CS
{
	/// <summary>
	/// Summary description for ListboundControls.
	/// </summary>
	public class ListboundControls : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList1;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter SqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand SqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand SqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand SqlSelectCommand1;
		protected Mod09CS.DataSet3 DataSet3;
		protected System.Data.SqlClient.SqlCommand SqlUpdateCommand1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SqlDataAdapter1.Fill(DataSet3);

				//dropdownlist
				DropDownList1.DataBind();
				//listbox
				ListBox1.DataBind();
				//checkbox list
				CheckBoxList1.DataBind();
				//radiobutton list
				RadioButtonList1.DataBind();
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.SqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.SqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.DataSet3 = new Mod09CS.DataSet3();
			((System.ComponentModel.ISupportInitialize)(this.DataSet3)).BeginInit();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=localhost;initial catalog=pubs;integrated security=SSPI;persist secur" +
				"ity info=True;packet size=4096";
			// 
			// SqlDataAdapter1
			// 
			this.SqlDataAdapter1.DeleteCommand = this.SqlDeleteCommand1;
			this.SqlDataAdapter1.InsertCommand = this.SqlInsertCommand1;
			this.SqlDataAdapter1.SelectCommand = this.SqlSelectCommand1;
			this.SqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "stores", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("stor_id", "stor_id"),
																																																				new System.Data.Common.DataColumnMapping("stor_name", "stor_name"),
																																																				new System.Data.Common.DataColumnMapping("stor_address", "stor_address"),
																																																				new System.Data.Common.DataColumnMapping("city", "city"),
																																																				new System.Data.Common.DataColumnMapping("state", "state"),
																																																				new System.Data.Common.DataColumnMapping("zip", "zip")})});
			this.SqlDataAdapter1.UpdateCommand = this.SqlUpdateCommand1;
			// 
			// SqlDeleteCommand1
			// 
			this.SqlDeleteCommand1.CommandText = @"DELETE FROM stores WHERE (stor_id = @stor_id) AND (city = @city OR @city1 IS NULL AND city IS NULL) AND (state = @state OR @state1 IS NULL AND state IS NULL) AND (stor_address = @stor_address OR @stor_address1 IS NULL AND stor_address IS NULL) AND (stor_name = @stor_name OR @stor_name1 IS NULL AND stor_name IS NULL) AND (zip = @zip OR @zip1 IS NULL AND zip IS NULL)";
			this.SqlDeleteCommand1.Connection = this.sqlConnection1;
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "stor_id", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city1", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_address", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_address1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_address", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_name", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_name1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_name", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			// 
			// SqlInsertCommand1
			// 
			this.SqlInsertCommand1.CommandText = "INSERT INTO stores(stor_id, stor_name, stor_address, city, state, zip) VALUES (@s" +
				"tor_id, @stor_name, @stor_address, @city, @state, @zip); SELECT stor_id, stor_na" +
				"me, stor_address, city, state, zip FROM stores WHERE (stor_id = @Select_stor_id)" +
				"";
			this.SqlInsertCommand1.Connection = this.sqlConnection1;
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_id", System.Data.SqlDbType.Char, 4, "stor_id"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_name", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_address", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_stor_id", System.Data.SqlDbType.Char, 4, "stor_id"));
			// 
			// SqlSelectCommand1
			// 
			this.SqlSelectCommand1.CommandText = "SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores";
			this.SqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// SqlUpdateCommand1
			// 
			this.SqlUpdateCommand1.CommandText = @"UPDATE stores SET stor_id = @stor_id, stor_name = @stor_name, stor_address = @stor_address, city = @city, state = @state, zip = @zip WHERE (stor_id = @Original_stor_id) AND (city = @Original_city OR @Original_city1 IS NULL AND city IS NULL) AND (state = @Original_state OR @Original_state1 IS NULL AND state IS NULL) AND (stor_address = @Original_stor_address OR @Original_stor_address1 IS NULL AND stor_address IS NULL) AND (stor_name = @Original_stor_name OR @Original_stor_name1 IS NULL AND stor_name IS NULL) AND (zip = @Original_zip OR @Original_zip1 IS NULL AND zip IS NULL); SELECT stor_id, stor_name, stor_address, city, state, zip FROM stores WHERE (stor_id = @Select_stor_id)";
			this.SqlUpdateCommand1.Connection = this.sqlConnection1;
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_id", System.Data.SqlDbType.Char, 4, "stor_id"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_name", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_address", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stor_id", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "stor_id", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city1", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stor_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_address", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stor_address1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_address", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stor_name", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_name", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_stor_name1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "stor_name", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_stor_id", System.Data.SqlDbType.Char, 4, "stor_id"));
			// 
			// DataSet3
			// 
			this.DataSet3.DataSetName = "DataSet3";
			this.DataSet3.Locale = new System.Globalization.CultureInfo("en-GB");
			this.DataSet3.Namespace = "http://www.tempuri.org/DataSet3.xsd";
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataSet3)).EndInit();

		}
		#endregion
	}
}
