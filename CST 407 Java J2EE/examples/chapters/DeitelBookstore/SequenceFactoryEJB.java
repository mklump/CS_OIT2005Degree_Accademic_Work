// SequenceFactoryEJB.java
// Entity EJB SequenceFactory generates unique primary keys.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;
import java.util.ArrayList;

// Java extension packages
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.PortableRemoteObject;

public class SequenceFactoryEJB implements EntityBean {
   private EntityContext entityContext;

   // container-managed fields
   public String tableName;    // table name for ID sequence
   public Integer nextID;      // next available unique ID

   // get next available orderID
   public Integer getNextID() 
   {
      // store nextID for returning to caller
      Integer ID = new Integer( nextID.intValue() );
      
      // increment ID to produce next available unique ID
      nextID = new Integer( ID.intValue() + 1 );
      
      return ID;
   }
   
   // set entity context
   public void setEntityContext( EntityContext context ) 
   {
      entityContext = context; 
   }

   // unset entity context
   public void unsetEntityContext() 
   { 
      entityContext = null; 
   }
   
   // activate SequenceFactory EJB instance
   public void ejbActivate() 
   {
      tableName = ( String ) entityContext.getPrimaryKey();
   }

   // passivate SequenceFactory EJB instance
   public void ejbPassivate() 
   {
      tableName = null;
   }

   // remove SequenceFactory EJB instance
   public void ejbRemove() {}

   // store SequenceFactory EJB data in database
   public void ejbStore() {}

   // load SequenceFactory EJB data from database
   public void ejbLoad() {}
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
