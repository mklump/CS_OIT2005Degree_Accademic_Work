//---------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   29 July 2003
// Last Change Date:  31 July 2003
// Project:        Minimal VS. Perfect Minimal Hash
// Filename:       minimal_hash.h
//
// Overview:  Header file for the minimal_hash class meant to inmitate
//			  all the properties and expectancies of a minimal hash
//			  table.
//			  The size of the Hash Table for this class is n^2 if n
//			  is the number of data elements that will hash into the
//			  Hash Table --> record **Table.
//
// Input:  Input is provider to this class via the driver method main.
//
// Output: The output for this program is printed to a "output.txt."
//   
//----------------------------------------------------------------------
#pragma once
#include <fstream>
#include <time.h>
#include <crtdbg.h>

using namespace std;

struct record
{
	char *data;
	int key,
		key2;
	record *next;
};

extern int NUM_TRANSFERS,
		   NUM_DATAUMS;
static int TABLE_SIZE = 0,
		   file_run = 0;

class minimal_hash
{
public:
	friend class perfect_minimal;
	minimal_hash()	{ }				// Not implemented
	minimal_hash(ifstream &iFile);

	~minimal_hash(void);

	int
		Hash1(
			  // This returns the hashed value for the hash fuction
			  // h(k) = ((85*k + 1195) modulus 2873 ) modulus 256
			  const int &key
			  );
	record *
		Hash_Insert(
							record **T,
							char *data
							);
	record *
		Hash_Search(
							record **T,
							const record *element
							);
	void
		Hash_Delete(
							record **T,
							record *element
							);
	record **
		Get_Table()
				{ return Table; }
	char *
		Get_InputFile()
				{ return inputfile; }
private:
	record **Table;
	char *inputfile;
};
