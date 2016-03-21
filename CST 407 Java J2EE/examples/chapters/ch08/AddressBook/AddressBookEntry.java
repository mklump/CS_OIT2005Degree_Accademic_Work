// Fig. 8.33: AddressBookEntry.java
// JavaBean to represent one address book entry.
package com.deitel.advjhtp1.jdbc.addressbook;

public class AddressBookEntry {
   private String firstName = "";
   private String lastName = "";
   private String address1 = "";
   private String address2 = "";
   private String city = "";
   private String state = "";
   private String zipcode = "";
   private String phoneNumber = "";
   private String emailAddress = "";
   private int personID;
   private int addressID;
   private int phoneID;
   private int emailID;
   
   // empty constructor
   public AddressBookEntry()
   {
   }

   // set person's id
   public AddressBookEntry( int id )
   {
      personID = id;
   }
   
   // set person's first name
   public void setFirstName( String first )
   {
      firstName = first;
   }
   
   // get person's first name
   public String getFirstName()
   {
      return firstName;
   }
   
   // set person's last name
   public void setLastName( String last )
   {
      lastName = last;
   }
   
   // get person's last name
   public String getLastName()
   {
      return lastName;
   }
   
   // set first line of person's address
   public void setAddress1( String firstLine )
   {
      address1 = firstLine;
   }
   
   // get first line of person's address
   public String getAddress1()
   {
      return address1;
   }
   
   // set second line of person's address
   public void setAddress2( String secondLine )
   {
      address2 = secondLine;
   }
   
   // get second line of person's address
   public String getAddress2()
   {
      return address2;
   }
   
   // set city in which person lives
   public void setCity( String personCity )
   {
      city = personCity;
   }
   
   // get city in which person lives
   public String getCity()
   {
      return city;
   }
   
   // set state in which person lives
   public void setState( String personState )
   {
      state = personState;
   }
   
   // get state in which person lives
   public String getState()
   {
      return state;
   }
   
   // set person's zip code
   public void setZipcode( String zip )
   {
      zipcode = zip;
   }
   
   // get person's zip code
   public String getZipcode()
   {
      return zipcode;
   }
   
   // set person's phone number
   public void setPhoneNumber( String number )
   {
      phoneNumber = number;
   }
   
   // get person's phone number 
   public String getPhoneNumber()
   {
      return phoneNumber;
   }

   // set person's email address
   public void setEmailAddress( String email )
   {
      emailAddress = email;
   }
   
   // get person's email address
   public String getEmailAddress()
   {
      return emailAddress;
   }
   
   // get person's ID
   public int getPersonID()
   {
      return personID;
   }
   
   // set person's addressID
   public void setAddressID( int id )
   {
      addressID = id;
   }
   
   // get person's addressID
   public int getAddressID()
   {
      return addressID;
   }
   
   // set person's phoneID
   public void setPhoneID( int id )
   {
      phoneID = id;
   }
   
   // get person's phoneID
   public int getPhoneID()
   {
      return phoneID;
   }
   
   // set person's emailID
   public void setEmailID( int id )
   {
      emailID = id;
   }
   
   // get person's emailID
   public int getEmailID()
   {
      return emailID;
   }
}  // end class AddressBookEntry


/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
