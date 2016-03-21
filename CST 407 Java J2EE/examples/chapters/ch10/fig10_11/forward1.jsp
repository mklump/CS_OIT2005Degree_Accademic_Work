<?xml version = "1.0"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<!-- Fig. 10.11: forward1.jsp -->

<html xmlns = "http://www.w3.org/1999/xhtml">

<head>
   <title>Forward request to another JSP</title>
</head>

<body>
   <% // begin scriptlet

      String name = request.getParameter( "firstName" );

      if ( name != null ) {

   %> <%-- end scriptlet to insert fixed template data --%>

         <jsp:forward page = "forward2.jsp">
            <jsp:param name = "date" 
               value = "<%= new java.util.Date() %>" />
         </jsp:forward>

   <% // continue scriptlet

      }  // end if
      else {

   %> <%-- end scriptlet to insert fixed template data --%>

         <form action = "forward1.jsp" method = "get">               
            <p>Type your first name and press Submit</p>

            <p><input type = "text" name = "firstName" />
               <input type = "submit" value = "Submit" />
            </p>
         </form>

   <%  // continue scriptlet

      }  // end else

   %> <%-- end scriptlet --%>
</body>

</html>  <!-- end XHTML document -->

<!--
 ***************************************************************
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
 ***************************************************************
-->