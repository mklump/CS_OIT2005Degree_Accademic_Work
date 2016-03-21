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
	/// Summary description for DataList.
	/// </summary>
	public class DataList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButtonList rbColumns;
		protected System.Data.SqlClient.SqlCommand SqlInsertCommand1;
		protected System.Data.SqlClient.SqlConnection SqlConnection1;
		protected System.Data.SqlClient.SqlCommand SqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter SqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand SqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand SqlUpdateCommand1;
		protected Mod09CS.DataSet1 DataSet1;
		protected System.Web.UI.WebControls.RadioButtonList rbDirection;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SqlDataAdapter1.Fill(DataSet1);
				DataList1.DataBind();
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
			this.SqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.SqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.DataSet1 = new Mod09CS.DataSet1();
			((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
			// 
			// SqlInsertCommand1
			// 
			this.SqlInsertCommand1.CommandText = @"INSERT INTO authors(au_id, au_lname, au_fname, phone, address, city, state, zip, contract) VALUES (@au_id, @au_lname, @au_fname, @phone, @address, @city, @state, @zip, @contract); SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors WHERE (au_id = @Select_au_id)";
			this.SqlInsertCommand1.Connection = this.SqlConnection1;
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_id", System.Data.SqlDbType.Char, 11, "au_id"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_lname", System.Data.SqlDbType.VarChar, 40, "au_lname"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_fname", System.Data.SqlDbType.VarChar, 20, "au_fname"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.Char, 12, "phone"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Current, null));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contract", System.Data.SqlDbType.Bit, 1, "contract"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_au_id", System.Data.SqlDbType.Char, 11, "au_id"));
			// 
			// SqlConnection1
			// 
			this.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=pubs;integrated security=SSPI;persist secur" +
				"ity info=True;packet size=4096";
			// 
			// SqlSelectCommand1
			// 
			this.SqlSelectCommand1.CommandText = "SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM" +
				" authors";
			this.SqlSelectCommand1.Connection = this.SqlConnection1;
			// 
			// SqlDataAdapter1
			// 
			this.SqlDataAdapter1.DeleteCommand = this.SqlDeleteCommand1;
			this.SqlDataAdapter1.InsertCommand = this.SqlInsertCommand1;
			this.SqlDataAdapter1.SelectCommand = this.SqlSelectCommand1;
			this.SqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "authors", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("au_id", "au_id"),
																																																				 new System.Data.Common.DataColumnMapping("au_lname", "au_lname"),
																																																				 new System.Data.Common.DataColumnMapping("au_fname", "au_fname"),
																																																				 new System.Data.Common.DataColumnMapping("phone", "phone"),
																																																				 new System.Data.Common.DataColumnMapping("address", "address"),
																																																				 new System.Data.Common.DataColumnMapping("city", "city"),
																																																				 new System.Data.Common.DataColumnMapping("state", "state"),
																																																				 new System.Data.Common.DataColumnMapping("zip", "zip"),
																																																				 new System.Data.Common.DataColumnMapping("contract", "contract")})});
			this.SqlDataAdapter1.UpdateCommand = this.SqlUpdateCommand1;
			// 
			// SqlDeleteCommand1
			// 
			this.SqlDeleteCommand1.CommandText = @"DELETE FROM authors WHERE (au_id = @au_id) AND (address = @address OR @address1 IS NULL AND address IS NULL) AND (au_fname = @au_fname) AND (au_lname = @au_lname) AND (city = @city OR @city1 IS NULL AND city IS NULL) AND (contract = @contract) AND (phone = @phone) AND (state = @state OR @state1 IS NULL AND state IS NULL) AND (zip = @zip OR @zip1 IS NULL AND zip IS NULL)";
			this.SqlDeleteCommand1.Connection = this.SqlConnection1;
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_id", System.Data.SqlDbType.Char, 11, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_id", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_fname", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_lname", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_lname", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city1", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contract", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "contract", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			// 
			// SqlUpdateCommand1
			// 
			this.SqlUpdateCommand1.CommandText = @"UPDATE authors SET au_id = @au_id, au_lname = @au_lname, au_fname = @au_fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip, contract = @contract WHERE (au_id = @Original_au_id) AND (address = @Original_address OR @Original_address1 IS NULL AND address IS NULL) AND (au_fname = @Original_au_fname) AND (au_lname = @Original_au_lname) AND (city = @Original_city OR @Original_city1 IS NULL AND city IS NULL) AND (contract = @Original_contract) AND (phone = @Original_phone) AND (state = @Original_state OR @Original_state1 IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip1 IS NULL AND zip IS NULL); SELECT au_id, au_lname, au_fname, phone, address, city, state, zip, contract FROM authors WHERE (au_id = @Select_au_id)";
			this.SqlUpdateCommand1.Connection = this.SqlConnection1;
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_id", System.Data.SqlDbType.Char, 11, "au_id"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_lname", System.Data.SqlDbType.VarChar, 40, "au_lname"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@au_fname", System.Data.SqlDbType.VarChar, 20, "au_fname"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.Char, 12, "phone"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Current, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contract", System.Data.SqlDbType.Bit, 1, "contract"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_id", System.Data.SqlDbType.Char, 11, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_id", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address1", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_fname", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_au_lname", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "au_lname", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city1", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_contract", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "contract", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_au_id", System.Data.SqlDbType.Char, 11, "au_id"));
			// 
			// DataSet1
			// 
			this.DataSet1.DataSetName = "DataSet1";
			this.DataSet1.Locale = new System.Globalization.CultureInfo("en-US");
			this.DataSet1.Namespace = "http://www.tempuri.org/DataSet1.xsd";
			this.rbColumns.SelectedIndexChanged += new System.EventHandler(this.rbColumns_SelectedIndexChanged);
			this.rbDirection.SelectedIndexChanged += new System.EventHandler(this.rbDirection_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();

		}
		#endregion

		private void rbColumns_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// set the column property of the DataList
			DataList1.RepeatColumns = Convert.ToInt16(rbColumns.SelectedItem.Value);
		}

		private void rbDirection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (rbDirection.SelectedItem.Value == "Vertical")
			{
				DataList1.RepeatDirection = RepeatDirection.Vertical;
			}
			else
			{
				DataList1.RepeatDirection = RepeatDirection.Horizontal;
			}
		}
	}
}
