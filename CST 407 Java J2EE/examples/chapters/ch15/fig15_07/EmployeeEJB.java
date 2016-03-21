// EmployeeEJB.java
// EmployeeEJB is an entity EJB that uses container-managed
// persistence to persist Employee data in a database.
package com.deitel.advjhtp1.ejb.entity.cmp;

// Java core libraries
import java.rmi.RemoteException;

// Java standard extensions
import javax.ejb.*;

public class EmployeeEJB implements EntityBean {
   
   private EntityContext entityContext;

   // container-managed fields
   public Integer employeeID;
   public String socialSecurityNumber;
   public String firstName;
   public String lastName;
   public String title;
   public Double salary;
   
   // get Employee ID
   public Integer getEmployeeID()
   {
      return employeeID;
   }
   
   // set social security number
   public void setSocialSecurityNumber( String number )
   {
      socialSecurityNumber = number;
   }
   
   // get social security number
   public String getSocialSecurityNumber()
   {
      return socialSecurityNumber;
   }
   
   // set first name
   public void setFirstName( String name )
   {
      firstName = name;
   }
   
   // get first name
   public String getFirstName()
   {
      return firstName;
   }
   
   // set last name
   public void setLastName( String name )
   {
      lastName = name;
   }
   
   // get last name
   public String getLastName()
   {
      return lastName;
   }
   
   // set title
   public void setTitle( String jobTitle )
   {
      title = jobTitle;
   }
   
   // get title
   public String getTitle()
   {
      return title;
   }
   
   // set salary
   public void setSalary( Double amount )
   {
      salary = amount;
   }
   
   // get salary
   public Double getSalary() 
   {
      return salary;
   }
   
   // create new Employee instance
   public Integer ejbCreate( Integer primaryKey )
   {    
      employeeID = primaryKey;
      
      return null;
   }
   
   // do post-creation tasks when creating new Employee
   public void ejbPostCreate( Integer primaryKey ) {}
   
   // set EntityContext
   public void setEntityContext( EntityContext context )
   {
      entityContext = context;
   }
   
   // unset EntityContext
   public void unsetEntityContext() 
   {
      entityContext = null;
   }
   
   // activate Employee instance
   public void ejbActivate() 
   {
      employeeID = ( Integer ) entityContext.getPrimaryKey();
   }
   
   // passivate Employee instance
   public void ejbPassivate() 
   {
      employeeID = null;
   }
   
   // load Employee instance in database
   public void ejbLoad() {}
   
   // store Employee instance in database
   public void ejbStore() {}
   
   // remove Employee instance from database
   public void ejbRemove() {}  
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