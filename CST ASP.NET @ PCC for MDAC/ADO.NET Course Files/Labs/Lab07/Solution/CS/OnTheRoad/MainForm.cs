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
		internal System.Int32 EmployeeID = 0;
		internal System.String ServerName = "(local)";
		
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
		internal OnTheRoad.localhost.NWDataSet dsNorthwind;
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
			this.s2 = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.mnuUpdate = new System.Windows.Forms.MenuItem();
			this.mnuFill = new System.Windows.Forms.MenuItem();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.dsNorthwind = new OnTheRoad.localhost.NWDataSet();
			this.mnuTools = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.grd = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dsNorthwind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
			this.SuspendLayout();
			// 
			// s2
			// 
			this.s2.Index = 2;
			this.s2.Text = "-";
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
			// mnuUpdate
			// 
			this.mnuUpdate.Index = 1;
			this.mnuUpdate.Text = "&Update to central database";
			this.mnuUpdate.Click += new System.EventHandler(this.mnuUpdate_Click);
			// 
			// mnuFill
			// 
			this.mnuFill.Index = 0;
			this.mnuFill.Text = "&Get from central database...";
			this.mnuFill.Click += new System.EventHandler(this.mnuFill_Click);
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
			// mnuExit
			// 
			this.mnuExit.Index = 3;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// dsNorthwind
			// 
			this.dsNorthwind.DataSetName = "NWDataSet";
			this.dsNorthwind.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsNorthwind.Namespace = "http://www.tempuri.org/NWDataSet.xsd";
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
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuTools,
																					this.mnuHelp});
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
			((System.ComponentModel.ISupportInitialize)(this.dsNorthwind)).EndInit();
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
			Options frmOptions = new Options();

			// TODO: display last selected server
			frmOptions.txtServer.Text = this.ServerName;

			// if user selects OK, change employee and load related data
			if (frmOptions.ShowDialog(this) == DialogResult.OK)
			{
				// TODO: retrieve server name entered in the text box
				this.ServerName = frmOptions.txtServer.Text;
			}
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
	        // TODO: try to read data set from local disk

			try // to open existing local cached DataSet
			{
				this.dsNorthwind.ReadXml("OnTheRoad.xml", XmlReadMode.DiffGram);

				// TODO: retrieve default values for EmployeeID and ServerName if found
				this.EmployeeID = 
					(int)(this.dsNorthwind.AppSettings.Rows[0]["EmployeeID"]);

				this.ServerName = 
					this.dsNorthwind.AppSettings.Rows[0]["ServerName"].ToString();

				this.RefreshUI();
			}
			catch
			{
				// TODO: if local file not found try to connect to central database and retrieve latest data set
				if (MessageBox.Show("An existing data set was not found or was corrupt. Do you want to connect to the central database to retrieve a new copy?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					try
					{
						// TODO: connect to the web service
						OnTheRoad.localhost.SalesManager wsSalesMgr;
						wsSalesMgr = new OnTheRoad.localhost.SalesManager();
					}
					catch (System.Exception Xcp)
					{
						MessageBox.Show("Failed to connect because:\n" + Xcp.ToString() + "\n\nUse Tools, Options to change the name of the SQL Server you are trying to connect to.", "Connect to central database", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
	                mnuFill_Click(sender, e);
				}
			}
		}

		private void ResetAppSettings()
		{

			// TODO: store default values in AppSettings table

			// clear any existing rows
			this.dsNorthwind.AppSettings.Clear();

			// insert a new blank row
			this.dsNorthwind.AppSettings.AddAppSettingsRow(this.EmployeeID, this.ServerName);

			// accept the changes to the table (we do not need to track)
			this.dsNorthwind.AppSettings.AcceptChanges();

		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.ResetAppSettings();
			
			// save as local cache
			this.dsNorthwind.WriteXml("OnTheRoad.xml", XmlWriteMode.DiffGram);
		}	

		private void mnuFill_Click(object sender, System.EventArgs e)
		{
			// TODO: instantiate the data set
			OnTheRoad.localhost.NWDataSet tempNW = 
				new OnTheRoad.localhost.NWDataSet();

			// TODO: instantiate the web service
			OnTheRoad.localhost.SalesManager wsSalesMgr = 
				new OnTheRoad.localhost.SalesManager();

			wsSalesMgr.Credentials = System.Net.CredentialCache.DefaultCredentials;

			try
			{
				// TODO: connect to web service
				tempNW = wsSalesMgr.GetDataSet(this.EmployeeID, this.ServerName);
			}
			catch (System.Exception Xcp)
			{
				MessageBox.Show("Failed to connect because:\n" + Xcp.ToString() + "\n\nTry a different web service name.", "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// create instance of logon form
			Logon frmLogon = new Logon();

			// TODO: set the data properties to link the list box to the Employees table
			frmLogon.lstEmployees.DataSource = tempNW.Employees;
			frmLogon.lstEmployees.DisplayMember = "FullName";
			frmLogon.lstEmployees.ValueMember = "EmployeeID";

			// TODO: display the last selected employee
			frmLogon.lstEmployees.SelectedValue = this.EmployeeID;

			// if user selects OK...
			if (frmLogon.ShowDialog(this) == DialogResult.OK)
			{
				// TODO: change employee and load related data
				this.EmployeeID = (int)frmLogon.lstEmployees.SelectedValue;

				try
				{
					tempNW = wsSalesMgr.GetDataSet(this.EmployeeID, this.ServerName);

					this.dsNorthwind = tempNW;

					this.RefreshUI();
				}
				catch (System.Exception Xcp)
				{
					MessageBox.Show("Failed to retrieve data because:\n" + Xcp.ToString() + "\n\nTry a different server name.", "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void RefreshUI()
		{
			// TODO: refresh the title bar of the form to show the current employee
			this.Text = dsNorthwind.Employees.Select("EmployeeID=" + this.EmployeeID)[0]["FullName"].ToString() +
				" - " + Application.ProductName;

			// TODO: bind grid to customers table in the data set
			this.grd.SetDataBinding(this.dsNorthwind, "Customers");
		}

		private void mnuUpdate_Click(object sender, System.EventArgs e)
		{
			// TODO: update the central database
			OnTheRoad.localhost.SalesManager wsSalesMgr = 
				new OnTheRoad.localhost.SalesManager();

			wsSalesMgr.Credentials = System.Net.CredentialCache.DefaultCredentials;

			try // to send the changes to the web service
			{
				// get the changes
				System.Data.DataSet dsChanges = this.dsNorthwind.GetChanges();

				if(dsChanges == null)
				{
					MessageBox.Show("There are no changes to update!", "Update to central database", 
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					this.ResetAppSettings();
					
					// add the app settings to the data set to pass the server name
					dsChanges.Merge(this.dsNorthwind.AppSettings);

					// call the web services update method
					wsSalesMgr.UpdateDatabase( (OnTheRoad.localhost.NWDataSet)dsChanges );

					// mark the changes as having been made
					this.dsNorthwind.AcceptChanges();

					if (MessageBox.Show("Do you want to refresh your local copy of data?", 
						"Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						// simulate clicking the Fill menu item
						mnuFill_Click(sender, e);
					}
				}
			}
			catch (System.Exception Xcp)
			{
				MessageBox.Show(Xcp.ToString());
				return;
			}
		}
	}
}
