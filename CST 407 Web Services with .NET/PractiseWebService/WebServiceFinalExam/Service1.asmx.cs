using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Services;

namespace CST407_FinalExam
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	[WebService(Namespace="http://CST407/WebServicesApplied/FinalExam")]
	public class Service1 : System.Web.Services.WebService
	{
		public string projectLOC;
		public RememberedThing[] data;
		private FileStream fs;

		public Service1()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
			projectLOC = @"C:\Documents and Settings\Matthew Klump\My Documents\Visual Studio " + 
						 @"Projects\Accademic_Work\CST 407 Web Services with .NET\PractiseWebService\" + 
						 @"WebServiceFinalExam\bin\";
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod]
		public void Remember(string valueToRemember)
		{
			fs = new FileStream( projectLOC + "data.xml", FileMode.OpenOrCreate, FileAccess.Read );
			if( fs.Length != 0 )
				data = (RememberedThing[]) new XmlSerializer(typeof(RememberedThing[])).Deserialize( fs );
			else
				data = new RememberedThing[100];

			for( int x = 0; x < data.Length; ++x )
			{
				if( data[x] == null )
				{
					string whatToRemember = valueToRemember + " Remembered at: " + DateTime.Now.ToString();
					data[x] = new RememberedThing( DateTime.Now, whatToRemember );
					break;
				}
			}
			fs.Close();

			// Store the data as an XML document "data.xml"
			FileStream fs_ = new FileStream( projectLOC + "data.xml", FileMode.Create, FileAccess.Write );
			XmlSerializer ser = new XmlSerializer( typeof(RememberedThing[]) );
			ser.Serialize( fs_, data );
			fs_.Close();
			return;
		}

		[WebMethod]
		public void Forget()
		{
			data = new RememberedThing[100];
			try
			{
				// Store the now blank data array.
				fs = new FileStream( projectLOC + "data.xml", FileMode.Create );
				XmlSerializer ser = new XmlSerializer( typeof(RememberedThing[]) );
				ser.Serialize( fs, data );
			}
			catch( XmlException e )
			{
				Trace.WriteLine( e.ToString() );
			}
			finally
			{
				fs.Close();
			}
		}

		[WebMethod]
		public RememberedThing[] Regurgitate()
		{
			RememberedThing[] retval = null;
			try
			{
				fs = new FileStream( projectLOC + "data.xml", FileMode.OpenOrCreate, FileAccess.Read );
				XmlSerializer ser = new XmlSerializer( typeof(RememberedThing[]) );
				retval = (RememberedThing[]) ser.Deserialize( fs );
			}
			catch( XmlException e )
			{
				Trace.WriteLine( e.ToString() );
			}
			finally
			{
				fs.Close();
			}
			return retval;
		}
	}
}
