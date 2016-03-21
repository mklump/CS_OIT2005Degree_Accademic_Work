using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CatchingSqlExceptions
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Data.SqlClient.SqlConnection cnNorthwind;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOpen = new System.Windows.Forms.Button();
			this.cnNorthwind = new System.Data.SqlClient.SqlConnection();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(104, 64);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// txtServerName
			// 
			this.txtServerName.Location = new System.Drawing.Point(88, 168);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.TabIndex = 2;
			this.txtServerName.Text = "(local)";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(104, 104);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtServerName,
																		  this.btnClose,
																		  this.btnOpen});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			try
			{
				cnNorthwind.ConnectionString =
					"Data Source=" + txtServerName.Text + ";" +
					"Connect Timeout=5;" +
					"Initial Catalog=Northwind;Integrated Security=SSPI;";
				
				cnNorthwind.Open();
			}
			catch (System.Data.SqlClient.SqlException XcpSQL)
			{
				foreach (System.Data.SqlClient.SqlError se in XcpSQL.Errors)
				{
					MessageBox.Show(se.Message, "SQL Error Level " + se.Class,
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (System.Exception Xcp)
			{
				MessageBox.Show(Xcp.Message, "Unexpected Exception",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			cnNorthwind.Close();
			cnNorthwind.Dispose();
		}

	}
}
