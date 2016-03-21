#pragma once

class Entry
{
public:
	Entry(const Time&, const char*);
	Entry(int, int, const char*);
	Entry(const Entry&);
	~Entry(void);
	Entry& operator= (const Entry&);
	static int getCount();
private:
	Time time;			//Note the use of composition here.
	char* entry;		//An Entry contains a Time and a string.
	static int count;
friend ostream& operator<< (ostream&, const Entry&);
};
