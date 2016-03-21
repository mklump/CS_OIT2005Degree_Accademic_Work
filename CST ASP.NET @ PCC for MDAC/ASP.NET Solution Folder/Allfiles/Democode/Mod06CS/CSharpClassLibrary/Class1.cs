using System;

namespace CSharpClassLibrary
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Class1
	{
		public Class1()
		{
			//
			// TODO: Add constructor logic here
			//
			//HttpContext.Current.Trace.IsEnabled=false;
			//HttpContext.Current.Trace.Write("component", "constructor");
		}
		public string hello()
		{
			//HttpContext.Current.Trace.IsEnabled=false;
			//HttpContext.Current.Trace.Write("component", "hello");
			return ("Hi from C# component");
		}
	
		public Single ComputeShipping(Single fPrice)
		{
			Single fShipping;

			if (fPrice > 20) 
				fShipping = fPrice * 0.2F;
			else
				fShipping = fPrice * 0.1F;

			return(fShipping);
		}
	}

	
}
