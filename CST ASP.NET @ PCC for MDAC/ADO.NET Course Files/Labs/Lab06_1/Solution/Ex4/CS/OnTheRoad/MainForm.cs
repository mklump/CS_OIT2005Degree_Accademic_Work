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
		private System.Data.SqlClient.SqlDataAdapter daEmployees;
		private System.Data.SqlClient.SqlCommand cmSelectEmployees;
		private System.Data.SqlClient.SqlConnection cnNorthwind;
		private OnTheRoad.NWDataSet dsNorthwind;
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
			this.daEmployees = new System.Data.SqlClient.SqlDataAdapter();
			this.cmSelectEmployees = new System.Data.SqlClient.SqlCommand();
			this.cnNorthwind = new System.Data.SqlClient.SqlConnection();
			this.dsNorthwind = new OnTheRoad.NWDataSet();
			((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsNorthwind)).BeginInit();
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
			this.grd.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grd.Name = "grd";
			this.grd.Size = new System.Drawing.Size(292, 273);
			this.grd.TabIndex = 0;
			// 
			// daEmployees
			// 
			this.daEmployees.SelectCommand = this.cmSelectEmployees;
			this.daEmployees.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Employees", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"),
																																																			   new System.Data.Common.DataColumnMapping("FullName", "FullName")})});
			// 
			// cmSelectEmployees
			// 
			this.cmSelectEmployees.CommandText = "SELECT EmployeeID, LastName + \', \' + FirstName AS FullName FROM Employees ORDER B" +
				"Y LastName, FirstName";
			this.cmSelectEmployees.Connection = this.cnNorthwind;
			// 
			// cnNorthwind
			// 
			this.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" +
				"curity info=False;";
			// 
			// dsNorthwind
			// 
			this.dsNorthwind.DataSetName = "NWDataSet";
			this.dsNorthwind.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsNorthwind.Namespace = "http://www.tempuri.org/NWDataSet.xsd";
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
			((System.ComponentModel.ISupportInitialize)(this.dsNorthwind)).EndInit();
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

			// display last selected server
			frmOptions.txtServer.Text = this.ServerName;

			// if user selects OK, change employee and load related data
			if (frmOptions.ShowDialog(this) == DialogResult.OK)
			{
				// retrieve server name entered in the text box
				this.ServerName = frmOptions.txtServer.Text;

				// set connection string using new server name
				this.cnNorthwind.ConnectionString = 
					"data source=" + this.ServerName + ";" +
					"initial catalog=Northwind;" +
					"integrated security=SSPI;" +
					"persist security info=False;";
			}
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// try to open existing local cached DataSet
			try	
			{
				this.dsNorthwind.ReadXml("OnTheRoad.xml", XmlReadMode.DiffGram);

				// retrieve default values for EmployeeID and ServerName if found
				this.EmployeeID = (int)this.dsNorthwind.AppSettings.Rows[0]["EmployeeID"];

				this.ServerName = this.dsNorthwind.AppSettings.Rows[0]["ServerName"].ToString();

				this.RefreshUI();
			}
			catch
			{
				// if local file not found try to connect to central database and retrieve latest data set
				if (MessageBox.Show("An existing data set was not found or was corrupt. Do you want to connect to the central database to retrieve a new copy?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					try
					{
						this.cnNorthwind.Open();
						mnuFill_Click(sender, e);
					}
					catch (System.Exception Xcp)
					{
						MessageBox.Show("Failed to connect because:\n" + Xcp.ToString() + "\n\nUse Tools, Options to change the name of the SQL Server you are trying to connect to.", "Connect to central database", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// clear any existing rows 
			this.dsNorthwind.AppSettings.Clear();

			// insert a new blank row
			this.dsNorthwind.AppSettings.AddAppSettingsRow(this.EmployeeID, this.ServerName);

			// accept changes because we do not need to track
			this.dsNorthwind.AppSettings.AcceptChanges();

			// save as local cache
			this.dsNorthwind.WriteXml("OnTheRoad.xml", XmlWriteMode.DiffGram);
		}	

		private void mnuFill_Click(object sender, System.EventArgs e)
		{

			// instantiate the data set
			OnTheRoad.NWDataSet tempNW = new OnTheRoad.NWDataSet();

			if (this.cnNorthwind.State != ConnectionState.Open)
			{
				try
				{
					this.cnNorthwind.Open();
				}
				catch (System.Exception Xcp)
				{
					MessageBox.Show("Failed to connect because:\n" + Xcp.ToString() + "\n\nTry a different server name.", "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			try
			{
				// fill the Employees DataTable
				this.daEmployees.Fill(tempNW.Employees);
			}
			catch (System.Exception Xcp)
			{
				MessageBox.Show("Failed to retrieve employee list because:\n" + Xcp.ToString(), "Get from central database", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


			// create instance of logon form
			Logon frmLogon = new Logon();


			// set the data properties to link the list box to the Employees table
			frmLogon.lstEmployees.DataSource = tempNW.Employees;
			frmLogon.lstEmployees.DisplayMember = "FullName";
			frmLogon.lstEmployees.ValueMember = "EmployeeID";

			// display the last selected employee
			frmLogon.lstEmployees.SelectedValue = this.EmployeeID;

			// if user selects OK...
			if (frmLogon.ShowDialog(this) == DialogResult.OK)
			{
				// change employee and load related data
				this.EmployeeID = (int)frmLogon.lstEmployees.SelectedValue;

				this.dsNorthwind = tempNW;
				this.RefreshUI();
			}
			this.cnNorthwind.Close();
		}

		private void RefreshUI()
		{
			// refresh the title bar of the form to show the current employee

			this.Text = dsNorthwind.Employees.Select("EmployeeID=" + this.EmployeeID)[0]["FullName"].ToString()
				+ " - " 
				+ Application.ProductName;

			// TODO: bind grid to customers table in the data set

		}

		private void mnuUpdate_Click(object sender, System.EventArgs e)
		{
			// TODO: update the central database

		}
	}
}
