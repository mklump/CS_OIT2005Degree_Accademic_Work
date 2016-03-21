#include <iostream>

using namespace std;

class IntegerPointer
{
public:
	IntegerPointer() : m_ptr(NULL) {};
	IntegerPointer(const IntegerPointer& rhs);
	IntegerPointer operator = (const IntegerPointer& rhs);
private:
	int * m_ptr;
};

void main()
{

}

IntegerPointer::IntegerPointer(const IntegerPointer& rhs)
{
	m_ptr = rhs.m_ptr;
}