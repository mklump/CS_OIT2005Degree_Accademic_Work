using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;

namespace LoadingDataSets
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmCustomer : System.Windows.Forms.Form
	{
		private const string myDocument = @"\Program Files\MSDNTrain\2389\Labs\Lab05\customers.xml";
		private const string myLoadSchema = @"\Program Files\MSDNTrain\2389\Labs\Lab05\customerschema.xsd";
		private DataSet myDS;
		
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox chkInferSchema;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCustomer()
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
			this.btnLoadData = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkInferSchema = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLoadData
			// 
			this.btnLoadData.Location = new System.Drawing.Point(232, 8);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(168, 23);
			this.btnLoadData.TabIndex = 1;
			this.btnLoadData.Text = "Display Customer Information";
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(224, 273);
			this.dataGrid1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(232, 72);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(168, 24);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkInferSchema
			// 
			this.chkInferSchema.Location = new System.Drawing.Point(232, 40);
			this.chkInferSchema.Name = "chkInferSchema";
			this.chkInferSchema.TabIndex = 3;
			this.chkInferSchema.Text = "Infer Schema";
			// 
			// frmCustomer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkInferSchema,
																		  this.btnClose,
																		  this.btnLoadData,
																		  this.dataGrid1});
			this.Name = "frmCustomer";
			this.Text = "Sales Information";
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
			Application.Run(new frmCustomer());
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnLoadData_Click(object sender, System.EventArgs e)
		{

			try
			{
				myDS = new DataSet();

				if(this.chkInferSchema.Checked)
				{
					//Console.WriteLine(myDocument);
					myDS.ReadXml(myDocument, XmlReadMode.InferSchema);
				}
				else
				{
					//Console.WriteLine(myLoadSchema);
					myDS.ReadXmlSchema(myLoadSchema);
					//Console.WriteLine(myDocument);
					myDS.ReadXml(myDocument, XmlReadMode.IgnoreSchema);
				}

				this.dataGrid1.DataSource = myDS.Tables["Customers"];
			}
			catch (Exception xcp)
			{
				MessageBox.Show(xcp.ToString());
			}

		}
	}
}
