using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BuildingDataSets
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid grd;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuOpen;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.MenuItem mnuSaveAs;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem s2;
		private System.Windows.Forms.MenuItem s1;
		private System.Windows.Forms.MenuItem mnuView;
		private System.Windows.Forms.MenuItem mnuCustomer;
		private System.Windows.Forms.MenuItem mnuCartItems;
		private System.Windows.Forms.MenuItem mnuProducts;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Data.DataSet dsShoppingCart;
		private System.Data.DataTable dtCustomer;
		private System.Data.DataTable dtCartItems;
		private System.Data.DataColumn dcCustomerID;
		private System.Data.DataColumn dcCustomerID2;
		private System.Data.DataColumn dcProductID;
		private System.Data.DataColumn dcCompanyName;
		private System.Data.DataColumn dcAddress;
		private System.Data.DataColumn dcCity;
		private System.Data.DataColumn dcUnitPrice;
		private System.Data.DataColumn dcQuantity;
		private System.Data.DataColumn dcCost;
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
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			this.mnuCustomer = new System.Windows.Forms.MenuItem();
			this.dcCustomerID2 = new System.Data.DataColumn();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.s1 = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.mnuSaveAs = new System.Windows.Forms.MenuItem();
			this.s2 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuView = new System.Windows.Forms.MenuItem();
			this.mnuCartItems = new System.Windows.Forms.MenuItem();
			this.mnuProducts = new System.Windows.Forms.MenuItem();
			this.dtCustomer = new System.Data.DataTable();
			this.dcCustomerID = new System.Data.DataColumn();
			this.dcCompanyName = new System.Data.DataColumn();
			this.dcAddress = new System.Data.DataColumn();
			this.dcCity = new System.Data.DataColumn();
			this.dsShoppingCart = new System.Data.DataSet();
			this.dtCartItems = new System.Data.DataTable();
			this.dcProductID = new System.Data.DataColumn();
			this.dcUnitPrice = new System.Data.DataColumn();
			this.dcQuantity = new System.Data.DataColumn();
			this.dcCost = new System.Data.DataColumn();
			this.grd = new System.Windows.Forms.DataGrid();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dtCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsShoppingCart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtCartItems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
			this.SuspendLayout();
			// 
			// dlgSave
			// 
			this.dlgSave.DefaultExt = "ds";
			this.dlgSave.FileName = "doc1";
			this.dlgSave.Filter = "DataSet Files (*.ds)|*.ds|All Files (*.*)|*.*";
			// 
			// mnuCustomer
			// 
			this.mnuCustomer.Index = 0;
			this.mnuCustomer.Shortcut = System.Windows.Forms.Shortcut.F7;
			this.mnuCustomer.Text = "&Customer";
			// 
			// dcCustomerID2
			// 
			this.dcCustomerID2.AllowDBNull = false;
			this.dcCustomerID2.ColumnName = "CustomerID";
			this.dcCustomerID2.MaxLength = 5;
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuView});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuNew,
																					this.mnuOpen,
																					this.s1,
																					this.mnuSave,
																					this.mnuSaveAs,
																					this.s2,
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.mnuNew.Text = "&New";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Index = 1;
			this.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.mnuOpen.Text = "&Open...";
			// 
			// s1
			// 
			this.s1.Index = 2;
			this.s1.Text = "-";
			// 
			// mnuSave
			// 
			this.mnuSave.Index = 3;
			this.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mnuSave.Text = "&Save";
			// 
			// mnuSaveAs
			// 
			this.mnuSaveAs.Index = 4;
			this.mnuSaveAs.Text = "Save &As...";
			// 
			// s2
			// 
			this.s2.Index = 5;
			this.s2.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 6;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuView
			// 
			this.mnuView.Index = 1;
			this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuCustomer,
																					this.mnuCartItems,
																					this.mnuProducts});
			this.mnuView.Text = "&View";
			// 
			// mnuCartItems
			// 
			this.mnuCartItems.Index = 1;
			this.mnuCartItems.Shortcut = System.Windows.Forms.Shortcut.ShiftF7;
			this.mnuCartItems.Text = "Cart &Items";
			// 
			// mnuProducts
			// 
			this.mnuProducts.Index = 2;
			this.mnuProducts.Shortcut = System.Windows.Forms.Shortcut.CtrlF7;
			this.mnuProducts.Text = "&Products";
			// 
			// dtCustomer
			// 
			this.dtCustomer.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dcCustomerID,
																			  this.dcCompanyName,
																			  this.dcAddress,
																			  this.dcCity});
			this.dtCustomer.TableName = "Customer";
			// 
			// dcCustomerID
			// 
			this.dcCustomerID.AllowDBNull = false;
			this.dcCustomerID.ColumnName = "CustomerID";
			this.dcCustomerID.MaxLength = 5;
			// 
			// dcCompanyName
			// 
			this.dcCompanyName.AllowDBNull = false;
			this.dcCompanyName.ColumnName = "CompanyName";
			this.dcCompanyName.MaxLength = 40;
			// 
			// dcAddress
			// 
			this.dcAddress.ColumnName = "Address";
			this.dcAddress.MaxLength = 60;
			// 
			// dcCity
			// 
			this.dcCity.ColumnName = "City";
			this.dcCity.MaxLength = 15;
			// 
			// dsShoppingCart
			// 
			this.dsShoppingCart.DataSetName = "NewDataSet";
			this.dsShoppingCart.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsShoppingCart.Tables.AddRange(new System.Data.DataTable[] {
																				this.dtCustomer,
																				this.dtCartItems});
			// 
			// dtCartItems
			// 
			this.dtCartItems.Columns.AddRange(new System.Data.DataColumn[] {
																			   this.dcCustomerID2,
																			   this.dcProductID,
																			   this.dcUnitPrice,
																			   this.dcQuantity,
																			   this.dcCost});
			this.dtCartItems.TableName = "CartItems";
			// 
			// dcProductID
			// 
			this.dcProductID.AllowDBNull = false;
			this.dcProductID.ColumnName = "ProductID";
			this.dcProductID.DataType = typeof(int);
			// 
			// dcUnitPrice
			// 
			this.dcUnitPrice.AllowDBNull = false;
			this.dcUnitPrice.ColumnName = "UnitPrice";
			this.dcUnitPrice.DataType = typeof(System.Decimal);
			// 
			// dcQuantity
			// 
			this.dcQuantity.AllowDBNull = false;
			this.dcQuantity.ColumnName = "Quantity";
			this.dcQuantity.DataType = typeof(int);
			// 
			// dcCost
			// 
			this.dcCost.ColumnName = "Cost";
			this.dcCost.DataType = typeof(System.Decimal);
			this.dcCost.Expression = "UnitPrice * Quantity";
			this.dcCost.ReadOnly = true;
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
			// dlgOpen
			// 
			this.dlgOpen.Filter = "DataSet Files (*.ds)|*.ds|All Files (*.*)|*.*";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grd});
			this.Menu = this.mnuMain;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dtCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsShoppingCart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtCartItems)).EndInit();
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
			Application.Run(new Form1());
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
			this.Close();
		}
	}
}
