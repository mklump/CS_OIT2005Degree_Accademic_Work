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
		private System.Windows.Forms.ListBox lstOrderSummary;
		private System.Windows.Forms.Label lblMaximumPrice;
		private System.Windows.Forms.Label lblMinimumPrice;
		private System.Windows.Forms.Label lblOutOfStock;
		private System.Windows.Forms.Label lblOrderSummary;
		private System.Windows.Forms.ListBox lstInStock;
		private System.Windows.Forms.Label lblInStock;
		private System.Windows.Forms.Button btnSummarizeOrders;
		private System.Data.SqlClient.SqlConnection cnNorthwind;
		private System.Data.SqlClient.SqlCommand cmCountProducts;
		private System.Data.SqlClient.SqlCommand cmGetProductsInRange;
		private System.Data.SqlClient.SqlCommand cmSummarizeOrders;
		private System.Data.SqlClient.SqlCommand cmGetOrderSummary;
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
			this.txtMaximumPrice = new System.Windows.Forms.TextBox();
			this.lblOutOfStock = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtMinimumPrice = new System.Windows.Forms.TextBox();
			this.lblMaximumPrice = new System.Windows.Forms.Label();
			this.lblInStock = new System.Windows.Forms.Label();
			this.lblMinimumPrice = new System.Windows.Forms.Label();
			this.btnCountProducts = new System.Windows.Forms.Button();
			this.btnDisplayProducts = new System.Windows.Forms.Button();
			this.lstOutOfStock = new System.Windows.Forms.ListBox();
			this.lstInStock = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lstOrderSummary = new System.Windows.Forms.ListBox();
			this.btnSummarizeOrders = new System.Windows.Forms.Button();
			this.lblOrderSummary = new System.Windows.Forms.Label();
			this.cnNorthwind = new System.Data.SqlClient.SqlConnection();
			this.cmCountProducts = new System.Data.SqlClient.SqlCommand();
			this.cmGetProductsInRange = new System.Data.SqlClient.SqlCommand();
			this.cmSummarizeOrders = new System.Data.SqlClient.SqlCommand();
			this.cmGetOrderSummary = new System.Data.SqlClient.SqlCommand();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtMaximumPrice
			// 
			this.txtMaximumPrice.Location = new System.Drawing.Point(224, 32);
			this.txtMaximumPrice.Name = "txtMaximumPrice";
			this.txtMaximumPrice.Size = new System.Drawing.Size(40, 20);
			this.txtMaximumPrice.TabIndex = 3;
			this.txtMaximumPrice.Text = "";
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
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(400, 288);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtMinimumPrice);
			this.tabPage1.Controls.Add(this.txtMaximumPrice);
			this.tabPage1.Controls.Add(this.lblMaximumPrice);
			this.tabPage1.Controls.Add(this.lblInStock);
			this.tabPage1.Controls.Add(this.lblMinimumPrice);
			this.tabPage1.Controls.Add(this.btnCountProducts);
			this.tabPage1.Controls.Add(this.btnDisplayProducts);
			this.tabPage1.Controls.Add(this.lstOutOfStock);
			this.tabPage1.Controls.Add(this.lstInStock);
			this.tabPage1.Controls.Add(this.lblOutOfStock);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(392, 262);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Product Prices";
			// 
			// txtMinimumPrice
			// 
			this.txtMinimumPrice.Location = new System.Drawing.Point(88, 32);
			this.txtMinimumPrice.Name = "txtMinimumPrice";
			this.txtMinimumPrice.Size = new System.Drawing.Size(40, 20);
			this.txtMinimumPrice.TabIndex = 1;
			this.txtMinimumPrice.Text = "";
			// 
			// lblMaximumPrice
			// 
			this.lblMaximumPrice.Location = new System.Drawing.Point(144, 32);
			this.lblMaximumPrice.Name = "lblMaximumPrice";
			this.lblMaximumPrice.Size = new System.Drawing.Size(88, 16);
			this.lblMaximumPrice.TabIndex = 2;
			this.lblMaximumPrice.Text = "Maximum price:";
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
			this.btnDisplayProducts.Click += new System.EventHandler(this.btnDisplayProducts_Click);
			// 
			// lstOutOfStock
			// 
			this.lstOutOfStock.Location = new System.Drawing.Point(8, 184);
			this.lstOutOfStock.Name = "lstOutOfStock";
			this.lstOutOfStock.Size = new System.Drawing.Size(256, 69);
			this.lstOutOfStock.TabIndex = 9;
			// 
			// lstInStock
			// 
			this.lstInStock.Location = new System.Drawing.Point(8, 88);
			this.lstInStock.Name = "lstInStock";
			this.lstInStock.Size = new System.Drawing.Size(256, 69);
			this.lstInStock.TabIndex = 7;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lstOrderSummary);
			this.tabPage2.Controls.Add(this.btnSummarizeOrders);
			this.tabPage2.Controls.Add(this.lblOrderSummary);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(392, 262);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Product Orders";
			// 
			// lstOrderSummary
			// 
			this.lstOrderSummary.Location = new System.Drawing.Point(8, 64);
			this.lstOrderSummary.Name = "lstOrderSummary";
			this.lstOrderSummary.Size = new System.Drawing.Size(256, 186);
			this.lstOrderSummary.TabIndex = 2;
			// 
			// btnSummarizeOrders
			// 
			this.btnSummarizeOrders.Location = new System.Drawing.Point(272, 64);
			this.btnSummarizeOrders.Name = "btnSummarizeOrders";
			this.btnSummarizeOrders.Size = new System.Drawing.Size(112, 24);
			this.btnSummarizeOrders.TabIndex = 0;
			this.btnSummarizeOrders.Text = "Summarize orders";
			this.btnSummarizeOrders.Click += new System.EventHandler(this.btnSummarizeOrders_Click);
			// 
			// lblOrderSummary
			// 
			this.lblOrderSummary.Location = new System.Drawing.Point(8, 40);
			this.lblOrderSummary.Name = "lblOrderSummary";
			this.lblOrderSummary.Size = new System.Drawing.Size(368, 16);
			this.lblOrderSummary.TabIndex = 1;
			this.lblOrderSummary.Text = "Obtain the total number of orders for each product.";
			// 
			// cnNorthwind
			// 
			this.cnNorthwind.ConnectionString = "workstation id=NOTEBOOK;packet size=4096;integrated security=SSPI;data source=NOT" +
				"EBOOK;persist security info=True;initial catalog=Northwind";
			// 
			// cmCountProducts
			// 
			this.cmCountProducts.CommandText = "dbo.[CountProducts]";
			this.cmCountProducts.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmCountProducts.Connection = this.cnNorthwind;
			this.cmCountProducts.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmCountProducts.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Min", System.Data.SqlDbType.Money, 4));
			this.cmCountProducts.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.Money, 4));
			// 
			// cmGetProductsInRange
			// 
			this.cmGetProductsInRange.CommandText = "dbo.[GetProductsInRange]";
			this.cmGetProductsInRange.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmGetProductsInRange.Connection = this.cnNorthwind;
			this.cmGetProductsInRange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmGetProductsInRange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Min", System.Data.SqlDbType.Money, 4));
			this.cmGetProductsInRange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Max", System.Data.SqlDbType.Money, 4));
			// 
			// cmSummarizeOrders
			// 
			this.cmSummarizeOrders.CommandText = "dbo.[SummarizeOrders]";
			this.cmSummarizeOrders.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmSummarizeOrders.Connection = this.cnNorthwind;
			this.cmSummarizeOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmGetOrderSummary
			// 
			this.cmGetOrderSummary.CommandText = "dbo.[GetOrderSummary]";
			this.cmGetOrderSummary.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmGetOrderSummary.Connection = this.cnNorthwind;
			this.cmGetOrderSummary.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// frmConnectedApp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 301);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmConnectedApp";
			this.Text = "Connected ADO.NET Application";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
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
			double minPrice = double.Parse( txtMinimumPrice.Text );
			double maxPrice = double.Parse( txtMaximumPrice.Text );
			cmCountProducts.Parameters["@Min"].Value = minPrice;
			cmCountProducts.Parameters["@Max"].Value = maxPrice;
			int retVal;
			try
			{
				cnNorthwind.Open();
				retVal = (int) cmCountProducts.ExecuteScalar();
			}
			catch( System.Data.SqlClient.SqlException error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			catch( System.InvalidOperationException error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			catch( Exception error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			finally
			{
				cnNorthwind.Close();
			}
			MessageBox.Show(
				"The return value from the CountProducts stored procedure is: " + retVal,
				"CountProducts Stored Procedure", MessageBoxButtons.OK, MessageBoxIcon.Information
				);
		}

		private void btnDisplayProducts_Click(object sender, System.EventArgs e)
		{
			lstInStock.Items.Clear();
			lstInStock.ClearSelected();
			cmGetProductsInRange.Parameters["@Min"].Value = txtMinimumPrice.Text;
			cmGetProductsInRange.Parameters["@Max"].Value = txtMaximumPrice.Text;
			System.Data.SqlClient.SqlDataReader drProducts = null;
			try
			{
				int resultCount = 0;
				cnNorthwind.Open();
				drProducts = cmGetProductsInRange.ExecuteReader( CommandBehavior.CloseConnection );
				do
				{
					while( drProducts.Read() )
					{
						if( 0 == resultCount )
							lstInStock.Items.Add(
								drProducts.GetSqlInt32( drProducts.GetOrdinal("ProductID") ) + " " +
								drProducts.GetString( drProducts.GetOrdinal("ProductName") ) + " " +
								drProducts.GetSqlMoney( drProducts.GetOrdinal("UnitPrice") )
								);
						else
							lstOutOfStock.Items.Add(
								drProducts.GetSqlInt32( drProducts.GetOrdinal("ProductID") ) + " " +
								drProducts.GetString( drProducts.GetOrdinal("ProductName") ) + " " +
								drProducts.GetSqlMoney( drProducts.GetOrdinal("UnitPrice") )
								);
					}
					if( 0 == resultCount )
					{
						lstOutOfStock.Items.Clear();
						lstOutOfStock.ClearSelected();
						resultCount++;
					}
				}
				while( drProducts.NextResult() );
			}
			catch( System.Data.SqlClient.SqlException error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			catch( System.InvalidOperationException error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			catch( Exception error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			finally
			{
				drProducts.Close();
				cnNorthwind.Close();
			}
		}

		private void btnSummarizeOrders_Click(object sender, System.EventArgs e)
		{
			lstOrderSummary.Items.Clear();
			lstOrderSummary.ClearSelected();
			System.Data.SqlClient.SqlDataReader drProducts = null;
			try
			{
				cnNorthwind.Open();
				cmSummarizeOrders.ExecuteNonQuery();
				drProducts = cmGetOrderSummary.ExecuteReader();
				while( drProducts.Read() )
				{
					lstOrderSummary.Items.Add( drProducts.GetSqlInt32( drProducts.GetOrdinal("Orders") ) +
						" " + drProducts.GetString( drProducts.GetOrdinal("ProductName") )
						);
				}
			}
			catch( System.Data.SqlClient.SqlException error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			catch( System.InvalidOperationException error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			catch( Exception error )
			{
				System.Diagnostics.Trace.WriteLine( error.ToString() );
				throw;
			}
			finally
			{
				drProducts.Close();
				cnNorthwind.Close();
			}
		}
	}
}
