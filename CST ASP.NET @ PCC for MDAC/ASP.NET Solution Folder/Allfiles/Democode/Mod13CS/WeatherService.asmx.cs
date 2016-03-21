using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace Mod13CS
{
	/// <summary>
	/// Summary description for WeatherService.
	/// </summary>
	public class WeatherService : System.Web.Services.WebService
	{
		public WeatherService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		//The WeatherByCity() service takes the city as parameter and returns the weather in this city.
		[WebMethod(Description="This XML Web service method gives the weather forcast for a given city")]
		public string WeatherByCity(String City)
		{
			if ((City).ToLower() == "seattle")
				//If the city is Seattle we know the answer
				return "sun";
			else
			{
				//Else we apply the best forcast algorithm
				int intRandomNb;
				Random rnd = new Random();
				//Generate random value between 1 and 3.
				intRandomNb = ((int)(3 * rnd.NextDouble()) + 1);
				switch(intRandomNb)
				{
					case 1:
						return "sun";
					case 2:
						return "cloudy";
					default:
						return "rain";
				}
			}
		}

		//The TemperatureByCity() service takes the city as parameter and returns the temperature in this city.
		[WebMethod(Description="This XML Web service method gives the temperature forcast for a given city in Fahrenheit")]
		public int TemperatureByCity(string City)
		{
			int intTemperature;
			Random rnd = new Random();
			//Generate random value between 31 and 60.
				intTemperature = ((int)(30 * rnd.NextDouble()) + 31);
			return intTemperature;
		}

		//The TravelAdviceByCity() service takes the city as parameter and returns an advise in this city.
		[WebMethod(Description="This XML Web service method gives advises for travellers")]
		public string TravelAdviceByCity(string City)
		{
			if (City.ToString() == "seattle")
				//If the city is Seattle we know what to say
				return "Don't forget your sunglasses";
			else
				if (City.ToString() == "Seattle")
					//If the city is Seattle we know what to say
					return "Don't forget your sunglasses";
				else
					return "Nothing special";
		
		}
	}
}
