using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace PoolingMonitor
{
	public class OpenNewConnection : System.Windows.Forms.Form
	{
		
		
		#region " Windows Form Designer generated code "
		
		public OpenNewConnection() {
			
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
		
		internal System.Windows.Forms.Button btnOpenSQL;
		internal System.Windows.Forms.Label lblUserName;
		internal System.Windows.Forms.Label lblSQLDatabase;
		internal System.Windows.Forms.ComboBox cboDatabase;
		internal System.Windows.Forms.CheckBox chkEnablePooling;
		internal System.Windows.Forms.Label lblPassword;
		internal System.Windows.Forms.ComboBox cboUsername;
		internal System.Windows.Forms.GroupBox grpPooling;
		internal System.Windows.Forms.CheckBox chkResetConnection;
		internal System.Windows.Forms.TextBox txtMinPoolSize;
		internal System.Windows.Forms.TextBox txtMaxPoolSize;
		internal System.Windows.Forms.TextBox txtLifetime;
		internal System.Windows.Forms.ComboBox cboPassword;
		internal System.Windows.Forms.Label lblConnStr;
		internal System.Windows.Forms.Button btnCloseSQL;
		internal System.Windows.Forms.Button btnRelease;
		internal System.Windows.Forms.Label lblConStr;
		internal System.Windows.Forms.Label lblLifetime;
		internal System.Windows.Forms.Label lblMinPoolSize;
		internal System.Windows.Forms.Label lblMaxPoolSize;
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
			this.lblConStr = new System.Windows.Forms.Label();
			base.Load += new System.EventHandler(OpenNewConnection_Load);
			this.grpPooling = new System.Windows.Forms.GroupBox();
			this.lblLifetime = new System.Windows.Forms.Label();
			this.lblMinPoolSize = new System.Windows.Forms.Label();
			this.chkResetConnection = new System.Windows.Forms.CheckBox();
			chkResetConnection.CheckedChanged += new System.EventHandler(UpdateConnStrLabel);
			this.lblMaxPoolSize = new System.Windows.Forms.Label();
			this.txtMinPoolSize = new System.Windows.Forms.TextBox();
			txtMinPoolSize.TextChanged += new System.EventHandler(UpdateConnStrLabel);
			this.txtMaxPoolSize = new System.Windows.Forms.TextBox();
			txtMaxPoolSize.TextChanged += new System.EventHandler(UpdateConnStrLabel);
			this.txtLifetime = new System.Windows.Forms.TextBox();
			txtLifetime.TextChanged += new System.EventHandler(UpdateConnStrLabel);
			this.cboPassword = new System.Windows.Forms.ComboBox();
			cboPassword.TextChanged += new System.EventHandler(UpdateConnStrLabel);
			this.lblConnStr = new System.Windows.Forms.Label();
			this.chkEnablePooling = new System.Windows.Forms.CheckBox();
			chkEnablePooling.CheckedChanged += new System.EventHandler(chkEnablePooling_CheckedChanged);
			chkEnablePooling.CheckedChanged += new System.EventHandler(UpdateConnStrLabel);
			this.cboUsername = new System.Windows.Forms.ComboBox();
			cboUsername.TextChanged += new System.EventHandler(UpdateConnStrLabel);
			this.lblUserName = new System.Windows.Forms.Label();
			this.btnOpenSQL = new System.Windows.Forms.Button();
			btnOpenSQL.Click += new System.EventHandler(btnOpenSQL_Click);
			this.btnRelease = new System.Windows.Forms.Button();
			btnRelease.Click += new System.EventHandler(btnRelease_Click);
			this.lblSQLDatabase = new System.Windows.Forms.Label();
			this.btnCloseSQL = new System.Windows.Forms.Button();
			btnCloseSQL.Click += new System.EventHandler(btnCloseSQL_Click);
			this.lblPassword = new System.Windows.Forms.Label();
			this.cboDatabase = new System.Windows.Forms.ComboBox();
			cboDatabase.TextChanged += new System.EventHandler(UpdateConnStrLabel);
			this.grpPooling.SuspendLayout();
			this.SuspendLayout();
			//
			//lblConStr
			//
			this.lblConStr.AutoSize = true;
			this.lblConStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,((byte)(0)));
			this.lblConStr.Location = new System.Drawing.Point(8, 112);
			this.lblConStr.Name = "lblConStr";
			this.lblConStr.Size = new System.Drawing.Size(98, 13);
			this.lblConStr.TabIndex = 11;
			this.lblConStr.Text = "Connection String";
			//
			//grpPooling
			//
			this.grpPooling.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblLifetime, this.lblMinPoolSize, this.chkResetConnection, this.lblMaxPoolSize, this.txtMinPoolSize, this.txtMaxPoolSize, this.txtLifetime });
			this.grpPooling.Enabled = false;
			this.grpPooling.Location = new System.Drawing.Point(200, 8);
			this.grpPooling.Name = "grpPooling";
			this.grpPooling.Size = new System.Drawing.Size(136, 144);
			this.grpPooling.TabIndex = 7;
			this.grpPooling.TabStop = false;
			//
			//lblLifetime
			//
			this.lblLifetime.Location = new System.Drawing.Point(8, 112);
			this.lblLifetime.Name = "lblLifetime";
			this.lblLifetime.Size = new System.Drawing.Size(56, 16);
			this.lblLifetime.TabIndex = 5;
			this.lblLifetime.Text = "Lifetime";
			//
			//lblMinPoolSize
			//
			this.lblMinPoolSize.AutoSize = true;
			this.lblMinPoolSize.Location = new System.Drawing.Point(8, 24);
			this.lblMinPoolSize.Name = "lblMinPoolSize";
			this.lblMinPoolSize.Size = new System.Drawing.Size(73, 13);
			this.lblMinPoolSize.TabIndex = 0;
			this.lblMinPoolSize.Text = "Min Pool Size";
			//
			//chkResetConnection
			//
			this.chkResetConnection.Location = new System.Drawing.Point(8, 88);
			this.chkResetConnection.Name = "chkResetConnection";
			this.chkResetConnection.Size = new System.Drawing.Size(120, 16);
			this.chkResetConnection.TabIndex = 4;
			this.chkResetConnection.Text = "Connection Reset";
			//
			//lblMaxPoolSize
			//
			this.lblMaxPoolSize.AutoSize = true;
			this.lblMaxPoolSize.Location = new System.Drawing.Point(8, 48);
			this.lblMaxPoolSize.Name = "lblMaxPoolSize";
			this.lblMaxPoolSize.Size = new System.Drawing.Size(76, 13);
			this.lblMaxPoolSize.TabIndex = 2;
			this.lblMaxPoolSize.Text = "Max Pool Size";
			//
			//txtMinPoolSize
			//
			this.txtMinPoolSize.Location = new System.Drawing.Point(88, 24);
			this.txtMinPoolSize.Name = "txtMinPoolSize";
			this.txtMinPoolSize.Size = new System.Drawing.Size(40, 20);
			this.txtMinPoolSize.TabIndex = 1;
			this.txtMinPoolSize.Text = "0";
			//
			//txtMaxPoolSize
			//
			this.txtMaxPoolSize.Location = new System.Drawing.Point(88, 48);
			this.txtMaxPoolSize.Name = "txtMaxPoolSize";
			this.txtMaxPoolSize.Size = new System.Drawing.Size(40, 20);
			this.txtMaxPoolSize.TabIndex = 3;
			this.txtMaxPoolSize.Text = "100";
			//
			//txtLifetime
			//
			this.txtLifetime.Location = new System.Drawing.Point(88, 112);
			this.txtLifetime.Name = "txtLifetime";
			this.txtLifetime.Size = new System.Drawing.Size(40, 20);
			this.txtLifetime.TabIndex = 6;
			this.txtLifetime.Text = "0";
			//
			//cboPassword
			//
			this.cboPassword.DropDownWidth = 120;
			this.cboPassword.Items.AddRange(new object[] { "AmyJ", "JohnK" });
			this.cboPassword.Location = new System.Drawing.Point(72, 64);
			this.cboPassword.Name = "cboPassword";
			this.cboPassword.Size = new System.Drawing.Size(120, 21);
			this.cboPassword.TabIndex = 5;
			//
			//lblConnStr
			//
			this.lblConnStr.Location = new System.Drawing.Point(8, 128);
			this.lblConnStr.Name = "lblConnStr";
			this.lblConnStr.Size = new System.Drawing.Size(184, 120);
			this.lblConnStr.TabIndex = 12;
			//
			//chkEnablePooling
			//
			this.chkEnablePooling.Location = new System.Drawing.Point(208, 8);
			this.chkEnablePooling.Name = "chkEnablePooling";
			this.chkEnablePooling.Size = new System.Drawing.Size(104, 16);
			this.chkEnablePooling.TabIndex = 6;
			this.chkEnablePooling.Text = "Enable Pooling";
			//
			//cboUsername
			//
			this.cboUsername.DropDownWidth = 120;
			this.cboUsername.Items.AddRange(new object[] { "AmyJ", "JohnK" });
			this.cboUsername.Location = new System.Drawing.Point(72, 40);
			this.cboUsername.Name = "cboUsername";
			this.cboUsername.Size = new System.Drawing.Size(120, 21);
			this.cboUsername.TabIndex = 3;
			//
			//lblUserName
			//
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(8, 40);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(61, 13);
			this.lblUserName.TabIndex = 2;
			this.lblUserName.Text = "User Name";
			//
			//btnOpenSQL
			//
			this.btnOpenSQL.Location = new System.Drawing.Point(200, 160);
			this.btnOpenSQL.Name = "btnOpenSQL";
			this.btnOpenSQL.Size = new System.Drawing.Size(136, 24);
			this.btnOpenSQL.TabIndex = 8;
			this.btnOpenSQL.Text = "Open";
			//
			//btnRelease
			//
			this.btnRelease.Enabled = false;
			this.btnRelease.Location = new System.Drawing.Point(200, 224);
			this.btnRelease.Name = "btnRelease";
			this.btnRelease.Size = new System.Drawing.Size(136, 24);
			this.btnRelease.TabIndex = 10;
			this.btnRelease.Text = "Release Resources";
			//
			//lblSQLDatabase
			//
			this.lblSQLDatabase.AutoSize = true;
			this.lblSQLDatabase.Location = new System.Drawing.Point(8, 16);
			this.lblSQLDatabase.Name = "lblSQLDatabase";
			this.lblSQLDatabase.Size = new System.Drawing.Size(53, 13);
			this.lblSQLDatabase.TabIndex = 0;
			this.lblSQLDatabase.Text = "Database";
			//
			//btnCloseSQL
			//
			this.btnCloseSQL.Enabled = false;
			this.btnCloseSQL.Location = new System.Drawing.Point(200, 192);
			this.btnCloseSQL.Name = "btnCloseSQL";
			this.btnCloseSQL.Size = new System.Drawing.Size(136, 24);
			this.btnCloseSQL.TabIndex = 9;
			this.btnCloseSQL.Text = "Close";
			//
			//lblPassword
			//
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(8, 64);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(54, 13);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "Password";
			//
			//cboDatabase
			//
			this.cboDatabase.DropDownWidth = 120;
			this.cboDatabase.Items.AddRange(new object[] { "Northwind", "pubs" });
			this.cboDatabase.Location = new System.Drawing.Point(72, 16);
			this.cboDatabase.Name = "cboDatabase";
			this.cboDatabase.Size = new System.Drawing.Size(120, 21);
			this.cboDatabase.TabIndex = 1;
			//
			//OpenNewConnection
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 261);
			this.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnCloseSQL, this.btnRelease, this.lblConStr, this.lblConnStr, this.btnOpenSQL, this.lblUserName, this.lblSQLDatabase, this.cboDatabase, this.chkEnablePooling, this.lblPassword, this.cboUsername, this.grpPooling, this.cboPassword });
			this.Name = "OpenNewConnection";
			this.Text = "OpenNewConnection";
			this.grpPooling.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
		#endregion
		
		private System.Data.SqlClient.SqlConnection cnSQLNorthwind;
		
		private void btnOpenSQL_Click (System.Object sender, System.EventArgs e)
		{
			string sConnStr;
			
			sConnStr = "Data Source=localhost;" + "Initial Catalog=" + cboDatabase.Text + ";" + "User ID=" + cboUsername.Text + ";" + "Password=" + cboPassword.Text + ";" + "Pooling=" +(chkEnablePooling.Checked).ToString() + ";" + "Min Pool Size=" + txtMinPoolSize.Text + ";" + "Max Pool Size=" + txtMaxPoolSize.Text + ";" + "Connection Reset=" +(chkResetConnection.Checked).ToString() + ";" + "Connection Lifetime=" + txtLifetime.Text + ";";
			
			cnSQLNorthwind = new System.Data.SqlClient.SqlConnection(sConnStr);
			
			try
			{
				cnSQLNorthwind.Open();
				
			}
			catch (System.Data.SqlClient.SqlException XcpSQL)
			{
				
				switch (XcpSQL.Number)
				{
					case 17:
						
						MessageBox.Show("Incorrect or missing server!");
						break;
					case 4060:
						
						MessageBox.Show("Wrong or missing database!");
						break;
					case 18456:
						
						MessageBox.Show("Incorrect or missing user name or password!");
						break;
					default:
						
						MessageBox.Show(XcpSQL.Message, "SQL Server Error " + XcpSQL.Number);
						break;
				}
				
			}
			catch (System.NullReferenceException XcpNullRef)
			{
				
				MessageBox.Show(XcpNullRef.Message);
				
			}
			catch (System.Exception Xcp) // unexpected exception
			{
				
				// generic exception handler
				
				MessageBox.Show(Xcp.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				
			}
			
			btnOpenSQL.Enabled = false;
			btnCloseSQL.Enabled = true;
			btnRelease.Enabled = true;
			
		}
		
		private void btnCloseSQL_Click (System.Object sender, System.EventArgs e)
		{
			
			// Close the connection to data source; exception occurs if object doesn't exist
			
			cnSQLNorthwind.Close();
			
			btnCloseSQL.Enabled = false;
			btnOpenSQL.Enabled = true;
			
		}
		
		private void btnRelease_Click (System.Object sender, System.EventArgs e)
		{
			
			// Call Dispose method to release resources used by object
			
			cnSQLNorthwind.Dispose();
			
			// Mark object as available to be released from memory; GC will remove
			// on next garbage collection cycle
			
			cnSQLNorthwind = null;
			
			//Close the current window
			
			this.Close();
			
		}
		
		private void chkEnablePooling_CheckedChanged (System.Object sender, System.EventArgs e)
		{
			
			// Only enable the Pooling group box if the check box is checked
			
			grpPooling.Enabled = chkEnablePooling.Checked;
			
		}
		
		private void UpdateConnStrLabel (object sender, System.EventArgs e)
		{
			
			lblConnStr.Text = "Data Source=localhost;" + "\r\n" + "Initial Catalog=" + cboDatabase.Text + ";" + "\r\n" + "User ID=" + cboUsername.Text + ";" + "\r\n" + "Password=" + cboPassword.Text + ";" + "\r\n" + "Pooling=" +(chkEnablePooling.Checked).ToString() + ";" + "\r\n" + "Min Pool Size=" + txtMinPoolSize.Text + ";" + "\r\n" + "Max Pool Size=" + txtMaxPoolSize.Text + ";" + "\r\n" + "Connection Reset=" +(chkResetConnection.Checked).ToString() + ";" + "\r\n" + "Connection Lifetime=" + txtLifetime.Text + ";";
			
		}
		
		private void OpenNewConnection_Load (System.Object sender, System.EventArgs e)
		{
			
			this.cboDatabase.Text = "Northwind";
			this.cboUsername.Text = "JohnK";
			this.cboPassword.Text = "JohnK";
			
		}
	}
	
}
