namespace Mod08CS
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for numberbox.
	/// </summary>
	public abstract class numberbox : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.RangeValidator txtNumRngValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtNumValidator1;
		protected System.Web.UI.WebControls.TextBox txtNum1;

		public int pNum
		{
			get
			{
				return Convert.ToInt32(txtNum1.Text);
			}
			set
			{
				txtNum1.Text = Convert.ToString(value);
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
				txtNum1.Text = "0";
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
