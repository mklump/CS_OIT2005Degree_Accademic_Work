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
	/// Summary description for ErrorHandling.
	/// </summary>
	public class ErrorHandling : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtConnString;
		protected System.Web.UI.WebControls.TextBox txtSelectString;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button cmdOpen;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblErrors;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label2;
	
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
			this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdOpen_Click(object sender, System.EventArgs e)
		{
			lblErrors.Text = "";
			DataGrid1.Visible = false;
			try
			{
				SqlConnection conn = new SqlConnection(txtConnString.Text);
				SqlDataAdapter da = new SqlDataAdapter(txtSelectString.Text, conn);
				DataSet ds = new DataSet();
				da.Fill(ds);
				DataGrid1.DataSource = ds;
				DataGrid1.DataBind();
				DataGrid1.Visible = true;
			}
			catch (SqlException ex1)
			{
				SqlErrorCollection erData = ex1.Errors;
				string strError;
				for(int i=0;i < erData.Count;++i)
				{
					strError = ("Error " + i + ": " + erData[i].Number + ", " + erData[i].Class + ", " + erData[i].Message + "<br>");
					lblErrors.Text += ("Error " + i + ": " + erData[i].Number + ", " + erData[i].Class + ", " + erData[i].Message + "<br>");
				}

				switch(ex1.Number)
				{
					case 17:
						lblErrors.Text += ("invalid server name");
						break;
					case 156:
					case 170: //bad SQL syntax
						lblErrors.Text += ("incorrect syntax");
						break;
					case 207: //bad field name in select
						lblErrors.Text += ("invalid column name");
						break;
					case 208: //bad table name in select
						lblErrors.Text += ("invalid object name");
						break;
					case 18452:
						lblErrors.Text += ("invalid user name");
						break;
					case 18456:
						lblErrors.Text += ("invalid password");
						break;
					case 4060:	
						lblErrors.Text += ("invalid database");
						break;
				}
			}
			catch (System.Exception ex2)
			{
				lblErrors.Text = lblErrors.Text + ("Unexpected exception: " + ex2.Message + ". ");
			}
		}
	}
}
