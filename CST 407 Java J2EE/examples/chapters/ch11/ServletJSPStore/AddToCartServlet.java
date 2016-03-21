// AddToCartServlet.java
// Servlet to add a book to the shopping cart.
package com.deitel.advjhtp1.store;

// Java core packages
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;

public class AddToCartServlet extends HttpServlet {
   protected void doPost( HttpServletRequest request,
      HttpServletResponse response )
      throws ServletException, IOException
   {
      HttpSession session = request.getSession( false );
      RequestDispatcher dispatcher;
      
      // if session does not exist, forward to index.html
      if ( session == null ) {
         dispatcher = 
            request.getRequestDispatcher( "/index.html" );
         dispatcher.forward( request, response );
      }
      
      // session exists, get cart HashMap and book to add
      Map cart = ( Map ) session.getAttribute( "cart" );
      BookBean book = 
         ( BookBean ) session.getAttribute( "bookToAdd" );
      
      // if cart does not exist, create it
      if ( cart == null ) {
         cart = new HashMap();
         
         // set session attribute "cart"
         session.setAttribute( "cart", cart );
      }
      
      // determine if book is in cart
      CartItemBean cartItem = 
         ( CartItemBean ) cart.get( book.getISBN() );
      
      // If book is already in cart, update its quantity.
      // Otherwise, create an entry in the cart.
      if ( cartItem != null ) 
         cartItem.setQuantity( cartItem.getQuantity() + 1 );
      else 
         cart.put( book.getISBN(), new CartItemBean( book, 1 ) );
      
      // send the user to viewCart.jsp
      dispatcher = 
         request.getRequestDispatcher( "/viewCart.jsp" );
      dispatcher.forward( request, response );
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
