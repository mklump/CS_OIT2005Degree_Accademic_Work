// DOMV
#include "package.h"

CPackage::CPackage()
{
	package_id = 0;
}

CPackage::~CPackage()
{}

void CPackage::setId(int id)
{
	package_id = id;
}

int CPackage::getId()
{
	return package_id;
}

ostream &operator<<( ostream &output, const CPackage &package )
{
   output << "(" << package.package_id << ") ";
   return output;     // enables cout << a << b << c;
}
