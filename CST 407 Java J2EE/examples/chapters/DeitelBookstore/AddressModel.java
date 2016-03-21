// AddressModel.java
// AddressModel represents a Customer's address, including
// street, city, state and zip code.
package com.deitel.advjhtp1.bookstore.model;

// Java core packages
import java.io.*;
import java.util.*;

// third-party packages
import org.w3c.dom.*;

public class AddressModel implements Serializable, 
   XMLGenerator {
      
   // AddressModel properties
   private Integer addressID;
   private String firstName;
   private String lastName;
   private String streetAddressLine1;
   private String streetAddressLine2;
   private String city;
   private String state;
   private String zipCode;
   private String country;
   private String phoneNumber;
   
   // construct empty AddressModel
   public AddressModel() {}
   
   // set addressID
   public void setAddressID( Integer id )
   {
      addressID = id;
   }
   
   // get addressID
   public Integer getAddressID()
   {
      return addressID;
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

   // set first line of street address
   public void setStreetAddressLine1( String address ) 
   { 
      streetAddressLine1 = address; 
   }
      
   // get first line of street address
   public String getStreetAddressLine1() 
   { 
      return streetAddressLine1; 
   }

   // set second line of street address
   public void setStreetAddressLine2( String address ) 
   { 
      streetAddressLine2 = address; 
   }
    
   // set second line of street address
   public String getStreetAddressLine2() 
   { 
      return streetAddressLine2; 
   }

   // set city 
   public void setCity( String addressCity ) 
   { 
      city = addressCity; 
   }
   
   // get city 
   public String getCity() 
   { 
      return city; 
   }

   // set state 
   public void setState( String addressState ) 
   { 
      state = addressState; 
   }
      
   // get state 
   public String getState() 
   { 
      return state; 
   }

   // set zip code 
   public void setZipCode( String zip ) 
   { 
      zipCode = zip; 
   }
      
   // get zip code 
   public String getZipCode() 
   { 
      return zipCode; 
   }

   // set country 
   public void setCountry( String addressCountry ) 
   { 
      country = addressCountry; 
   }
      
   // get country 
   public String getCountry() 
   { 
      return country; 
   }

   // set phone number 
   public void setPhoneNumber( String phone ) 
   { 
      phoneNumber = phone;
   }
      
   // get phone number 
   public String getPhoneNumber() 
   { 
      return phoneNumber; 
   }
      
   // build XML representation of Customer
   public Element getXML( Document document )
   {
      // create address Element
      Element address = document.createElement( "address" );
      
      // crate firstName Element
      Element temp = document.createElement( "firstName" );
      temp.appendChild( 
         document.createTextNode( getFirstName() ) );
      address.appendChild( temp );
      
      // create lastName Element
      temp = document.createElement( "lastName" );
      temp.appendChild( 
         document.createTextNode( getLastName() ) );
      address.appendChild( temp );
      
      // create streetAddressLine1 Element
      temp = document.createElement( "streetAddressLine1" );
      temp.appendChild( 
         document.createTextNode( getStreetAddressLine1() ) );
      address.appendChild( temp );
      
      // create streetAddressLine2 Element
      temp = document.createElement( "streetAddressLine2" );
      temp.appendChild( 
         document.createTextNode( getStreetAddressLine2() ) );
      address.appendChild( temp );
      
      // create city Element
      temp = document.createElement( "city" );
      temp.appendChild( document.createTextNode( city ) );
      address.appendChild( temp );
      
      // create state Element
      temp = document.createElement( "state" );
      temp.appendChild( 
         document.createTextNode( getState() ) );
      address.appendChild( temp );
      
      // create zipCode Element
      temp = document.createElement( "zipCode" );
      temp.appendChild( 
         document.createTextNode( getZipCode() ) );
      address.appendChild( temp );
      
      // create country Element
      temp = document.createElement( "country" );
      temp.appendChild( 
         document.createTextNode( getCountry() ) );
      address.appendChild( temp );
      
      // create phoneNumber Element
      temp = document.createElement( "phoneNumber" );
      temp.appendChild( 
         document.createTextNode( getPhoneNumber() ) );
      address.appendChild( temp );
      
      return address;
      
   } // end method getXML
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
