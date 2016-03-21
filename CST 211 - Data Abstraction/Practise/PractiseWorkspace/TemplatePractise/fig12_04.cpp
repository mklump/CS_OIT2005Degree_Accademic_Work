// Fig. 12.4: fig12_04.cpp
// Test driver for Stack template.
// Function main uses a function template to manipulate
// objects of type Stack< T >.
#include <iostream>
#include <string>
#include <cstring>

using std::cout;
using std::cin;
using std::endl;

#include "tstack1.h"
#include "package.h"

// Function template to manipulate Stack< T >
template< class T >
void testStack( 
   Stack< T > &theStack,   // reference to the Stack< T >
   T value,                // initial value to be pushed
   T increment,            // increment for subsequent values
   const char *stackName ) // name of the Stack < T > object
{
   cout << "\nPushing elements onto " << stackName << '\n';

   while ( theStack.push( value ) ) { // success true returned
      cout << value << ' ';
      value += increment;
   }

   cout << "\nStack is full. Cannot push " << value 
        << "\n\nPopping elements from " << stackName << '\n';

   while ( theStack.pop( value ) )  // success true returned
      cout << value << ' ';

   cout << "\nStack is empty. Cannot pop\n";
}

//string b1( "cat" );

int main()
{
	CPackage *package = new CPackage;

	package->setId(23653);
	cout << package->getId();
	Stack< double > doubleStack( 5 );   
	Stack< int > intStack;

	testStack( doubleStack, 1.1, 1.1, "doubleStack" );
	testStack( intStack, 1, 1, "intStack" );

	return 0;
}



/**************************************************************************
 * (C) Copyright 2000 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
