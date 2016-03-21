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

using System.Xml;
using System.Data.SqlClient;

namespace BenefitsCS
{
	/// <summary>
	/// Summary description for retirement.
	/// </summary>
	public partial class retirement : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//TODO Lab 12: Create a DataSet, fill it out with the
				//XML file, and display it
				DataSet dsRetirement = new DataSet( "dsRetirement" );
				dsRetirement.ReadXml( Server.MapPath("mutual_funds.xml") );
				dgRetirement.DataSource = dsRetirement;
				dgRetirement.DataBind();
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
	}
}
