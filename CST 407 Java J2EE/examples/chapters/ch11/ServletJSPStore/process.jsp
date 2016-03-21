<?xml version = "1.0"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<!-- process.jsp -->

<%-- JSP page settings --%>
<%@ page language = "java" session = "true" %>
<%@ page import = "java.text.*" %>

<html xmlns = "http://www.w3.org/1999/xhtml">

<head>
   <title>Thank You!</title>

   <link rel = "stylesheet" href = "styles.css" 
      type = "text/css" />
</head>

<% // start scriptlet

   // get total order amount
   Double d = ( Double ) session.getAttribute( "total" );
   double total = d.doubleValue();

   // invalidate session because processing is complete
   session.invalidate();

%> <%-- end scriptlet --%>

<body>
   <p class = "bigFont">Thank You</p>

   <p>Your order has been processed.</p>

   <p>Your credit card has been billed:
      <span class = "bold">
         $<%= new DecimalFormat( "0.00" ).format( total ) %>
      </span>
   </p>
</body>

</html>

<!--
 ***************************************************************
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
 ***************************************************************
-->
