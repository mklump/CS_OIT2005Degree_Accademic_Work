namespace BenefitsCS
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for namedate.
	/// </summary>
	public abstract class namedate : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.CompareValidator vldBirthType;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldBirth;
		protected System.Web.UI.WebControls.TextBox txtBirth;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldName;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Label Label2;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		public String strName
		{
			get
			{
				return txtName.Text;
			}
			set
			{
				txtName.Text = value;
			}
		}
		public DateTime dtDate
		{
			get
			{
				return Convert.ToDateTime(txtBirth.Text);
			}
			set
			{
				txtBirth.Text = value.ToString();
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
