//--------------------------------------------------------------------
// Author:          P. Hannan     
// Date Created:    11 Feb 2002
// Last Change Date:  
// Project:         Pull together all the date list code from the slides
// Filename:        DateList.cpp
//
// Overview:        Provides a linked list of dates.
//   
// Input:           None
//   
// Output:          A list of dates.
//   
//--------------------------------------------------------------------
// NOTE:  This program needs a function to delete the list.
//  

#include <iostream>
using namespace std;
struct Date {
	int day,  month,  year;
	Date * next;
};

typedef Date * DatePtr;  



//--------------------------------------------------------------------
// Prints our list of Dates
void PrintList(DatePtr list);
// Create a single node in our list
DatePtr CreateNode(int dy, int mn, int yr);
//--------------------------------------------------------------------

void main (void)
{
	DatePtr head, temp;  
	  
	head = NULL;
	for (int i = 1; i<5; i++) {
		temp = CreateNode(i,02,2002);
		temp->next = head;  // Insert at front
		head = temp;        // add the rest of list
	} 
	PrintList(head);
	
}

//--------------------------------------------------------------------
// Insert your functions here.
//--------------------------------------------------------------------
DatePtr CreateNode(int dy, int mn, int yr)
{
	DatePtr temp = new Date;
	
	temp->day = dy;      // Initialize structure
	temp->month = mn;
	temp->year = yr;
	temp->next = NULL; // We aren't inserting yet

	return(temp);
} 
void PrintList(DatePtr list)
{
	DatePtr temp = list;
	
	while (temp != NULL)
	{
		cout << temp->month << ":";
		cout << temp->day   << ":";
		cout << temp->year  << endl;
		temp = temp->next;
	}
} 