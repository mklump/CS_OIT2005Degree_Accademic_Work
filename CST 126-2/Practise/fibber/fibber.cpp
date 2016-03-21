//--------------------------------------------------------------------
// Author:          P. Hannan      
// Date Created:    Dec 4, 2001
// Last Change Date:  
// Project:      fibber magee's closet  
// Filename:     fibber.cpp
//
// Overview:     This program simulates a closet at Paula's house
//   
// Input:        None
//   
// Output:	     Spilling over closet
//   
//--------------------------------------------------------------------

#include <iostream>
#include <string>
  using namespace std;

//fibber to show friend functions


class fibber {
public:
   //  Constructor
   fibber(int i, int j = 0);  
   // Output
   void  print(string name) const;      //formatted printout
   
   // Add functions
   void  stuff();            //add to the closet
   //If fibber add was not a friend function, the private member data
   //of this class would have to be PUBLIC!!!
   friend fibber add(fibber f1, fibber f2);
   friend fibber operator+(fibber f1, fibber f2);

private:
   int m_lost_socks, m_cheap_hangers;
};


//--------------------------------------------------------------------

void main()
{
   // Notice the two different calls to the constructor.
   cout << " ------- Declarations -----------" << endl;
   fibber  linen(59), hall(99,55); 
   cout << endl;
   fibber cleaned(0);
   fibber silly(5);
 

   cout << "\n------- AFTER Declarations-----------" << endl;
   silly = 6;
   cout << endl;
   silly.print("silly");
   cout << endl;
   
   cout << "Initial values are" << endl;
   cout << "---------------------------------" << endl;
   linen.print("linen");
   hall.print("hall");
   cleaned.print("Cleaned");

   cout << "Add" << endl;
   cout << "---------------------------------" << endl;
   
   cleaned = add(linen, hall);
   cleaned.print("Cleaned");
   
}
//--------------------------------------------------------------------
// FIBBER functions
//--------------------------------------------------------------------

fibber::fibber(int i,int j)
{
	cout << "fibber::fibber i="<< i << " j=" << j << "\t";
   m_lost_socks = i;
   m_cheap_hangers = j;
}
void fibber::stuff()
{

   m_lost_socks++;
   m_cheap_hangers++;

}
fibber add (fibber c1, fibber c2)
{
   fibber temp(0);
   
   temp.m_lost_socks = c1.m_lost_socks + c2.m_lost_socks;
   temp.m_cheap_hangers = c1.m_cheap_hangers + c2.m_cheap_hangers;
   
   return (temp);
}

fibber operator+(fibber c1, fibber c2)
{
	fibber temp(0);
	
	temp.m_lost_socks = c1.m_lost_socks + c2.m_lost_socks;
	temp.m_cheap_hangers = c1.m_cheap_hangers + c2.m_cheap_hangers;
	return (temp);
}
void fibber::print(string name) const
{
	
   cout << "The " << name << " closet has: " ;
   cout  << "Hangers "  << m_cheap_hangers << " Socks " << m_lost_socks << endl;
   cout << "---------------------------------" << endl;
}

