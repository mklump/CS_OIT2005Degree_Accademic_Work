// SeminarProvider.java
// SeminarProvider is an Entry object for the SeminarInfo service.
package com.deitel.advjhtp1.jini.utilities.entry;

// Jini extension package
import net.jini.entry.*;
import net.jini.lookup.entry.*;

public class SeminarProvider extends AbstractEntry 
   implements ServiceControlled
{
   public String providerName = "";
   
   // no-argument constructor
   public SeminarProvider() {}
   
   // SeminarProvider constructor for specifying providerName
   public SeminarProvider( String provider )
   {
      providerName = provider;
   }
}

/***************************************************************
 * (C) Copyright 2002 by Deitel & Associates, Inc. and         *
 * Prentice Hall. All Rights Reserved.                         *
 *                                                             *
 * DISCLAIMER: The authors and publisher of this book have     *
 * used their best efforts in preparing the book. These        *
 * efforts include the development, research, and testing of   *
 * the theories and programs to determine their effectiveness. *
 * The authors and publisher make no warranty of any kind,     *
 * expressed or implied, with regard to these programs or to   *
 * the documentation contained in these books. The authors     *
 * and publisher shall not be liable in any event for          *
 * incidental or consequential damages in connection with, or  *
 * arising out of, the furnishing, performance, or use of      *
 * these programs.                                             *
 ***************************************************************/