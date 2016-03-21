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
		protected System.Web.UI.WebControls.ListBox lstSpecialties;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//TODO Lab 9: bind the datagrid to the doctors table

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
