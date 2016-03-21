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

namespace BenefitsCS
{
	/// <summary>
	/// Summary description for nestedData.
	/// </summary>
	public class nestedData : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter daSpecialties;
		protected System.Data.SqlClient.SqlCommand SqlDeleteCommand3;
		protected System.Data.SqlClient.SqlCommand SqlInsertCommand3;
		protected System.Data.SqlClient.SqlCommand SqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand SqlSelectCommand2;
		protected System.Data.SqlClient.SqlConnection SqlConnection1;
		protected System.Data.SqlClient.SqlCommand SqlDeleteCommand2;
		protected System.Data.SqlClient.SqlDataAdapter daDrSpecialties;
		protected System.Data.SqlClient.SqlCommand SqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand SqlUpdateCommand2;
		protected System.Data.SqlClient.SqlDataAdapter daDoctors;
		protected System.Data.SqlClient.SqlCommand SqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand SqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand SqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand SqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand SqlUpdateCommand3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			DataSet dsDoctorsSpecialties = new DataSet();
			daDoctors.Fill(dsDoctorsSpecialties, "doctors");
			daDrSpecialties.Fill(dsDoctorsSpecialties, "drspecialties");
			daSpecialties.Fill(dsDoctorsSpecialties, "specialties");
			DataRelation dr1;

			//Link doctors DataTable and drspecialities DataTable together
			DataColumn parentCol1;
			DataColumn childCol1;
			parentCol1 = dsDoctorsSpecialties.Tables["doctors"].Columns["dr_id"];
			childCol1 = dsDoctorsSpecialties.Tables["drspecialties"].Columns["dr_id"];
			dr1 = new DataRelation("rel1", parentCol1, childCol1);
			//TODO: Lab 12, step 1, create a nested relationship  
			//dr1.Nested = true;
			dsDoctorsSpecialties.Relations.Add(dr1);

			//Link specialities DataTable and drspecialities DataTable together
			DataRelation dr2;
			DataColumn parentCol2;
			DataColumn childCol2;
			parentCol2 = dsDoctorsSpecialties.Tables["specialties"].Columns["spec_id"];
			childCol2 = dsDoctorsSpecialties.Tables["drspecialties"].Columns["specialty_id"];
			dr2 = new DataRelation("rel2", parentCol2, childCol2);
			//TODO: Lab 12, step 2, create a nested relationship  
			//dr2.Nested = true;
			dsDoctorsSpecialties.Relations.Add(dr2);

			//output the result in xml
			dsDoctorsSpecialties.WriteXml(Server.MapPath("Output.xml"), XmlWriteMode.IgnoreSchema);
			Response.Redirect("Output.xml");
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
			this.daSpecialties = new System.Data.SqlClient.SqlDataAdapter();
			this.SqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
			this.SqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.SqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.SqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
			this.SqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.SqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.SqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.daDrSpecialties = new System.Data.SqlClient.SqlDataAdapter();
			this.SqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.SqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.daDoctors = new System.Data.SqlClient.SqlDataAdapter();
			this.SqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// daSpecialties
			// 
			this.daSpecialties.DeleteCommand = this.SqlDeleteCommand3;
			this.daSpecialties.InsertCommand = this.SqlInsertCommand3;
			this.daSpecialties.SelectCommand = this.SqlSelectCommand3;
			this.daSpecialties.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "specialties", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("spec_id", "spec_id"),
																																																				   new System.Data.Common.DataColumnMapping("specialty", "specialty")})});
			this.daSpecialties.UpdateCommand = this.SqlUpdateCommand3;
			// 
			// SqlDeleteCommand3
			// 
			this.SqlDeleteCommand3.CommandText = "DELETE FROM specialties WHERE (spec_id = @Original_spec_id) AND (specialty = @Ori" +
				"ginal_specialty)";
			this.SqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_spec_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "spec_id", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_specialty", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "specialty", System.Data.DataRowVersion.Original, null));
			// 
			// SqlInsertCommand3
			// 
			this.SqlInsertCommand3.CommandText = "INSERT INTO specialties(spec_id, specialty) VALUES (@spec_id, @specialty); SELECT" +
				" spec_id, specialty FROM specialties WHERE (spec_id = @spec_id)";
			this.SqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@spec_id", System.Data.SqlDbType.SmallInt, 2, "spec_id"));
			this.SqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@specialty", System.Data.SqlDbType.VarChar, 20, "specialty"));
			// 
			// SqlSelectCommand3
			// 
			this.SqlSelectCommand3.CommandText = "SELECT spec_id, specialty FROM specialties";
			// 
			// SqlUpdateCommand3
			// 
			this.SqlUpdateCommand3.CommandText = "UPDATE specialties SET spec_id = @spec_id, specialty = @specialty WHERE (spec_id " +
				"= @Original_spec_id) AND (specialty = @Original_specialty); SELECT spec_id, spec" +
				"ialty FROM specialties WHERE (spec_id = @spec_id)";
			this.SqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@spec_id", System.Data.SqlDbType.SmallInt, 2, "spec_id"));
			this.SqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@specialty", System.Data.SqlDbType.VarChar, 20, "specialty"));
			this.SqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_spec_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "spec_id", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_specialty", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "specialty", System.Data.DataRowVersion.Original, null));
			// 
			// SqlSelectCommand2
			// 
			this.SqlSelectCommand2.CommandText = "SELECT dr_id, specialty_id FROM drspecialties";
			this.SqlSelectCommand2.Connection = this.SqlConnection1;
			// 
			// SqlConnection1
			// 
			this.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=doctors;integrated security=SSPI;persist se" +
				"curity info=True;packet size=4096";
			// 
			// SqlDeleteCommand2
			// 
			this.SqlDeleteCommand2.CommandText = "DELETE FROM drspecialties WHERE (dr_id = @Original_dr_id) AND (specialty_id = @Or" +
				"iginal_specialty_id)";
			this.SqlDeleteCommand2.Connection = this.SqlConnection1;
			this.SqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_id", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_specialty_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "specialty_id", System.Data.DataRowVersion.Original, null));
			// 
			// daDrSpecialties
			// 
			this.daDrSpecialties.DeleteCommand = this.SqlDeleteCommand2;
			this.daDrSpecialties.InsertCommand = this.SqlInsertCommand2;
			this.daDrSpecialties.SelectCommand = this.SqlSelectCommand2;
			this.daDrSpecialties.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "drspecialties", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("dr_id", "dr_id"),
																																																					   new System.Data.Common.DataColumnMapping("specialty_id", "specialty_id")})});
			this.daDrSpecialties.UpdateCommand = this.SqlUpdateCommand2;
			// 
			// SqlInsertCommand2
			// 
			this.SqlInsertCommand2.CommandText = "INSERT INTO drspecialties(dr_id, specialty_id) VALUES (@dr_id, @specialty_id); SE" +
				"LECT dr_id, specialty_id FROM drspecialties WHERE (dr_id = @dr_id) AND (specialt" +
				"y_id = @specialty_id)";
			this.SqlInsertCommand2.Connection = this.SqlConnection1;
			this.SqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"));
			this.SqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@specialty_id", System.Data.SqlDbType.SmallInt, 2, "specialty_id"));
			// 
			// SqlUpdateCommand2
			// 
			this.SqlUpdateCommand2.CommandText = "UPDATE drspecialties SET dr_id = @dr_id, specialty_id = @specialty_id WHERE (dr_i" +
				"d = @Original_dr_id) AND (specialty_id = @Original_specialty_id); SELECT dr_id, " +
				"specialty_id FROM drspecialties WHERE (dr_id = @dr_id) AND (specialty_id = @spec" +
				"ialty_id)";
			this.SqlUpdateCommand2.Connection = this.SqlConnection1;
			this.SqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"));
			this.SqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@specialty_id", System.Data.SqlDbType.SmallInt, 2, "specialty_id"));
			this.SqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_id", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_specialty_id", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "specialty_id", System.Data.DataRowVersion.Original, null));
			// 
			// daDoctors
			// 
			this.daDoctors.DeleteCommand = this.SqlDeleteCommand1;
			this.daDoctors.InsertCommand = this.SqlInsertCommand1;
			this.daDoctors.SelectCommand = this.SqlSelectCommand1;
			this.daDoctors.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "doctors", new System.Data.Common.DataColumnMapping[] {
																																																		   new System.Data.Common.DataColumnMapping("dr_id", "dr_id"),
																																																		   new System.Data.Common.DataColumnMapping("dr_lname", "dr_lname"),
																																																		   new System.Data.Common.DataColumnMapping("dr_fname", "dr_fname"),
																																																		   new System.Data.Common.DataColumnMapping("phone", "phone"),
																																																		   new System.Data.Common.DataColumnMapping("address", "address"),
																																																		   new System.Data.Common.DataColumnMapping("city", "city"),
																																																		   new System.Data.Common.DataColumnMapping("state", "state"),
																																																		   new System.Data.Common.DataColumnMapping("zip", "zip")})});
			this.daDoctors.UpdateCommand = this.SqlUpdateCommand1;
			// 
			// SqlDeleteCommand1
			// 
			this.SqlDeleteCommand1.CommandText = @"DELETE FROM doctors WHERE (dr_id = @Original_dr_id) AND (address = @Original_address OR @Original_address IS NULL AND address IS NULL) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (dr_fname = @Original_dr_fname) AND (dr_lname = @Original_dr_lname) AND (phone = @Original_phone OR @Original_phone IS NULL AND phone IS NULL) AND (state = @Original_state OR @Original_state IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL)";
			this.SqlDeleteCommand1.Connection = this.SqlConnection1;
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_id", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_fname", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_lname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_lname", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			// 
			// SqlInsertCommand1
			// 
			this.SqlInsertCommand1.CommandText = @"INSERT INTO doctors(dr_id, dr_lname, dr_fname, phone, address, city, state, zip) VALUES (@dr_id, @dr_lname, @dr_fname, @phone, @address, @city, @state, @zip); SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors WHERE (dr_id = @dr_id)";
			this.SqlInsertCommand1.Connection = this.SqlConnection1;
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_lname", System.Data.SqlDbType.VarChar, 20, "dr_lname"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_fname", System.Data.SqlDbType.VarChar, 20, "dr_fname"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"));
			this.SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 10, "zip"));
			// 
			// SqlSelectCommand1
			// 
			this.SqlSelectCommand1.CommandText = "SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors";
			this.SqlSelectCommand1.Connection = this.SqlConnection1;
			// 
			// SqlUpdateCommand1
			// 
			this.SqlUpdateCommand1.CommandText = @"UPDATE doctors SET dr_id = @dr_id, dr_lname = @dr_lname, dr_fname = @dr_fname, phone = @phone, address = @address, city = @city, state = @state, zip = @zip WHERE (dr_id = @Original_dr_id) AND (address = @Original_address OR @Original_address IS NULL AND address IS NULL) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (dr_fname = @Original_dr_fname) AND (dr_lname = @Original_dr_lname) AND (phone = @Original_phone OR @Original_phone IS NULL AND phone IS NULL) AND (state = @Original_state OR @Original_state IS NULL AND state IS NULL) AND (zip = @Original_zip OR @Original_zip IS NULL AND zip IS NULL); SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors WHERE (dr_id = @dr_id)";
			this.SqlUpdateCommand1.Connection = this.SqlConnection1;
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_id", System.Data.SqlDbType.VarChar, 4, "dr_id"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_lname", System.Data.SqlDbType.VarChar, 20, "dr_lname"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dr_fname", System.Data.SqlDbType.VarChar, 20, "dr_fname"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.VarChar, 12, "phone"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.VarChar, 40, "address"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 20, "city"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@state", System.Data.SqlDbType.VarChar, 2, "state"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 10, "zip"));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_id", System.Data.SqlDbType.VarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_id", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_address", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "address", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_fname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_fname", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_dr_lname", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "dr_lname", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_phone", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "phone", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_state", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "state", System.Data.DataRowVersion.Original, null));
			this.SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_zip", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "zip", System.Data.DataRowVersion.Original, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
