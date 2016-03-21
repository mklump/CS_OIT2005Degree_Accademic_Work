using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WinFormFinalExamClient.localhost;

namespace WinFormFinalExamClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Web Service class scope level variable
		/// </summary>
		private Service1 service;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button Remember;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Forget;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button ShowAll;
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
			service = new Service1();
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Remember = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.Forget = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.ShowAll = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "String To Remember:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(240, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// Remember
			// 
			this.Remember.Location = new System.Drawing.Point(256, 40);
			this.Remember.Name = "Remember";
			this.Remember.Size = new System.Drawing.Size(72, 24);
			this.Remember.TabIndex = 2;
			this.Remember.Text = "Remember";
			this.Remember.Click += new System.EventHandler(this.Remember_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Click This Button to Forget All Strings:";
			// 
			// Forget
			// 
			this.Forget.Location = new System.Drawing.Point(208, 72);
			this.Forget.Name = "Forget";
			this.Forget.Size = new System.Drawing.Size(120, 23);
			this.Forget.TabIndex = 4;
			this.Forget.Text = "Forget All Strings";
			this.Forget.Click += new System.EventHandler(this.Forget_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(176, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Click to Display List of All Strings:";
			// 
			// ShowAll
			// 
			this.ShowAll.Location = new System.Drawing.Point(192, 104);
			this.ShowAll.Name = "ShowAll";
			this.ShowAll.Size = new System.Drawing.Size(136, 23);
			this.ShowAll.TabIndex = 6;
			this.ShowAll.Text = "Show All Strings";
			this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 136);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(320, 360);
			this.dataGrid1.TabIndex = 7;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 502);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.ShowAll);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Forget);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Remember);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Things To Remember";
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

		private void Remember_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			IAsyncResult asi = service.BeginRemember( textBox1.Text, new AsyncCallback( this.SetRememberString ), service );
		}

		private void Forget_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			IAsyncResult asi = service.BeginForget( new AsyncCallback( this.EndForget ), service );
		}

		private void ShowAll_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			IAsyncResult asi = service.BeginRegurgitate( new AsyncCallback( this.EndRegurgitate ), service );
		}

		private void SetRememberString(IAsyncResult ar)
		{
			service.EndRemember( ar );
			this.Cursor = Cursors.Default;
		}

		private void EndForget(IAsyncResult ar)
		{
			service.EndForget( ar );
			textBox1.Text = "";
			this.Cursor = Cursors.Default;
		}

		private void EndRegurgitate(IAsyncResult ar)
		{
			 RememberedThing[] result = service.EndRegurgitate( ar );
			PopulateDataGrid( result );
			this.Cursor = Cursors.Default;
		}

		private void PopulateDataGrid( RememberedThing[] result )
		{
			DataSet myDataSet = new DataSet("myDataSet");
			DataTable myDataTable = myDataSet.Tables.Add("myDataTable");

			// Insert code to populate the DataSet.
			dataGrid1.CaptionText = "List of Remembered Strings:";
			myDataTable.Columns.Add("Thing#");
			myDataTable.Columns.Add("String Remembered");
			myDataTable.Columns.Add("Date/Time Remembered");
			for( int x = 0; result[x] != null && x < result.Length; ++x )
			{
				DataRow nextRow = myDataTable.NewRow();
				x++;
				nextRow[0] = x.ToString();
				x--;
				nextRow[1] = result[x].StringRemembered;
				nextRow[2] = result[x].TimeRemembered.ToString();
				myDataTable.Rows.Add( nextRow );
			}
			dataGrid1.DataSource = myDataSet;
		}
	}
}
