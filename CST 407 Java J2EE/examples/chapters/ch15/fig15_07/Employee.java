// Employee.java
// Employee is the remote interface for the Address EJB.
package com.deitel.advjhtp1.ejb.entity;

// Java core libraries
import java.rmi.RemoteException;

// Java standard extensions
import javax.ejb.EJBObject;

public interface Employee extends EJBObject {
  
   // get Employee ID
   public Integer getEmployeeID() throws RemoteException;
   
   // set social security number
   public void setSocialSecurityNumber( String number )
      throws RemoteException;
   
   // get social security number
   public String getSocialSecurityNumber() 
      throws RemoteException;
   
   // set first name
   public void setFirstName( String name ) 
      throws RemoteException;
   
   // get first name
   public String getFirstName() throws RemoteException;
   
   // set last name
   public void setLastName( String name )
      throws RemoteException;
   
   // get last name
   public String getLastName() throws RemoteException;
   
   // set title
   public void setTitle( String title )
      throws RemoteException;
   
   // get title
   public String getTitle() throws RemoteException;
   
   // set salary
   public void setSalary( Double salary ) throws RemoteException;
   
   // get salary
   public Double getSalary() throws RemoteException;
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