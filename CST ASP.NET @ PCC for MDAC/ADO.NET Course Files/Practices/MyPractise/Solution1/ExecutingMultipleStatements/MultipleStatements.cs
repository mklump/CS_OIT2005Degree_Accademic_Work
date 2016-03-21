using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;

namespace ExecutingMultipleStatements
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button button1;
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=NOTEBOOK;packet size=4096;integrated security=SSPI;data source=NOT" +
				"EBOOK;persist security info=True;initial catalog=Northwind";
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.[CategoriesAndProducts]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 80);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(208, 238);
			this.listBox1.TabIndex = 0;
			// 
			// listBox2
			// 
			this.listBox2.Location = new System.Drawing.Point(224, 80);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(208, 238);
			this.listBox2.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(216, 40);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 334);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
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
			sqlConnection1.Open();
			SqlDataReader dr;
			dr = sqlCommand1.ExecuteReader( CommandBehavior.CloseConnection );

			int resultSetNum = 0;
			do
			{
				// Loop through the ResultSets
				while( dr.Read() )
				{
					for( int col = 0; col < dr.FieldCount; col++ )
					{

						if( 0 == resultSetNum && typeof(byte[]) != dr.GetValue( col ).GetType() )
							listBox1.Items.Add( dr.GetValue( col ) );
						else if( typeof(byte[]) != dr.GetValue( col ).GetType() )
							listBox2.Items.Add( dr.GetValue( col ) );
					}
				}
				resultSetNum++;
			}
			while( dr.NextResult() );
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
