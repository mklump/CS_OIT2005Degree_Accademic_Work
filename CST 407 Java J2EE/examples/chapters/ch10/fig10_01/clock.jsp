<?xml version = "1.0"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<!-- Fig. 10.1: clock.jsp -->

<html xmlns = "http://www.w3.org/1999/xhtml">

<head>
   <meta http-equiv = "refresh" content = "60" />
	 
   <title>A Simple JSP Example</title>

   <style type = "text/css">
      .big { font-family: helvetica, arial, sans-serif;
             font-weight: bold;
             font-size: 2em; }
   </style>
</head>

<body>
   <p class = "big">Simple JSP Example</p>

   <table style = "border: 6px outset;">
      <tr>
         <td style = "background-color: black;">
            <p class = "big" style = "color: cyan;">

               <!-- JSP expression to insert date/time -->
               <%= new java.util.Date() %>

            </p> 
         </td>
      </tr>
   </table>
</body>

</html>

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