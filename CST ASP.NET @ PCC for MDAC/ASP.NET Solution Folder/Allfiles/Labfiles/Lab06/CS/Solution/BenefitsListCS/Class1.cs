namespace BenefitsListCS
{
	public class Benefits
	{
		public struct BenefitInfo
		{
			public string strName;
			public string strPage;
		}

		public BenefitInfo[] GetBenefitsList()
		{
			/*
			 * return a 2-dimensional array of the available benefits and the names of the 
			 * pages that implement the benefit
			*/
			
			//System.Web.HttpContext.Current.Trace.IsEnabled = true;
			//System.Web.HttpContext.Current.Trace.Warn 
			//	("BenefitsList component", 
			//	"Beginning of GetBenefitsList");

			BenefitInfo[] arBenefits = new BenefitInfo[4];

			arBenefits[0].strName="Dental";
			arBenefits[0].strPage = "dental.aspx";
			arBenefits[1].strName = "Medical";
			arBenefits[1].strPage = "medical.aspx";
			arBenefits[2].strName = "Life Insurance";
			arBenefits[2].strPage = "life.aspx";
			arBenefits[3].strName = "Retirement Account";
			arBenefits[3].strPage = "retirement.aspx";

			//System.Web.HttpContext.Current.Trace.Warn
			//	("BenefitsList component", 
			//	"End of GetBenefitsList");

			return arBenefits;
		}
	}
}
