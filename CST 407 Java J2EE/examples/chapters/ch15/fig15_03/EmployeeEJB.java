// EmployeeEJB.java
// EmployeeEJB is an entity EJB that uses bean-managed
// persistence to persist Employee data in a database.
package com.deitel.advjhtp1.ejb.entity.bmp;

// Java core libraries
import java.sql.*;
import java.rmi.RemoteException;

// Java standard extensions
import javax.ejb.*;
import javax.sql.*;
import javax.naming.*;

public class EmployeeEJB implements EntityBean {
   
   private EntityContext entityContext;
   private Connection connection;

   private Integer employeeID;
   private String socialSecurityNumber;
   private String firstName;
   private String lastName;
   private String title;
   private Double salary;
      
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
   
   // create new Employee
   public Integer ejbCreate( Integer primaryKey ) 
      throws CreateException
   {
      employeeID = primaryKey;
           
      // INSERT new Employee in database
      try {
         
         // create INSERT statement
         String insert = "INSERT INTO Employee " +
            "( employeeID ) VALUES ( ? )";

         // create PreparedStatement to perform INSERT
         PreparedStatement insertStatement = 
            connection.prepareStatement( insert );

         // set values for PreparedStatement
         insertStatement.setInt( 1, employeeID.intValue() );

         // execute INSERT and close PreparedStatement
         insertStatement.executeUpdate();
         insertStatement.close();

         return employeeID;
      }
      
      // throw EJBException if INSERT fails
      catch ( SQLException sqlException ) {
         throw new CreateException( sqlException.getMessage() );
      } 
   } // end method ejbCreate
   
   // do post-creation tasks when creating new Employee
   public void ejbPostCreate( Integer primaryKey ) {}
   
   // remove Employee information from database
   public void ejbRemove() throws RemoveException
   {
      // DELETE Employee record
      try {
         
         // get primary key of Employee to be removed
         Integer primaryKey = 
            ( Integer ) entityContext.getPrimaryKey(); 
         
         // create DELETE statement
         String delete = "DELETE FROM Employee WHERE " +
            "employeeID = ?";        

         // create PreparedStatement to perform DELETE
         PreparedStatement deleteStatement = 
            connection.prepareStatement( delete );
         
         // set values for PreparedStatement
         deleteStatement.setInt( 1, primaryKey.intValue() );

         // execute DELETE and close PreparedStatement
         deleteStatement.executeUpdate();
         deleteStatement.close();
      }
      
      // throw new EJBException if DELETE fails
      catch ( SQLException sqlException ) {
         throw new RemoveException( sqlException.getMessage() );
      } 
   } // end method ejbRemove
   
   // store Employee information in database
   public void ejbStore() throws EJBException 
   {
      // UPDATE Employee record
      try {
         
         // get primary key for Employee to be updated
         Integer primaryKey = 
            ( Integer ) entityContext.getPrimaryKey();     
         
         // create UPDATE statement
         String update = "UPDATE Employee SET " +
            "socialSecurityNumber = ?, firstName = ?, " +
            "lastName = ?, title = ?, salary = ? " +
            "WHERE employeeID = ?";

         // create PreparedStatement to perform UPDATE
         PreparedStatement updateStatement = 
            connection.prepareStatement( update );
         
         // set values in PreparedStatement
         updateStatement.setString( 1, socialSecurityNumber );
         updateStatement.setString( 2, firstName );
         updateStatement.setString( 3, lastName );
         updateStatement.setString( 4, title );
         updateStatement.setDouble( 5, salary.doubleValue() );
         updateStatement.setInt( 6, primaryKey.intValue() );

         // execute UPDATE and close PreparedStatement
         updateStatement.executeUpdate();
         updateStatement.close();
      }
      
      // throw EJBException if UPDATE fails
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      } 
   } // end method ejbStore
   
   // load Employee information from database
   public void ejbLoad() throws EJBException 
   {
      // get Employee record from Employee database table
      try {
         
         // get primary key for Employee to be loaded
         Integer primaryKey = 
            ( Integer ) entityContext.getPrimaryKey();           

         // create SELECT statement
         String select = "SELECT * FROM Employee WHERE " +
            "employeeID = ?";
         
         // create PreparedStatement for SELECT
         PreparedStatement selectStatement = 
            connection.prepareStatement( select );

         // set employeeID value in PreparedStatement
         selectStatement.setInt( 1, primaryKey.intValue() );

         // execute selectStatement
         ResultSet resultSet = selectStatement.executeQuery();

         // get Employee information from ResultSet and update
         // local member variables to cache data
         if ( resultSet.next() ) {

            // get employeeID
            employeeID = new Integer( resultSet.getInt( 
               "employeeID" ) );

            // get social-security number
            socialSecurityNumber = resultSet.getString( 
               "socialSecurityNumber" );

            // get first name
            firstName = resultSet.getString( "firstName" );

            // get last name
            lastName = resultSet.getString( "lastName" );

            // get job title
            title = resultSet.getString( "title" );

            // get salary
            salary = new Double( resultSet.getDouble( 
               "salary" ) );
            
         } // end if
         
         else
            throw new EJBException( "No such employee." );
         
         // close PreparedStatement
         selectStatement.close();
         
      } // end try
      
      // throw EJBException if SELECT fails
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }    
   } // end method ejbLoad
   
   // find Employee using its primary key
   public Integer ejbFindByPrimaryKey( Integer primaryKey )
      throws FinderException, EJBException
   {     
      // find Employee in database
      try {
         
         // create SELECT statement
         String select = "SELECT employeeID FROM Employee " +
            "WHERE employeeID = ?";
         
         // create PreparedStatement for SELECT
         PreparedStatement selectStatement = 
            connection.prepareStatement( select );
         
         // set employeeID value in PreparedStatement
         selectStatement.setInt( 1, primaryKey.intValue() );

         // execute selectStatement
         ResultSet resultSet = selectStatement.executeQuery();

         // return primary key if SELECT returns a record
         if ( resultSet.next() ) {
            
            // close resultSet and selectStatement
            resultSet.close();
            selectStatement.close();
            
            return primaryKey;
         }
         
         // throw ObjectNotFoundException if SELECT produces
         // no records
         else 
            throw new ObjectNotFoundException();
      }
      
      // throw EJBException if SELECT fails
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }   
   } // end method ejbFindByPrimaryKey
   
   // set EntityContext and create DataSource Connection
   public void setEntityContext( EntityContext context ) 
      throws EJBException 
   {
      // set entityContext
      entityContext = context;
      
      // look up the Employee DataSource and create Connection
      try {
         InitialContext initialContext = new InitialContext();

         // get DataSource reference from JNDI directory
         DataSource dataSource = ( DataSource )
            initialContext.lookup( 
               "java:comp/env/jdbc/Employee" );

         // get Connection from DataSource
         connection = dataSource.getConnection();
      }
      
      // handle exception if DataSource not found in directory
      catch ( NamingException namingException ) {
         throw new EJBException( namingException );
      }
      
      // handle exception when getting Connection to DataSource
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }
   } // end method setEntityContext
   
   // unset EntityContext
   public void unsetEntityContext() throws EJBException 
   {
      entityContext = null;
      
      // close DataSource Connection
      try {
         connection.close();
      }

      // throw EJBException if closing Connection fails
      catch ( SQLException sqlException ) {
         throw new EJBException( sqlException );
      }
      
      // prepare connection for reuse
      finally {
         connection = null;
      }
   }
   
   // set employeeID to null when container passivates EJB
   public void ejbPassivate()
   {
      employeeID = null;
   }
   
   // get primary key value when container activates EJB
   public void ejbActivate()
   {
      employeeID = ( Integer ) entityContext.getPrimaryKey();
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