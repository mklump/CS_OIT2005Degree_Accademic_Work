// EmployeeEJBClient.java
// EmployeeEJBClient is a user interface for interacting with
// bean- and container-managed persistence Employee EJBs.
package com.deitel.advjhtp1.ejb.entity.client;

// Java core libraries
import java.awt.*;
import java.awt.event.*;
import java.text.*;
import java.util.*;
import java.rmi.RemoteException;

// Java standard extensions
import javax.swing.*;
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.*;

// Deitel libraries
import com.deitel.advjhtp1.ejb.entity.*;

public class EmployeeEJBClient extends JFrame {
   
   // variables for accessing EJBs
   private InitialContext initialContext;
   private EmployeeHome employeeHome;
   private Employee currentEmployee;
   
   // JTextFields for user input
   private JTextField employeeIDTextField;
   private JTextField socialSecurityTextField;
   private JTextField firstNameTextField;
   private JTextField lastNameTextField;   
   private JTextField titleTextField;
   private JTextField salaryTextField;
   
   // BMPEmployeeEJBClient constructor
   public EmployeeEJBClient( String JNDIName )
   {
      super( "Employee EJB Client" );
      
      // create user interface
      createGUI();
      
      // get EmployeeHome reference for Employee EJB
      try {
         initialContext = new InitialContext();
         
         // look up Employee EJB using given JNDI name
         Object homeObject =  
            initialContext.lookup( JNDIName );
      
         // get EmployeeHome interface
         employeeHome = ( EmployeeHome ) 
            PortableRemoteObject.narrow(
               homeObject, EmployeeHome.class );
      }
      
      // handle exception when looking up Employee EJB
      catch ( NamingException namingException ) {
         namingException.printStackTrace( System.err );
      }    

      // close application when user closes window
      setDefaultCloseOperation( EXIT_ON_CLOSE );
      
      // set size of application window and make it visible
      setSize( 600, 300 );
      setVisible( true );
      
   } // end EmployeeEJBClient constructor
   
   // prompt user for employeeID
   private Integer getEmployeeID()
   {
      String primaryKeyString = JOptionPane.showInputDialog(
         this, "Please enter an employeeID" );

      // check if primaryKeyString is null, else return
      // Integer
      if ( primaryKeyString == null )
         return null;
      else 
         return new Integer( primaryKeyString );
   }
   
   // get Employee reference for user-supplied employeeID
   private void getEmployee()
   {    
      // prompt user for employeeID and get Employee reference
      Integer employeeID = getEmployeeID();
      
      // return if employeeID is null
      if ( employeeID == null )
         return;

      try {                   
         // find Employee with given employeeID
         Employee employee = 
            employeeHome.findByPrimaryKey( employeeID );

         // update display with current Employee
         setCurrentEmployee( employee );   
      }

      // handle exception when finding Employee
      catch ( RemoteException remoteException ) {
         JOptionPane.showMessageDialog( 
            EmployeeEJBClient.this, 
               remoteException.getMessage() ); 
      }

      // handle exception when finding Employee
      catch ( FinderException finderException ) {
         JOptionPane.showMessageDialog( 
            EmployeeEJBClient.this, "Employee not " +
               "found: " + finderException.getMessage() ); 
      }  
   } // end method getEmployee
   
   // add new Employee by creating new Employee EJB instance
   private void addEmployee()
   {
      // prompt user for employeeID and create Employee
      try {   
         Integer employeeID = getEmployeeID();
         
         // return if employeeID null
         if ( employeeID == null )
            return;

         // create new Employee
         Employee employee = employeeHome.create( employeeID );

         // update display with new Employee
         setCurrentEmployee( employee );
      }

      // handle exception when creating Employee
      catch ( CreateException createException ) {
         JOptionPane.showMessageDialog( this, 
            createException.getMessage() );
      }

      // handle exception when creating Employee
      catch ( RemoteException remoteException ) {
         JOptionPane.showMessageDialog( this, 
            remoteException.getMessage() );
      }
   } // end method addEmployee
   
   // update current Employee with user-supplied information
   private void updateEmployee()
   {
      // get information from JTextFields and update Employee
      try {      
         
         // set Employee socialSecurityNumber
         currentEmployee.setSocialSecurityNumber( 
            socialSecurityTextField.getText() );
         
         // set Employee firstName
         currentEmployee.setFirstName( 
            firstNameTextField.getText() );
         
         // set Employee lastName
         currentEmployee.setLastName( 
            lastNameTextField.getText() );
         
         // set Employee title
         currentEmployee.setTitle( titleTextField.getText() );
         
         // set Employee salary
         Double salary = new Double( salaryTextField.getText() );
         currentEmployee.setSalary( salary );
         
      } // end try
      
      // handle exception when invoking Employee business methods
      catch ( RemoteException remoteException ) {
         JOptionPane.showMessageDialog( this, 
            remoteException.getMessage() );
      }            
   } // end method updateEmployee
   
   // delete current Employee
   private void deleteEmployee()
   {
      // remove current Employee EJB
      try {
         currentEmployee.remove();
         
         // clear JTextFields
         employeeIDTextField.setText( "" );
         socialSecurityTextField.setText( "" );
         firstNameTextField.setText( "" );
         lastNameTextField.setText( "" );   
         titleTextField.setText( "" );
         salaryTextField.setText( "" );         
         
      } // end try
      
      // handle exception when removing Employee
      catch ( RemoteException remoteException ) {
         JOptionPane.showMessageDialog( this, 
            remoteException.getMessage() );
      } 
      
      // handle exception when removing Employee
      catch ( RemoveException removeException ) {
         JOptionPane.showMessageDialog( this, 
            removeException.getMessage() );
      }     
   } // end method deleteEmployee
   
   // update display with current Employee information
   private void setCurrentEmployee( Employee employee )
   {
      // get information for currentEmployee and update display
      try {      
         currentEmployee = employee;
         
         // get the employeeID
         Integer employeeID = ( Integer ) 
            currentEmployee.getEmployeeID();
         
         // update display     
         employeeIDTextField.setText( employeeID.toString() );
         
         // set socialSecurityNumber in display
         socialSecurityTextField.setText(
            currentEmployee.getSocialSecurityNumber() );         
          
         // set firstName in display
         firstNameTextField.setText(
            currentEmployee.getFirstName() );
            
         // set lastName in display
         lastNameTextField.setText(
            currentEmployee.getLastName() );
         
         // set title in display
         titleTextField.setText( currentEmployee.getTitle() );
         
         // get Employee salary
         Double salary = currentEmployee.getSalary();
         
         // ensure salary is not null and update display
         if ( salary != null ) {
            NumberFormat dollarFormatter =
               NumberFormat.getCurrencyInstance( 
                  Locale.US );
            
          salaryTextField.setText( dollarFormatter.format( 
             salary ) );
         }
         else
            salaryTextField.setText( "" );
      } // end try
      
      // handle exception invoking Employee business methods
      catch ( RemoteException remoteException ) {
         JOptionPane.showMessageDialog( this, 
            remoteException.getMessage() );
      }            
   } // end method setCurrentEmployee
   
   // create the application GUI
   private void createGUI()
   {
      // create JPanel for Employee form components
      JPanel formPanel = new JPanel( new GridLayout( 6, 2 ) );
      
      // create read-only JTextField for employeeID      
      employeeIDTextField = new JTextField();
      employeeIDTextField.setEditable( false );
      formPanel.add( new JLabel( "Employee ID" ) );
      formPanel.add( employeeIDTextField );
      
      // create JTextField and JLabel for social security #
      socialSecurityTextField = new JTextField();
      formPanel.add( new JLabel( "Social Security #" ) );
      formPanel.add( socialSecurityTextField );
      
      // create JTextField and JLabel for first name
      firstNameTextField = new JTextField();
      formPanel.add( new JLabel( "First Name" ) );
      formPanel.add( firstNameTextField );

      // create JTextField and JLabel for last name
      lastNameTextField = new JTextField();
      formPanel.add( new JLabel( "Last Name" ) );
      formPanel.add( lastNameTextField );

      // create JTextField and JLabel for job title
      titleTextField = new JTextField();
      formPanel.add( new JLabel( "Title" ) );
      formPanel.add( titleTextField );
      
      // create JTextField and JLabel for salary
      salaryTextField = new JTextField();
      formPanel.add( new JLabel( "Salary" ) );
      formPanel.add( salaryTextField );
      
      // add formPanel to the JFrame's contentPane
      Container contentPane = getContentPane();
      contentPane.add( formPanel, BorderLayout.CENTER );
      
      // create JPanel for JButtons
      JPanel employeeButtonPanel = 
         new JPanel( new FlowLayout() );
      
      // create JButton for adding Employees
      JButton addButton = new JButton( "Add Employee" );      
      addButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               addEmployee();
            }
         }
      );      
      employeeButtonPanel.add( addButton );
      
      // create JButton for saving Employee information
      JButton saveButton = new JButton( "Save Changes" );
      saveButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               updateEmployee();
            }
         }
      );
      employeeButtonPanel.add( saveButton );
      
      // create JButton for deleting Employees
      JButton deleteButton = new JButton( "Delete Employee" );
      deleteButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               deleteEmployee();
            }
         }
      );
      employeeButtonPanel.add( deleteButton );
      
      // create JButton for finding existing Employees
      JButton findButton = new JButton( "Find Employee" );
      findButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               getEmployee();
            }
         }
      );
      employeeButtonPanel.add( findButton );
      
      // add employeeButtonPanel to JFrame's contentPane
      contentPane.add( employeeButtonPanel, 
         BorderLayout.NORTH );
      
   } // end method createGUI

   // execute application
   public static void main( String[] args ) 
   {
      // ensure user provided JNDI name for Employee EJB
      if ( args.length != 1 ) {
         System.err.println( 
            "Usage: java EmployeeEJBClient <JNDI Name>" );
         System.exit( 1 );
      }
      
      // start application using provided JNDI name
      else
         new EmployeeEJBClient( args[ 0 ] );
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