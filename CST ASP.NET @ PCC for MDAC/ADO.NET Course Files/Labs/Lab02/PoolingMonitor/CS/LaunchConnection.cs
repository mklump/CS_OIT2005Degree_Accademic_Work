using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace PoolingMonitor
{
	public class LaunchConnection : System.Windows.Forms.Form
	{
		
		[STAThread]
		static void Main()
		{
			Application.Run(new LaunchConnection());
		}
		
		#region " Windows Form Designer generated code "
		
		public LaunchConnection() {
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			
		}
		
		//Form overrides dispose to clean up the component list.
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		internal System.Windows.Forms.Button btnExit;
		internal System.Windows.Forms.Button btnNew;
		internal System.Windows.Forms.TextBox txtConName;
		internal System.Windows.Forms.Label lblConnection;
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
			this.txtConName = new System.Windows.Forms.TextBox();
			txtConName.Enter += new System.EventHandler(txtConName_Enter);
			this.btnExit = new System.Windows.Forms.Button();
			btnExit.Click += new System.EventHandler(btnExit_Click);
			this.btnNew = new System.Windows.Forms.Button();
			btnNew.Click += new System.EventHandler(btnNew_Click);
			this.lblConnection = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			//txtConName
			//
			this.txtConName.Location = new System.Drawing.Point(8, 24);
			this.txtConName.Name = "txtConName";
			this.txtConName.Size = new System.Drawing.Size(240, 20);
			this.txtConName.TabIndex = 1;
			this.txtConName.Text = "Enter a Connection Name";
			//
			//btnExit
			//
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(176, 56);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(72, 24);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "Exit";
			//
			//btnNew
			//
			this.btnNew.Location = new System.Drawing.Point(56, 56);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(112, 24);
			this.btnNew.TabIndex = 2;
			this.btnNew.Text = "New Connection";
			//
			//lblConnection
			//
			this.lblConnection.AutoSize = true;
			this.lblConnection.Location = new System.Drawing.Point(8, 8);
			this.lblConnection.Name = "lblConnection";
			this.lblConnection.Size = new System.Drawing.Size(95, 13);
			this.lblConnection.TabIndex = 0;
			this.lblConnection.Text = "Connection Name";
			//
			//LaunchConnection
			//
			this.AcceptButton = this.btnNew;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(264, 93);
			this.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnExit, this.btnNew, this.txtConName, this.lblConnection });
			this.Name = "LaunchConnection";
			this.Text = "Launch Connection";
			this.ResumeLayout(false);
			
		}
		
		#endregion
		
		private void btnNew_Click (System.Object sender, System.EventArgs e)
		{
			
			OpenNewConnection mycon = new OpenNewConnection();
			
			mycon.Text = txtConName.Text;
			
			mycon.Show();
			
		}
		
		private void btnExit_Click (System.Object sender, System.EventArgs e)
		{
			
			this.Close();
			
		}
		
		private void txtConName_Enter (object sender, System.EventArgs e)
		{
			
			txtConName.SelectAll();
			
		}
		
	}
	
}
