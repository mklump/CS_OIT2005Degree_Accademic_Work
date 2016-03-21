using System;
using System.IO;
using System.Collections;
using System.Reflection;
using Car_ClassLibrary;

namespace Dynamic_Loader
{
	/// <summary>
	/// Summary description for DynamicLoader.
	/// </summary>
	public class DynamicLoader
	{
		private Assembly assembler;
		private ArrayList list;

		public DynamicLoader()
		{
			list = new ArrayList();
			Dynamically_Load_Car_ClassLibrary_Objects();
		}
		/// <summary>
		/// Property Assemble (Assembly)
		/// </summary>
		public Assembly Assembler
		{
			get
			{
				return this.assembler;
			}
			set
			{
				this.assembler = value;
			}
		}
		/// <summary>
		/// Property List (ArrayList)
		/// </summary>
		public ArrayList List
		{
			get
			{
				return this.list;
			}
			set
			{
				this.list = value;
			}
		}
		public void Dynamically_Load_Car_ClassLibrary_Objects()
		{
			string	   fname = @"..\..\..\App.config";
			FileStream fstream = new FileStream( fname, FileMode.Open );

			System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader( fstream );
			System.Data.DataSet myDataSet = new System.Data.DataSet("My Data Set");
			
			myDataSet.ReadXml( xmlReader );
			xmlReader.Close();

			foreach(System.Data.DataTable table in myDataSet.Tables)
			{
				foreach(System.Data.DataRow row in table.Rows)
				{
					for(int column = 0; column < 1; ++column)
					{
						list.Add( row[column].ToString() );
					}
				}
			}

			IEnumerator myEnum = list.GetEnumerator();
			myEnum.Reset();
			myEnum.MoveNext();			// Move Enumerator from position 0 to 1
			while( myEnum.MoveNext() )
			{
				CreateInstance( myEnum.Current );
				list.Remove( myEnum.Current );
			}
		}
		public void CreateInstance( object type )
		{
			object [] actAttribs = { "URLAttribute(http://tempuri.org/App.xsd)" };
			string typename = (string)type;
            Car carObj = new Car();
			switch( typename )
			{
				case "Car":
					carObj = (Car)carObj;
					break;
				case "Van":
					carObj = (Van)carObj;
					break;
				case "Truck":
					carObj = (Truck)carObj;
					break;
				case "Station_Wagon":
					carObj = (Station_Wagon)carObj;
					break;
				case "Plane":
					carObj = (Plane)carObj;
					break;
				case "Train":
					carObj = (Train)carObj;
					break;
				default:
					break;
			}

			assembler.CreateInstance( carObj.ToString(), false,
				BindingFlags.Instance, null, null, 
				System.Globalization.CultureInfo.CurrentCulture,
				actAttribs );
		}

	}
}
