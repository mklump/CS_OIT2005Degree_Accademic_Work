// ProductModel.java
// ProductModel represents a Product in the Deitel Bookstore, 
// including ISBN, author, title and a picture of the cover.
package com.deitel.advjhtp1.bookstore.model;

// Java core packages
import java.io.*;
import java.util.*;
import java.text.*;

// third-party packages
import org.w3c.dom.*;

public class ProductModel implements Serializable, 
   XMLGenerator {
      
   // ProductModel properties
   private String ISBN;
   private String publisher;
   private String author;
   private String title;
   private double price;
   private int pages;
   private String image;
   private int quantity;

   // set ISBN
   public void setISBN( String productISBN ) 
   { 
      ISBN = productISBN; 
   }

   // get ISBN
   public String getISBN() 
   { 
      return ISBN; 
   }

   // set publisher
   public void setPublisher( String productPublisher )
   { 
      publisher = productPublisher; 
   }

   // get publisher
   public String getPublisher()
   { 
      return publisher; 
   }

   // set author
   public void setAuthor( String productAuthor )
   { 
      author = productAuthor; 
   }

   // get author
   public String getAuthor() 
   { 
      return author; 
   }

   // set title
   public void setTitle( String productTitle ) 
   { 
      title = productTitle; 
   }

   // get title
   public String getTitle() 
   { 
      return title; 
   }

   // set price
   public void setPrice( double productPrice ) 
   { 
      price = productPrice; 
   }

   // get price
   public double getPrice() 
   { 
      return price; 
   }

   // set number of pages
   public void setPages( int pageCount ) 
   { 
      pages = pageCount; 
   }

   // get number of pages
   public int getPages() 
   { 
      return pages; 
   }

   // set URL of cover image
   public void setImage( String productImage ) 
   { 
      image = productImage; 
   }

   // get URL of cover image
   public String getImage() 
   { 
      return image; 
   }

   // get XML representation of Product
   public Element getXML( Document document )
   {
      // create product Element
      Element product = document.createElement( "product" );
      
      // create ISBN Element
      Element temp = document.createElement( "ISBN" );
      temp.appendChild( 
         document.createTextNode( getISBN() ) );
      product.appendChild( temp );

      // create publisher Element
      temp = document.createElement( "publisher" );
      temp.appendChild( 
         document.createTextNode( getPublisher() ) );
      product.appendChild( temp );
      
      // create author Element
      temp = document.createElement( "author" );
      temp.appendChild( 
         document.createTextNode( getAuthor() ) );
      product.appendChild( temp );
      
      // create title Element
      temp = document.createElement( "title" );
      temp.appendChild( 
         document.createTextNode( getTitle() ) );
      product.appendChild( temp );
      
      NumberFormat priceFormatter =
         NumberFormat.getCurrencyInstance( Locale.US );
          
      // create price Element
      temp = document.createElement( "price" );
      temp.appendChild( document.createTextNode( 
         priceFormatter.format( getPrice() ) ) );
      product.appendChild( temp );
      
      // create pages Element
      temp = document.createElement( "pages" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getPages() ) ) );
      product.appendChild( temp );
      
      // create image Element
      temp = document.createElement( "image" );
      temp.appendChild( 
         document.createTextNode( getImage() ) );
      product.appendChild( temp );
      
      return product;
      
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
