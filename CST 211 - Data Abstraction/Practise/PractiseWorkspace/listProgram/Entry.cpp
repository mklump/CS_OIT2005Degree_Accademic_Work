//Note: YOU MUST EXCLUDE ENTRY.CPP FROM THE PROJECT BUILD
#include "StdAfx.h"
#include <iostream>
#include <string>
#include "Time.h"

using namespace std;

template <class T>
Entry<T>::Entry(void)
: time(0, 0, 0)
{
	entry = "";
	count++;
}

template <class T>
Entry<T>::Entry(const Time& t, T s)
: time(t)
{
	entry = s;
	count++;
}

template <class T>
Entry<T>::Entry(int hr, int min, T s)
: time(hr, min, 0), entry(s)
{
	count++;
}

template <class T>
Entry<T>::~Entry(void)
{
	count--;
}

template <class T>
int Entry<T>::getCount() {
	return count;
}

template <class T>
int Entry<T>::count = 0;		

template <class T>
ostream& operator<< (ostream& output, const Entry<T>& e) {
	output << e.time << "\t" << e.entry;
	return output;
}
