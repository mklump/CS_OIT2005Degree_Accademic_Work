//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 26, 2002
// Last Change Date:  August 26, 2002
// Project:        Ordered List
// Filename:       Exercise1-MapSTL.cpp
//
// Overview:  Test program that reassembles numbered text packets that
//			  are randomized in a text file using the Map Structure in
//			  the standard template library.
//     
//--------------------------------------------------------------------

#pragma warning(disable:4786)
#include <iostream>
#include <fstream>
#include <map>

using namespace std;

const int PACKETSIZE = 6;	// Number of characters in a packet
							// including null ('\0') terminator
struct Packet
{
	int position;			// Packet's potistion within the message
	char body[PACKETSIZE];	// Character's in the packet

	inline int key() const
		{ return position; }// Returns the key field
};

int main(void)
{
	Packet packet;
	map<int, Packet> decipher;
	
	int indexKey = 0; // Loop variable for the STL
					  // map's overloaded subscript
					  // operator []

	ifstream iFile("message.dat");
	
	if( iFile.fail() )
		cout << endl << "Could not open file, \"message.dat\"" << endl;
	
	// Input the scrambled message
	while( iFile >> packet.position && 
		   iFile.ignore(1) &&
		   iFile.get( (char*)packet.body, 6) )
	{
		decipher.insert(make_pair(packet.position, packet));
	}

	// Output the unscrambled message
	
	cout << endl;
	while( indexKey < decipher.size() )
	{
		cout << decipher[indexKey].body;
		++indexKey;
	}
	cout << endl << endl;
	
	return 0;
}