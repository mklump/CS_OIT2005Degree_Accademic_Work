<!-- Fig. 10.15: plugin.jsp -->

<html>

   <head>
      <title>Using jsp:plugin to load an applet</title>
   </head>

   <body>
      <jsp:plugin type = "applet" 
         code = "com.deitel.advjhtp1.jsp.applet.ShapesApplet" 
         codebase = "/advjhtp1/jsp" 
         width = "400" 
         height = "400">

         <jsp:params>
            <jsp:param name = "red" value = "255" />
            <jsp:param name = "green" value = "255" /> 
            <jsp:param name = "blue" value = "0" /> 
         </jsp:params>

      </jsp:plugin>
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