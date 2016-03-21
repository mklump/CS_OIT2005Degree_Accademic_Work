using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnOpen;
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
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(8, 8);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(136, 248);
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "OPEN";
			this.btnOpen.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnClose
			// 
			this.btnClose.Enabled = false;
			this.btnClose.Location = new System.Drawing.Point(152, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(128, 248);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "CLOSE";
			this.btnClose.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnOpen);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private SqlConnection cnNorthWind;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			cnNorthWind = new SqlConnection("integrated security=SSPI;data source=localhost;initial catalog=Northwind");
			cnNorthWind.StateChange += new StateChangeEventHandler(cnNorthWind_StateChange);
		}
		
		private void button1_Click(object sender, System.EventArgs e)
		{
			cnNorthWind.Open();		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			cnNorthWind.Close();
		}

		private void cnNorthWind_StateChange(object sender, StateChangeEventArgs e)
		{
			btnOpen.Enabled = (e.CurrentState == ConnectionState.Closed);
			btnClose.Enabled = (e.CurrentState == ConnectionState.Open);
		}
	}
}
