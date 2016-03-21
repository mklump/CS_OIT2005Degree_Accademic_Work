//--------------------------------------------------------------------
// Author:             P. Hannan
// Date Created:        17 Jan 02
// Last Change Date:  
// Project:            Hands On, Pointers
// Filename:           palindrome.cpp
//
// Overview            This program uses two methods to determine
//                      if something is a palindrome.
//                     A palindrome is a word that is the same
//                       both backwards and forward.  
//                       For example ewe.
//   
// Input:
//   
// Output:
//   
//--------------------------------------------------------------------

#include <iostream>
using namespace std;


//--------------------------------------------------------------------
// Function Prototypes
void loopCheckPalindrome(char p[]);
void pointerCheckPalindrome (char * p);

//--------------------------------------------------------------------

void main (void)
{
	char pali[11];
	char c;
	
	cout << "Welcome to the palindrome Detector" << endl;
	
	do {
		cout << "Enter a word of up to 10 letters" << endl;
		cin >> pali;
		// STUDENT TASK - pass pali to both functions;
		loopCheckPalindrome(pali);
        pointerCheckPalindrome(pali);
        cout << "Do you want to continue? y/n";
        cin >> c;
        
   } while (c == 'y' || c == 'Y');
    
				
    
}

//--------------------------------------------------------------------
//  loopCheckPalindrome - checks to see if input is a palindrome
//    input - a character array
//    output - messages about whether its a palindrome
void loopCheckPalindrome(char p[])
{
	int start, end;
	
	cout << endl;
	start = 0;
	// STUDENT TASK - 
	//   The position of the last character in the array is
	//   length - 1;
	//   Assign length - 1 to end
	end = strlen(p) - 1;
	
	// march through the array and compare the
	//   first and last character.  If they aren't
	//   equal its not a palindrome.
	//   STUDENT TASK - desk check this code for the word
	//     "ewe" (a palindrome)  Then for "2012" (Not a palindrome)
	while (end > start && p[start] == p[end])
	{
		start++;
		end--;
	}
	if (p[start] == p[end])
	  cout << "Loop: " << p << " is a palindrome" << endl;
	else {
	  cout << "Loop: This word is not a palindrome ";
	  cout << "mismatch on character " << start << endl;
	  cout << p[start] << "\tis not the same as " << p[end] << endl;
  }
}
//--------------------------------------------------------------------
//  pointerCheckPalindrome - checks to see if input is a palindrome
//    input - a pointer to char
//    output - messages about whether its a palindrome
void pointerCheckPalindrome (char * p) 
{
	char * start;
	char * end;
	
	cout << endl;
	start = p;
	//STUDENT TASK.  Complete the following poitner arithmatic
	//   to point end to the last character of p
	end = start + strlen(p) - 1;
	
	while (end != p && start[0] == end[0])
	{
    // STUDENT TASK:  Use pointer arithmatic to	
    //  move start up one character at a time.
    //    Use poitner arithmatic to move end down 
    //    one character at a time	
		start++;
		end--;
	}
	if (start[0] == end[0])
	  cout << "Pointer: " << p << " is a palindrome" << endl;
	else {
	  cout << "pointer: This word is not a palindrome ";
	  cout << "mismatch at " << start << endl;
	  cout << start[0] << "\tis not the same as " << end[0] << endl;
  }

}
