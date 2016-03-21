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
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace BenefitsCS
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button cmdLogin;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.HyperLink lnkRegister;
	
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
			this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//*******************************************************
		//
		// Login() Function
		//
		// The Login method validates a email/password pair
		// against credentials stored in the Coho database.
		// If the email/password pair is valid, the method returns
		// the "EmployeeId" number of the employee.  Otherwise
		// it returns an empty string.
		//
		//*******************************************************

		string Login(string strEmail, string strPassword)
		{
			//Retrieve the connection string from the <appSettings> section of Web.config
			string conStrCoho = ConfigurationSettings.AppSettings["conStrCoho"];

			//Create Instance of Connection and Command Object
			SqlConnection objConnection = new SqlConnection(conStrCoho);
			SqlCommand objCommand = new SqlCommand("EmployeeLogin", objConnection);

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
			int EmployeeId = Convert.ToInt16(parameterEmployeeID.Value);

			if (EmployeeId == 0)
			{
				return "";
			}
			else
			{
				return EmployeeId.ToString();
			}
		}

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			//ID of an employee
			string strEmployeeId;

			//TODO Lab 16: Call the Login function
			strEmployeeId = Login(txtEmail.Text, txtPassword.Text);

			//TODO Lab 16: Login users and generate an auth. cookie
			if (strEmployeeId != "")
			{
				FormsAuthentication.RedirectFromLoginPage(strEmployeeId, false);
			}
			else //Login failed
			{
				lblInfo.Text = "Login Failed!";
			}

		}
	}
}
