//--------------------------------------------------------------------
// Author:         P. Hannan   
// Date Created:   18 Feb 2002
// Last Change Date:  
// Project:        Linked List demonstration
// Filename:       dict.h
//
// Overview:	   provides a dictionary object
//   
//--------------------------------------------------------------------

#ifndef DICTH
#define DICTH
#include <string>
  using namespace std;

struct word_list {
	string french_word;
	string english_word;
	word_list * next;
	
};

typedef word_list * ListPtr;

class dictionary {
	public:
	//  this isn't the best we to do the constructor.  You'll learn
	// a better way in 136
		dictionary(void)   {head = NULL;};	   
		~dictionary(void);
		void display(void) const;
		void dictionary::append(string inEng, string inFr);
		void dictionary::AddEngSorted(string inEng, string inFr);
		bool ValidWord(string, string &, bool) ;
	private:
		ListPtr head;
};

int compare_words(ListPtr theWord, string check_word, bool french );
ListPtr create_node(string inEng, string inFr);


		
#endif;
