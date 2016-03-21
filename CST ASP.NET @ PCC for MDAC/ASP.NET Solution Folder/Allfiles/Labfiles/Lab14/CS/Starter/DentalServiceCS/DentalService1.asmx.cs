using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace DentalServiceCS
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	[WebService(Namespace="http://microsoft.com/webservices/",
	Description="This XML Web Service contains " + "information about the dentists.")]
	public class DentalService1 : System.Web.Services.WebService
	{
		public DentalService1()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DentalServiceCS.dsDentists dsDentists1;

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.dsDentists1 = new DentalServiceCS.dsDentists();
			((System.ComponentModel.ISupportInitialize)(this.dsDentists1)).BeginInit();
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT FirstName, LastName, Speciality, Address, City, Region, State, PostalCode," +
				" Country, Phone, Fax, DentistID FROM Dentists";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=localhost;initial catalog=dentists;integrated security=SSPI;persist s" +
				"ecurity info=True;workstation id=CAESAR;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Dentists", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
																																																				  new System.Data.Common.DataColumnMapping("LastName", "LastName"),
																																																				  new System.Data.Common.DataColumnMapping("Speciality", "Speciality"),
																																																				  new System.Data.Common.DataColumnMapping("Address", "Address"),
																																																				  new System.Data.Common.DataColumnMapping("City", "City"),
																																																				  new System.Data.Common.DataColumnMapping("Region", "Region"),
																																																				  new System.Data.Common.DataColumnMapping("State", "State"),
																																																				  new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
																																																				  new System.Data.Common.DataColumnMapping("Country", "Country"),
																																																				  new System.Data.Common.DataColumnMapping("Phone", "Phone"),
																																																				  new System.Data.Common.DataColumnMapping("Fax", "Fax"),
																																																				  new System.Data.Common.DataColumnMapping("DentistID", "DentistID")})});
			// 
			// dsDentists1
			// 
			this.dsDentists1.DataSetName = "dsDentists";
			this.dsDentists1.Locale = new System.Globalization.CultureInfo("en-GB");
			this.dsDentists1.Namespace = "http://www.tempuri.org/dsDentists.xsd";
			((System.ComponentModel.ISupportInitialize)(this.dsDentists1)).EndInit();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod(Description= "This XML Web service method returns all the dentists")]
		public DataSet GetAllDentists()
		{
			sqlDataAdapter1.Fill(dsDentists1);
			return dsDentists1;
		}

		[WebMethod(Description= "This XML Web service method returns the dentists from a supplied postal code.")]
		public DataSet GetDentistsByPostalCode(String strPostalCode)
		{
			SqlConnection conn = new SqlConnection ("data source=localhost;initial catalog=Dentists;integrated security=true");
			SqlDataAdapter daDentistsPoCode;
			DataSet dsDentistsPoCode = new DataSet();
			SqlParameter workParam  = null;

			//call the DentistsByState stored procedure
			daDentistsPoCode = new SqlDataAdapter("DentistsByPostalCode", conn);
			daDentistsPoCode.SelectCommand.CommandType = CommandType.StoredProcedure;

			//add the postal code input parameter
			workParam = new SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar);
			workParam.Direction = ParameterDirection.Input;
			workParam.Value = strPostalCode;
			daDentistsPoCode.SelectCommand.Parameters.Add(workParam);

			//run the stored procedure and fill a dataset
			daDentistsPoCode.Fill(dsDentistsPoCode, "DentistsPoCode");

			//close the connection
			conn.Close();

			return dsDentistsPoCode;
		}
	}
}
