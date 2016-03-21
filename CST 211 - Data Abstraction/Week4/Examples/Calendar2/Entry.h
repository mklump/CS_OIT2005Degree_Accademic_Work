#pragma once

template <class T>
class Entry
{
public:
	Entry(const Time&, const T&);
	Entry(int, int, const T&);
	~Entry(void);
	static int getCount();
private:
	Time time;			
	T entry;		
	static int count;
friend ostream& operator<< (ostream&, const Entry<T>&);
};

typedef Entry<string> StringEntry;	
typedef Entry<double> NumberEntry;

#include "Entry.cpp"	//NOTE: THE .H FILE MUST INCLUDE THE .CPP AT THE END
				//YOU MUST EXCLUDE THE CPP FILE FROM THE PROJECT BUILD
