   // DOMV
#include <iostream>
using std::ostream;
   class CPackage {
   public:
	   CPackage();
	   ~CPackage();
	   void setId(int id);
	   int getId();

friend ostream &operator<<( ostream&, const CPackage & );   
   private:
	   int package_id;
   };
