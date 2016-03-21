// BookBean.java
// A BookBean object contains the data for one book.
package com.deitel.advjhtp1.store;

// Java core packages
import java.io.*;
import java.text.*;
import java.util.*;

// third-party packages
import org.w3c.dom.*;

public class BookBean implements Serializable {
   private String ISBN, title, copyright, imageFile;
   private int editionNumber, publisherID;
   private double price;
   
   // set ISBN number
   public void setISBN( String isbn )
   {
      ISBN = isbn;
   }
   
   // return ISBN number
   public String getISBN()
   {
      return ISBN;
   }
   
   // set book title 
   public void setTitle( String bookTitle )
   {
      title = bookTitle;
   }
   
   // return book title 
   public String getTitle()
   {
      return title;
   }
   
   // set copyright year
   public void setCopyright( String year )
   {
      copyright = year;
   }
   
   // return copyright year
   public String getCopyright()
   {
      return copyright;
   }
   
   // set file name of image representing product cover
   public void setImageFile( String fileName )
   {
      imageFile = fileName;
   }
   
   // return file name of image representing product cover
   public String getImageFile()
   {
      return imageFile;
   }
   
   // set edition number
   public void setEditionNumber( int edition )
   {
      editionNumber = edition;
   }
   
   // return edition number
   public int getEditionNumber()
   {
      return editionNumber;
   }
   
   // set publisher ID number
   public void setPublisherID( int id )
   {
      publisherID = id;
   }
   
   // return publisher ID number
   public int getPublisherID()
   {
      return publisherID;
   }
   
   // set price
   public void setPrice( double amount )
   {
      price = amount;
   }
   
   // return price
   public double getPrice()
   {
      return price;
   }
   
   // get an XML representation of the Product
   public Element getXML( Document document )
   {
      // create product root element
      Element product = document.createElement( "product" );
      
      // create isbn element, append as child of product
      Element temp = document.createElement( "isbn" );
      temp.appendChild( document.createTextNode( getISBN() ) );
      product.appendChild( temp );

      // create title element, append as child of product
      temp = document.createElement( "title" );
      temp.appendChild( document.createTextNode( getTitle() ) );
      product.appendChild( temp );
      
      // create a currency formatting object for US dollars
      NumberFormat priceFormatter =
         NumberFormat.getCurrencyInstance( Locale.US );
            
      // create price element, append as child of product
      temp = document.createElement( "price" );
      temp.appendChild( document.createTextNode( 
         priceFormatter.format( getPrice() ) ) );
      product.appendChild( temp );
      
      // create imageFile element, append as child of product
      temp = document.createElement( "imageFile" );
      temp.appendChild( 
         document.createTextNode( getImageFile() ) );
      product.appendChild( temp );
      
      // create copyright element, append as child of product
      temp = document.createElement( "copyright" );
      temp.appendChild( 
         document.createTextNode( getCopyright() ) );
      product.appendChild( temp );
      
      // create publisherID element, append as child of product
      temp = document.createElement( "publisherID" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getPublisherID() ) ) );
      product.appendChild( temp );
      
      // create editionNumber element, append as child of product
      temp = document.createElement( "editionNumber" );
      temp.appendChild( document.createTextNode( 
          String.valueOf( getEditionNumber() ) ) );
      product.appendChild( temp );
      
      // return product element
      return product;
   }   
}

/***************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and         *
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
