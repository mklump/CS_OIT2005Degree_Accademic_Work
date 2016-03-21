using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace nGallerySQLConnectionTesting
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            DataSet nGallery = new DataSet("nGalleryDataSet");
            nGallery.ReadXml(@"C:\Documents and Settings\ACER USER\" +
                @"Desktop\ngallery.xml", XmlReadMode.Auto);
            nGallery.WriteXml( @"..\..\outputTesting.xml", XmlWriteMode.IgnoreSchema );
            SqlConnection conn = new SqlConnection(
                "Data Source=(local);Initial Catalog=ngallery;Persist Security Info=True;" +
				"User ID='Matthew Klump';Password=$%^@!mjk_-@1842"
                );
            conn.Open();
			SqlCommand command = new SqlCommand();
            int rowsAffected = 0;
			try 
            { 
				foreach( DataRow row in nGallery.Tables["Album"].Rows )
				{
					command.CommandText =
						"INSERT INTO Album (AlbumID, AlbumName, AlbumDesc, AlbumCreateDate, ParentAlbumID)" +
						"VALUES("+ (string)row[0]+ "," + (string)row[1]+ "," + (string)row[2]+ "," +
						(string)row[3]+ "," + (string)row[4] +")";
				}
				rowsAffected = command.ExecuteNonQuery();
            } 
            catch (SqlException error) 
            { 
                Console.WriteLine(error.ToString()); 
                System.Diagnostics.Trace.WriteLine(error.ToString()); 
                System.IO.StreamWriter wri = new System.IO.StreamWriter(@"..\..\SqlError.txt",false); 
                wri.WriteLine(error.ToString()); 
                wri.Close(); 
                System.Threading.Thread.CurrentThread.Abort(); 
            } 
            finally 
            { 
                conn.Close(); 
            } 
//			command = new SqlCommand("ngCreateAlbum", conn);
//            command.CommandType = CommandType.StoredProcedure;
//            SqlParameter param = null;
//            foreach( DataRow row in nGallery.Tables["Album"].Rows )
//            {
//                param = new SqlParameter("@AlbumName", row["Name"] );
//                param.Direction = ParameterDirection.Input;
//                command.Parameters.Add( param );
//                param = new SqlParameter( "@AlbumDesc", row["Description"] );
//                param.Direction = ParameterDirection.Input;
//                command.Parameters.Add( param );
//                param = new SqlParameter( "@ParentAlbumID", row["ParentAlbumID"] );
//                param.Direction = ParameterDirection.Input;
//                command.Parameters.Add( param );
//                DateTime dt = DateTime.Parse((string)row["CreateDate"]);
//                param = new SqlParameter( "@Date", dt );
//                param.Direction = ParameterDirection.Input;
//                command.Parameters.Add( param );
//                try
//                {
//                    rowsAffected = command.ExecuteNonQuery();
//                }
//                catch (SqlException error)
//                {
//                    Console.WriteLine(error.ToString());
//                    System.Diagnostics.Trace.WriteLine(error.ToString());
//                    System.IO.StreamWriter wri = new System.IO.StreamWriter(@"..\..\SqlError.txt",false);
//                    wri.WriteLine(error.ToString());
//                    wri.Close();
//                    System.Threading.Thread.CurrentThread.Abort();
//                }
//                finally
//                {
//                    conn.Close();
//                }
//            }
            conn.Close();
		}
		public static void Main(string [] args)
		{
			Form1 form = new Form1();
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 323);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion


        private void Form1_Load(object sender, EventArgs e)
        {
        }

	}
}
