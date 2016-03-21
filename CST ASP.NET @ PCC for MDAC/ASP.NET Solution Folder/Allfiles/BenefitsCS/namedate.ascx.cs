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
	public partial class namedate : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( !Page.IsPostBack )
			{
				txtName.Text = (string) Session["Name"];
				txtBirth.Text = (string) Session["Birth"];
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		/// <summary>
		/// Property strName (string)
		/// </summary>
		public string strName
		{
			get
			{
				Session["Name"] = txtName.Text;
				return txtName.Text;
			}
			set { txtName.Text = value; }
		}

		/// <summary>
		/// Property dtDate (DateTime)
		/// </summary>
		public DateTime dtDate
		{
			get
			{
				Session["Birth"] = txtBirth.Text;
				return Convert.ToDateTime( txtBirth.Text );
			}
			set { txtBirth.Text = Convert.ToString( value ); }
		}

		/// <summary>
		/// Reloads this page
		/// </summary>
		public void PageReload()
		{
			this.Page_Load( new object(), new EventArgs() );
		}
	}
}
