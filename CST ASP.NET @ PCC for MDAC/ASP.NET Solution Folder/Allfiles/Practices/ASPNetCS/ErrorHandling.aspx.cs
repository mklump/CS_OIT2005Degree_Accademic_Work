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
using ado = System.Data.SqlClient;

namespace ASPNetCS
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnOpenConnection;
		protected System.Web.UI.WebControls.TextBox txtErrors;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox txtInfoMessages;
	
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.btnOpenConnection.Click += new System.EventHandler(this.btnOpenConnection_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.conSQL_InfoMessage);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOpenConnection_Click(object sender, System.EventArgs e)
		{
			this.sqlConnection1.ConnectionString = Application["connectionString"].ToString();
				
			try
			{
				this.sqlConnection1.Open();
				this.sqlConnection1.ChangeDatabase("Pubs");
			}
			catch (ado.SqlException sqlXcp)
			{
				ado.SqlErrorCollection erData = sqlXcp.Errors;
				for (int i = 0; i < erData.Count; i++)
				{
					
					this.txtErrors.Text += "Error" + i + ": " +
						erData[i].Number + ", " +
						erData[i].Class + ", " +
						erData[i].Message + "\r\n";

					;
				}
			}
			catch (System.Exception Xcp)
			{
				//Do Something
				System.Diagnostics.Trace.WriteLine( Xcp.ToString() );
				throw;
			}
			finally
			{
				if (this.sqlConnection1.State == System.Data.ConnectionState.Open)
				{
					this.sqlConnection1.Close();
				}
			}
			}

		private void conSQL_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
			ado.SqlErrorCollection erData = e.Errors;
			for (int i = 0; i < erData.Count; i++)
			{
					
				this.txtInfoMessages.Text += "Error" + i + ": " +
					erData[i].Number + ", " +
					erData[i].Class + ", " +
					erData[i].Message + "\r\n";

				;
			}
		}
	}
}
