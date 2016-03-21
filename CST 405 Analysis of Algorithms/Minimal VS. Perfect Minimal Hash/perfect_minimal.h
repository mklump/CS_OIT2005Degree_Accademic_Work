#pragma once
#include "minimal_hash.h"

class perfect_minimal :
	public minimal_hash
{
public:
	perfect_minimal( void ) { } // Not Implemented

	perfect_minimal(
					ifstream &iFile
					);
	~perfect_minimal(void);

	int
		Hash2(
			  // This returns the hashed value for the hash fuction
			  // h(k) = ((85*k + 1195) modulus 2873 ) modulus sub_array_size
			  const int &key,
			  const int &sub_array_size
			  );
	record *
		Hash_Insert(
							record ***T,
							char *data
							);
	record *
		Hash_Search(
							record ***T,
							const record *element
							);
	void
		Hash_Delete(
							record ***T,
							record *element
							);

	record *
		operator =(
				   record &right
				   );
	record ***
		Get_Table()
				{ return Table_p; }
private:
	record ***Table_p;
	int *sub_array_size;
};
