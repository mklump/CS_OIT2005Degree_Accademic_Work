using System;

namespace Calculator
{
	/// <summary>
	/// Summary description for Calculator_.
	/// </summary>
	public class Calculator_
	{
		private FormMain calculatorForm;

		public Calculator_()
		{
			calculatorForm = new FormMain();
			calculatorForm.Show();
			calculatorForm.Refresh();
		}
		public static void Main()
		{
			Calculator_ calc = new Calculator_();
		}
	}
}
