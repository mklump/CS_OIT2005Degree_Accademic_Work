#include "perfect_minimal.h"

perfect_minimal::perfect_minimal(
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
	sub_array_size = new int[TABLE_SIZE];
	Table = new record *[TABLE_SIZE];
	for( int index = 0; index < TABLE_SIZE; ++index )
	{
		Table[index] = NULL;
		sub_array_size[index] = 0;
	}
	iFile.clear();
	iFile.seekg( ios::beg );
	Table_p = new record **[TABLE_SIZE];
	for( int x = 0; x < TABLE_SIZE; ++x )
	{
		for( int y = 0; y < 1; ++y )
		{
			Table_p[ x ] = new record *;
			Table_p[ x ][ y ] = Table[ y ];
		}
	}
}

perfect_minimal::~perfect_minimal(
								  void
								  )
{
	delete [] Table_p;
}

int
perfect_minimal::Hash2(
					   const int &key,
					   const int &sub_array_size
					   )
{
	return ( ( (85 * key + 1195) % 2873 ) % sub_array_size );
}

record *
perfect_minimal::Hash_Insert(
							 record ***T,
							 char *data
							 )
{
	// Prepare a new entry into the Perfect Minimal Hash Table
	static int key1 = 0, key2 = 0;
	record *entry;
	entry = new record;
	entry->data = strdup( data ); NUM_TRANSFERS++;
	entry->key = ++key1;		  NUM_DATAUMS++;
	entry->key2 = key2 = NUM_DATAUMS * NUM_DATAUMS;
	entry->next = NULL;

	// Setup a temporary storage for slot x in the Hash Table T.
	int x = Hash1( entry->key ),
	    m = ++sub_array_size[ x ];
	record *temp = new record[ m ];

	// Reallocate the size of the array at slot x.
	for( int z = 0; z < sub_array_size[ x ] &&
			T[ x ][ z ] != NULL; ++z )
		temp[ z ] = *T[ x ][ z ];
	T[ x ] = new record*[ m ];
	for( z = 0; z < sub_array_size[ x ]; ++z )
		T[ x ][ z ] = &temp[ z ];

	// Insert the new entry into slot array x at secondary
	// hashed location y.
	int y = Hash2( key1, key2 );
	return T[ x ][ y ] = entry;
}

record *
perfect_minimal::Hash_Search(
							 record ***T,
 							 const record *element
							 )
{
	for( int index = 0; index < TABLE_SIZE; ++index )
	{
		for( int y = 0; y < (sizeof(T[index])/sizeof(T[index][0])); ++y )
		{
			if( T[index][y] != NULL )
			{
				if ( (unsigned int)T[index][y]->data == 0xcdcdcdcd )
					T[index][y]->data = strdup( "" );
			}
			if( T[index][y] != NULL && element != NULL &&
				(unsigned int)element->data != 0xcdcdcdcd )
			{
				if( strcmp(T[index][y]->data, element->data) == 0 )
					return T[index][y];
			}
		}
	}
	return NULL;
}

void
perfect_minimal::Hash_Delete(
							 record ***T,
							 record *element
							 )
{
	record *temp = Hash_Search( T, element ),
		   *last;
	if( element == NULL )
		return;
	last = T[ Hash1(temp->key) ][ Hash2(temp->key, temp->key2) ];
	if( last == NULL || temp == NULL )
		return;
	temp = NULL;
}

record *
perfect_minimal::operator =(
							record &right
							)
{
	record *temp = new record;
	temp->data = strdup( right.data );
	temp->key = right.key;
	temp->next = right.next;
	return temp;
}
