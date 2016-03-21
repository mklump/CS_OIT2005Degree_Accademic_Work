///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Assignment #3
/// Date Created:   October 20, 2002
/// Last Change Date:  October 20, 2002
/// Project:        Car_ClassLibrary
/// Filename:       Car_Classes.cs
///
/// Overview:  This file containg the interface for the Car object
///			  hierarchy. This code is meant to demonstrate practise
///			  for writing good object oriented design and software
///			  solution.
///
/// Input:	  No Input is accepted.
/// Output:	  Output is written to a file "output.txt".
///-------------------------------------------------------------------
///</Intro>

using System;
using System.IO;

//#region "Class Car_ClassLibrary implementation"
namespace Car_ClassLibrary
{
	/// <summary>
	/// Summary description for Car_ClassLibrary.
	/// </summary>

	public enum Make
	{
		Toyota = 1,
		Nissan,
		Ford,
		Chevy,
		SAAB,
		Voltswagon,
		Boeing,
		Amtrack
	}
	public enum Model
	{
		Extracab = 9,
		Kingsize,
		Econo_line,
		Convertable,
		_4_Door,
		_2_Door,
		Seven_Forty_Seven,
		Cascade
	}
	public class EngineSizeException : ApplicationException
	{
		public EngineSizeException() :
			base("Invalid engine size.",
			new System.ArgumentOutOfRangeException(
			"engine", "Recheck your specified engine size.") ) {}
	}
	public class WheelSizeException : ApplicationException
	{
		public WheelSizeException() :
			base("Invalid wheel size.",
			new System.ArgumentOutOfRangeException(
			"wheels", "Recheck your specified wheel radius.") ) {}
	}
	public class Car
	{
		protected Make	make;
		protected Model model;
		protected bool	windows;  // position up or down
		protected int	engine;	  // Expandable and clapsable engine
		protected int	wheels;	  // Expandable and claspable wheel radius

		public Car() // Default constructor
		{
			make = Make.Toyota;
			model = Model.Extracab;
			windows = false;
			engine = 6; // Cubic inch engine
			wheels = 12; // Radial tires
		}
		public Car( Make ma, Model mo, bool win, int eng, int whe )
		{	// Six arguement constructor
			make = ma;
			model = mo;
			windows = win;
			engine = eng;
			wheels = whe;
		}
		protected bool RoleUp()
		{
			return windows = true;
		}
		protected bool RoleDown()
		{
			return windows = false;
		}

		protected virtual int IncreaseEngineSize()
		{	return ++engine;	}
		protected virtual int DecreaseEngineSize()
		{  	return --engine;	}
		protected virtual int IncreaseWheelSize()
		{	return ++wheels;	}
		protected virtual int DecreaseWheelSize()
		{	return --wheels;	}

		/// <summary>
		/// Property Make (Make)
		/// </summary>
		public Make prop_Make
		{
			get
			{
				return this.make;
			}
			set
			{
				this.make = value;
			}
		}
		/// <summary>
		/// Property Model (Model)
		/// </summary>
		public Model prop_Model
		{
			get
			{
				return this.model;
			}
			set
			{
				this.model = value;
			}
		}
		/// <summary>
		/// Property Windows		 (bool)
		/// </summary>
		public bool Windows		
		{
			get
			{
				return this.windows;
			}
			set
			{
				this.windows = value;
			}
		}
		
		/// <summary>
		/// Property Access_Engine (int)
		/// </summary>
		public int Engine
		{
			get
			{
				return this.engine;
			}
			set
			{
				this.engine = value;
			}
		}

		/// <summary>
		/// Property Access_Wheel (int)
		/// </summary>
		public int Wheels
		{
			get
			{
				return this.wheels;
			}
			set
			{
				this.wheels = value;
			}
		}
	} // public Class Car

	public class Van : Car
	{
		private bool side_door;
		private bool onboard_TV;
		private bool air_Conditioning;

		public Van() :
			base( Make.Ford, Model.Econo_line, true, 60, 12 )
		{
			side_door = true; // Meaning open
			onboard_TV = false;
			air_Conditioning = false;
		}
		public Van( Make ma, Model mo, bool win, int eng, int whe, bool side) :
			base( ma, mo, win, eng, whe )
		{ side_door = side; }

		/// <summary>
		/// Property Air_Conditioning (bool)
		/// </summary>
		public bool Air_Conditioning
		{
			get
			{   // read access only
				return this.air_Conditioning;
			}
		}
		/// <summary>
		/// Property Side_door (bool)
		/// </summary>
		public bool Side_door
		{
			get
			{	// read access only
				return this.side_door;
			}
		}
		/// <summary>
		/// Property Onboard_TV (bool)
		/// </summary>
		public bool Onboard_TV
		{
			get
			{   // read access only
				return this.onboard_TV;
			}
		}
		public bool OpenSideDoor()
		{
			return side_door = true;
		}
		public bool CloseSideDoor()
		{
			return side_door = false;
		}
		public bool TurnOnTV()
		{
			return this.onboard_TV = true;
		}
		public bool TurnOn_Air_Conditioning()
		{
			return this.air_Conditioning = true;
		}
		public bool TurnOffTV()
		{
			return this.onboard_TV = false;
		}
		public bool TurnOff_Air_Conditioning()
		{
			return this.air_Conditioning = false;
		}
		protected override int IncreaseEngineSize()
		{
			if( engine > 100 )
				throw new EngineSizeException();
			
			return ++engine;
		}
		protected override int DecreaseEngineSize()
		{
			if( engine < 1 )
				throw new EngineSizeException();
			
			return --engine;
		}
		protected override int IncreaseWheelSize()
		{
			if( wheels > 16 )
				throw new WheelSizeException();
			
			return ++wheels;
		}
		protected override int DecreaseWheelSize()
		{
			if( wheels < 1 )
				throw new WheelSizeException();
			
			return --wheels;
		}
	}
	public class Truck : Car
	{
		private int towingCapacity; // Measured in lbs towing capacity.
		private bool fourWheelDrive;
		private bool tailGate;

		public Truck() :
			base( Make.Ford, Model.Kingsize, false, 6, 12 )
		{
			towingCapacity = 600;
			fourWheelDrive = false; // Four wheel drive is off
			tailGate = true;		// Gate is closed
		}
		public Truck( Make ma, Model mo, bool win, int eng, int whe, int cap ) :
			base( ma, mo, win, eng, whe )
		{ towingCapacity = cap; }

		/// <summary>
		/// Property TowingCapacity (int)
		/// </summary>
		public int TowingCapacity
		{
			get
			{
				return this.towingCapacity;
			}
			set
			{
				this.towingCapacity = value;
			}
		}
		/// <summary>
		/// Property FourWheelDrive (bool)
		/// </summary>
		public bool FourWheelDrive
		{
			get
			{	// read access only
				return this.fourWheelDrive;
			}
		}
		/// <summary>
		/// Property TailGate (bool)
		/// </summary>
		public bool TailGate
		{
			get
			{	// read access only
				return this.tailGate;
			}
		}
		public bool ActivateFourWheelDrive() { return fourWheelDrive = true; }
		public bool DeactivateFourWheelDrive() { return fourWheelDrive = false; }
		public bool OpenTailGate() { return tailGate = true; }
		public bool CloseTailGate() { return tailGate = false; }

		public int IncreaseTowingCapacity()
		{
			return ++towingCapacity;
		}
		public int DecreaseTowingCapacity()
		{
			return --towingCapacity;
		}
		protected override int IncreaseEngineSize()
		{
			if( engine > 400 )
				throw new EngineSizeException();
			
			return ++engine;
		}
		protected override int DecreaseEngineSize()
		{
			if( engine < 1 )
				throw new EngineSizeException();
			
			return --engine;
		}
		protected override int IncreaseWheelSize()
		{
			if( wheels > 42 )
				throw new WheelSizeException();
			
			return ++wheels;
		}
		protected override int DecreaseWheelSize()
		{
			if( wheels < 1 )
				throw new WheelSizeException();
			
			return --wheels;
		}
	}
	public class Station_Wagon : Car
	{
		private int passengerSize;
		private bool crying_Kids;
		private bool annoyed_Parents;

		public Station_Wagon() :
			base( Make.SAAB, Model._4_Door, false, 3, 6)
		{
			passengerSize = 5;
			crying_Kids = false;
			annoyed_Parents = false;
		}
		public Station_Wagon( Make ma, Model mo, bool win,
			int eng, int whe, int pass ) :
			base( ma, mo, win, eng, whe )
		{ passengerSize = pass; }
        
		/// <summary>
		/// Property PassengerSize (int)
		/// </summary>
		public int PassengerSize
		{
			get
			{
				return this.passengerSize;
			}
			set
			{
				this.passengerSize = value;
			}
		}
		/// <summary>
		/// Property Crying_Kids (bool)
		/// </summary>
		public bool Crying_Kids
		{
			get
			{	// read access only
				return this.crying_Kids;
			}
		}
		/// <summary>
		/// Property Annoyed_Parents (bool)
		/// </summary>
		public bool Annoyed_Parents
		{
			get
			{	// read access only
				return this.annoyed_Parents;
			}
		}
		public bool HaveBrotherPullSistersHair() { return crying_Kids = true; }
		public bool HaveSisterGiveBrotherNoogies() { return crying_Kids = true; }
		public bool HaveParentsThreatenToTurnCarAround()
			{ return crying_Kids = false; }
		public bool HaveParentsCheckOnKids()
			{ return annoyed_Parents = crying_Kids ? true : false; }
		public bool LeaveKidsWithSitter() { return annoyed_Parents = false; }

		public int IncreasePassengerSize() { return ++passengerSize; }
		public int DecreasePassengerSize() { return --passengerSize; }

		protected override int IncreaseEngineSize()
		{
			if( engine > 60 )
				throw new EngineSizeException();
			
			return ++engine;
		}
		protected override int DecreaseEngineSize()
		{
			if( engine < 1 )
				throw new EngineSizeException();
			
			return --engine;
		}
		protected override int IncreaseWheelSize()
		{
			if( wheels > 16 )
				throw new WheelSizeException();
			
			return ++wheels;
		}
		protected override int DecreaseWheelSize()
		{
			if( wheels < 1 )
				throw new WheelSizeException();
			
			return --wheels;
		}
	}

	/// <summary>
	/// Class Plane (Car)
	/// </summary>
	public class Plane : Car
	{
		private bool wings; // expandable and retractable wings
		private int numberOfPassengers;
		private int numberOfFlightAttendents;
		private int numberOfPilots;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Plane():
			base(Make.Boeing, Model.Seven_Forty_Seven, true, 1200, 10)
		{
			wings = true; // in the expanded posistion
			numberOfPassengers = 60;
			numberOfFlightAttendents = 6;
			numberOfPilots = 4;
		}		
		/// <summary>
		/// Property Wings (bool)
		/// </summary>
		public bool Wings
		{
			get
			{
				return this.wings;
			}
			set
			{
				this.wings = value;
			}
		}
		/// <summary>
		/// Property NumberOfPassengers (int)
		/// </summary>
		public int NumberOfPassengers
		{
			get
			{
				return this.numberOfPassengers;
			}
			set
			{
				this.numberOfPassengers = value;
			}
		}
		/// <summary>
		/// Property NumberOfPilots (int)
		/// </summary>
		public int NumberOfPilots
		{
			get
			{
				return this.numberOfPilots;
			}
			set
			{
				this.numberOfPilots = value;
			}
		}
		/// <summary>
		/// Property NumberOfFlightAttendents (int)
		/// </summary>
		public int NumberOfFlightAttendents
		{
			get
			{
				return this.numberOfFlightAttendents;
			}
			set
			{
				this.numberOfFlightAttendents = value;
			}
		}
		protected override int IncreaseEngineSize()
		{
			if( engine > 1700 )
				throw new EngineSizeException();
			
			return ++engine;
		}
		protected override int DecreaseEngineSize()
		{
			if( engine < 1 )
				throw new EngineSizeException();
			
			return --engine;
		}
		protected override int IncreaseWheelSize()
		{
			if( wheels > 42 )
				throw new WheelSizeException();
			
			return ++wheels;
		}
		protected override int DecreaseWheelSize()
		{
			if( wheels < 1 )
				throw new WheelSizeException();
			
			return --wheels;
		}
	}
	/// <summary>
	/// Class Train (Car)
	/// </summary>
	public class Train : Car
	{
		private int engineers;
		private int numberOfBoxcars;
		private int numberOfPassengers;
		private int numberOfAttendents;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Train():
			base( Make.Amtrack, Model.Cascade, true, 2700, 52 )
		{
			engineers = 4;
			numberOfBoxcars = 16;
			numberOfPassengers = 100;
			numberOfAttendents = 10;
		}

		/// <summary>
		/// Property Engineers (int)
		/// </summary>
		public int Engineers
		{
			get
			{
				return this.engineers;
			}
			set
			{
				this.engineers = value;
			}
		}
		/// <summary>
		/// Property NumberOfBoxcars (int)
		/// </summary>
		public int NumberOfBoxcars
		{
			get
			{
				return this.numberOfBoxcars;
			}
			set
			{
				this.numberOfBoxcars = value;
			}
		}
		/// <summary>
		/// Property NumberOfPassengers (int)
		/// </summary>
		public int NumberOfPassengers
		{
			get
			{
				return this.numberOfPassengers;
			}
			set
			{
				this.numberOfPassengers = value;
			}
		}
		/// <summary>
		/// Property NumberOfAttendents (int)
		/// </summary>
		public int NumberOfAttendents
		{
			get
			{
				return this.numberOfAttendents;
			}
			set
			{
				this.numberOfAttendents = value;
			}
		}
		protected override int IncreaseEngineSize()
		{
			if( engine > 2701 )
				throw new EngineSizeException();
			
			return ++engine;
		}
		protected override int DecreaseEngineSize()
		{
			if( engine < 1 )
				throw new EngineSizeException();
			
			return --engine;
		}
		protected override int IncreaseWheelSize()
		{
			if( wheels > 52 )
				throw new WheelSizeException();
			
			return ++wheels;
		}
		protected override int DecreaseWheelSize()
		{
			if( wheels < 1 )
				throw new WheelSizeException();
			
			return --wheels;
		}
	}
}
//#endregion // "Class Car_ClassLibrary implementation"