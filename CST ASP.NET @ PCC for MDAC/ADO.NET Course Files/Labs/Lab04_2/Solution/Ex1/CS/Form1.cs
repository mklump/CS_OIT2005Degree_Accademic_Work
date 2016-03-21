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
		public System.String Filename;

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
			this.dcAddress = new System.Data.DataColumn();
			this.s1 = new System.Windows.Forms.MenuItem();
			this.dtCartItems = new System.Data.DataTable();
			this.dcCustomerID2 = new System.Data.DataColumn();
			this.dcProductID = new System.Data.DataColumn();
			this.dcUnitPrice = new System.Data.DataColumn();
			this.dcQuantity = new System.Data.DataColumn();
			this.dcCost = new System.Data.DataColumn();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.s2 = new System.Windows.Forms.MenuItem();
			this.mnuSaveAs = new System.Windows.Forms.MenuItem();
			this.dtCustomer = new System.Data.DataTable();
			this.dcCustomerID = new System.Data.DataColumn();
			this.dcCompanyName = new System.Data.DataColumn();
			this.dcCity = new System.Data.DataColumn();
			this.mnuProducts = new System.Windows.Forms.MenuItem();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.mnuCartItems = new System.Windows.Forms.MenuItem();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.mnuView = new System.Windows.Forms.MenuItem();
			this.mnuCustomer = new System.Windows.Forms.MenuItem();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.dsShoppingCart = new System.Data.DataSet();
			this.grd = new System.Windows.Forms.DataGrid();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dtCartItems)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsShoppingCart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
			this.SuspendLayout();
			// 
			// dcAddress
			// 
			this.dcAddress.ColumnName = "Address";
			this.dcAddress.MaxLength = 60;
			// 
			// s1
			// 
			this.s1.Index = 2;
			this.s1.Text = "-";
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
			// dcCustomerID2
			// 
			this.dcCustomerID2.AllowDBNull = false;
			this.dcCustomerID2.ColumnName = "CustomerID";
			this.dcCustomerID2.MaxLength = 5;
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
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.mnuNew.Text = "&New";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// s2
			// 
			this.s2.Index = 5;
			this.s2.Text = "-";
			// 
			// mnuSaveAs
			// 
			this.mnuSaveAs.Index = 4;
			this.mnuSaveAs.Text = "Save &As...";
			this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
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
			// dcCity
			// 
			this.dcCity.ColumnName = "City";
			this.dcCity.MaxLength = 15;
			// 
			// mnuProducts
			// 
			this.mnuProducts.Index = 2;
			this.mnuProducts.Shortcut = System.Windows.Forms.Shortcut.CtrlF7;
			this.mnuProducts.Text = "&Products";
			// 
			// mnuOpen
			// 
			this.mnuOpen.Index = 1;
			this.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.mnuOpen.Text = "&Open...";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// mnuCartItems
			// 
			this.mnuCartItems.Index = 1;
			this.mnuCartItems.Shortcut = System.Windows.Forms.Shortcut.ShiftF7;
			this.mnuCartItems.Text = "Cart &Items";
			this.mnuCartItems.Click += new System.EventHandler(this.mnuCartItems_Click);
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "DataSet Files (*.ds)|*.ds|All Files (*.*)|*.*";
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
			// mnuCustomer
			// 
			this.mnuCustomer.Index = 0;
			this.mnuCustomer.Shortcut = System.Windows.Forms.Shortcut.F7;
			this.mnuCustomer.Text = "&Customer";
			this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
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
			// mnuSave
			// 
			this.mnuSave.Index = 3;
			this.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mnuSave.Text = "&Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 6;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// dsShoppingCart
			// 
			this.dsShoppingCart.DataSetName = "NewDataSet";
			this.dsShoppingCart.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsShoppingCart.Tables.AddRange(new System.Data.DataTable[] {
																				this.dtCustomer,
																				this.dtCartItems});
			// 
			// grd
			// 
			this.grd.DataMember = "";
			this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grd.Name = "grd";
			this.grd.Size = new System.Drawing.Size(292, 273);
			this.grd.TabIndex = 0;
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuView});
			// 
			// dlgSave
			// 
			this.dlgSave.DefaultExt = "ds";
			this.dlgSave.FileName = "doc1";
			this.dlgSave.Filter = "DataSet Files (*.ds)|*.ds|All Files (*.*)|*.*";
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
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtCartItems)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsShoppingCart)).EndInit();
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

		public void OpenFromFile()
		{
			try
			{
				this.dsShoppingCart.Tables["CartItems"].Clear();
				this.dsShoppingCart.Tables["Customer"].Clear();
				this.dsShoppingCart.ReadXml(this.Filename);
			}
			catch (System.Exception Xcp)
			{
				MessageBox.Show(Xcp.ToString(),
					"Failed to open: " + this.Filename,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void SaveToFile()
		{
			try
			{
				this.dsShoppingCart.WriteXml(this.Filename);
			}
			catch(System.Exception Xcp)
			{
				MessageBox.Show(Xcp.ToString(),
					"Failed to open: " + this.Filename,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void SetFormCaption()
		{
			this.Text = this.Filename + 
				" - Shopping Cart : Test WinApp";
		}

		private void mnuCustomer_Click(object sender, System.EventArgs e)
		{
			this.grd.DataSource = new DataView(
				this.dsShoppingCart.Tables["Customer"]);

			this.mnuCustomer.Checked = true;
			this.mnuCartItems.Checked = false;
		}

		private void mnuCartItems_Click(object sender, System.EventArgs e)
		{
			this.grd.DataSource = new DataView(
				this.dsShoppingCart.Tables["CartItems"]);

			this.mnuCustomer.Checked = false;
			this.mnuCartItems.Checked = true;
		}

		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			this.dsShoppingCart.Tables["CartItems"].Clear();
			this.dsShoppingCart.Tables["Customer"].Clear();
			this.Filename = "ShoppingCart1.ds";
			this.SetFormCaption();
			this.mnuCustomer_Click(sender, e);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.mnuNew_Click(sender, e);
			
			this.dtCustomer.Constraints.Add("PK_Customer",
				this.dtCustomer.Columns["CustomerID"], true);

			this.dsShoppingCart.Relations.Add("FK_Customer_CartItems",
				this.dtCustomer.Columns["CustomerID"],
				this.dtCartItems.Columns["CustomerID"], true);
		}

		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
			if (this.dlgOpen.ShowDialog() == DialogResult.OK)
			{
				this.Filename = this.dlgOpen.FileName;
				this.OpenFromFile();
				this.SetFormCaption();
				this.mnuCustomer_Click(sender, e);
			}
		}

		private void mnuSaveAs_Click(object sender, System.EventArgs e)
		{
			if (this.dlgSave.ShowDialog() == DialogResult.OK)
			{
				this.Filename = this.dlgSave.FileName;
				this.SaveToFile();
				this.SetFormCaption();
			}
		}

		private void mnuSave_Click(object sender, System.EventArgs e)
		{
			this.SaveToFile();
		}
	}
}
