//------------------------------------------------------------------------------
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
using System.Xml.Serialization;

namespace orderNameSpace
{
	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mycompany.com")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://mycompany.com", IsNullable=false)]
	public class order 
	{
    
		/// <remarks/>
		public string orderNum;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SendToAddress")]
		public orderSendToAddress[] SendToAddress;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("item", typeof(orderItemsItem), IsNullable=false)]
		public orderItemsItem[][] items;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mycompany.com")]
	public class orderSendToAddress 
	{
    
		/// <remarks/>
		public string street;
    
		/// <remarks/>
		public string city;
    
		/// <remarks/>
		public string state;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mycompany.com")]
	public class orderItemsItem 
	{
    
		/// <remarks/>
		public string name;
    
		/// <remarks/>
		public string unit_price;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string number;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://mycompany.com")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://mycompany.com", IsNullable=false)]
	public class NewDataSet 
	{
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("order")]
		public order[] Items;
	}
}