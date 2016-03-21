//---------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   29 July 2003
// Last Change Date:  31 July 2003
// Project:        Minimal VS. Perfect Minimal Hash
// Filename:       minimal_hash.cpp
//
// Overview:  Implementation file for the minimal_hash class meant to
//			  inmitate all the properties and expectancies of a minimal
//			  hash table.
//
// Input:  Input is provider to this class via the driver method main.
//
// Output: The output for this program is printed to a "output.txt."
//   
//----------------------------------------------------------------------
#include "minimal_hash.h"

minimal_hash::minimal_hash(
						   ifstream &iFile
						   )
{
	switch(file_run)
	{
	case 0:
		inputfile = strdup( "1000words.txt" );
		break;
	case 1:
		inputfile = strdup( "10000words.txt" );
		break;
	case 2:
		inputfile = strdup( "100000words.txt" );
		break;
	case 3:
		inputfile = strdup( "1000000words.txt" );
	default:
		break;
	}
	iFile.open( inputfile, ios::in );
	char buffer[256];
	while( iFile >> buffer )
		TABLE_SIZE++;
	file_run++;
	Table = new record *[TABLE_SIZE];
	for( int index = 0; index < TABLE_SIZE; ++index )
	{
		Table[index] = NULL;
	}
	iFile.clear();
	iFile.seekg( ios::beg );
}

minimal_hash::~minimal_hash(
							void
							)
{
	delete [] Table;
}

int
minimal_hash::Hash1(
					const int &key
					)
{   // This returns the hashed value for the hash fuction
	// h(k) = ((85*k + 1195) modulus 2873 ) modulus 256
	return ( ( ( 85 * key + 1195 ) % 2873 ) % 256 );
}

record *
minimal_hash::Hash_Insert(
						  record **T,
						  char *data
						  )
{
	static int key = 0;
	record *entry = new record;
	entry->data = strdup( data ); NUM_TRANSFERS++;
	entry->key = ++key;			  NUM_DATAUMS++;
	entry->next = NULL;

	int index = Hash1( entry->key );
	T[ index ] = new record;
	return T[ index ]->next = entry;
}

record *
minimal_hash::Hash_Search(
						  record **T,
						  const record *element
						  )
{
	for( int index = 0; index < TABLE_SIZE; ++index )
	{
		if( T[index] != NULL )
		{
			if ( (unsigned int)T[index]->data == 0xcdcdcdcd )
				T[index]->data = strdup( "" );
		}
		while( T[index] != NULL && element != NULL &&
			   (unsigned int)element->data != 0xcdcdcdcd )
		{
			if( strcmp(T[index]->data, element->data) == 0 )
				return T[index];
			else
				T[index] = T[index]->next;
		}
	}
	return NULL;
}

void
minimal_hash::Hash_Delete(
						  record **T,
						  record *element
						  )
{
	record *temp = Hash_Search( T, element ),
		   *last;
	if( element == NULL )
		return;
	last = T[ Hash1(temp->key) ];
	if( last == NULL || temp == NULL )
		return;
	while( last != NULL && last->next != temp )
		last = last->next;
	temp = NULL;
}