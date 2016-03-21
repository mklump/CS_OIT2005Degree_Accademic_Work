using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CreateDataSets
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.DataSet dsNorthWind;
		private System.Data.DataTable dtProducts;
		private System.Data.DataColumn dcProductID;
		private System.Data.DataColumn dcProductName;
		private System.Data.DataColumn dcUnitPrice;

		private System.Data.DataColumn dcUnitsInStock;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.DataGrid dataGrid1;

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
			this.dsNorthWind = new System.Data.DataSet();
			this.dtProducts = new System.Data.DataTable();
			this.dcProductID = new System.Data.DataColumn();
			this.dcProductName = new System.Data.DataColumn();
			this.dcUnitPrice = new System.Data.DataColumn();
			this.dcUnitsInStock = new System.Data.DataColumn();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dsNorthWind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtProducts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dsNorthWind
			// 
			this.dsNorthWind.DataSetName = "NewDataSet";
			this.dsNorthWind.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsNorthWind.Tables.AddRange(new System.Data.DataTable[] {
																			 this.dtProducts});
			// 
			// dtProducts
			// 
			this.dtProducts.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dcProductID,
																			  this.dcProductName,
																			  this.dcUnitPrice,
																			  this.dcUnitsInStock});
			this.dtProducts.TableName = "Products";
			// 
			// dcProductID
			// 
			this.dcProductID.ColumnName = "ProductID";
			this.dcProductID.DataType = typeof(int);
			// 
			// dcProductName
			// 
			this.dcProductName.ColumnName = "ProductName";
			// 
			// dcUnitPrice
			// 
			this.dcUnitPrice.ColumnName = "UnitPrice";
			this.dcUnitPrice.DataType = typeof(System.Double);
			// 
			// dcUnitsInStock
			// 
			this.dcUnitsInStock.ColumnName = "UnitsInStock";
			this.dcUnitsInStock.DataType = typeof(System.Double);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(152, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(128, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(280, 16);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(136, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(416, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(136, 20);
			this.textBox4.TabIndex = 3;
			this.textBox4.Text = "";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(552, 16);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(136, 20);
			this.textBox5.TabIndex = 4;
			this.textBox5.Text = "";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(24, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(664, 224);
			this.dataGrid1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(712, 326);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsNorthWind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtProducts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			dsNorthWind.Tables[0].Columns["ProductName"].Unique = true;
			dsNorthWind.EnforceConstraints = true;

			DataColumn dcl = new DataColumn( "StockValue", typeof(System.Double) );
			dcl.Expression = "UnitPrice * UnitsInStock";
			dsNorthWind.Tables[0].Columns.Add( dcl );
		}
	}
}
