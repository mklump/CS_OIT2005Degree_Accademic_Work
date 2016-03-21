<!-- Fig. 10.9: clock2.jsp                        -->
<!-- date and time to include in another document -->

<table>
   <tr>
      <td style = "background-color: black;">
         <p class = "big" style = "color: cyan; font-size: 3em; 
            font-weight: bold;">

            <%-- script to determine client local and --%>
            <%-- format date accordingly              --%>
            <% 
               // get client locale
               java.util.Locale locale = request.getLocale();

               // get DateFormat for client's Locale
               java.text.DateFormat dateFormat = 
                  java.text.DateFormat.getDateTimeInstance(
                     java.text.DateFormat.LONG,
                     java.text.DateFormat.LONG, locale );

            %>  <%-- end script --%>

            <%-- output date --%>
            <%= dateFormat.format( new java.util.Date() ) %>
         </p> 
      </td>
   </tr>
</table>

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