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
using System.Configuration;
using System.Web.Security;

namespace BenefitsCS
{
	/// <summary>
	/// Summary description for register.
	/// </summary>
	public class register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldEmailReq;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldEmailExpr;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldPasswordReq;
		protected System.Web.UI.WebControls.TextBox txtConfirmPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldConfirmPasswordReq;
		protected System.Web.UI.WebControls.CompareValidator vldConfirmPasswordComp;
		protected System.Web.UI.WebControls.Button cmdValidation;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.Label lblInfo;
	
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
			this.cmdValidation.Click += new System.EventHandler(this.cmdValidation_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//*******************************************************
		//
		// AddEmployee() Function
		//
		// The AddCustomer method inserts a new employee record
		// into the Coho database.  A unique "EmployeeId"
		// key is then returned from the method.  This can be 
		// used later within the Web application.
		//
		//*******************************************************


		public string AddEmployee(string strEmail, string strPassword)
		{
			string conStrCoho = ConfigurationSettings.AppSettings["conStrCoho"];
			//Create Instance of Connection and Command Object
			SqlConnection objConnection = new SqlConnection(conStrCoho);
			SqlCommand objCommand = new SqlCommand("EmployeeAdd", objConnection);

			//Mark the Command as a SPROC
			objCommand.CommandType = CommandType.StoredProcedure;

			//Add Parameters to SPROC

			//Email (user name) input parameter
			SqlParameter parameterEmail = new SqlParameter("@userName", SqlDbType.VarChar, 50);
			parameterEmail.Value = strEmail;
			objCommand.Parameters.Add(parameterEmail);

			//Password input parameter
			SqlParameter parameterPassword = new SqlParameter("@password", SqlDbType.VarChar, 20);
			parameterPassword.Value = strPassword;
			objCommand.Parameters.Add(parameterPassword);

			//EmployeeID output parameter
			SqlParameter parameterEmployeeID = new SqlParameter("@employeeID", SqlDbType.Int, 4);
			parameterEmployeeID.Direction = ParameterDirection.Output;
			objCommand.Parameters.Add(parameterEmployeeID);

			try
			{
				//Open the connection and execute the Command
				objConnection.Open();
				objCommand.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				//An error occurred
				lblInfo.Text = "Error of connection to the database, please try again later.";
			}
			finally
			{
				//Close the Connection
				if (objConnection.State == ConnectionState.Open)
				{
					objConnection.Close();
				}
			}

			//Return the EmployeeID Output Param from SPROC
			int EmployeeId;
			EmployeeId = Convert.ToInt16(parameterEmployeeID.Value);

			return EmployeeId.ToString();

		}

		private void cmdValidation_Click(object sender, System.EventArgs e)
		{

			//Only attempt a validation if all form fields on this
			//page are valid

			if (Page.IsValid)
			{

				//ID of a employee
				string strEmployeeId ="";

				//TODO Lab 16: Call the AddEmployee function
				strEmployeeId = AddEmployee(txtEmail.Text, txtPassword.Text);


				if (strEmployeeId != "")
				{
					//TODO Lab 16: Login users and generate an auth. cookie
					FormsAuthentication.SetAuthCookie(strEmployeeId, false);
					Response.Redirect("default.aspx");
				}
			}
		}
	}
}
