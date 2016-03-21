using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.BZip2 
{
	
	/// <summary>
	/// Does all the compress and decompress pre-operation stuff.
	/// Sets up the streams and file header characters.
	/// Uses multiply overloaded methods to call for the compress/decompress.
	/// </summary>
	public sealed class BZip2
	{
		/// <summary>
		/// Decompress <paramref name="instream">input</paramref> writing 
		/// decompressed data to <paramref name="outstream">output stream</paramref>
		/// </summary>
		public static void Decompress(Stream instream, Stream outstream) 
		{
			System.IO.Stream bos = outstream;
			System.IO.Stream bis = instream;
			BZip2InputStream bzis = new BZip2InputStream(bis);
			int ch = bzis.ReadByte();
			while (ch != -1) {
				bos.WriteByte((byte)ch);
				ch = bzis.ReadByte();
			}
			bos.Flush();
		}
		
		/// <summary>
		/// Compress <paramref name="instream">input stream</paramref> sending 
		/// result to <paramref name="outputstream">output stream</paramref>
		/// </summary>
		public static void Compress(Stream instream, Stream outstream, int blockSize) 
		{			
			System.IO.Stream bos = outstream;
			System.IO.Stream bis = instream;
			int ch = bis.ReadByte();
			BZip2OutputStream bzos = new BZip2OutputStream(bos, blockSize);
			while (ch != -1) {
				bzos.WriteByte((byte)ch);
				ch = bis.ReadByte();
			}
			bis.Close();
			bzos.Close();
		}
	}
}

