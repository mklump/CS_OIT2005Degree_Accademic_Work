using System;
using System.IO;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;

namespace EncryptionExtension {
	public class EncExtension : SoapExtension {
		Stream oldStream;
		MemoryStream newStream;

		public override object GetInitializer(Type serviceType) {
			return null;
		}

		public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) {
			return null;
		}

		public override void Initialize(object initializer) {
		}

		public override void ProcessMessage( SoapMessage msg ) {
			switch( msg.Stage ) {
				case SoapMessageStage.BeforeSerialize:
					SoapHeader head = new MyHeader();
					head.DidUnderstand = true;
					msg.Headers.Add( head );
					break;
				case SoapMessageStage.AfterSerialize:
					Encrypt( msg );
					break;
				case SoapMessageStage.BeforeDeserialize:
					byte[] bytes = new byte[oldStream.Length];
					oldStream.Read( bytes, 0, (int) oldStream.Length);
					newStream.Write( bytes, 0, (int) oldStream.Length );
					newStream.Seek( 0, SeekOrigin.Begin );
					break;
				case SoapMessageStage.AfterDeserialize:
					break;
			}
		}

		public override Stream ChainStream( Stream stream ) {
			oldStream = stream;
			newStream = new MemoryStream();
			return newStream;
		}

		private void Encrypt( SoapMessage msg ) {
			Stream stream = msg.Stream;
			stream.Position = 0;
			StreamReader sr = new StreamReader( stream );

			XmlDocument xdoc = new XmlDocument();
			xdoc.LoadXml( sr.ReadToEnd() );

			try {
				XmlNamespaceManager xnm = new XmlNamespaceManager( xdoc.NameTable );
				xnm.AddNamespace( "soap", "http://schemas.xmlsoap.org/soap/envelope/" );
				XmlNode body = xdoc.SelectSingleNode( "//soap:Body", xnm );
				body.ChildNodes[0].FirstChild.InnerText = "qijuifhjnhasjdhfi";
			} catch( Exception e ) {
				System.Diagnostics.Debug.Write( e.ToString() );
			}

			MemoryStream ms = new MemoryStream();
			XmlTextWriter xtw = new XmlTextWriter( ms, System.Text.Encoding.UTF8 );

			xdoc.Save( xtw );
			ms.Position = 0;
			Copy( ms, oldStream );
		}

		void Copy( Stream from, Stream to ) {
			TextReader reader = new StreamReader( from );
			TextWriter writer = new StreamWriter( to );
			writer.WriteLine( reader.ReadToEnd() );
			writer.Flush();
		}
	}

	public class MyHeader : SoapHeader {
		public string HelloWorld = "HelloWorld";
	}
}
