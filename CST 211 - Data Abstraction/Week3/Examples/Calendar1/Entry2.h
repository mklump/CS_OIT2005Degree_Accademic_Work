#pragma once

class Entry2
{
public:
	Entry2(const Time&, string);
	Entry2(int, int, string);
	~Entry2(void);
	static int getCount();
private:
	Time time;			//Note the use of composition here.
	string entry;		//An Entry2 contains a Time and a string.
	static int count;
friend ostream& operator<< (ostream&, const Entry2&);
};
