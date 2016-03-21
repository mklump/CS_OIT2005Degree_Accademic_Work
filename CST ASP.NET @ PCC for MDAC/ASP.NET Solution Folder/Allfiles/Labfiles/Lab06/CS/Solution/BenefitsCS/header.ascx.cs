namespace BenefitsCS
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for header.
	/// </summary>
	public abstract class header : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlAnchor A2;
		protected System.Web.UI.HtmlControls.HtmlAnchor A3;
		protected System.Web.UI.HtmlControls.HtmlAnchor A4;
		protected System.Web.UI.HtmlControls.HtmlAnchor A1;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//System.Web.HttpContext.Current.Trace.Warn 
			//	("Header", "Start Header");

			BenefitsListCS.Benefits clBenefits = new BenefitsListCS.Benefits();
			BenefitsListCS.Benefits.BenefitInfo[] arBenefits;

			arBenefits = clBenefits.GetBenefitsList();
			A1.HRef = arBenefits[0].strPage;
			A1.InnerText = arBenefits[0].strName;
			A2.HRef = arBenefits[1].strPage;
			A2.InnerText = arBenefits[1].strName;
			A3.HRef = arBenefits[2].strPage;
			A3.InnerText = arBenefits[2].strName;
			A4.HRef = arBenefits[3].strPage;
			A4.InnerText = arBenefits[3].strName;

			//System.Web.HttpContext.Current.Trace.Warn 
			//	("Header", "End Header");
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
