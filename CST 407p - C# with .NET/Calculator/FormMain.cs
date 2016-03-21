using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Calculator
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Button BackspaceButton;
		private System.Windows.Forms.TextBox txtDisplay;
		private System.Windows.Forms.Button buttonSeven;
		private System.Windows.Forms.Button buttonEight;
		private System.Windows.Forms.Button buttonNine;
		private System.Windows.Forms.Button buttonFour;
		private System.Windows.Forms.Button buttonFive;
		private System.Windows.Forms.Button buttonSix;
		private System.Windows.Forms.Button buttonOne;
		private System.Windows.Forms.Button buttonTwo;
		private System.Windows.Forms.Button buttonThree;
		private System.Windows.Forms.Button buttonZero;
		private System.Windows.Forms.Button buttonDivison;
		private System.Windows.Forms.Button buttonMult;
		private System.Windows.Forms.Button buttonSubraction;
		private System.Windows.Forms.Button buttonAddition;
		private System.Windows.Forms.Button buttonEquals;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Operation = new bool[4];
			Operand1 = new string(String.Empty.ToCharArray());
			Operand2 = new string(String.Empty.ToCharArray());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.ClearButton = new System.Windows.Forms.Button();
			this.BackspaceButton = new System.Windows.Forms.Button();
			this.buttonSeven = new System.Windows.Forms.Button();
			this.buttonEight = new System.Windows.Forms.Button();
			this.buttonNine = new System.Windows.Forms.Button();
			this.buttonFour = new System.Windows.Forms.Button();
			this.buttonFive = new System.Windows.Forms.Button();
			this.buttonSix = new System.Windows.Forms.Button();
			this.buttonOne = new System.Windows.Forms.Button();
			this.buttonTwo = new System.Windows.Forms.Button();
			this.buttonThree = new System.Windows.Forms.Button();
			this.buttonZero = new System.Windows.Forms.Button();
			this.buttonDivison = new System.Windows.Forms.Button();
			this.buttonMult = new System.Windows.Forms.Button();
			this.buttonSubraction = new System.Windows.Forms.Button();
			this.buttonAddition = new System.Windows.Forms.Button();
			this.buttonEquals = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(8, 8);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new System.Drawing.Size(192, 20);
			this.txtDisplay.TabIndex = 0;
			this.txtDisplay.Text = "";
			this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ClearButton
			// 
			this.ClearButton.Location = new System.Drawing.Point(16, 40);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(72, 32);
			this.ClearButton.TabIndex = 1;
			this.ClearButton.Text = "Clear";
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// BackspaceButton
			// 
			this.BackspaceButton.Location = new System.Drawing.Point(128, 40);
			this.BackspaceButton.Name = "BackspaceButton";
			this.BackspaceButton.Size = new System.Drawing.Size(72, 32);
			this.BackspaceButton.TabIndex = 2;
			this.BackspaceButton.Text = "Backspace";
			this.BackspaceButton.Click += new System.EventHandler(this.BackspaceButton_Click);
			// 
			// buttonSeven
			// 
			this.buttonSeven.Location = new System.Drawing.Point(16, 88);
			this.buttonSeven.Name = "buttonSeven";
			this.buttonSeven.Size = new System.Drawing.Size(40, 40);
			this.buttonSeven.TabIndex = 3;
			this.buttonSeven.Text = "7";
			this.buttonSeven.Click += new System.EventHandler(this.buttonSeven_Click);
			// 
			// buttonEight
			// 
			this.buttonEight.Location = new System.Drawing.Point(64, 88);
			this.buttonEight.Name = "buttonEight";
			this.buttonEight.Size = new System.Drawing.Size(40, 40);
			this.buttonEight.TabIndex = 4;
			this.buttonEight.Text = "8";
			this.buttonEight.Click += new System.EventHandler(this.buttonEight_Click);
			// 
			// buttonNine
			// 
			this.buttonNine.Location = new System.Drawing.Point(112, 88);
			this.buttonNine.Name = "buttonNine";
			this.buttonNine.Size = new System.Drawing.Size(40, 40);
			this.buttonNine.TabIndex = 5;
			this.buttonNine.Text = "9";
			this.buttonNine.Click += new System.EventHandler(this.buttonNine_Click);
			// 
			// buttonFour
			// 
			this.buttonFour.Location = new System.Drawing.Point(16, 136);
			this.buttonFour.Name = "buttonFour";
			this.buttonFour.Size = new System.Drawing.Size(40, 40);
			this.buttonFour.TabIndex = 6;
			this.buttonFour.Text = "4";
			this.buttonFour.Click += new System.EventHandler(this.buttonFour_Click);
			// 
			// buttonFive
			// 
			this.buttonFive.Location = new System.Drawing.Point(64, 136);
			this.buttonFive.Name = "buttonFive";
			this.buttonFive.Size = new System.Drawing.Size(40, 40);
			this.buttonFive.TabIndex = 7;
			this.buttonFive.Text = "5";
			this.buttonFive.Click += new System.EventHandler(this.buttonFive_Click);
			// 
			// buttonSix
			// 
			this.buttonSix.Location = new System.Drawing.Point(112, 136);
			this.buttonSix.Name = "buttonSix";
			this.buttonSix.Size = new System.Drawing.Size(40, 40);
			this.buttonSix.TabIndex = 8;
			this.buttonSix.Text = "6";
			this.buttonSix.Click += new System.EventHandler(this.button6_Click);
			// 
			// buttonOne
			// 
			this.buttonOne.Location = new System.Drawing.Point(16, 184);
			this.buttonOne.Name = "buttonOne";
			this.buttonOne.Size = new System.Drawing.Size(40, 40);
			this.buttonOne.TabIndex = 9;
			this.buttonOne.Text = "1";
			this.buttonOne.Click += new System.EventHandler(this.buttonOne_Click);
			// 
			// buttonTwo
			// 
			this.buttonTwo.Location = new System.Drawing.Point(64, 184);
			this.buttonTwo.Name = "buttonTwo";
			this.buttonTwo.Size = new System.Drawing.Size(40, 40);
			this.buttonTwo.TabIndex = 10;
			this.buttonTwo.Text = "2";
			this.buttonTwo.Click += new System.EventHandler(this.buttonTwo_Click);
			// 
			// buttonThree
			// 
			this.buttonThree.Location = new System.Drawing.Point(112, 184);
			this.buttonThree.Name = "buttonThree";
			this.buttonThree.Size = new System.Drawing.Size(40, 40);
			this.buttonThree.TabIndex = 11;
			this.buttonThree.Text = "3";
			this.buttonThree.Click += new System.EventHandler(this.button9_Click);
			// 
			// buttonZero
			// 
			this.buttonZero.Location = new System.Drawing.Point(16, 232);
			this.buttonZero.Name = "buttonZero";
			this.buttonZero.Size = new System.Drawing.Size(40, 40);
			this.buttonZero.TabIndex = 12;
			this.buttonZero.Text = "0";
			this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
			// 
			// buttonDivison
			// 
			this.buttonDivison.Location = new System.Drawing.Point(160, 88);
			this.buttonDivison.Name = "buttonDivison";
			this.buttonDivison.Size = new System.Drawing.Size(40, 40);
			this.buttonDivison.TabIndex = 13;
			this.buttonDivison.Text = "/";
			this.buttonDivison.Click += new System.EventHandler(this.buttonDivison_Click);
			// 
			// buttonMult
			// 
			this.buttonMult.Location = new System.Drawing.Point(160, 136);
			this.buttonMult.Name = "buttonMult";
			this.buttonMult.Size = new System.Drawing.Size(40, 40);
			this.buttonMult.TabIndex = 14;
			this.buttonMult.Text = "*";
			this.buttonMult.Click += new System.EventHandler(this.buttonMult_Click);
			// 
			// buttonSubraction
			// 
			this.buttonSubraction.Location = new System.Drawing.Point(160, 184);
			this.buttonSubraction.Name = "buttonSubraction";
			this.buttonSubraction.Size = new System.Drawing.Size(40, 40);
			this.buttonSubraction.TabIndex = 15;
			this.buttonSubraction.Text = "-";
			this.buttonSubraction.Click += new System.EventHandler(this.buttonSubraction_Click);
			// 
			// buttonAddition
			// 
			this.buttonAddition.Location = new System.Drawing.Point(160, 232);
			this.buttonAddition.Name = "buttonAddition";
			this.buttonAddition.Size = new System.Drawing.Size(40, 40);
			this.buttonAddition.TabIndex = 16;
			this.buttonAddition.Text = "+";
			this.buttonAddition.Click += new System.EventHandler(this.buttonAddition_Click);
			// 
			// buttonEquals
			// 
			this.buttonEquals.Location = new System.Drawing.Point(112, 232);
			this.buttonEquals.Name = "buttonEquals";
			this.buttonEquals.Size = new System.Drawing.Size(40, 40);
			this.buttonEquals.TabIndex = 17;
			this.buttonEquals.Text = "=";
			this.buttonEquals.Click += new System.EventHandler(this.buttonEquals_Click);
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 288);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.buttonEquals,
																		  this.buttonAddition,
																		  this.buttonSubraction,
																		  this.buttonMult,
																		  this.buttonDivison,
																		  this.buttonZero,
																		  this.buttonThree,
																		  this.buttonTwo,
																		  this.buttonOne,
																		  this.buttonSix,
																		  this.buttonFive,
																		  this.buttonFour,
																		  this.buttonNine,
																		  this.buttonEight,
																		  this.buttonSeven,
																		  this.BackspaceButton,
																		  this.ClearButton,
																		  this.txtDisplay});
			this.Name = "FormMain";
			this.Text = "BasicCalculator";
			this.ResumeLayout(false);

		}
		#endregion

		private bool[] Operation;
		private string Operand1;
		private string Operand2;

		private void ClearButton_Click(object sender, System.EventArgs e)
		{
			txtDisplay.Clear();
		}

		private void BackspaceButton_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			for(int ix = temp.Length-1; ix >= 0; --ix)
				temp.ToCharArray()[ix - 1] = temp.ToCharArray()[ix];
			temp.ToCharArray()[temp.Length-1] = ' ';
			txtDisplay.Text = temp;
		}

		private void buttonZero_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			while(temp.StartsWith("0"))
				temp.ToCharArray()[0] = ' ';
			String.Concat(temp,"0");
			txtDisplay.Text = temp;
		}

		private void buttonOne_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"1");
			txtDisplay.Text = temp;
		}

		private void buttonTwo_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"2");
			txtDisplay.Text = temp;
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"3");
			txtDisplay.Text = temp;
		}

		private void buttonFour_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"4");
			txtDisplay.Text = temp;
		}

		private void buttonFive_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"5");
			txtDisplay.Text = temp;
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"6");
			txtDisplay.Text = temp;
		}

		private void buttonSeven_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"7");
			txtDisplay.Text = temp;
		}

		private void buttonEight_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"8");
			txtDisplay.Text = temp;
		}

		private void buttonNine_Click(object sender, System.EventArgs e)
		{
			string temp = txtDisplay.Text;
			String.Concat(temp,"9");
			txtDisplay.Text = temp;
		}

		private void buttonDivison_Click(object sender, System.EventArgs e)
		{
			Operand1 = txtDisplay.Text;
			txtDisplay.Clear();
			Operation[0] = true;
			for(int ix = 1; ix < 4; ++ix)
				Operation[ix] = false;
		}

		private void buttonMult_Click(object sender, System.EventArgs e)
		{
			Operand1 = txtDisplay.Text;
			txtDisplay.Clear();
			Operation[0] = false;
			Operation[1] = true;
			for(int ix = 2; ix < 4; ++ix)
				Operation[ix] = false;
		}

		private void buttonSubraction_Click(object sender, System.EventArgs e)
		{
			Operand1 = txtDisplay.Text;
			txtDisplay.Clear();
			for(int ix = 0; ix < 2; ++ix)
				Operation[ix] = false;
			Operation[2] = true;
			Operation[3] = false;
		}

		private void buttonAddition_Click(object sender, System.EventArgs e)
		{
			Operand1 = txtDisplay.Text;
			txtDisplay.Clear();
			for(int ix = 0; ix < 3; ++ix)
				Operation[ix] = false;
			Operation[3] = true;
		}

		private void buttonEquals_Click(object sender, System.EventArgs e)
		{
			Operand2 = txtDisplay.Text;
			txtDisplay.Clear();
			int result = 0;
			if( Operation[0] )
			{
				result = Convert.ToInt32(Operand1) / Convert.ToInt32(Operand2);
				txtDisplay.Text = result.ToString();
			}
			else if( Operation[1] )
			{
				result = Convert.ToInt32(Operand1) * Convert.ToInt32(Operand2);
				txtDisplay.Text = result.ToString();
			}
			else if( Operation[2] )
			{
				result = Convert.ToInt32(Operand1) - Convert.ToInt32(Operand2);
				txtDisplay.Text = result.ToString();
			}
			else if( Operation[3] )
			{
				result = Convert.ToInt32(Operand1) + Convert.ToInt32(Operand2);
				txtDisplay.Text = result.ToString();
			}
		}
	}
}
