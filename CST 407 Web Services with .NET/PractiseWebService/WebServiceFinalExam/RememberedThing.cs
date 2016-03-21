﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=1.1.4322.2032.
//
using System;
using System.Xml.Serialization;

namespace CST407_FinalExam
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://CST407/AppliedWebServices/FinalExam/FinalExamDataSample.xsd")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://CST407/AppliedWebServices/FinalExam/FinalExamDataSample.xsd", IsNullable=false)]
	public class RememberedThings 
	{
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("RememberedThing")]
		public RememberedThing[] Items;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://CST407/AppliedWebServices/FinalExam/FinalExamDataSample.xsd", TypeName="RememberedThing")]
	public class RememberedThing 
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RememberedThing()
		{
			TimeRemembered = new DateTime(TimeSpan.Zero.Ticks);
			StringRemembered = "";
		}

		/// <summary>
		/// Two arguement constructor to what and when should be remembered.
		/// </summary>
		/// <param name="stamp">DateTime when to remember it.</param>
		/// <param name="whatToRemember">string what to remember.</param>
		public RememberedThing( DateTime stamp, string whatToRemember )
		{
			TimeRemembered = new DateTime( stamp.Ticks );
			StringRemembered = whatToRemember;
		}
    
		/// <remarks/>
		public DateTime TimeRemembered;
    
		/// <remarks/>
		public string StringRemembered;
	}
}