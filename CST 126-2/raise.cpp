//--------------------------------------------------------------------
// Author:            P. Hannan
// Date Created:      18 Jan 2002
// Last Change Date:  
// Project:           Dynamic Array Demonstration
// Filename:          raise.cpp
//
// Overview:          This program displays the potential 
//                    raises for employees
//   
// Input:			  Employee Salary File
//   
// Output:			  Old and New Salary.
//   
//--------------------------------------------------------------------

#include <iostream>
#include <iomanip>
#include <fstream>
   using namespace std;
   
// STUDENT TASK - Notice the call by reference for the pointer salary.
bool loadFile(ifstream & sFile, double * & salary,int & emplCount);
// loadFile loads the salary file into the dynamic array salary.
//  it gets the emplCount from the first record of the file

void giveRaise(double & amt, double rate);
//  giveRaise updates the amt by the percentage in rate.

void main()
{
	// STUDENT TASK - Define a pointer to double called salary to be
	//  used for a dynamic array.
   double * salary;       // dynamic array for salary
	
   ifstream sFile;        // file of salarys
   int emplCount;         // count of salarys in file
   double sum_old = 0, sum_new = 0;
   
    cout.setf(ios::fixed);
    cout.setf(ios::showpoint);
    cout.precision(2);

   // STUDENT TASK - pass SFille, salary and emplCount into the 
   //  loadFile routine.
   if (loadFile(sFile,salary,emplCount)) {
	    // print headings
	    cout << "\n\t       Old Salary\t        New Salary" << endl;
        // Loop through the array and print out the proposed salary.
   		for (int i = 0; i<emplCount; i++) {
	   		// STUDENT TASK add the i'th element of salary to sum_old
	   		sum_old += salary[i];
	   		cout << "\t    " << setw(13) << salary[i];
   			giveRaise(salary[i],.05);
	   		cout << "\t    " << setw(13) << salary[i];
   			sum_new += salary[i];
   			cout << endl;
   		}
   }
   cout << endl;
   cout << "Grand Total " << setw(13) << sum_old;
   cout << "\t"<<setw(17) << sum_new;
   cout << endl;
   
   // STUDENT TASK - Notice the delete
   delete [] salary;
   salary = NULL;
   
}
void giveRaise(double & amt, double rate)
{
	amt = amt + amt * rate;
}

bool loadFile(ifstream & sFile, double * & salary,int & emplCount) 
{
	char filename[50];
	
	cout << "Please enter the salary file name including extension : ";
	cin >> filename;

	sFile.open(filename);
	
	if (sFile.fail()) {
		cout << "ERROR: Unable to open file : " << filename << endl;
		return false;
	}	
	else {
		// The top of the file has a count of records.  Use it to
		//   update emplCount
		sFile >> emplCount;
		// STUDENT TASK - allocate emplCount double elements to the
		// salary array.
		salary = new double[emplCount];
		int i = 0;
		while (!sFile.eof() && i < emplCount)
		{
			// STUDENT TASK read SFILE into the i'th element of salary
			sFile >> salary[i];
			i++;
		}
		return true;
	}
}
