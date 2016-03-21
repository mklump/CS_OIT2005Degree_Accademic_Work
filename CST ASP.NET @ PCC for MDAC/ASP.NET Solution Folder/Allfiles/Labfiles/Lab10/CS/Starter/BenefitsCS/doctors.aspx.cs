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
	/// Summary description for doctors.
	/// </summary>
	public class doctors : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSpecialties;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected BenefitsCS.dsDoctors dsDoctors1;
		protected System.Web.UI.WebControls.DataGrid dgDoctors;
		protected System.Web.UI.WebControls.ListBox lstSpecialties;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//TODO Lab 9: bind the datagrid to the doctors table
				sqlDataAdapter1.Fill(dsDoctors1);
				dgDoctors.DataBind();

				//TODO Lab10: bind the listbox to city field in the doctors table
	
				//TODO Lab11: bind the listbox to the getUniqueCities stored procedure

				//TODO Lab10: add the "All" item to the list and select it

				//hide the specialties listbox
				lstSpecialties.Visible = false;
				lblSpecialties.Visible = false;
			}
		}

		private void reset()
		{
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.dsDoctors1 = new BenefitsCS.dsDoctors();
			((System.ComponentModel.ISupportInitialize)(this.dsDoctors1)).BeginInit();
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=CM-T23-STEPHENW;initial catalog=doctors;integrated security=SSPI;pers" +
				"ist security info=True;workstation id=CM-T23-STEPHENW;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
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
			// 
			// dsDoctors1
			// 
			this.dsDoctors1.DataSetName = "dsDoctors";
			this.dsDoctors1.Locale = new System.Globalization.CultureInfo("en-GB");
			this.dsDoctors1.Namespace = "http://www.tempuri.org/dsDoctors.xsd";
			this.dgDoctors.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgDoctors_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsDoctors1)).EndInit();

		}
		#endregion

		private void dgDoctors_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgDoctors.CurrentPageIndex = e.NewPageIndex;
			sqlDataAdapter1.Fill(dsDoctors1);
			dgDoctors.DataBind();
		}

		private void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			string strDrName;
			strDrName = dgDoctors.Items
				[dgDoctors.SelectedIndex].Cells[3].Text
				.Trim() + " " +
				dgDoctors.Items[dgDoctors.SelectedIndex].Cells[2]
				.Text.Trim();
			Response.Redirect("medical.aspx?pcp=" + strDrName);
		}
	}
}
