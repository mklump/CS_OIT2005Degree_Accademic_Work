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
using System.Diagnostics;

namespace BenefitsCS
{
	/// <summary>
	/// Summary description for doctors.
	/// </summary>
	public class doctors : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSpecialties;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		protected System.Web.UI.WebControls.ListBox lstSpecialties;
		protected System.Web.UI.WebControls.DataGrid dgDoctors;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected BenefitsCS.dsDoctors dsDoctors1;
		protected System.Web.UI.WebControls.DropDownList lstCities;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Cache["doctors"] == null)
			{
				sqlDataAdapter1.Fill(dsDoctors1);
				Cache.Insert("doctors", dsDoctors1, null, DateTime.Now.AddMinutes(4), TimeSpan.Zero);
			}
			
			if (!Page.IsPostBack)
			{
				//TODO Lab 9: bind the datagrid to the doctors table
				dgDoctors.DataSource=Cache["doctors"];
				//sqlDataAdapter1.Fill(dsDoctors1);
				dgDoctors.DataBind();

				//TODO Lab10: bind the listbox to city field in the doctors table
//				SqlCommand cmdCities = new SqlCommand("Select city from doctors", sqlConnection1);
//				SqlDataReader drCities;
//				sqlConnection1.Open();
//				drCities = cmdCities.ExecuteReader();
//				lstCities.DataSource = drCities;
//				lstCities.DataTextField = "City";
//				lstCities.DataBind();
//				drCities.Close();
//				sqlConnection1.Close();
	
				//TODO Lab11: bind the listbox to the getUniqueCities stored procedure
				SqlCommand cmdCities = new SqlCommand("getUniqueCities", sqlConnection1);
				cmdCities.CommandType = CommandType.StoredProcedure;
				sqlConnection1.Open();
				SqlDataReader drCities;
				drCities = cmdCities.ExecuteReader();
				lstCities.DataSource = drCities;
				lstCities.DataTextField = "City";
				lstCities.DataBind();
				drCities.Close();
				sqlConnection1.Close();

				//TODO Lab10: add the "All" item to the list and select it
	            lstCities.Items.Add("[All]");
		        lstCities.SelectedIndex = lstCities.Items.Count - 1;

				//hide the specialties listbox
				lstSpecialties.Visible = false;
				lblSpecialties.Visible = false;
			}
		}

		private void reset()
		{
			//reset page index to 0
			dgDoctors.CurrentPageIndex = 0;

			//remove the selection from the datagrid
			dgDoctors.SelectedIndex = -1;

			//hide the specialites listbox
			lstSpecialties.Visible = false;
			lblSpecialties.Visible = false;
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsDoctors1 = new BenefitsCS.dsDoctors();
			((System.ComponentModel.ISupportInitialize)(this.dsDoctors1)).BeginInit();
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.dgDoctors.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgDoctors_PageIndexChanged);
			this.dgDoctors.SelectedIndexChanged += new System.EventHandler(this.dgDoctors_SelectedIndexChanged);
			this.lstCities.SelectedIndexChanged += new System.EventHandler(this.lstCities_SelectedIndexChanged);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=localhost;initial catalog=doctors;integrated security=SSPI;persist se" +
				"curity info=True;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "doctors", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("dr_id", "dr_id"),
																																																				 new System.Data.Common.DataColumnMapping("dr_lname", "dr_lname"),
																																																				 new System.Data.Common.DataColumnMapping("dr_fname", "dr_fname"),
																																																				 new System.Data.Common.DataColumnMapping("phone", "phone"),
																																																				 new System.Data.Common.DataColumnMapping("address", "address"),
																																																				 new System.Data.Common.DataColumnMapping("city", "city"),
																																																				 new System.Data.Common.DataColumnMapping("state", "state"),
																																																				 new System.Data.Common.DataColumnMapping("zip", "zip")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM doctors WHERE (dr_id = @Original_dr_id) AND (address = @Original_address OR @Original_address IS NULL AND address IS NULL) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (dr_fname = @Original_dr_fname) AND (dr_lname = @Original_dr_lname) AND (phone = @Original_phone OR @Original_phone IS NULL AND phone IS NULL) AND (state = @Original_state OR @Original_state IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_id", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_fname", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_lname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_lname", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO doctors(dr_id, dr_lname, dr_fname, phone, address, city, state, zip) VALUES (@dr_id, @dr_lname, @dr_fname, @phone, @address, @city, @state, @zip); SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors WHERE (dr_id = @dr_id)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_lname", System.Data.SqlDbType.VarChar, 20, "dr_lname"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_fname", System.Data.SqlDbType.VarChar, 20, "dr_fname"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 10, "zip"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE doctors SET dr_id = @dr_id, dr_lname = @dr_lname, dr_fname = @dr_fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip WHERE (dr_id = @Original_dr_id) AND (address = @Original_address OR @Original_address IS NULL AND address IS NULL) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (dr_fname = @Original_dr_fname) AND (dr_lname = @Original_dr_lname) AND (phone = @Original_phone OR @Original_phone IS NULL AND phone IS NULL) AND (state = @Original_state OR @Original_state IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL); SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors WHERE (dr_id = @dr_id)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_lname", System.Data.SqlDbType.VarChar, 20, "dr_lname"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_fname", System.Data.SqlDbType.VarChar, 20, "dr_fname"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 10, "zip"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_fname", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_lname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_lname", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			// 
			// dsDoctors1
			// 
			this.dsDoctors1.DataSetName = "dsDoctors";
			this.dsDoctors1.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsDoctors1.Namespace = "http://www.tempuri.org/dsDoctors.xsd";
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsDoctors1)).EndInit();

		}
		#endregion

		private void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			if (dgDoctors.SelectedIndex != -1)
			{
				string strDrName;
				strDrName = dgDoctors.Items[dgDoctors.SelectedIndex].Cells[3].Text.Trim() + " " + dgDoctors.Items[dgDoctors.SelectedIndex].Cells[2].Text.Trim();
				Response.Redirect("medical.aspx?pcp=" + strDrName);
			}
		}

		private void dgDoctors_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			string strCity = lstCities.SelectedItem.Value.Trim();
	        dgDoctors.CurrentPageIndex = e.NewPageIndex;
			sqlDataAdapter1.Fill(dsDoctors1);
			if (strCity == "[All]")
			{
				dgDoctors.DataSource = dsDoctors1;
			}
			else
			{
				DataView dvDocs = new DataView(dsDoctors1.Tables[0]);
				dvDocs.RowFilter = "city = '" + strCity + "'";
				dgDoctors.DataSource = dvDocs;
			}
	        dgDoctors.DataBind();
		}

		private void lstCities_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strCity = lstCities.SelectedItem.Value.Trim();

			if (Cache["doctors"] == null)
			{
				sqlDataAdapter1.Fill(dsDoctors1);
				Cache.Insert("doctors", dsDoctors1, null, DateTime.Now.AddMinutes(4), TimeSpan.Zero);
			}
			
			if (strCity == "[All]")
			{
				dgDoctors.DataSource = dsDoctors1;
			}
			else
			{
				DataSet tds = (DataSet)(Cache["Doctors"]);
				DataView dvDocs = new DataView(tds.Tables[0]);
				dvDocs.RowFilter = "city = '" + strCity + "'";
				dgDoctors.DataSource = dvDocs;
			}
			
			reset();
			dgDoctors.DataBind();
		}

		private void dgDoctors_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strDrID;
			strDrID = dgDoctors.SelectedItem.Cells[1].Text;

			SqlCommand cmdSpecialty = new SqlCommand("getDrSpecialty", sqlConnection1);
			cmdSpecialty.CommandType = CommandType.StoredProcedure;

            SqlParameter paramSpecialty = new SqlParameter("@dr_id", SqlDbType.Char, 4);
			paramSpecialty.Direction = ParameterDirection.Input;
			paramSpecialty.Value = strDrID;
			cmdSpecialty.Parameters.Add(paramSpecialty);

			sqlConnection1.Open();
			SqlDataReader drSpecialty;
			drSpecialty = cmdSpecialty.ExecuteReader();

			lstSpecialties.DataSource = drSpecialty;
			lstSpecialties.DataTextField = "Specialty";
			lstSpecialties.DataBind();
			drSpecialty.Close();
			sqlConnection1.Close();

			if (drSpecialty!=null)
			{
				lstSpecialties.Visible = true;
				lblSpecialties.Visible = true;
			}
		}
	}
}
