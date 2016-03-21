using System;
using System.IO;

namespace Video_Store
{
	/// <summary>
	/// This class represents the encapsulation of a VideoStore.
	/// </summary>
	public class VideoStore
	{
		private string [][] store_Inventory; /// Class data members
		private string filename;
		private static int size;

		public bool testFlag1, testFlag2, testFlag3, testFlag4;

		public VideoStore() /// Class constructor
		{
			testFlag1 = testFlag2 = testFlag3 = testFlag4 = false;
		}

		public void processInventory() /// Called within main which in 
		{							   /// turn calls the private methods
			Console.Write( "Using input file: 10000words.txt" );
			///filename = Console.ReadLine();
			filename = "10000words.txt";
			readInventory( openInventory( filename ) );
			writeInventory();
		}

		private	void writeInventory()
		{
			int rows = size / 2, cols = 2;
			for( int ix = 0; ix < rows; ++ix )
				for( int iy = 0; iy < cols; ++iy )
					Console.WriteLine( store_Inventory[ix][iy] );
		}

		private	void initJaggedArray( int rows, int cols )
		{
			store_Inventory = new string[rows][];
			for( int ix = 0; ix < rows; ++ ix )
				store_Inventory[ix] = new String[2];
		}

		private	void readInventory( StreamReader f_reader )
		{
			int count = 0;
			while( ( f_reader.ReadLine() ) != null )
				size = count++;
			f_reader.Close();
			f_reader = openInventory( filename );
			int rows = count / 2, cols = 2;
			initJaggedArray( rows, cols );

			for( int ix = 0; ix < rows; ++ix )
				for( int iy = 0; iy < cols; ++iy )
					store_Inventory[ix][iy] = f_reader.ReadLine();
		}

		private	StreamReader openInventory( string file_name )
		{
			if( file_name == null )
			{
				testFlag1 = true;
				throw new ArgumentNullException();
			}
			else if( !File.Exists(file_name) )
			{
				testFlag2 = true;
				string message = "Invalid file name: " + file_name;

				throw new ArgumentException( message );
			}
			else if( !file_name.EndsWith(".txt") )
			{
				testFlag3 = true;
				string message = "\nSupport is only provided for .txt files." +
					"\nUsage: Video Store [InventoryList.txt]";

				throw new Exception( message );
			}

			return File.OpenText( file_name );

		}  /// openInventory

		public static int Main()
		{
			Console.WriteLine( "Begin inventory analysis ... " );

			VideoStore store = new VideoStore();

			store.processInventory();

			Console.WriteLine( "End inventory analysis ... " );
			if( store.testFlag1 == true )
				return 1;
			else if( store.testFlag2 == true )
				return 2;
			else if( store.testFlag3 == true )
				return 3;
			else if( store.testFlag4 == true )
				return 4;
			else
				return 0;
		}
	}  /// public class VideoStores
}	/// namespace Video_Stores
