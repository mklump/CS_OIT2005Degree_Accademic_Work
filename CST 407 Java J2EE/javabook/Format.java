package javabook;

/**
 * This class is used to format the numerical and textual values for 
 * a properly aligned output display.
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class Format
{  
    
//-------------------------------------------------------------
//    Public Methods:
//          static String centerAlign   ( int, int, double  )
//          static String centerAlign   ( int, long         )
//          static String centerAlign   ( int, String       )
//           
//          static String leftAlign     ( int, int, double  )
//          static String leftAlign     ( int, long         )
//          static String leftAlign     ( int, String       )
//            
//          static String rightAlign    ( int, int, double  )
//          static String rightAlign    ( int, long         )
//          static String rightAlign    ( int, String       )
//           
//-------------------------------------------------------------

   /**
    * Formats a real number using the center alignment.
    * The passed <code>number</code> is converted to a <code>String</code> 
    * with <code>width</code> characters. The number is placed at the center,
    * and the second parameter <code>decimalPlaces</code> determines the
    * number of decimal places to be shown. If the converted number has
    * more characters than the designated <code>width</code>, then 
    * the converted number is returned without any formatting.
    * 
    * @param width          number of characters the resulting string will contain
    * @param decimalPlaces  the number of decimal places within the designated 
    *                       field width
    * @param number         the value to be formatted
    *
    * @return a formatted string
    */
   public static String centerAlign(int width, int decimalPlaces, double number)
   {
      double num = number * Math.pow(10,decimalPlaces);
      num = Math.round(num);
      num = num / Math.pow(10,decimalPlaces);
      String str = convert(num,decimalPlaces);
         
      if (width < str.length()) {
         return str;
      }
      else {
         return pad(' ',(width-str.length()+1)/2) +
                    str + pad(' ',(width-str.length())/2);
      }
   }   
   
   /**
    * Formats an integer using the center alignment.
    * The passed <code>number</code> is converted to a <code>String</code> 
    * with <code>width</code> characters. The number is placed at the center.
    * If the converted number has more characters than the designated <code>width</code>, then 
    * the converted number is returned without any formatting.
    *
    * @param width    the number of characters the resulting string will contain
    * @param number   the integer value to be formatted
    *
    * @return a formatted string
    */
   public static String centerAlign(int width, long number)
   {
      String str = convert(number);

      if (width < str.length()) {
         return str;
      }
      else {
         return pad(' ',(width-str.length()+1)/2) +
                    str + pad(' ',(width-str.length())/2);
      }
   }

   /**
    * Formats a <code>String</code> using the center alignment.
    * The passed <code>str</code> is converted to a new <code>String</code> 
    * with <code>width</code> characters. The string <code>str</code> is placed 
    * at the center of the new string.
    * If the original <code>str</code> has more characters than the designated <code>width</code>, then 
    * the original <code>str</code> is returned without any formatting.
    *
    * @param width  the number of characters the resulting string will contain
    * @param str    the <code>String</code> value to be formatted
    *
    * @return a formatted string
    */
   public static String centerAlign(int width, String str)
   {
      if (width < str.length()) {
         return str;
      }
      else {
         return pad(' ',(width-str.length()+1)/2) +
                    str + pad(' ',(width-str.length())/2);
      }
   }

   /**
    * Formats a real number using the left alignment.
    * The passed <code>number</code> is converted to a <code>String</code> 
    * with <code>width</code> characters. The number is placed at the left,
    * and the second parameter <code>decimalPlaces</code> determines the
    * number of decimal places to be shown. If the converted number has
    * more characters than the designated <code>width</code>, then 
    * the converted number is returned without any formatting.
    * 
    * @param width          number of characters the resulting string will contain
    * @param decimalPlaces  the number of decimal places within the designated 
    *                       field width
    * @param number         the value to be formatted
    *
    * @return a formatted string
    */   
   public static String leftAlign(int width, int decimalPlaces, double number)
   {
      double num = number * Math.pow(10,decimalPlaces);
      num = Math.round(num);
      num = num / Math.pow(10,decimalPlaces);
      String str = convert(num,decimalPlaces);
     
      if (width < str.length()) {
         return str;
      }
      else {
         return str + pad(' ', width-str.length());
      }
   }

   /**
    * Formats an integer using the left alignment.
    * The passed <code>number</code> is converted to a <code>String</code> 
    * with <code>width</code> characters. The number is placed at the left.
    * If the converted number has more characters than the designated <code>width</code>, then 
    * the converted number is returned without any formatting.
    *
    * @param width    the number of characters the resulting string will contain
    * @param number   the integer value to be formatted
    *
    * @return a formatted string
    */
   public static String leftAlign(int width, long number)
   {
      String str = convert(number);

      if (width < str.length()) {
         return str;
      }
      else {
         return str + pad(' ',width-str.length());
      }
   }

   /**
    * Formats a <code>String</code> using the left alignment.
    * The passed <code>str</code> is converted to a new <code>String</code> 
    * with <code>width</code> characters. The string <code>str</code> is placed 
    * at the left of the new string.
    * If the original <code>str</code> has more characters than the designated <code>width</code>, then 
    * the original <code>str</code> is returned without any formatting.
    *
    * @param width  the number of characters the resulting string will contain
    * @param str    the <code>String</code> value to be formatted
    *
    * @return a formatted string
    */
   public static String leftAlign(int width, String str)
   {
      if (width < str.length()) {
         return str;
      }
      else {
         return str + pad(' ',width-str.length());
      }
   }
   
   /**
    * Formats a real number using the right alignment.
    * The passed <code>number</code> is converted to a <code>String</code> 
    * with <code>width</code> characters. The number is placed at the right,
    * and the second parameter <code>decimalPlaces</code> determines the
    * number of decimal places to be shown. If the converted number has
    * more characters than the designated <code>width</code>, then 
    * the converted number is returned without any formatting.
    * 
    * @param width          number of characters the resulting string will contain
    * @param decimalPlaces  the number of decimal places within the designated 
    *                       field width
    * @param number         the value to be formatted
    *
    * @return a formatted string
    */ 
   public static String rightAlign(int width, int decimalPlaces, double number)
   {
      double num = number * Math.pow(10,decimalPlaces);
      num = Math.round(num);
      num = num / Math.pow(10,decimalPlaces);
      String str = convert(num,decimalPlaces);
         
      if (width < str.length()) {
         return str;
      }
      else {
         return pad(' ', width-str.length()) + str;
      }
   }

   /**
    * Formats an integer using the right alignment.
    * The passed <code>number</code> is converted to a <code>String</code> 
    * with <code>width</code> characters. The number is placed at the right.
    * If the converted number has more characters than the designated <code>width</code>, then 
    * the converted number is returned without any formatting.
    *
    * @param width    the number of characters the resulting string will contain
    * @param number   the integer value to be formatted
    *
    * @return a formatted string
    */
   public static String rightAlign(int width, long number)
   {
      String str = convert(number);

      if (width <= str.length()) {
         return str;
      }
      else {
         return pad(' ',width-str.length()) + str;
      }
   }

   /**
    * Formats a <code>String</code> using the right alignment.
    * The passed <code>str</code> is converted to a new <code>String</code> 
    * with <code>width</code> characters. The string <code>str</code> is placed 
    * at the right of the new string.
    * If the original <code>str</code> has more characters than the designated <code>width</code>, then 
    * the original <code>str</code> is returned without any formatting.
    *
    * @param width  the number of characters the resulting string will contain
    * @param str    the <code>String</code> value to be formatted
    *
    * @return a formatted string
    */
   public static String rightAlign(int width, String str)
   {
      if (width < str.length()) {
         return str;
      }
      else {
         return pad(' ',width-str.length()) + str;
      }
   }

//-------------------------------------------------------------
//    Private Methods:
//
//          static String convert   ( double, int   )
//          static String convert   ( long          )
//           
//          static String pad       ( char, int     )
//           
//-------------------------------------------------------------

   /**
    * Converts a real number to a string. The converted value is rounded and
    * has the number of decimal places as specified by the second parameter.
    * The value is padded with 0s at the end as necessary. 
    *
    * @param number         a real number to be converted   
    * @param decimalPlaces  a number of decimal places the converted will have    
    *
    * @return a string equivalent of <code>number</code>
    */
   private static String convert(double number, int decimalPlaces)
   {
      int i = 0, fractionalPart, strlen, numOfDigitsToAppend;
      StringBuffer str = new StringBuffer("" + number);
      strlen = str.length();

      //note: number may not have a decimal point
      while (i < strlen && str.charAt(i) != '.') {
            i++;
      }

      if (i == strlen) {
         //no decimal point, so add it
         str.append(".");
         numOfDigitsToAppend = decimalPlaces;
      }
      else {

         fractionalPart = strlen - i-1; //# of digits right of decimal pt

         //now pad zeroes if necessary
         numOfDigitsToAppend = decimalPlaces - fractionalPart;
      }

      for (i = 0; i < numOfDigitsToAppend; i++) {
         str.append("0");
      }

      return str.toString();
   }

   /**
    * Converts an integer value to a string.
    *
    * @param number an integer value to be converted      
    *
    * @return a string equivalent of <code>number</code>
    */
   private static String convert(long number)
   {
      return "" + number;
   }

   /**
    * Creates a string with <code>width</code> number of character <code>c</code>.
    * If the designated <code>width</code> is less than one, then 
    * an empty string is returned.
    *
    * @param c      
    * @param width  the number of characters the resulting string will contain
    *
    * @return a string padded with <code>c</code>
    */
   private static String pad(char c, int width)
   {
      StringBuffer str = new StringBuffer("");
      if (width < 1) {
         return "";
      }
      else {
         for (int i = 0; i < width; i++) {
            str.append(c);
         }
         return str.toString();
      }
   }

}