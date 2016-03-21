using System;
using System.IO;
using System.Threading;
using System.Web.Services.Protocols;
using CompressionClient.localhost;
using ICSharpCode.SharpZipLib.BZip2;

namespace CompressionClient
{
	/// <summary>
	/// Summary description for ClassCompressionClient.
	/// </summary>
	class ClassCompressionClient
	{
		private static byte[][] decimals;
		private static string projectLOC;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				CompressionService service = new CompressionService();
				projectLOC = @"C:\Documents and Settings\Matthew Klump\My Documents\" + 
							 @"Visual Studio Projects\Accademic_Work\CST 407 Web Services " + 
							 @"with .NET\Home Work #6\SoapBZip2Data_Compression_Solutions\" + 
							 @"SoapBZip2Data_Compression\bin\";

				//IAsyncResult asi = service.BeginGetLargeStructure(new AsyncCallback(CallBackGet), service);
				//WaitHandle wh = asi.AsyncWaitHandle;

				decimals = service.GetLargeStructure();
				Console.WriteLine("Result of Get Decimals:");
				for( int x = 0; x < decimals.Length; ++x )
					Console.WriteLine("{0}", decimals[x].ToString());

				byte [][] newdecimals = new byte[99][];
				for( int x = 0; x < newdecimals.Length; ++x )
				{
					newdecimals[x] = new byte[12];
					for(int y = 0; y < 12; ++y )
					{
						int nextint = (x + y + 1) > 255 ? (-x - y + 1) : (x + y + 1);
						nextint = nextint < -252 ? (x - x + y + 1) : nextint;
						newdecimals[x][y] = Convert.ToByte( nextint );
					}
				}
				//			WaitHandle.WaitAll( new WaitHandle [] { wh } );
				//			asi = service.BeginSetLargeStructure( newdecimals, new AsyncCallback(CallBackSet), service );
				//			wh = asi.AsyncWaitHandle;
				//			WaitHandle.WaitAll( new WaitHandle [] { wh } );
				//			asi = service.BeginGetLargeStructure(new AsyncCallback(CallBackGet), service );
				//			wh = asi.AsyncWaitHandle;
				//			WaitHandle.WaitAll( new WaitHandle [] { wh } );

				bool val = service.SetLargeStructure( newdecimals );
				Console.WriteLine("The result of saving data set is {0}.", val);
				decimals = service.GetLargeStructure();
				Console.WriteLine("Result of Get Decimals second time:");
				for( int x = 0; x < decimals.Length; ++x )
					Console.WriteLine("{0}", decimals[x].ToString());
			}
			catch(SoapException e)
			{
				StreamWriter error = new StreamWriter( projectLOC + "error.txt", false );
				error.Write( e.ToString() );
				error.Close();
			}
			catch(Exception e)
			{
				StreamWriter error = new StreamWriter( projectLOC + "error.txt", false );
				error.Write( e.ToString() );
				error.Close();
			}
			finally
			{
			}
		}

		private static void CallBackGet(IAsyncResult isa)
		{
			CompressionService s = (CompressionService) isa.AsyncState;
			byte[][] bytes = s.EndGetLargeStructure(isa);
			decimals = bytes;
			for( int x = 0; x < bytes.Length; ++x )
				Console.WriteLine("{0}", bytes[x].ToString());
		}

		private static void CallBackSet(IAsyncResult isa)
		{
			CompressionService s = (CompressionService) isa.AsyncState;
			bool val = s.EndSetLargeStructure( isa );
			Console.WriteLine("The result of saving data set is {0}.", val);
		}
	}

	/// <summary>
	/// Class ClientCommunication
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class ClientCommunication : SoapExtensionAttribute
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
		public ClientCommunication()
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
					break;
				case SoapMessageStage.AfterSerialize:
					BZip2.Compress( oldStream, newStream, 1 );
					break;
				case SoapMessageStage.BeforeDeserialize:
					BZip2.Decompress( oldStream, newStream );
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
//			oldStream.Seek( 0, SeekOrigin.Begin );
//			int nextbyte = 0;
//			while( ( nextbyte = oldStream.ReadByte() ) != -1 )
//			{
//				newStream.WriteByte( (byte) nextbyte );
//			}
			return newStream;
		}
	}
	
}
