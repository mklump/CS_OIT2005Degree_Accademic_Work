// ProductEJB.java
// Entity EJB Product represents a Product, including the 
// ISBN, publisher, author, title, price number of pages 
// and cover image.
package com.deitel.advjhtp1.bookstore.ejb;

// Java extension packages
import javax.ejb.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.*;

public class ProductEJB implements EntityBean {
   private EntityContext entityContext;

   // container-managed fields
   public String ISBN;
   public String publisher;
   public String author;
   public String title;
   public double price;
   public int pages;
   public String image;

   // get Product details as ProductModel
   public ProductModel getProductModel() 
   {
      // construct new ProductModel
      ProductModel productModel = new ProductModel();
      
      // initialize ProductModel with data from Product
      productModel.setISBN( ISBN );
      productModel.setPublisher( publisher );
      productModel.setAuthor( author );
      productModel.setTitle( title );
      productModel.setPrice( price );
      productModel.setPages( pages );
      productModel.setImage( image );
      
      return productModel;
      
   } // end method getProductModel
   
   // set Product details using ProductModel
   private void setProductModel( ProductModel productModel ) 
   {
      // populate Product's data members with data in 
      // provided ProductModel
      ISBN = productModel.getISBN();
      publisher = productModel.getPublisher();
      author = productModel.getAuthor();
      title = productModel.getTitle();
      price = productModel.getPrice();
      pages = productModel.getPages();
      image = productModel.getImage();
      
   } // end method setProductModel 

   // create instance of Product EJB using given ProductModel
   public String ejbCreate( ProductModel productModel ) 
   {
      setProductModel( productModel );      
      return null;
   }
   
   // perform any necessary post-creation tasks
   public void ejbPostCreate( ProductModel productmodel ) {}

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
   
   // activate Product EJB instance
   public void ejbActivate() 
   {
      ISBN = ( String ) entityContext.getPrimaryKey();
   }
   
   // passivate Product EJB instance
   public void ejbPassivate() 
   {
      ISBN = null;
   }
   
   // remove Product EJB instance
   public void ejbRemove() {}
      
   // store Product EJB data in database
   public void ejbStore() {}
      
   // load Product EJB data from database
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
