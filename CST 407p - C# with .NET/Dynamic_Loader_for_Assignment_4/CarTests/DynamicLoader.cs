using System;
using System.IO;
using System.Collections;
using System.Reflection;
using Car_ClassLibrary;
using System.Configuration;
using System.Diagnostics;

namespace Dynamic_Loader
{
	/// <summary>
	/// Summary description for DynamicLoader.
	/// </summary>
	public class DynamicLoader
	{
		public DynamicLoader()
		{
			Dynamically_Load_Car_ClassLibrary_Objects();
		}
		public void Dynamically_Load_Car_ClassLibrary_Objects()
		{
			foreach (string s in ConfigurationSettings.AppSettings)
			{
				string[] assemblyString =
					ConfigurationSettings.AppSettings[s].Split(',');
				string type = assemblyString[0];
				string assembly = assemblyString[1];
				CreateInstance( ref type, ref assembly );
			}
		}
		public void CreateInstance( ref string type, ref string assembly)
		{
			Assembly a = Assembly.Load( assembly.Trim() );
			object theObj = a.CreateInstance( type.Trim() );
			Trace.WriteLine( String.Format("Dynamically Created object {0}", theObj.GetType().ToString()) );
		}
	}
}

