using System;
using System.Diagnostics;
using NUnit.Framework;
using Video_Store;

namespace ClassLibraryVideoStore
{
	/// <summary>
	/// This class library represents the test cases for
	/// the VideoStore class.
	/// </summary>
	[TestFixture]
	public class TestClass
	{
		int result = VideoStore.Main();
		[Test]
		public void TestingFlag1()
		{
			Trace.WriteLine( result );
			Assertion.Assert( result != 1 );
		}
		[Test]
		public void TestingFlag2()
		{
			Trace.WriteLine( result );
			Assertion.Assert( result != 2 );
		}
		[Test]
		public void TestingFlag3()
		{
			Trace.WriteLine( result );
			Assertion.Assert( result != 3 );
		}
		[Test]
		public void TestingFlag4()
		{
			Trace.WriteLine( result );
			Assertion.Assert( result != 4 );
		}
		[Test]
		[IgnoreTest]
		public void LastTest()
		{
			Trace.WriteLine( result );
			Assertion.Assert( result == 0 );
		}
	}
}
