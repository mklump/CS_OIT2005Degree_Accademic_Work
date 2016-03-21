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

namespace Mod10CS
{
	/// <summary>
	/// Summary description for DataReaderCode.
	/// </summary>
	public class DataReaderCode : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator4;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator5;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator6;
		protected System.Web.UI.WebControls.DropDownList DropDownList7;
		protected System.Web.UI.WebControls.CustomValidator CustomValidator7;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Put user code to initialize the page here
			Label2.Text = "";
			if (!Page.IsPostBack)
			{
				ArrayList aCode = new ArrayList();

				aCode.Add("-----");
				aCode.Add("conn.Close();");
				aCode.Add("SqlCommand cmdAuthors = new SqlCommand('select * from Authors', conn);");
				aCode.Add("dr = cmdAuthors.ExecuteReader();");
				aCode.Add("SqlDataReader dr;");
				aCode.Add("SqlConnection conn = new SqlConnection('valid connection string');");
				aCode.Add("conn.Open();");
				aCode.Add("dr.Close();");

				DropDownList1.DataSource = aCode;
				DropDownList1.DataBind();
				DropDownList2.DataSource = aCode;
				DropDownList2.DataBind();
				DropDownList3.DataSource = aCode;
				DropDownList3.DataBind();
				DropDownList4.DataSource = aCode;
				DropDownList4.DataBind();
				DropDownList5.DataSource = aCode;
				DropDownList5.DataBind();
				DropDownList6.DataSource = aCode;
				DropDownList6.DataBind();
				DropDownList7.DataSource = aCode;
				DropDownList7.DataBind();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//there are a couple of valid answers. the required parts are declare before use, 
			//create conn, da, then dataset
			if (Page.IsValid)
			{
				Label2.Text = "Good job! All answers are correct.";
			}
			else
			{
				Label2.Text = "Sorry, try again.";
			}
		}
	}
}
