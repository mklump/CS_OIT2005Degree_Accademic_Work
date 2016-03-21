//--------------------------------------------------------------------
// Author:        P. Hannan  
// Date Created:  15 Jan 2002
// Last Change Date:  
// Project:        Demo parsing
// Filename:       parse.cpp
//
// Overview:   parses the components of a URL
//   
// Input:      None
//   
// Output:		Display the components
//   
//--------------------------------------------------------------------

#include <iostream>   // for basic I/O
#include <cstring>
  using namespace std;
  
const int MAX_URL = 50;


void main (void)
{
	char url[MAX_URL] = "www.oit.edu";
	const char DOT[] = ".";

	unsigned int dotPos;  // The position of the "."
	
	int number_words = 0;
	char before[MAX_URL], // the stuff before the current "."
	     after[MAX_URL];  // the stuff after the current "."

	string components[3];
  
	strcpy(after,url);  // start out with whole url
	
	while (after != NULL && strlen(after) > 0)    {
	  dotPos = strcspn(after,DOT);
	  if (dotPos == strlen(after)) 
	  {
	  //  Hit the end		  
	  //  strcspn returns the position of the first '\0' if not found
	  	strcpy(before,after);
	  	after[0] = '\0';	
	  }	
	  else 
	  {
		// before gets everything before the .
	  	strncpy(before,after,dotPos);
	  	before[dotPos] = '\0';
	  	
		//  after gets everything after the .
		//  Why do I use dotPos + 1 ??
	  	strcpy(after,after+dotPos+1);
	  }
	  components[number_words] = before;
	  number_words++;
	}

	cout << "The components of: " << url << " are:" << endl;
	cout << "\t";
	for (int i = 0;i < 3;i++)
		cout << components[i] << " " ;
}
