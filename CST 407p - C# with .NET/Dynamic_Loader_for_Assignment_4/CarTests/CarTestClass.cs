///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Assignment #3
/// Date Created:   October 20, 2002
/// Last Change Date:  October 20, 2002
/// Project:        Car_ClassLibrary
/// Filename:       CarTestClass.cs
///
/// Overview:  This file containg the interface for the Car object
///			  hierarchy. This code is meant to demonstrate practise
///			  for writing good object oriented design and software
///			  solution.
///
/// Input:	  No Input is accepted.
/// Output:	  Output is written to a file "output.txt"
///-------------------------------------------------------------------

using System;
using System.IO;
using System.Diagnostics;
using NUnit.Framework;
using Car_ClassLibrary;
using Dynamic_Loader;

#region "namespace testHarness_Car implementation"
namespace testHarness_Car
{
	/// </summary>
	/// Summary description for testHarness_Car.
	/// </summary>
	[TestFixture]
	public class CarTestClass
	{
		private Car      m_car;    // Gemeric base class object
		private object   ob;		 // Typeless object for testing
		private FileStream myOutput;	// For testing output
		private TextWriterTraceListener myWriter;

		public CarTestClass()
		{
			ob = new Object();
			m_car = new Van();
			/* Create a listener, which outputs to a file "output.txt", and 
			* add it to the trace listeners. */
			myOutput = new FileStream( "output.txt", FileMode.OpenOrCreate, FileAccess.Write );
			myWriter = new TextWriterTraceListener( myOutput );
			Trace.Listeners.Add(myWriter);
		}
		[SetUp]
		public void Setup_Testing()
		{
		}
		[TearDown]
		public void Dispose_Testing()
		{
			//Trace.Close();
		}
		[Test]
		public void Test_Car()
		{
			Type checksum;
			checksum = ob.GetType();
			Trace.WriteLine("Now testing to see if the object is a car.");
			try 
			{
				Assertion.Assert( "Sepcified object is not a car.",
					checksum.IsInstanceOfType(Type.GetType("Car")) );

			}
			catch( NullReferenceException except )
			{
				Trace.WriteLine( except.Message );
			}
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}						    
		[Test]
		public void Test_Van()
		{
			Type checksum;
			checksum = ob.GetType();
			Trace.WriteLine("Now testing to see if the object is a Van.");
			try 
			{
				Assertion.Assert( "Sepcified object is not a Van.",
					checksum.IsInstanceOfType(Type.GetType("Van")) );
			}
			catch( NullReferenceException except )
			{
				Trace.WriteLine( except.Message );
			}
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Truck()
		{
			Type checksum;
			checksum = ob.GetType();
			Trace.WriteLine("Now testing to see if the object is a Truck.");
			try 
			{
				Assertion.Assert( "Sepcified object is not a Truck.",
					checksum.IsInstanceOfType(Type.GetType("Truck")) );
			}
			catch( NullReferenceException except )
			{
				Trace.WriteLine( except.Message );
			}
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Station_Wagon()
		{
			Type checksum;
			checksum = ob.GetType();
			Trace.WriteLine("Now testing to see if the object is a Station Wagon.");
			try 
			{
				Assertion.Assert( "Sepcified object is not a Station Wagon.",
					checksum.IsInstanceOfType(Type.GetType("Station_Wagon")) );
						}
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
			catch( NullReferenceException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Make()
		{
			bool bMake = false;
			Make [] checksum = new Make[6]
				{
						Make.Toyota, Make.Nissan, Make.Ford,
					Make.Chevy, Make.SAAB, Make.Voltswagon };
			Trace.WriteLine("Now checking to see if that Make is in inventory.");
			foreach( Make ma in checksum )
				bMake = (m_car.prop_Make == ma) ? true : false;
			try 
			{
				Assertion.Assert("Specified make is not in inventory",	bMake);
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Model()
		{
			bool bModel = false;
			Model [] checksum = new Model[6]
				{
						Model._2_Door, Model._4_Door, Model.Convertable,
					Model.Econo_line, Model.Extracab, Model.Kingsize };
			Trace.WriteLine("Now checking to see if specified model is available.");
			foreach( Model mo in checksum )
				bModel = (m_car.prop_Model == mo) ? true : false;
			try 
			{
				Assertion.Assert("Specified model is not available.", bModel);
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Window()
		{
			Test_Car();
			try 
			{
				Assertion.Assert("The windows are down.", m_car.Windows );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Engine()
		{
			try 
			{
				Assertion.Assert("Specified engine is not valid",
					m_car.Engine < 0 || m_car.Engine > 16 );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Wheels()
		{
			try 
			{
				Assertion.Assert("Specified wheels are not valid",
					m_car.Wheels < 0 || m_car.Wheels > 46 );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_SideDoor()
		{
			Van van = new Van();
			van.OpenSideDoor();
			try
			{
				Assertion.Assert("The side door of the van is open",
					van.Side_door);
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_TowingCapacity()
		{
			Truck truck = new Truck();
			truck.DecreaseTowingCapacity();
			try 
			{
				Assertion.Assert("You don't have enough towing capacity.",
					truck.TowingCapacity < 1200 );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_PassengerSize()
		{
			Station_Wagon station_wagon = new Station_Wagon();
			station_wagon.DecreasePassengerSize();
			try 
			{
				Assertion.Assert("Get an SUV, your station wagon is too small.",
					station_wagon.PassengerSize < 6 );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_TV()
		{
			Trace.WriteLine("Now checking the TV set.");
			Van van = new Van();
			try
			{
				Assertion.Assert( "Someone left the TV on!", van.Onboard_TV );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_AirConditioning()
		{
			Trace.WriteLine("Now checking the air conditioning.");
			Van van = new Van();
			try
			{
				Assertion.Assert( "Someone left the air conditioning on!",
					van.Air_Conditioning );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_FourWheelDrive()
		{
			Trace.WriteLine("Now checking four wheel drive.");
			Truck truck = new Truck();
			try
			{
				Assertion.Assert( "The four wheel drive is disengaged.",
					truck.FourWheelDrive );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_TailGate()
		{
			Trace.WriteLine("Now checking test flag 4.");
			Truck truck = new Truck();
			try
			{
				Assertion.Assert( "Your tailgate is open.", truck.TailGate );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Check_On_Kids()
		{
			Trace.WriteLine("Now checking on the children.");
			Trace.WriteLine("Are we there yet?");
			Station_Wagon station_wagon = new Station_Wagon();
			try
			{
				Assertion.Assert( "The kids are misbehaving.",
					station_wagon.Crying_Kids );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Parents()
		{
			Trace.WriteLine("Now checking on the parents.");
			Station_Wagon station_wagon = new Station_Wagon();
			station_wagon.HaveSisterGiveBrotherNoogies();
			Trace.WriteLine("If you don't stop this instant, neither");
			Trace.WriteLine("of you get ice cream!");
			station_wagon.HaveParentsThreatenToTurnCarAround();
			station_wagon.HaveParentsCheckOnKids();
			try
			{
				Assertion.Assert( "Well, they almost took that well.",
					station_wagon.Annoyed_Parents );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Airplane()
		{
			Trace.WriteLine("Now checking aircraft plane object.");
			Plane airplane = new Plane();
			bool pilots = true, passengers = true, flightattendants = true;
			try
			{
				Assertion.Assert( "The wings are retracted.", airplane.Wings );
				if( airplane.NumberOfPilots < 4 )
				{
					Trace.WriteLine("Not enough pilots present to fly the plane.");
					pilots = false;
				}
				else if( airplane.NumberOfPassengers < 60 )
				{
					Trace.WriteLine("You did not sell enough tickets.");
					passengers = false;
				}
				else if( airplane.NumberOfFlightAttendents < 6 )
				{
					Trace.WriteLine("Not enough flight attendants " +
						"for this flight.");
					flightattendants = false;
				}
				Assertion.Assert( "An exception occured with the passengers or the " +					"flight crew.", pilots || passengers || flightattendants );
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_Train()
		{
			Trace.WriteLine("Now checking train object.");
			Train train = new Train();
			bool engineers = true, boxcars = true,
				passengers = true, attendents = true;

			try
			{
				if( train.Engineers < 4 )
				{
					Trace.WriteLine("Not enough engineers to operate the train.");
					engineers = false;
				}
				else if( train.NumberOfPassengers < 100 )
				{
					Trace.WriteLine("You did not sell enough tickets.");
					passengers = false;
				}
				else if( train.NumberOfBoxcars < 16 )
				{
					Trace.WriteLine("Not enough boxcars to make up a full train.");
					boxcars = false;
				}
				else if( train.NumberOfAttendents < 10 )
				{
					Trace.WriteLine("Not enough attendents to service the train.");
					attendents = false;
				}
				Assertion.Assert( "An exception occured with the passengers " +
					"or the crew.", engineers || boxcars ||	passengers || attendents);
			}		
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		[Test]
		public void Test_DynamicLoader()
		{
			DynamicLoader loader = new DynamicLoader();			
		}

		[Test]
		public void AnotherTest()
		{
			Car [] testCars = new Car[4];
			CarTestClass testobj = this;
			Trace.WriteLine("Now checking Main()");
			int ix;
			for( ix = 0; ix < 4; ++ix )
			{
				switch(ix)
				{
					case 0:
						testCars[ix] = new Truck();
						ob = testCars[ix];
						testobj.Test_Car();
						break;
					case 1:
						testCars[ix] = new Van();
						ob = testCars[ix];
						testobj.Test_Car();
						break;
					case 2:
						testCars[ix] = new Truck();
						ob = testCars[ix];
						testobj.Test_Car();
						break;
					case 3:
						testCars[ix] = new Station_Wagon();
						ob = testCars[ix];
						testobj.Test_Car();
						break;
					default:
						break;
				}
				ob = m_car = testCars[ix];
				testobj.Test_Make();
				testobj.Test_Model();
				testobj.Test_Window();
				testobj.Test_Engine();
				testobj.Test_Wheels();
				testobj.Test_SideDoor();
				testobj.Test_TowingCapacity();
				testobj.Test_PassengerSize();
				testobj.Test_DynamicLoader();
			}
			try
			{
				Assertion.AssertEquals("Indexer ix did not finish its loop", 3, ix);
			}
			catch( AssertionException except )
			{
				Trace.WriteLine( except.Message );
			}
		}
		public static void Main()
		{
			CarTestClass test = new CarTestClass();
			test.Test_AirConditioning();
			test.Test_Engine();
			test.Test_Airplane();
			test.Test_FourWheelDrive();
			test.Test_Make();
			test.Test_Model();
			test.Check_On_Kids();
			test.Test_Parents();
			test.Test_PassengerSize();
			test.Test_SideDoor();
			test.Test_Station_Wagon();
			test.Test_TailGate();
			test.Test_TowingCapacity();
			test.Test_Train();
			test.Test_Truck();
			test.Test_TV();
			test.Test_Van();
			test.Test_Wheels();
			test.Test_Window();
			test.AnotherTest();
		}
	} // class CarTestClass

} // namespace testHarness_Car
#endregion // "namespace testHarness_Car implementation"