// OutofPaperPolicy.java
// This class defines the interface for the dynamic service.
package com.deitel.advjhtp1.jiro.DynamicService.policy;

// Java core package
import java.rmi.*;
import java.util.*;

// Jini core package
import net.jini.core.event.*;

public interface OutofPaperPolicy extends RemoteEventListener {

   public void stopPolicy( ) throws RemoteException;
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
