using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Microsoft.VisualBasic;

namespace BuildingDataSets
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : Form
	{
		private DataGrid grd;
		private OpenFileDialog dlgOpen;
		private SaveFileDialog dlgSave;
		private MenuItem mnuFile;
		private MenuItem mnuNew;
		private MenuItem mnuOpen;
		private MenuItem mnuSave;
		private MenuItem mnuSaveAs;
		private MenuItem mnuExit;
		private MenuItem s2;
		private MenuItem s1;
		private MenuItem mnuView;
		private MenuItem mnuCustomer;
		private MenuItem mnuCartItems;
		private MenuItem mnuProducts;
		private MainMenu mnuMain;

		private DataColumn dcCustomerID;
		private DataColumn dcCustomerID2;
		private DataColumn dcProductID;
		private DataColumn dcCompanyName;
		private DataColumn dcAddress;
		private DataColumn dcCity;
		private DataColumn dcUnitPrice;
		private DataColumn dcQuantity;
		private DataColumn dcCost;

        private DataSet dsCatProd;
		private DataSet dsShoppingCart;
		private DataTable dtCustomer;
		private DataTable dtCartItems;

		private static string filename;
        private MenuItem mnuSubtotal;
        private MenuItem mnuEdit;
        private MenuItem mnuAddToCart;
        private MenuItem menuItem2;
        private MenuItem menuItem1;
        private MenuItem mnuDiscontinued;
        private MenuItem mnuOutOfStock;
        private IContainer components;
		/// <summary>
		/// Property Filename (string)
		/// </summary>
		public string Filename
		{
			get { return filename; }
			set { filename = value; }
        }

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
            this.components = new System.ComponentModel.Container();
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
            this.mnuSubtotal = new System.Windows.Forms.MenuItem();
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuSave = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.dsShoppingCart = new System.Data.DataSet();
            this.grd = new System.Windows.Forms.DataGrid();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuAddToCart = new System.Windows.Forms.MenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.mnuDiscontinued = new System.Windows.Forms.MenuItem();
            this.mnuOutOfStock = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
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
            this.dcUnitPrice.DataType = typeof(decimal);
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
            this.dcCost.DataType = typeof(decimal);
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
            this.mnuProducts.Click += new System.EventHandler(this.mnuProducts_Click);
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
            this.mnuProducts,
            this.menuItem2,
            this.mnuSubtotal,
            this.menuItem1,
            this.mnuDiscontinued,
            this.mnuOutOfStock});
            this.mnuView.Text = "&View";
            this.mnuView.Select += new System.EventHandler(this.mnuView_Select);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Index = 0;
            this.mnuCustomer.Shortcut = System.Windows.Forms.Shortcut.F7;
            this.mnuCustomer.Text = "&Customer";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuSubtotal
            // 
            this.mnuSubtotal.Index = 4;
            this.mnuSubtotal.Shortcut = System.Windows.Forms.Shortcut.F9;
            this.mnuSubtotal.Text = "Cart &Subtotal";
            this.mnuSubtotal.Click += new System.EventHandler(this.mnuSubtotal_Click);
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
            this.grd.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(292, 273);
            this.grd.TabIndex = 0;
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuEdit});
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 2;
            this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAddToCart});
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.Select += new System.EventHandler(this.mnuEdit_Select);
            // 
            // mnuAddToCart
            // 
            this.mnuAddToCart.Index = 0;
            this.mnuAddToCart.Shortcut = System.Windows.Forms.Shortcut.Ins;
            this.mnuAddToCart.Text = "&Add To Cart";
            this.mnuAddToCart.Click += new System.EventHandler(this.mnuAddToCart_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "ds";
            this.dlgSave.FileName = "doc1";
            this.dlgSave.Filter = "DataSet Files (*.ds)|*.ds|All Files (*.*)|*.*";
            // 
            // mnuDiscontinued
            // 
            this.mnuDiscontinued.Checked = true;
            this.mnuDiscontinued.Index = 6;
            this.mnuDiscontinued.Text = "&Discontinued";
            // 
            // mnuOutOfStock
            // 
            this.mnuOutOfStock.Checked = true;
            this.mnuOutOfStock.Index = 7;
            this.mnuOutOfStock.Text = "&Out Of Stock";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // Form1
            //
            mnuProducts.Click += new EventHandler(FilterMenus);
            mnuOutOfStock.Click += new EventHandler(FilterMenus);
            mnuDiscontinued.Click += new EventHandler(FilterMenus);

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.grd);
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
			Dispose();
			Close();
		}

		public void OpenFromFile()
		{
			try
			{
				dsShoppingCart.Tables["CartItems"].Clear();
				dsShoppingCart.Tables["Customer"].Clear();
				dsShoppingCart.ReadXml(filename);
			}
			catch (System.Exception Xcp)
			{
				MessageBox.Show(Xcp.ToString(),
					"Failed to open: " + filename,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void SaveToFile()
		{
			try
			{
				dsShoppingCart.WriteXml(filename);
			}
			catch(System.Exception Xcp)
			{
				MessageBox.Show(Xcp.ToString(),
					"Failed to open: " + filename,
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void SetFormCaption()
		{
			Text = filename + 
				" - Shopping Cart : Test WinApp";
		}

		private void mnuCustomer_Click(object sender, System.EventArgs e)
		{
			grd.DataSource = new DataView(
				dsShoppingCart.Tables["Customer"]);

			mnuCustomer.Checked = true;
			mnuCartItems.Checked = false;
            mnuProducts.Checked = false;
		}

		private void mnuCartItems_Click(object sender, System.EventArgs e)
		{
			grd.DataSource = new DataView(
				dsShoppingCart.Tables["CartItems"]);

			mnuCustomer.Checked = false;
			mnuCartItems.Checked = true;
            mnuProducts.Checked = false;
		}

		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			dsShoppingCart.Tables["CartItems"].Clear();
			dsShoppingCart.Tables["Customer"].Clear();
			filename = "ShoppingCart1.ds";
			SetFormCaption();
			mnuCustomer_Click(sender, e);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            // Create a primary key
			mnuNew_Click(sender, e);
			dtCustomer.Constraints.Add( "PK_Customer",
				dtCustomer.Columns["CustomerID"], true );

            // Create a foreign key with a foreigh key constraint to enforce referential integrity
            dsShoppingCart.Relations.Add("FK_Customer_CartItems",
                dtCustomer.Columns["CustomerID"],
                dtCartItems.Columns["CustomerID"], true );

            // Instruct the dataset to enforce the relationship with the foreign key constraint
            dsShoppingCart.EnforceConstraints = true;

            // Progmatically create a new column to the Customer table
            dsShoppingCart.Tables["Customer"].Columns.Add(
                "CartSubtotal", typeof(decimal), "Sum(Child.Cost)");

            dsCatProd = new DataSet("dsCatProd");
            dsCatProd.ReadXml(@"..\..\catprod.ds", XmlReadMode.ReadSchema);
		}

		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				filename = dlgOpen.FileName;
				OpenFromFile();
				SetFormCaption();
				mnuCustomer_Click(sender, e);
			}
		}

		private void mnuSaveAs_Click(object sender, System.EventArgs e)
		{
			if (dlgSave.ShowDialog() == DialogResult.OK)
			{
				filename = dlgSave.FileName;
				SaveToFile();
				SetFormCaption();
			}
		}

		private void mnuSave_Click(object sender, System.EventArgs e)
		{
			SaveToFile();
		}

        private void mnuSubtotal_Click(object sender, EventArgs e)
        {
            string sCustomerID = string.Empty;
            DataRow drCustomer;
            decimal dSubtotal = 0;

            try
            {
                sCustomerID = (string)grd[grd.CurrentRowIndex, 0];
                drCustomer = dsShoppingCart.Tables["Customer"].Select("CustomerID='" + sCustomerID + "'")[0];

                foreach (DataRow drCartItem in
                    drCustomer.GetChildRows("FK_Customer_CartItems"))
                    dSubtotal += (decimal)drCartItem["Cost"];

                MessageBox.Show(drCustomer["CompanyName"] + " owes"
                    + dSubtotal.ToString("$0.00"), "Cart Subtotal");
            }
            catch (Exception error)
            {
                System.Diagnostics.Trace.WriteLine(error.ToString());
                throw;
            }
        }

        private void mnuProducts_Click(object sender, EventArgs e)
        {
            mnuProducts.Checked = true;
            mnuCustomer.Checked = false;
            mnuCartItems.Checked = false;

            // grd.DataSource = new DataView(dsCatProd.Tables["Products"]);
        }

        private void mnuEdit_Select(object sender, EventArgs e)
        {
            mnuAddToCart.Enabled = mnuProducts.Checked;
        }

        private void mnuAddToCart_Click(object sender, EventArgs e)
        {
            object CustomerID, ProductID, UnitPrice, Quantity;
            CustomerID = dtCustomer.Rows[0][0];
            ProductID = grd[grd.CurrentRowIndex, 0];
            UnitPrice = grd[grd.CurrentRowIndex, 5];
            Quantity = Interaction.InputBox("How many "
                + grd[grd.CurrentRowIndex, 1] + " do you want?",
                "Add To Cart", "", 0, 0);
            try
            {
                dsShoppingCart.Tables["CartItems"].Rows.Add(
                    new object[] { CustomerID, ProductID, UnitPrice, Quantity });
            }
            catch (Exception error)
            {
                System.Diagnostics.Trace.WriteLine(error.ToString());
            }
        }

        private void mnuView_Select(object sender, EventArgs e)
        {
            mnuDiscontinued.Enabled = mnuProducts.Checked;
            mnuOutOfStock.Enabled = mnuProducts.Checked;
        }

        private void FilterMenus(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            if (mi != mnuProducts)
                mi.Checked = !(mi.Checked);

            DataView dvProducts = new DataView(dsCatProd.Tables["Products"]);
            if (!mnuOutOfStock.Checked && !mnuDiscontinued.Checked)
                dvProducts.RowFilter = "Discontinued=False And Units>0";
            else if (!mnuOutOfStock.Checked)
                dvProducts.RowFilter = "UnitsInStock>0";
            else if (!mnuDiscontinued.Checked)
                dvProducts.RowFilter = "Discontinued=False";

            grd.DataSource = dvProducts;
        }
	}
}
