using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OnTheRoad
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		// TODO: declare fields for EmployeeID and ServerName

		
		internal System.Windows.Forms.MainMenu mnuMain;
		internal System.Windows.Forms.MenuItem mnuFile;
		internal System.Windows.Forms.MenuItem mnuTools;
		internal System.Windows.Forms.MenuItem mnuHelp;
		internal System.Windows.Forms.MenuItem mnuFill;
		internal System.Windows.Forms.MenuItem mnuUpdate;
		internal System.Windows.Forms.MenuItem s2;
		internal System.Windows.Forms.MenuItem mnuExit;
		internal System.Windows.Forms.MenuItem mnuOptions;
		internal System.Windows.Forms.MenuItem mnuAbout;
		internal System.Windows.Forms.DataGrid grd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
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
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuFill = new System.Windows.Forms.MenuItem();
			this.mnuUpdate = new System.Windows.Forms.MenuItem();
			this.s2 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuTools = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.grd = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuTools,
																					this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFill,
																					this.mnuUpdate,
																					this.s2,
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuFill
			// 
			this.mnuFill.Index = 0;
			this.mnuFill.Text = "&Get from central database...";
			this.mnuFill.Click += new System.EventHandler(this.mnuFill_Click);
			// 
			// mnuUpdate
			// 
			this.mnuUpdate.Index = 1;
			this.mnuUpdate.Text = "&Update to central database";
			this.mnuUpdate.Click += new System.EventHandler(this.mnuUpdate_Click);
			// 
			// s2
			// 
			this.s2.Index = 2;
			this.s2.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 3;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuTools
			// 
			this.mnuTools.Index = 1;
			this.mnuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuOptions});
			this.mnuTools.Text = "&Tools";
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 0;
			this.mnuOptions.Text = "&Options...";
			this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 0;
			this.mnuAbout.Text = "&About...";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// grd
			// 
			this.grd.DataMember = "";
			this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grd.Name = "grd";
			this.grd.Size = new System.Drawing.Size(292, 273);
			this.grd.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grd});
			this.Menu = this.mnuMain;
			this.Name = "MainForm";
			this.Text = "On The Road";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			About frmAbout = new About();
			frmAbout.ShowDialog(this);
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void mnuOptions_Click(object sender, System.EventArgs e)
		{
			// TODO: create instance of Options form

			// TODO: display last selected server

			// TODO: show dialog box, and test if user selects OK...

				// TODO: retrieve server name entered in the text box

				// TODO: set connection string using new server name


		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// TODO: try to read data set from local disk

			// TODO: retrieve default values for EmployeeID and ServerName if found

			// TODO: if local file not found try to connect to central database and retrieve latest data set

		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// TODO: store default values in AppSettings table

			// TODO: save data set to disk

		}	

		private void mnuFill_Click(object sender, System.EventArgs e)
		{

			// TODO: instantiate the data set

			// TODO: create instance of logon form

			// TODO: set the data properties to link the list box to the Employees table

			// TODO: display the last selected employee

			// TODO: show dialog box, and test if user selects OK...

				// TODO: change employee and load related data

			// TODO: close datebase connection

		}

		private void RefreshUI()
		{
			// TODO: refresh the title bar of the form to show the current employee

			// TODO: bind grid to customers table in the data set

		}

		private void mnuUpdate_Click(object sender, System.EventArgs e)
		{
			// TODO: update the central database

		}
	}
}
