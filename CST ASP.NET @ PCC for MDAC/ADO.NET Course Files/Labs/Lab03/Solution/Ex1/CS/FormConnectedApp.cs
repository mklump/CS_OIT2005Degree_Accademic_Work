using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ConnectedApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmConnectedApp : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtMinimumPrice;
		private System.Windows.Forms.TextBox txtMaximumPrice;
		private System.Windows.Forms.ListBox lstOutOfStock;
		private System.Windows.Forms.Button btnCountProducts;
		private System.Windows.Forms.Button btnDisplayProducts;
		private System.Windows.Forms.Label lblMaximumPrice;
		private System.Windows.Forms.Label lblMinimumPrice;
		private System.Windows.Forms.Label lblOutOfStock;
		private System.Data.SqlClient.SqlConnection cnNorthwind;
		private System.Data.SqlClient.SqlCommand cmCountProducts;
		private System.Windows.Forms.ListBox lstInStock;
		private System.Windows.Forms.Label lblInStock;
		private System.Windows.Forms.ListBox lstOrderSummary;
		private System.Windows.Forms.Label lblOrderSummary;
		private System.Windows.Forms.Button btnSummarizeOrders;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmConnectedApp()
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
			this.btnCountProducts = new System.Windows.Forms.Button();
			this.btnDisplayProducts = new System.Windows.Forms.Button();
			this.lstInStock = new System.Windows.Forms.ListBox();
			this.lstOrderSummary = new System.Windows.Forms.ListBox();
			this.lblMaximumPrice = new System.Windows.Forms.Label();
			this.lblOrderSummary = new System.Windows.Forms.Label();
			this.txtMinimumPrice = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnSummarizeOrders = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtMaximumPrice = new System.Windows.Forms.TextBox();
			this.lblInStock = new System.Windows.Forms.Label();
			this.lblMinimumPrice = new System.Windows.Forms.Label();
			this.lstOutOfStock = new System.Windows.Forms.ListBox();
			this.lblOutOfStock = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.cmCountProducts = new System.Data.SqlClient.SqlCommand();
			this.cnNorthwind = new System.Data.SqlClient.SqlConnection();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCountProducts
			// 
			this.btnCountProducts.Location = new System.Drawing.Point(280, 32);
			this.btnCountProducts.Name = "btnCountProducts";
			this.btnCountProducts.Size = new System.Drawing.Size(104, 24);
			this.btnCountProducts.TabIndex = 4;
			this.btnCountProducts.Text = "Count products";
			this.btnCountProducts.Click += new System.EventHandler(this.btnCountProducts_Click);
			// 
			// btnDisplayProducts
			// 
			this.btnDisplayProducts.Location = new System.Drawing.Point(280, 72);
			this.btnDisplayProducts.Name = "btnDisplayProducts";
			this.btnDisplayProducts.Size = new System.Drawing.Size(104, 24);
			this.btnDisplayProducts.TabIndex = 5;
			this.btnDisplayProducts.Text = "Display products";
			// 
			// lstInStock
			// 
			this.lstInStock.Location = new System.Drawing.Point(8, 88);
			this.lstInStock.Name = "lstInStock";
			this.lstInStock.Size = new System.Drawing.Size(256, 69);
			this.lstInStock.TabIndex = 7;
			// 
			// lstOrderSummary
			// 
			this.lstOrderSummary.Location = new System.Drawing.Point(8, 64);
			this.lstOrderSummary.Name = "lstOrderSummary";
			this.lstOrderSummary.Size = new System.Drawing.Size(256, 186);
			this.lstOrderSummary.TabIndex = 2;
			// 
			// lblMaximumPrice
			// 
			this.lblMaximumPrice.Location = new System.Drawing.Point(144, 32);
			this.lblMaximumPrice.Name = "lblMaximumPrice";
			this.lblMaximumPrice.Size = new System.Drawing.Size(88, 16);
			this.lblMaximumPrice.TabIndex = 2;
			this.lblMaximumPrice.Text = "Maximum price:";
			// 
			// lblOrderSummary
			// 
			this.lblOrderSummary.Location = new System.Drawing.Point(8, 40);
			this.lblOrderSummary.Name = "lblOrderSummary";
			this.lblOrderSummary.Size = new System.Drawing.Size(368, 16);
			this.lblOrderSummary.TabIndex = 1;
			this.lblOrderSummary.Text = "Obtain the total number of orders for each product.";
			// 
			// txtMinimumPrice
			// 
			this.txtMinimumPrice.Location = new System.Drawing.Point(88, 32);
			this.txtMinimumPrice.Name = "txtMinimumPrice";
			this.txtMinimumPrice.Size = new System.Drawing.Size(40, 20);
			this.txtMinimumPrice.TabIndex = 1;
			this.txtMinimumPrice.Text = "";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lstOrderSummary,
																				   this.btnSummarizeOrders,
																				   this.lblOrderSummary});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(392, 262);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Product Orders";
			// 
			// btnSummarizeOrders
			// 
			this.btnSummarizeOrders.Location = new System.Drawing.Point(272, 64);
			this.btnSummarizeOrders.Name = "btnSummarizeOrders";
			this.btnSummarizeOrders.Size = new System.Drawing.Size(112, 24);
			this.btnSummarizeOrders.TabIndex = 0;
			this.btnSummarizeOrders.Text = "Summarize Orders";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtMinimumPrice,
																				   this.txtMaximumPrice,
																				   this.lblMaximumPrice,
																				   this.lblInStock,
																				   this.lblMinimumPrice,
																				   this.btnCountProducts,
																				   this.btnDisplayProducts,
																				   this.lstOutOfStock,
																				   this.lstInStock,
																				   this.lblOutOfStock});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(392, 262);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Product Prices";
			// 
			// txtMaximumPrice
			// 
			this.txtMaximumPrice.Location = new System.Drawing.Point(224, 32);
			this.txtMaximumPrice.Name = "txtMaximumPrice";
			this.txtMaximumPrice.Size = new System.Drawing.Size(40, 20);
			this.txtMaximumPrice.TabIndex = 3;
			this.txtMaximumPrice.Text = "";
			// 
			// lblInStock
			// 
			this.lblInStock.Location = new System.Drawing.Point(8, 72);
			this.lblInStock.Name = "lblInStock";
			this.lblInStock.Size = new System.Drawing.Size(248, 16);
			this.lblInStock.TabIndex = 6;
			this.lblInStock.Text = "In-stock products in price range";
			// 
			// lblMinimumPrice
			// 
			this.lblMinimumPrice.Location = new System.Drawing.Point(8, 32);
			this.lblMinimumPrice.Name = "lblMinimumPrice";
			this.lblMinimumPrice.Size = new System.Drawing.Size(88, 16);
			this.lblMinimumPrice.TabIndex = 0;
			this.lblMinimumPrice.Text = "Minimum price:";
			// 
			// lstOutOfStock
			// 
			this.lstOutOfStock.Location = new System.Drawing.Point(8, 184);
			this.lstOutOfStock.Name = "lstOutOfStock";
			this.lstOutOfStock.Size = new System.Drawing.Size(256, 69);
			this.lstOutOfStock.TabIndex = 9;
			// 
			// lblOutOfStock
			// 
			this.lblOutOfStock.Location = new System.Drawing.Point(8, 168);
			this.lblOutOfStock.Name = "lblOutOfStock";
			this.lblOutOfStock.Size = new System.Drawing.Size(248, 16);
			this.lblOutOfStock.TabIndex = 8;
			this.lblOutOfStock.Text = "Out-of-stock products in price range";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(400, 288);
			this.tabControl1.TabIndex = 0;
			// 
			// cmCountProducts
			// 
			this.cmCountProducts.CommandText = "dbo.CountProducts";
			this.cmCountProducts.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmCountProducts.Connection = this.cnNorthwind;
			this.cmCountProducts.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmCountProducts.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Min", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(19)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmCountProducts.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(19)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cnNorthwind
			// 
			this.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" +
				"curity info=False;packet size=4096";
			// 
			// frmConnectedApp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1});
			this.Name = "frmConnectedApp";
			this.Text = "Connected ADO.NET Application";
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmConnectedApp());
		}

		private void btnCountProducts_Click(object sender, System.EventArgs e)
		{
			// Get the text in the txtMinimumPrice and txtMaximumPrice text boxes
			double min = double.Parse(this.txtMinimumPrice.Text);
			double max = double.Parse(this.txtMaximumPrice.Text);

			// Set the @Min and @Max parameters for the cmCountProducts stored procedure
			this.cmCountProducts.Parameters["@Min"].Value = min;
			this.cmCountProducts.Parameters["@Max"].Value = max;

			// Open a connection to the Northwind database
			this.cnNorthwind.Open();

			// Execute the cmCountProducts stored procedure command
			int iProductsCount = (int)this.cmCountProducts.ExecuteScalar();

			// Close the database connection 
			this.cnNorthwind.Close();

			// Display the return value from the cmCountProducts stored procedure command
			MessageBox.Show("There are " + iProductsCount.ToString() + 
				" products in this price range.",
				"Products costing between $" + 
				min.ToString() + " and $" + max.ToString());

		}
	}
}
