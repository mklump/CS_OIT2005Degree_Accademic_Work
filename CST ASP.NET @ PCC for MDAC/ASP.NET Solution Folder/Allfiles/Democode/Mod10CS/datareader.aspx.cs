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
	/// Summary description for datareader.
	/// </summary>
	public class datareader : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lstBoundNames;
		protected System.Web.UI.WebControls.ListBox lstBuiltNames;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			SqlDataReader dr;
			SqlConnection conn;
			SqlCommand cmdAuthors;

			conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=pubs");
			conn.Open();
			cmdAuthors = new SqlCommand("Select * from Authors", conn);

			//now bind the same datareader to a list box
			dr = cmdAuthors.ExecuteReader();
			lstBoundNames.DataSource = dr;
			lstBoundNames.DataTextField = "au_lname";
			lstBoundNames.DataBind();

			//now display (last name, first name) in a listbox
			dr.Close();
			dr = cmdAuthors.ExecuteReader();
			
			while (dr.Read())
			{
				lstBuiltNames.Items.Add(dr["au_lname"] + ", " + dr["au_fname"]);
			}

			//close the datareader and connection
			dr.Close();
			conn.Close();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
