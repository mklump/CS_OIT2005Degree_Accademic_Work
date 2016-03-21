using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using WindowsAppAssignment3.net.webservicex.www;

namespace WindowsAppAssignment3
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// This variable was added to get the results of the web service calls.
		/// </summary>
		private OrderList results;

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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowDrop = true;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(464, 480);
			this.dataGrid1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(280, 504);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(176, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Get Last 100 Trades Button";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(136, 504);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(136, 21);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 504);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter Stock Symbol:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(480, 542);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGrid1);
			this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "Form1";
			this.Text = "Most Recent Trading";
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			RealTimeMarketData marketData = new RealTimeMarketData();
			this.Cursor = Cursors.WaitCursor;
			IAsyncResult asi = marketData.BeginLastExecution( textBox1.Text, 100,
									  new AsyncCallback(this.CallBack), marketData );
			WaitHandle.WaitAll( new System.Threading.WaitHandle [] {asi.AsyncWaitHandle} );
			PopulateDataGrid();
		}

		private void PopulateDataGrid()
		{
			DataSet myDataSet = new DataSet("myDataSet");
			DataTable myDataTable = myDataSet.Tables.Add("myDataTable");
			// Insert code to populate the DataSet.

			dataGrid1.CaptionText = "Last 100 Trades for " + textBox1.Text;
			myDataTable.Columns.Add("ID");
			myDataTable.Columns.Add("Trade Number");
			myDataTable.Columns.Add("Trade Price");
			myDataTable.Columns.Add("Shares Volume");
			myDataTable.Columns.Add("Trade Type");
			myDataTable.Columns.Add("Trade Date");
			for( int x = 0; x < results.OrderLists.Length; ++x )
			{
				DataRow nextRow = myDataTable.NewRow();
				x++;
				nextRow[0] = x.ToString();
				x--;
				nextRow[1] = results.OrderLists[x].ReferenceNumber;
				nextRow[2] = results.OrderLists[x].Price;
				nextRow[3] = results.OrderLists[x].Shares;
				nextRow[4] = results.OrderLists[x].Type;
				nextRow[5] = results.OrderLists[x].DateTime;
				myDataTable.Rows.Add( nextRow );
			}
			dataGrid1.DataSource = myDataSet;
		}

		private void CallBack(IAsyncResult ar)
		{
			RealTimeMarketData marketData = (RealTimeMarketData) ar.AsyncState;
			results = marketData.EndLastExecution( ar );
			this.Cursor = Cursors.Default;
		}
	}
}
