//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   July 10, 2002
// Last Change Date:  July 10, 2002
// Project:        STRING
// Filename:       String.cpp
//
// Overview:  This include contains the implentation of the
//			  String class.
//     
//--------------------------------------------------------------------

#include "String.h"

#include <iostream>
#include <iomanip>

using namespace std;

//--------------------------------------------------------------------

String::String ( const int& numChars ) // Create an empty string
{
	bufferSize = numChars + 1;
	buffer = new char[bufferSize];
	strcpy(buffer , "");
}
String::String ( const char *charSeq ) // Initialize using char*
{
	bufferSize = static_cast<int>(strlen( charSeq )) + 1;
	buffer = new char[bufferSize];
	strcpy(buffer, charSeq);
}

String::String ( const String &valueString )
{
	buffer = new char[ strlen( valueString.buffer ) + 1 ];	//Allocate same size String
	bufferSize = static_cast<int>( strlen( buffer ) );
	strcpy( buffer, valueString.buffer );
}

//--------------------------------------------------------------------

String:: ~String ()
{
	delete [] buffer;
}

//--------------------------------------------------------------------

int String::length () const
{
	return static_cast<int>( strlen(buffer) );
}

char String::operator [] ( int n ) const
{
	return *(buffer + n);
}

void String::operator = ( const String &rightString ) throw()
{
	if( this == &rightString)
		return;
	this->~String();
	buffer = new char[ strlen( rightString.buffer ) + 1 ];	//Allocate same size String
	bufferSize = static_cast<int>( strlen( buffer ) );
	strcpy( buffer, rightString.buffer );
}

void String::clear()
{
	strcpy(buffer, "");
}

//--------------------------------------------------------------------

void String::showStructure () const
{
	cout << "This String prints as : ";
	for(int iterator=0; iterator < int(strlen(buffer) + 1); ++iterator)
		cout << *(buffer + iterator);
	cout << endl << endl;
}

char* String::getBuffer() const
{
	return buffer;
}

//--------------------------------------------------------------------

istream& operator>> ( istream& input, String& inputString )

// String input function. Extracts a string from istream input and
// returns it in inputString. Returns the state of the input stream.

{
	const int textBufferSize = 256;
	char textBuffer[textBufferSize];
    
	// Read a string into textBuffer, setw is used to prevent buffer
    // overflow.
	input >> setw(textBufferSize) >> textBuffer;

	strcpy(inputString.buffer, textBuffer);

	// Return the state of the input stream.
	return input;
}

ostream& operator<< ( ostream& output, const String& outputString )

// String output function. Inserts outputString in ostream output.
// Returns the state of the output stream.

{
   output << outputString.buffer;
   return output;
}

//--------------------------------------------------------------------

int operator == ( const String& leftString, const String& rightString )
{
	if( strcmp( leftString.buffer, rightString.buffer ) == 0 )
		return 1;
	else
		return 0;
}

int operator < ( const String& leftString, const String& rightString )
{
	if( strcmp( leftString.buffer, rightString.buffer ) < 0 )
		return 1;
	else
		return 0;
}

int operator > ( const String& leftString, const String& rightString )
{
	if( strcmp( leftString.buffer, rightString.buffer ) > 0 )
		return 1;
	else
		return 0;
}