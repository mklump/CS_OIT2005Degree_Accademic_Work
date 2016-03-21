<?xml version = "1.0"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<!-- Fig. 10.24: guestBookErrorPage.jsp -->

<%-- page settings --%>
<%@ page isErrorPage = "true" %>
<%@ page import = "java.util.*" %>
<%@ page import = "java.sql.*" %>

<html xmlns = "http://www.w3.org/1999/xhtml">

   <head>
      <title>Error!</title>

      <style type = "text/css">
         .bigRed {
            font-size: 2em;
            color: red; 
            font-weight: bold;
         }
      </style>
   </head>

   <body>
      <p class = "bigRed"> 

      <% // scriptlet to determine exception type
         // and output beginning of error message
         if ( exception instanceof SQLException )
      %>

            An SQLException
      
      <%
         else if ( exception instanceof ClassNotFoundException )
      %>

            A ClassNotFoundException
      
      <%
         else
      %>

            An exception

      <%-- end scriptlet to insert fixed template data --%>

         <%-- continue error message output --%>
         occurred while interacting with the guestbook database. 
      </p>

      <p class = "bigRed">
         The error message was:<br />
         <%= exception.getMessage() %>
      </p>

      <p class = "bigRed">Please try again later</p>
   </body>

</html>
