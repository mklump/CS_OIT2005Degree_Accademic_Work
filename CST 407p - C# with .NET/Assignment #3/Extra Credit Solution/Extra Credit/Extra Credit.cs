///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Assignment #3
/// Date Created:   October 20, 2002
/// Last Change Date:  October 20, 2002
/// Project:        Extra Credit
/// Filename:       Extra Credit.cs
///
/// Overview:  This file contains the interface for the Extra Credit
///			   object along with Main() for testing.
///			   Note to Scott Hanselman:
///			   To this program's very core it took precisely one line
///			   of executeable code to have this extra credit ready to go.
///			   All the extra stuff with CallMain() is so I could
///			   keep Nunit from complaining about "Main() not called: Make
///			   sure the fuction is an instance medthod."
///
/// Input:	  No Input is accepted.
/// Output:	  Output is written to the Console.
///-------------------------------------------------------------------
using System;
using System.IO;
using NUnit.Framework;

namespace Extra_Credit
{
	/// <summary>
	/// Summary description for Extra_Credit.
	/// </summary>
	[TestFixture]
	public class ExtraCredit
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[Test]
		[STAThread]
		public static int Main()
		{
			StreamWriter ofstream = new StreamWriter("output.txt", false);
			StreamReader ifstream = new StreamReader((Stream)File.OpenRead("input.txt"));
			
			ifstream.BaseStream.Seek(0, SeekOrigin.Begin);
			while( ifstream.Peek() != -1 )
				ofstream.WriteLine( DateTime.IsLeapYear(
					Convert.ToInt32(ifstream.ReadLine())) );

			ifstream.Close();
			ofstream.Close();
			return 0;
		}
	}
}

