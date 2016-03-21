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

namespace ASPNetCS
{
	/// <summary>
	/// Summary description for WebForm11.
	/// </summary>
	public class WebForm11 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			ASPNetCS.WeatherWebRef.WeatherService
				ProxyGetWeather = new
				ASPNetCS.WeatherWebRef.WeatherService();
			try
			{
				Label1.Text = ProxyGetWeather.WeatherByCity( TextBox1.Text );
				if( "" == TextBox1.Text )
					throw new System.Web.Services.Protocols.SoapException(
						"Soap Exception", System.Xml.XmlQualifiedName.Empty
						);
				ProxyGetWeather.Timeout = 10000;
			}
			catch( System.Web.Services.Protocols.SoapException error )
			{
				Label1.Text = "Unable to process you request.";
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				//throw;
			}
			catch( System.Exception error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
		}
	}
}
