//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 22, 2002
// Last Change Date:  August 22, 2002
// Project:        Ordered List
// Filename:       Packet Assembler.cpp
//
// Overview:  Test program that reassembles numbered text packets that
//			  are randomized in a text file using the Ordered List ADT
//     
//--------------------------------------------------------------------

#include <fstream>
#include "listord.cpp"

const int PACKETSIZE = 6;	// Number of characters in a packet
							// including null ('\0') terminator
struct Packet
{
	int position;			// Packet's potistion within the message
	char body[PACKETSIZE];	// Character's in the packet

	inline void setkey(const int& key)
		{ position = key; } // Sets the key field
	inline int key() const
		{ return position; }// Returns the key field
};

int main(void)
{
	OrdList<Packet,int> decipher(128);
	Packet packet;

	ifstream iFile("message.dat");

	if( iFile.fail() )
		cout << endl << "Could not open file, \"message.dat\"" << endl;

	// Input the scrambled message
	while( iFile >> packet.position && 
		   iFile.ignore(1) &&
		   iFile.get( (char*)packet.body, 6) )
	{
		decipher.insert(packet);
	}

	// Output the unscrambled message
	decipher.gotoBeginning();
	cout << endl;
	while( !decipher.empty() )
	{
		cout << decipher.getCursor().body;
		decipher.remove();
	}
	cout << endl << endl;
	
	return 0;
}