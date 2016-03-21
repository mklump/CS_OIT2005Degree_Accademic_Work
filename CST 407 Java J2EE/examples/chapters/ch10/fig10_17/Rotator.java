// Fig. 10.17: Rotator.java
// A JavaBean that rotates advertisements.
package com.deitel.advjhtp1.jsp.beans;

public class Rotator {
   private String images[] = { "images/jhtp3.jpg",
      "images/xmlhtp1.jpg", "images/ebechtp1.jpg",
      "images/iw3htp1.jpg", "images/cpphtp3.jpg"};
      
   private String links[] = {
      "http://www.amazon.com/exec/obidos/ASIN/0130125075/" + 
         "deitelassociatin",
      "http://www.amazon.com/exec/obidos/ASIN/0130284173/" + 
         "deitelassociatin",
      "http://www.amazon.com/exec/obidos/ASIN/013028419X/" + 
         "deitelassociatin",
      "http://www.amazon.com/exec/obidos/ASIN/0130161438/" + 
         "deitelassociatin",
      "http://www.amazon.com/exec/obidos/ASIN/0130895717/" + 
         "deitelassociatin" };
         
   private int selectedIndex = 0;

   // returns image file name for current ad
   public String getImage()
   {
      return images[ selectedIndex ];
   }

   // returns the URL for ad's corresponding Web site
   public String getLink()
   {
      return links[ selectedIndex ];
   }
   
   // update selectedIndex so next calls to getImage and 
   // getLink return a different advertisement
   public void nextAd()
   {
      selectedIndex = ( selectedIndex + 1 ) % images.length;      
   }
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