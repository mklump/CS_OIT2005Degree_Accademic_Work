using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ConnectingToDataSources
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox grpOleDb;
		private System.Windows.Forms.Label lblProvider;
		private System.Windows.Forms.TextBox txtProvider;
		private System.Windows.Forms.Label lblOleDbDatabase;
		private System.Windows.Forms.TextBox txtOleDbDatabase;
		private System.Windows.Forms.Button btnOpenOleDb;
		private System.Windows.Forms.Button btnCloseOleDb;
		private System.Windows.Forms.GroupBox grpSQLClient;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label lblSQLDatabase;
		private System.Windows.Forms.TextBox txtSQLDatabase;
		private System.Windows.Forms.Label lblTimeout;
		private System.Windows.Forms.TextBox txtTimeout;
		private System.Windows.Forms.CheckBox chkIntegratedSecurity;
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnOpenSQL;
		private System.Windows.Forms.Button btnCloseSQL;
		private System.Windows.Forms.Button btnExit;
		private System.Data.SqlClient.SqlConnection cnSQLNorthWind;
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
				if(components != null)
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
			this.txtOleDbDatabase = new System.Windows.Forms.TextBox();
			this.lblProvider = new System.Windows.Forms.Label();
			this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
			this.lblSQLDatabase = new System.Windows.Forms.Label();
			this.btnCloseOleDb = new System.Windows.Forms.Button();
			this.btnOpenSQL = new System.Windows.Forms.Button();
			this.txtSQLDatabase = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblOleDbDatabase = new System.Windows.Forms.Label();
			this.grpOleDb = new System.Windows.Forms.GroupBox();
			this.btnOpenOleDb = new System.Windows.Forms.Button();
			this.txtProvider = new System.Windows.Forms.TextBox();
			this.txtTimeout = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblServer = new System.Windows.Forms.Label();
			this.btnCloseSQL = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.lblTimeout = new System.Windows.Forms.Label();
			this.grpSQLClient = new System.Windows.Forms.GroupBox();
			this.cnSQLNorthWind = new System.Data.SqlClient.SqlConnection();
			this.grpOleDb.SuspendLayout();
			this.grpSQLClient.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtOleDbDatabase
			// 
			this.txtOleDbDatabase.Location = new System.Drawing.Point(64, 48);
			this.txtOleDbDatabase.Name = "txtOleDbDatabase";
			this.txtOleDbDatabase.Size = new System.Drawing.Size(320, 20);
			this.txtOleDbDatabase.TabIndex = 3;
			this.txtOleDbDatabase.Text = "\\Program Files\\Microsoft Office\\Office10\\Samples\\Northwind.mdb";
			// 
			// lblProvider
			// 
			this.lblProvider.Location = new System.Drawing.Point(8, 24);
			this.lblProvider.Name = "lblProvider";
			this.lblProvider.Size = new System.Drawing.Size(64, 16);
			this.lblProvider.TabIndex = 0;
			this.lblProvider.Text = "Provider";
			// 
			// chkIntegratedSecurity
			// 
			this.chkIntegratedSecurity.Location = new System.Drawing.Point(200, 24);
			this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
			this.chkIntegratedSecurity.Size = new System.Drawing.Size(128, 16);
			this.chkIntegratedSecurity.TabIndex = 8;
			this.chkIntegratedSecurity.Text = "Integrated Security";
			this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkIntegratedSecurity_CheckedChanged);
			// 
			// lblSQLDatabase
			// 
			this.lblSQLDatabase.AutoSize = true;
			this.lblSQLDatabase.Location = new System.Drawing.Point(8, 48);
			this.lblSQLDatabase.Name = "lblSQLDatabase";
			this.lblSQLDatabase.Size = new System.Drawing.Size(53, 16);
			this.lblSQLDatabase.TabIndex = 2;
			this.lblSQLDatabase.Text = "Database";
			// 
			// btnCloseOleDb
			// 
			this.btnCloseOleDb.Location = new System.Drawing.Point(304, 80);
			this.btnCloseOleDb.Name = "btnCloseOleDb";
			this.btnCloseOleDb.TabIndex = 1;
			this.btnCloseOleDb.Text = "Close";
			this.btnCloseOleDb.Click += new System.EventHandler(this.btnCloseOleDb_Click);
			// 
			// btnOpenSQL
			// 
			this.btnOpenSQL.Location = new System.Drawing.Point(224, 104);
			this.btnOpenSQL.Name = "btnOpenSQL";
			this.btnOpenSQL.TabIndex = 2;
			this.btnOpenSQL.Text = "Open";
			this.btnOpenSQL.Click += new System.EventHandler(this.btnOpenSQL_Click);
			// 
			// txtSQLDatabase
			// 
			this.txtSQLDatabase.Location = new System.Drawing.Point(64, 48);
			this.txtSQLDatabase.Name = "txtSQLDatabase";
			this.txtSQLDatabase.Size = new System.Drawing.Size(120, 20);
			this.txtSQLDatabase.TabIndex = 3;
			this.txtSQLDatabase.Text = "Northwind";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(264, 72);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(120, 20);
			this.txtPassword.TabIndex = 7;
			this.txtPassword.Text = "";
			// 
			// lblOleDbDatabase
			// 
			this.lblOleDbDatabase.Location = new System.Drawing.Point(8, 48);
			this.lblOleDbDatabase.Name = "lblOleDbDatabase";
			this.lblOleDbDatabase.Size = new System.Drawing.Size(56, 16);
			this.lblOleDbDatabase.TabIndex = 2;
			this.lblOleDbDatabase.Text = "Database";
			// 
			// grpOleDb
			// 
			this.grpOleDb.Controls.Add(this.btnCloseOleDb);
			this.grpOleDb.Controls.Add(this.btnOpenOleDb);
			this.grpOleDb.Controls.Add(this.txtOleDbDatabase);
			this.grpOleDb.Controls.Add(this.lblOleDbDatabase);
			this.grpOleDb.Controls.Add(this.txtProvider);
			this.grpOleDb.Controls.Add(this.lblProvider);
			this.grpOleDb.Location = new System.Drawing.Point(8, 152);
			this.grpOleDb.Name = "grpOleDb";
			this.grpOleDb.Size = new System.Drawing.Size(392, 112);
			this.grpOleDb.TabIndex = 4;
			this.grpOleDb.TabStop = false;
			this.grpOleDb.Text = "Exercise 4: Connecting to an OLE DB data source";
			// 
			// btnOpenOleDb
			// 
			this.btnOpenOleDb.Location = new System.Drawing.Point(224, 80);
			this.btnOpenOleDb.Name = "btnOpenOleDb";
			this.btnOpenOleDb.TabIndex = 0;
			this.btnOpenOleDb.Text = "Open";
			// 
			// txtProvider
			// 
			this.txtProvider.Location = new System.Drawing.Point(64, 24);
			this.txtProvider.Name = "txtProvider";
			this.txtProvider.Size = new System.Drawing.Size(320, 20);
			this.txtProvider.TabIndex = 1;
			this.txtProvider.Text = "Microsoft.Jet.OLEDB.4.0";
			// 
			// txtTimeout
			// 
			this.txtTimeout.Location = new System.Drawing.Point(64, 72);
			this.txtTimeout.Name = "txtTimeout";
			this.txtTimeout.Size = new System.Drawing.Size(120, 20);
			this.txtTimeout.TabIndex = 10;
			this.txtTimeout.Text = "15";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(200, 72);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(54, 16);
			this.lblPassword.TabIndex = 6;
			this.lblPassword.Text = "Password";
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(200, 48);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(61, 16);
			this.lblUserName.TabIndex = 4;
			this.lblUserName.Text = "User Name";
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(8, 24);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(38, 16);
			this.lblServer.TabIndex = 0;
			this.lblServer.Text = "Server";
			// 
			// btnCloseSQL
			// 
			this.btnCloseSQL.Location = new System.Drawing.Point(304, 104);
			this.btnCloseSQL.Name = "btnCloseSQL";
			this.btnCloseSQL.TabIndex = 3;
			this.btnCloseSQL.Text = "Close";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(312, 280);
			this.btnExit.Name = "btnExit";
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(264, 48);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(120, 20);
			this.txtUsername.TabIndex = 5;
			this.txtUsername.Text = "sa";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(64, 24);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(120, 20);
			this.txtServer.TabIndex = 1;
			this.txtServer.Text = "localhost";
			// 
			// lblTimeout
			// 
			this.lblTimeout.AutoSize = true;
			this.lblTimeout.Location = new System.Drawing.Point(8, 72);
			this.lblTimeout.Name = "lblTimeout";
			this.lblTimeout.Size = new System.Drawing.Size(45, 16);
			this.lblTimeout.TabIndex = 9;
			this.lblTimeout.Text = "Timeout";
			// 
			// grpSQLClient
			// 
			this.grpSQLClient.Controls.Add(this.btnCloseSQL);
			this.grpSQLClient.Controls.Add(this.btnOpenSQL);
			this.grpSQLClient.Controls.Add(this.txtPassword);
			this.grpSQLClient.Controls.Add(this.lblPassword);
			this.grpSQLClient.Controls.Add(this.txtUsername);
			this.grpSQLClient.Controls.Add(this.lblUserName);
			this.grpSQLClient.Controls.Add(this.chkIntegratedSecurity);
			this.grpSQLClient.Controls.Add(this.txtTimeout);
			this.grpSQLClient.Controls.Add(this.lblTimeout);
			this.grpSQLClient.Controls.Add(this.txtSQLDatabase);
			this.grpSQLClient.Controls.Add(this.lblSQLDatabase);
			this.grpSQLClient.Controls.Add(this.txtServer);
			this.grpSQLClient.Controls.Add(this.lblServer);
			this.grpSQLClient.Location = new System.Drawing.Point(8, 8);
			this.grpSQLClient.Name = "grpSQLClient";
			this.grpSQLClient.Size = new System.Drawing.Size(392, 136);
			this.grpSQLClient.TabIndex = 5;
			this.grpSQLClient.TabStop = false;
			this.grpSQLClient.Text = "Exercises 1 and 2: Connecting to a SQL Server data source";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 317);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.grpSQLClient);
			this.Controls.Add(this.grpOleDb);
			this.Name = "Form1";
			this.Text = "Form1";
			this.grpOleDb.ResumeLayout(false);
			this.grpSQLClient.ResumeLayout(false);
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

		private void chkIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
		{

			// disable the username and password text boxes when 
			// integrated security is checked

			this.txtUsername.Enabled = !this.chkIntegratedSecurity.Checked;
			this.txtPassword.Enabled = !this.chkIntegratedSecurity.Checked;

		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{

			// dispose and close the form

			this.Dispose();
			this.Close();

		}

		private void btnOpenSQL_Click(object sender, System.EventArgs e)
		{
			cnSQLNorthWind.ConnectionString =
				"Data Source=" + this.txtServer.Text + ";" +
				"Initial Catalog=" + this.txtSQLDatabase.Text + ";" +
				"Integrated Security=" + this.chkIntegratedSecurity.Checked.ToString() + ";" +
				"User ID=" + this.txtUsername.Text + ";" +
				"Password=" + this.txtPassword.Text + ";" +
				"Connection Timeout=" + this.txtTimeout.Text + ";";

			cnSQLNorthWind.Open();
		}

		private void btnCloseOleDb_Click(object sender, System.EventArgs e)
		{
			cnSQLNorthWind.Close();
			cnSQLNorthWind.Dispose();
		}
	}
}