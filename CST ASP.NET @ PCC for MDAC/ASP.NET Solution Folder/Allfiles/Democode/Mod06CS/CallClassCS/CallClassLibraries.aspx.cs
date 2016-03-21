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

namespace CallClassCS
{
	/// <summary>
	/// Summary description for CallClassLibraries.
	/// </summary>
	public class CallClassLibraries : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdUseWS;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button cmdUseCSharp;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button cmdUseVB;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.cmdUseCSharp.Click += new System.EventHandler(this.cmdUseCSharp_Click);
			this.cmdUseVB.Click += new System.EventHandler(this.cmdUseVB_Click);
			this.cmdUseWS.Click += new System.EventHandler(this.cmdUseWS_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			VBClassLibrary.Class1 x = new VBClassLibrary.Class1();
			Button1.Text = x.hello();
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			CSharpClassLibrary.Class1 x = new CSharpClassLibrary.Class1();
			Button2.Text = x.hello();
		}

		private void cmdUseCSharp_Click(object sender, System.EventArgs e)
		{
			CSharpClassLibrary.Class1 x = new CSharpClassLibrary.Class1();
			Single sngShipping;
			sngShipping = x.ComputeShipping(Convert.ToSingle( TextBox1.Text));
			Label1.Text = (sngShipping).ToString();
		}

		private void cmdUseVB_Click(object sender, System.EventArgs e)
		{
			VBClassLibrary.Class1 x = new VBClassLibrary.Class1();
			Single sngShipping;
			sngShipping = x.ComputeShipping(Convert.ToSingle(TextBox1.Text));
			Label1.Text = (sngShipping).ToString();
		}

		private void cmdUseWS_Click(object sender, System.EventArgs e)
		{
			CallClassCS.shippingWebRef.Service1 service = new CallClassCS.shippingWebRef.Service1();
			Single sngShipping;
			sngShipping = service.ComputeShipping(Convert.ToSingle(TextBox1.Text));
			Label1.Text = (sngShipping).ToString();
		}
	}
}
