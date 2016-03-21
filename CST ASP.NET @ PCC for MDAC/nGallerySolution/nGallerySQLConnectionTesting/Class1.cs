using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace nGallerySQLConnectionTesting
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			SqlConnection conn = null;
			try
			{
				conn = new SqlConnection("Data Source=localhost; Initial Catalog=nGallery; " +
						"User ID=ngallery_app; Password=%$@%.!ngallery_");
				conn.Open();
				Console.WriteLine("\nSuccessfully opened local database with the nGallery Credentials.\n");
//				SqlCommand cmd = new SqlCommand(
//					"SELECT definition " +
//					"FROM sysdiagrams " +
//					"WHERE name='SchemaDiagram_0'",
//					conn );
//				SqlDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );
//				System.Runtime.Serialization.IFormatter formatter = new
//					System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
//				string schema = "";
//				while( reader.Read() )
//				{
//					for( int x = 0; x < reader.FieldCount; x++ )
//					{
//						System.IO.BinaryReader binReader =
//							new System.IO.BinaryReader(
//							new System.IO.MemoryStream(
//								(byte [])reader.GetValue( x )
//							) );
//						foreach( char character in binReader.ReadChars((int)binReader.BaseStream.Length) )
//							schema += character;
//					}
//				}
//				System.IO.StreamWriter writer = new System.IO.StreamWriter( @"..\..\ngallery.xsd", false );
//				writer.WriteLine( schema );
//				writer.Close();
				int rowsSynchronized = 0;
				SqlCommand cmd = new SqlCommand( "ngGetALLData", conn );
				DataSet allData = new DataSet("allData"),
					currentData = new DataSet("currentData");
				cmd.CommandType = CommandType.StoredProcedure;
				SqlParameter retVal = new SqlParameter( "@ROWS_SELECTED", rowsSynchronized );
				retVal.Direction = ParameterDirection.ReturnValue;
				cmd.Parameters.Add( retVal );
				SqlDataAdapter adp = new SqlDataAdapter( cmd );
				adp.Fill( allData );
				allData.ReadXml( @"..\..\ngallery.xml", XmlReadMode.Auto );
				adp.Fill( allData );
				rowsSynchronized = (int) adp.SelectCommand.Parameters["@ROWS_SELECTED"].Value;
				allData.WriteXml( @"..\..\outputTesting.xml", XmlWriteMode.IgnoreSchema );
				if( 0 == rowsSynchronized )
				{
					cmd.CommandType  = CommandType.Text;
					string [] tables = {"Album", "Comment", "Contact", "Invitation",
						"Invitation_Contacts", "Picture", "Rating", "System_Variables"};
					cmd.CommandText = "SELECT * FROM " +
						"Album, Comment, Contact, Invitation, Invitation_Contacts," + 
						"Picture, Rating, System_Variables " +
						"WHERE " +
						"Album.AlbumID = Picture.PictureAlbumID AND " +
						"Album.AlbumID = Comment.CommentAlbumID AND " +
						"Album.AlbumID = Invitation.AlbumID AND " +
						"Invitation.InvitationID = Invitation_Contacts.InvitationID AND " +
						"Contact.ContactID = Invitation_Contacts.ContactID" +
					";";
					adp.UpdateCommand = cmd;
					DataTable schema = new DataTable( "schema" );
					allData.
					allData.Tables.Add( 
					adp.Update( allData, currentData.Tables[0].TableName );
					rowsSynchronized = (int) adp.SelectCommand.Parameters["@ROWS_SELECTED"].Value;
					allData.WriteXml( @"..\..\outputTesting.xml", XmlWriteMode.IgnoreSchema );
				}
				Console.WriteLine( "Successfully updated the nGallery database. Synchronized {0} row(s).", rowsSynchronized );
			}
			catch( SqlException exception )
			{
				System.Diagnostics.Trace.WriteLine( "Exception ocurred:\n" + exception.ToString() );
				Console.WriteLine( exception.ToString() );
			}
			finally
			{
				conn.Close();
			}
		}
	}
}
