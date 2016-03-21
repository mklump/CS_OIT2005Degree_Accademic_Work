#region "Far too many using statements."
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Xml;
using System.Web.Services;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
// BZip2 namespace specific:
using ICSharpCode.SharpZipLib.BZip2;
#endregion

namespace SoapBZip2Data_Compression
{
	/// <summary>
	/// Summary description for CompressionService.
	/// </summary>
	[WebService(Namespace="http://localhost/mywebprojects/SoapBZip2Data_Compression")]
	public class CompressionService : System.Web.Services.WebService
	{
		public ClassLargeStructure structure;
		public string projectLOC;

		public CompressionService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
			structure = new ClassLargeStructure();
			projectLOC = @"C:\Documents and Settings\Nostro\My Documents\Visual Studio Projects\" + 
						 @"Accademic_Work\CST 407 Web Services with .NET\PractiseWebService\" + 
						 @"SoapBZip2Data_Compression\bin\";
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
		[CompressionExtensionAttribute]
		[SoapDocumentMethod(ParameterStyle=SoapParameterStyle.Bare)]
		public bool SetLargeStructure( byte [][] your_structure )
		{
			structure.data = your_structure;
			FileStream fsIN = new FileStream( projectLOC + "data.xml", FileMode.OpenOrCreate);

			XmlSerializer ser = new XmlSerializer( typeof(byte[][]),
				"http://localhost/mywebprojects/CompressionService/data");
			ser.Serialize( fsIN, structure.data );
			fsIN.Close();
			return structure.data.Equals(your_structure);
		}

		[WebMethod]
		[CompressionExtensionAttribute]
		[SoapDocumentMethod(ParameterStyle=SoapParameterStyle.Bare)]
		public byte[][] GetLargeStructure()
		{
			FileStream fsOUT = new FileStream( projectLOC + "data.xml", FileMode.OpenOrCreate );

			XmlSerializer ser = new XmlSerializer( typeof(byte[][]),
				"http://localhost/mywebprojects/CompressionService/data");
			byte [][] retval = (byte[][]) ser.Deserialize( fsOUT );
			fsOUT.Close();
			return retval;
		}
	}
	/// <summary>
	/// Class ClassLargeStructure
	/// </summary>
	public class ClassLargeStructure : SoapHeader
	{
		public byte [][] data;
		private Random rand;

		/// <summary>
		/// Default constructor
		/// </summary>
		public ClassLargeStructure()
		{
			rand = new Random();
			data = new byte[99][];
			for( int x = 0; x < data.Length; ++x )
			{
				data[x] = new byte[12];
				rand.NextBytes( data[x] );
			}
			XmlSerializer ser = new XmlSerializer( typeof(byte[][]),
				"http://localhost/mywebprojects/CompressionService/data" );
			FileStream fsout = new FileStream( new CompressionService().projectLOC + "data.xml", FileMode.OpenOrCreate );

			ser.Serialize( fsout, data );
			fsout.Close();
		}
	}
	
	/// <summary>
	/// Class CompressionExtensionAttribute
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class CompressionExtensionAttribute : SoapExtensionAttribute
	{
		private int priority;

		/// <summary>
		/// ExtensionType Override
		/// </summary>
		public override Type ExtensionType
		{
			get
			{
				return typeof(CompressionExtension);
			}
		}
		/// <summary>
		/// Priority Integer Override
		/// </summary>
		public override int Priority
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
			}
		}
		/// <summary>
		/// Default constructor
		/// </summary>
		public CompressionExtensionAttribute()
		{
			priority = 1;
		}
	}
	
	/// <summary>
	/// Class CompressionExtension
	/// </summary>
	public class CompressionExtension : SoapExtension
	{
		public Stream oldStream;
		public MemoryStream newStream;

		/// <summary>
		/// Default constructor
		/// </summary>
		public CompressionExtension()
		{
			oldStream = null;
			newStream = null;
		}
		/// <summary>
		/// Must be overriden
		/// </summary>
		/// <param name="methodInfo"></param>
		/// <param name="attribute"></param>
		/// <returns></returns>
		public override object GetInitializer(
									LogicalMethodInfo methodInfo,
									SoapExtensionAttribute attribute)
		{
			return null;
		}
		/// <summary>
		/// Another required override
		/// </summary>
		/// <param name="serviceType"></param>
		/// <returns></returns>
		public override object GetInitializer(Type serviceType)
		{
			return null;
		}
		/// <summary>
		/// Yet another required override
		/// </summary>
		/// <param name="initializer"></param>
		public override void Initialize(object initializer)
		{	
		}
		/// <summary>
		/// And now the method we've needed all along...
		/// </summary>
		/// <param name="message"></param>
		public override void ProcessMessage(SoapMessage message)
		{
			switch(message.Stage)
			{
				case SoapMessageStage.BeforeSerialize:
					SoapHeader head = new ClassLargeStructure();
					head.DidUnderstand = true;
					message.Headers.Add( head );
					break;
				case SoapMessageStage.AfterSerialize:
					// At this level I completely missed the fact that: To send any data at all
					// back to the client, you MUST do so manually by selecting the enc:body
					// element of the SOAP message using XPath navigator and THEN insert your data
					// for the client!
					PrepareDataEncryption( message );
					break;
				case SoapMessageStage.BeforeDeserialize:
//					oldStream.Seek( 0, SeekOrigin.Begin );
//					int nextbyte = 0;
//					while( ( nextbyte = oldStream.ReadByte() ) != -1 )
//					{
//						newStream.WriteByte( (byte) nextbyte );
//					}
//					BZip2.Decompress( oldStream, newStream );
//					newStream.Seek( 0, SeekOrigin.Begin );

					byte[] bytes = new byte[oldStream.Length];
					oldStream.Read( bytes, 0, (int) oldStream.Length);
					newStream.Write( bytes, 0, (int) oldStream.Length );
					newStream.Seek( 0, SeekOrigin.Begin );

					break;
				case SoapMessageStage.AfterDeserialize:
					break;
				default:
					break;
			}
		}
		/// <summary>
		/// Needed to replace the network stream with
		/// my own buffered stream.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public override Stream ChainStream(Stream stream)
		{
			oldStream = stream;
			newStream = new MemoryStream();
			return newStream;
		}
		/// <summary>
		/// Prepares the data with encrption inside the SOAP body 
		/// to send back to the client when used with "GetLargeStructure."
		/// </summary>
		/// The SoapMessage parameter <param name="message"> specifies what SOAP message to work with.</param>
		private void PrepareDataEncryption( SoapMessage message )
		{
			Stream msgStream = message.Stream;
			msgStream.Position = 0;
			StreamReader sr = new StreamReader( msgStream );

			XmlDocument xdoc = new XmlDocument();
			xdoc.LoadXml( sr.ReadToEnd() );

			try 
			{
				XmlNamespaceManager xnm = new XmlNamespaceManager( xdoc.NameTable );
				xnm.AddNamespace( "soap", "http://schemas.xmlsoap.org/soap/envelope/" );
				XmlNode body = xdoc.SelectSingleNode( "//soap:Body", xnm );
				body.ChildNodes[0].FirstChild.InnerText = "ASDFJKL:";
			} 
			catch( Exception e ) 
			{
				System.Diagnostics.Debug.Write( e.ToString() );
			}

			MemoryStream ms = new MemoryStream();
			XmlTextWriter xtw = new XmlTextWriter( ms, System.Text.Encoding.UTF8 );

			xdoc.Save( xtw );
			ms.Position = 0;
			//BZip2.Compress( ms, oldStream, 1 );
			CopyStream( ms, oldStream );
		}

		private void CopyStream( Stream from, Stream to ) 
		{
			TextReader reader = new StreamReader( from );
			TextWriter writer = new StreamWriter( to );
			writer.WriteLine( reader.ReadToEnd() );
			writer.Flush();
		}
	}

}
