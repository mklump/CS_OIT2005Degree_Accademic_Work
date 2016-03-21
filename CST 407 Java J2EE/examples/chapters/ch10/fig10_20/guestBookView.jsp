<?xml version = "1.0"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<!-- Fig. 10.23: guestBookView.jsp -->

<%-- page settings --%>
<%@ page errorPage = "guestBookErrorPage.jsp" %>
<%@ page import = "java.util.*" %>
<%@ page import = "com.deitel.advjhtp1.jsp.beans.*" %>

<%-- GuestDataBean to obtain guest list --%>
<jsp:useBean id = "guestData" scope = "request" 
   class = "com.deitel.advjhtp1.jsp.beans.GuestDataBean" />

<html xmlns = "http://www.w3.org/1999/xhtml">

   <head>
      <title>Guest List</title>

      <style type = "text/css">
         body { 
            font-family: tahoma, helvetica, arial, sans-serif; 
         }

         table, tr, td, th { 
            text-align: center;
            font-size: .9em;
            border: 3px groove;
            padding: 5px;
            background-color: #dddddd;
         }
      </style>
   </head>

   <body>
      <p style = "font-size: 2em;">Guest List</p>

      <table>
         <thead>
            <tr>
               <th style = "width: 100px;">Last name</th>
               <th style = "width: 100px;">First name</th>
               <th style = "width: 200px;">Email</th>
            </tr>
         </thead>

         <tbody>

         <% // start scriptlet

            List guestList = guestData.getGuestList();
            Iterator guestListIterator = guestList.iterator();
            GuestBean guest;

            while ( guestListIterator.hasNext() ) {
               guest = ( GuestBean ) guestListIterator.next();

         %> <%-- end scriptlet; insert fixed template data --%>
 
               <tr>
                  <td><%= guest.getLastName() %></td>

                  <td><%= guest.getFirstName() %></td>

                  <td>
                     <a href = "mailto:<%= guest.getEmail() %>">
                        <%= guest.getEmail() %></a>
                  </td>
               </tr>

         <% // continue scriptlet

            } // end while

         %> <%-- end scriptlet --%>
         
         </tbody>
      </table>
   </body>

</html>
