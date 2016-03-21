using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Calculator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CaculatorForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btn_MC;
		private System.Windows.Forms.Button btn_MR;
		private System.Windows.Forms.Button btn_MS;
		private System.Windows.Forms.Button btn_MemAdd;
		private System.Windows.Forms.Button btn_7;
		private System.Windows.Forms.Button btn_4;
		private System.Windows.Forms.Button btn_1;
		private System.Windows.Forms.Button btn_0;
		private System.Windows.Forms.Button btn_8;
		private System.Windows.Forms.Button btn_5;
		private System.Windows.Forms.Button btn_2;
		private System.Windows.Forms.Button btn_PlusMinus;
		private System.Windows.Forms.Button btn_9;
		private System.Windows.Forms.Button btn_6;
		private System.Windows.Forms.Button btn_3;
		private System.Windows.Forms.Button btn_Period;
		private System.Windows.Forms.Button btn_Divide;
		private System.Windows.Forms.Button btn_Multiply;
		private System.Windows.Forms.Button btn_Subtract;
		private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.Button btn_sqrt;
		private System.Windows.Forms.Button btn_backspace;
		private System.Windows.Forms.Button btn_CE;
		private System.Windows.Forms.Button btn_C;
		private System.Windows.Forms.Button btn_Percent;
		private System.Windows.Forms.Button btn_Invert;
		private System.Windows.Forms.Button btn_Equals;
		private System.Windows.Forms.TextBox txtDisplay;

		/// <summary>
		/// Calcuator operation variables
		/// </summary>
		private bool[] Operation;
		decimal Operand1;
		decimal Operand2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CaculatorForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Operand1 = Operand2 = 0;
			Operation = new bool[11];
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.btn_MC = new System.Windows.Forms.Button();
			this.btn_MR = new System.Windows.Forms.Button();
			this.btn_MS = new System.Windows.Forms.Button();
			this.btn_MemAdd = new System.Windows.Forms.Button();
			this.btn_7 = new System.Windows.Forms.Button();
			this.btn_4 = new System.Windows.Forms.Button();
			this.btn_1 = new System.Windows.Forms.Button();
			this.btn_0 = new System.Windows.Forms.Button();
			this.btn_8 = new System.Windows.Forms.Button();
			this.btn_5 = new System.Windows.Forms.Button();
			this.btn_2 = new System.Windows.Forms.Button();
			this.btn_PlusMinus = new System.Windows.Forms.Button();
			this.btn_9 = new System.Windows.Forms.Button();
			this.btn_6 = new System.Windows.Forms.Button();
			this.btn_3 = new System.Windows.Forms.Button();
			this.btn_Period = new System.Windows.Forms.Button();
			this.btn_Divide = new System.Windows.Forms.Button();
			this.btn_Multiply = new System.Windows.Forms.Button();
			this.btn_Subtract = new System.Windows.Forms.Button();
			this.btn_Add = new System.Windows.Forms.Button();
			this.btn_sqrt = new System.Windows.Forms.Button();
			this.btn_Percent = new System.Windows.Forms.Button();
			this.btn_Invert = new System.Windows.Forms.Button();
			this.btn_Equals = new System.Windows.Forms.Button();
			this.btn_backspace = new System.Windows.Forms.Button();
			this.btn_CE = new System.Windows.Forms.Button();
			this.btn_C = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(8, 8);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new System.Drawing.Size(248, 20);
			this.txtDisplay.TabIndex = 0;
			this.txtDisplay.Text = "0.";
			this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btn_MC
			// 
			this.btn_MC.ForeColor = System.Drawing.Color.Red;
			this.btn_MC.Location = new System.Drawing.Point(8, 72);
			this.btn_MC.Name = "btn_MC";
			this.btn_MC.Size = new System.Drawing.Size(32, 32);
			this.btn_MC.TabIndex = 1;
			this.btn_MC.Text = "MC";
			// 
			// btn_MR
			// 
			this.btn_MR.ForeColor = System.Drawing.Color.Red;
			this.btn_MR.Location = new System.Drawing.Point(8, 112);
			this.btn_MR.Name = "btn_MR";
			this.btn_MR.Size = new System.Drawing.Size(32, 32);
			this.btn_MR.TabIndex = 2;
			this.btn_MR.Text = "MR";
			// 
			// btn_MS
			// 
			this.btn_MS.ForeColor = System.Drawing.Color.Red;
			this.btn_MS.Location = new System.Drawing.Point(8, 152);
			this.btn_MS.Name = "btn_MS";
			this.btn_MS.Size = new System.Drawing.Size(32, 32);
			this.btn_MS.TabIndex = 3;
			this.btn_MS.Text = "MS";
			// 
			// btn_MemAdd
			// 
			this.btn_MemAdd.ForeColor = System.Drawing.Color.Red;
			this.btn_MemAdd.Location = new System.Drawing.Point(8, 192);
			this.btn_MemAdd.Name = "btn_MemAdd";
			this.btn_MemAdd.Size = new System.Drawing.Size(32, 32);
			this.btn_MemAdd.TabIndex = 4;
			this.btn_MemAdd.Text = "M+";
			// 
			// btn_7
			// 
			this.btn_7.ForeColor = System.Drawing.Color.Blue;
			this.btn_7.Location = new System.Drawing.Point(64, 72);
			this.btn_7.Name = "btn_7";
			this.btn_7.Size = new System.Drawing.Size(32, 32);
			this.btn_7.TabIndex = 5;
			this.btn_7.Text = "7";
			this.btn_7.Click += new System.EventHandler(this.btn_7_Click_1);
			// 
			// btn_4
			// 
			this.btn_4.ForeColor = System.Drawing.Color.Blue;
			this.btn_4.Location = new System.Drawing.Point(64, 112);
			this.btn_4.Name = "btn_4";
			this.btn_4.Size = new System.Drawing.Size(32, 32);
			this.btn_4.TabIndex = 6;
			this.btn_4.Text = "4";
			this.btn_4.Click += new System.EventHandler(this.btn_4_Click);
			// 
			// btn_1
			// 
			this.btn_1.ForeColor = System.Drawing.Color.Blue;
			this.btn_1.Location = new System.Drawing.Point(64, 152);
			this.btn_1.Name = "btn_1";
			this.btn_1.Size = new System.Drawing.Size(32, 32);
			this.btn_1.TabIndex = 7;
			this.btn_1.Text = "1";
			this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
			// 
			// btn_0
			// 
			this.btn_0.ForeColor = System.Drawing.Color.Blue;
			this.btn_0.Location = new System.Drawing.Point(64, 192);
			this.btn_0.Name = "btn_0";
			this.btn_0.Size = new System.Drawing.Size(32, 32);
			this.btn_0.TabIndex = 8;
			this.btn_0.Text = "0";
			this.btn_0.Click += new System.EventHandler(this.btn_0_Click);
			// 
			// btn_8
			// 
			this.btn_8.ForeColor = System.Drawing.Color.Blue;
			this.btn_8.Location = new System.Drawing.Point(104, 72);
			this.btn_8.Name = "btn_8";
			this.btn_8.Size = new System.Drawing.Size(32, 32);
			this.btn_8.TabIndex = 9;
			this.btn_8.Text = "8";
			this.btn_8.Click += new System.EventHandler(this.btn_8_Click_1);
			// 
			// btn_5
			// 
			this.btn_5.ForeColor = System.Drawing.Color.Blue;
			this.btn_5.Location = new System.Drawing.Point(104, 112);
			this.btn_5.Name = "btn_5";
			this.btn_5.Size = new System.Drawing.Size(32, 32);
			this.btn_5.TabIndex = 10;
			this.btn_5.Text = "5";
			this.btn_5.Click += new System.EventHandler(this.btn_5_Click);
			// 
			// btn_2
			// 
			this.btn_2.ForeColor = System.Drawing.Color.Blue;
			this.btn_2.Location = new System.Drawing.Point(104, 152);
			this.btn_2.Name = "btn_2";
			this.btn_2.Size = new System.Drawing.Size(32, 32);
			this.btn_2.TabIndex = 11;
			this.btn_2.Text = "2";
			this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
			// 
			// btn_PlusMinus
			// 
			this.btn_PlusMinus.ForeColor = System.Drawing.Color.Blue;
			this.btn_PlusMinus.Location = new System.Drawing.Point(104, 192);
			this.btn_PlusMinus.Name = "btn_PlusMinus";
			this.btn_PlusMinus.Size = new System.Drawing.Size(32, 32);
			this.btn_PlusMinus.TabIndex = 12;
			this.btn_PlusMinus.Text = "+/-";
			this.btn_PlusMinus.Click += new System.EventHandler(this.btn_PlusMinus_Click);
			// 
			// btn_9
			// 
			this.btn_9.ForeColor = System.Drawing.Color.Blue;
			this.btn_9.Location = new System.Drawing.Point(144, 72);
			this.btn_9.Name = "btn_9";
			this.btn_9.Size = new System.Drawing.Size(32, 32);
			this.btn_9.TabIndex = 13;
			this.btn_9.Text = "9";
			this.btn_9.Click += new System.EventHandler(this.btn_9_Click_1);
			// 
			// btn_6
			// 
			this.btn_6.ForeColor = System.Drawing.Color.Blue;
			this.btn_6.Location = new System.Drawing.Point(144, 112);
			this.btn_6.Name = "btn_6";
			this.btn_6.Size = new System.Drawing.Size(32, 32);
			this.btn_6.TabIndex = 14;
			this.btn_6.Text = "6";
			this.btn_6.Click += new System.EventHandler(this.btn_6_Click_1);
			// 
			// btn_3
			// 
			this.btn_3.ForeColor = System.Drawing.Color.Blue;
			this.btn_3.Location = new System.Drawing.Point(144, 152);
			this.btn_3.Name = "btn_3";
			this.btn_3.Size = new System.Drawing.Size(32, 32);
			this.btn_3.TabIndex = 15;
			this.btn_3.Text = "3";
			this.btn_3.Click += new System.EventHandler(this.btn_3_Click);
			// 
			// btn_Period
			// 
			this.btn_Period.ForeColor = System.Drawing.Color.Blue;
			this.btn_Period.Location = new System.Drawing.Point(144, 192);
			this.btn_Period.Name = "btn_Period";
			this.btn_Period.Size = new System.Drawing.Size(32, 32);
			this.btn_Period.TabIndex = 16;
			this.btn_Period.Text = ".";
			this.btn_Period.Click += new System.EventHandler(this.btn_Period_Click);
			// 
			// btn_Divide
			// 
			this.btn_Divide.ForeColor = System.Drawing.Color.Red;
			this.btn_Divide.Location = new System.Drawing.Point(184, 72);
			this.btn_Divide.Name = "btn_Divide";
			this.btn_Divide.Size = new System.Drawing.Size(32, 32);
			this.btn_Divide.TabIndex = 17;
			this.btn_Divide.Text = "/";
			this.btn_Divide.Click += new System.EventHandler(this.btn_Divide_Click);
			// 
			// btn_Multiply
			// 
			this.btn_Multiply.ForeColor = System.Drawing.Color.Red;
			this.btn_Multiply.Location = new System.Drawing.Point(184, 112);
			this.btn_Multiply.Name = "btn_Multiply";
			this.btn_Multiply.Size = new System.Drawing.Size(32, 32);
			this.btn_Multiply.TabIndex = 18;
			this.btn_Multiply.Text = "*";
			this.btn_Multiply.Click += new System.EventHandler(this.btn_Multiply_Click);
			// 
			// btn_Subtract
			// 
			this.btn_Subtract.ForeColor = System.Drawing.Color.Red;
			this.btn_Subtract.Location = new System.Drawing.Point(184, 152);
			this.btn_Subtract.Name = "btn_Subtract";
			this.btn_Subtract.Size = new System.Drawing.Size(32, 32);
			this.btn_Subtract.TabIndex = 19;
			this.btn_Subtract.Text = "-";
			this.btn_Subtract.Click += new System.EventHandler(this.btn_Subtract_Click);
			// 
			// btn_Add
			// 
			this.btn_Add.ForeColor = System.Drawing.Color.Red;
			this.btn_Add.Location = new System.Drawing.Point(184, 192);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(32, 32);
			this.btn_Add.TabIndex = 20;
			this.btn_Add.Text = "+";
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// btn_sqrt
			// 
			this.btn_sqrt.ForeColor = System.Drawing.Color.Blue;
			this.btn_sqrt.Location = new System.Drawing.Point(224, 72);
			this.btn_sqrt.Name = "btn_sqrt";
			this.btn_sqrt.Size = new System.Drawing.Size(32, 32);
			this.btn_sqrt.TabIndex = 21;
			this.btn_sqrt.Text = "sqrt";
			this.btn_sqrt.Click += new System.EventHandler(this.btn_sqrt_Click);
			// 
			// btn_Percent
			// 
			this.btn_Percent.ForeColor = System.Drawing.Color.Blue;
			this.btn_Percent.Location = new System.Drawing.Point(224, 112);
			this.btn_Percent.Name = "btn_Percent";
			this.btn_Percent.Size = new System.Drawing.Size(32, 32);
			this.btn_Percent.TabIndex = 22;
			this.btn_Percent.Text = "%";
			// 
			// btn_Invert
			// 
			this.btn_Invert.ForeColor = System.Drawing.Color.Blue;
			this.btn_Invert.Location = new System.Drawing.Point(224, 152);
			this.btn_Invert.Name = "btn_Invert";
			this.btn_Invert.Size = new System.Drawing.Size(32, 32);
			this.btn_Invert.TabIndex = 23;
			this.btn_Invert.Text = "1/x";
			this.btn_Invert.Click += new System.EventHandler(this.btn_Invert_Click);
			// 
			// btn_Equals
			// 
			this.btn_Equals.ForeColor = System.Drawing.Color.Red;
			this.btn_Equals.Location = new System.Drawing.Point(224, 192);
			this.btn_Equals.Name = "btn_Equals";
			this.btn_Equals.Size = new System.Drawing.Size(32, 32);
			this.btn_Equals.TabIndex = 24;
			this.btn_Equals.Text = "=";
			this.btn_Equals.Click += new System.EventHandler(this.btn_Equals_Click);
			// 
			// btn_backspace
			// 
			this.btn_backspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_backspace.ForeColor = System.Drawing.Color.Red;
			this.btn_backspace.Location = new System.Drawing.Point(64, 32);
			this.btn_backspace.Name = "btn_backspace";
			this.btn_backspace.Size = new System.Drawing.Size(64, 32);
			this.btn_backspace.TabIndex = 25;
			this.btn_backspace.Text = "Backspace";
			this.btn_backspace.Click += new System.EventHandler(this.btn_backspace_Click);
			// 
			// btn_CE
			// 
			this.btn_CE.ForeColor = System.Drawing.Color.Red;
			this.btn_CE.Location = new System.Drawing.Point(136, 32);
			this.btn_CE.Name = "btn_CE";
			this.btn_CE.Size = new System.Drawing.Size(56, 32);
			this.btn_CE.TabIndex = 26;
			this.btn_CE.Text = "CE";
			// 
			// btn_C
			// 
			this.btn_C.ForeColor = System.Drawing.Color.Red;
			this.btn_C.Location = new System.Drawing.Point(200, 32);
			this.btn_C.Name = "btn_C";
			this.btn_C.Size = new System.Drawing.Size(56, 32);
			this.btn_C.TabIndex = 27;
			this.btn_C.Text = "C";
			this.btn_C.Click += new System.EventHandler(this.btn_C_Click);
			// 
			// CaculatorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 231);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btn_C,
																		  this.btn_CE,
																		  this.btn_backspace,
																		  this.btn_Equals,
																		  this.btn_Invert,
																		  this.btn_Percent,
																		  this.btn_sqrt,
																		  this.btn_Add,
																		  this.btn_Subtract,
																		  this.btn_Multiply,
																		  this.btn_Divide,
																		  this.btn_Period,
																		  this.btn_3,
																		  this.btn_6,
																		  this.btn_9,
																		  this.btn_PlusMinus,
																		  this.btn_2,
																		  this.btn_5,
																		  this.btn_8,
																		  this.btn_0,
																		  this.btn_1,
																		  this.btn_4,
																		  this.btn_7,
																		  this.btn_MemAdd,
																		  this.btn_MS,
																		  this.btn_MR,
																		  this.btn_MC,
																		  this.txtDisplay});
			this.Name = "CaculatorForm";
			this.Text = "Caculator";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new CaculatorForm());
		}

		private void btn_C_Click(object sender, System.EventArgs e)
		{
			txtDisplay.Text = "0.";
		}

		private void btn_backspace_Click(object sender, System.EventArgs e)
		{
		}

		private void btn_0_Click(object sender, System.EventArgs e)
		{
			if( txtDisplay.Text.StartsWith("0") && !Operation[4] )
				return;

			PrintNumber( 0 );
		}

		private void PrintNumber( int digit )
		{
		}

		private void btn_1_Click(object sender, System.EventArgs e)
		{
			PrintNumber( 1 );
		}

		private void btn_2_Click(object sender, System.EventArgs e)
		{
			PrintNumber( 2 );
		}

		private void btn_3_Click(object sender, System.EventArgs e)
		{
			PrintNumber( 3 );
		}

		private void btn_4_Click(object sender, System.EventArgs e)
		{
			PrintNumber( 4 );
		}

		private void btn_5_Click(object sender, System.EventArgs e)
		{
			PrintNumber( 5 );
		}

		private void btn_6_Click_1(object sender, System.EventArgs e)
		{
			PrintNumber( 6 );
		}
	
		private void btn_7_Click_1(object sender, System.EventArgs e)
		{
			PrintNumber( 7 );
		}

		private void btn_8_Click_1(object sender, System.EventArgs e)
		{
			PrintNumber( 8 );
		}

		private void btn_9_Click_1(object sender, System.EventArgs e)
		{
			PrintNumber( 9 );
		}

		private void btn_Period_Click(object sender, System.EventArgs e)
		{
		}

		private void btn_PlusMinus_Click(object sender, System.EventArgs e)
		{
		}

		private
			decimal
			PerformOperation( decimal num1, decimal num2 )
		{
			try
			{
				int iswitch;
				switch( iswitch )
				{
					case 0:
						num1 += num2;
						break;
					case 1:
						num1 -= num2;
						break;
					case 2:
						num1 *= num2;
						break;
					case 3:
						if( num2 == 0 )
							throw new ApplicationException("Cannot divide by zero.");

						num1 /= num2;
						break;
					case 4:
						if( num1 < 0 )
							throw new ApplicationException("Invalid input for function.");

						num1 = Convert.ToDecimal(Math.Sqrt( Convert.ToDouble(num1) ));
						break;
					case 5:
						break;
					case 6:
						if( num1 == 0 )
							throw new ApplicationException("Cannot divide by zero.");

						num1 = 1 / num1;
						break;
					default:
						num1 = -1;
						break;
				}
			}
			catch( ApplicationException exception )
			{
				txtDisplay.Text = exception.Message;
			}
			return num1;
		}

		private void btn_sqrt_Click(object sender, System.EventArgs e)
		{
			Operand1 = PerformOperation( Convert.ToDecimal(txtDisplay.Text), 0);
		}

		private void btn_Invert_Click(object sender, System.EventArgs e)
		{
			Operand1 = PerformOperation( Convert.ToDecimal(txtDisplay.Text), 0);
		}

		private void btn_Divide_Click(object sender, System.EventArgs e)
		{
		}

		private void btn_Multiply_Click(object sender, System.EventArgs e)
		{
		}

		private void btn_Subtract_Click(object sender, System.EventArgs e)
		{
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
		}

		private void btn_Equals_Click(object sender, System.EventArgs e)
		{
			Operand1 = PerformOperation( Operand1, Operand2 );
		}
	}
}