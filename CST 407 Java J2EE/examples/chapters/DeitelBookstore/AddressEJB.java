// AddressEJB.java
// Entity EJB Address represents an Address, including
// the street address, city, state and zip code.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.util.*;
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.PortableRemoteObject;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public class AddressEJB implements EntityBean {
   private EntityContext entityContext;

   // container-managed fields
   public Integer addressID;
   public String firstName;
   public String lastName;
   public String streetAddressLine1;
   public String streetAddressLine2;
   public String city;
   public String state;
   public String zipCode;
   public String country;
   public String phoneNumber;

   // get AddressModel
   public AddressModel getAddressModel()
   {
      // construct new AddressModel
      AddressModel address = new AddressModel();
      
      // populate AddressModel fields with Address EJB 
      // data members
      address.setAddressID( addressID );
      address.setFirstName( firstName );
      address.setLastName( lastName );
      address.setStreetAddressLine1( streetAddressLine1 );
      address.setStreetAddressLine2( streetAddressLine2 );
      address.setCity( city );
      address.setState( state );
      address.setZipCode( zipCode );
      address.setCountry( country );
      address.setPhoneNumber( phoneNumber );

      return address;
      
   } // end method getAddressModel
   
   // set Address data using AddressModel
   private void setAddressModel( AddressModel address )
   {
      // update Address' data members using values provided 
      // in the AddressModel      
      firstName = address.getFirstName();
      lastName = address.getLastName();
      streetAddressLine1 = address.getStreetAddressLine1();
      streetAddressLine2 = address.getStreetAddressLine2();
      city = address.getCity();
      state = address.getState();
      zipCode = address.getZipCode();
      country = address.getCountry();
      phoneNumber = address.getPhoneNumber();
      
   } // end method setAddressModel   

   // create Address EJB using given AddressModel
   public Integer ejbCreate( AddressModel address ) 
      throws CreateException
   {
      // retrieve unique value for primary key using 
      // SequenceFactory EJB
      try {
         Context initialContext = new InitialContext();
         
         // look up SequenceFactory EJB
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/SequenceFactory" );
         
         SequenceFactoryHome sequenceFactoryHome =
            ( SequenceFactoryHome ) 
               PortableRemoteObject.narrow(
                  object, SequenceFactoryHome.class );
         
         // find sequence for Address EJB
         SequenceFactory sequenceFactory = 
            sequenceFactoryHome.findByPrimaryKey( "Address" );
         
         // retrieve next available addressID
         addressID = sequenceFactory.getNextID(); 

         // set addressID for Address (primary key)
         address.setAddressID( addressID );   
         
         // use AddressModel to set data for new Address
         setAddressModel( address );         
         
      } // end try
      
      // handle exception using SequenceFactory EJB
      catch ( Exception exception ) { 
         throw new CreateException( exception.getMessage() ); 
      }
      
      // EJB container will return a remote reference
      return null;
      
   } // end method ejbCreate
   
   // perform any necessary post-creation tasks
   public void ejbPostCreate( AddressModel address ) {}

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
 
   // activate Address EJB instance
   public void ejbActivate() 
   {
      addressID = ( Integer ) entityContext.getPrimaryKey();
   }
   
   // passivate Address EJB instance
   public void ejbPassivate() 
   {
      addressID = null;
   }
   
   // remove Address EJB instance
   public void ejbRemove() {}
   
   // store Address EJB data in database
   public void ejbStore() {}   
   
   // load Address EJB data from database
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
