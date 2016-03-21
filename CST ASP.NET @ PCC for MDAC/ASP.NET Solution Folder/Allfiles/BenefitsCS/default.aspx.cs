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
	/// Summary description for _default.
	/// </summary>
	public partial class _default : System.Web.UI.Page
	{
	
		/// <summary>
		/// <!-- Tracing was specifically added to this Page with the tag <%@ Page Trace="true" %> -->
		/// </summary>
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Trace.Warn( "2310", "Beginning of Page_Load" );
			// Trace.Warn( "2310", "IsPostBack=" + IsPostBack );
			if( !IsPostBack )
			{
				BenefitsListCS.Benefits clBenefits = new BenefitsListCS.Benefits();
				foreach( BenefitsListCS.Benefits.BenefitInfo bi in clBenefits.GetBenefitsList() )
				{
					chkListBenefits.Items.Add( 
						string.Format("<a href={0}> {1} </a>", bi.strPage, bi.strName )
						);
				}
				chkListBenefits.DataBind();
			}
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

		}
		#endregion

		protected void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			foreach( ListItem item in chkListBenefits.Items )
			{
				if( item.Selected )
					lblSelections.Text += ", " + item.Value;
			}
		}
	}
}

