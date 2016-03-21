package javabook; 

/**
 * This class includes various methods for converting values from one data type to 
 * another data type. The advantage of using this class over the standard classes such 
 * as Integer, Double, and others is the consistency. Every method in this class follows
 * the consistent form of "to<datatype>", e.g., toInt, toFloat, and so forth.
 * <p>
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * <p>
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class Convert 
{

//-------------------------------------------------------------
//    Public Methods:
//          static boolean  toBoolean   ( String  )
//          static char     toChar      ( String  )
//          static double   toDouble    ( String  )
//          static float    toFloat     ( String  )
//          static int      toInt       ( String  )
//          static long     toLong      ( String  )
//            
//          static String   toString    ( boolean )
//          static String   toString    ( char    )
//          static String   toString    ( double  )
//          static String   toString    ( long    ) 
//          
//-------------------------------------------------------------
    
    /**
     * Converts the argument String object str to a boolean value.
     * 
     * @param  str A String object to convert to a value (true or false) of data type boolean.
     * @return a boolean equivalent of the passed argument
     * @exception java.lang.NumberFormatException This exception is raised when the passed argument cannnot be converted to a boolean value.
     * Example: "true" can be converted to a boolean value true, but "T" cannot be converted.
     */
 	  public static boolean toBoolean(String str) 
    { 
        Boolean boolObj = new Boolean(str); 
        return boolObj.booleanValue(); 
    }
    
    /**
     * Converts the argument String object str to a char value.
     * 
     * @param str A String object to convert to a value of data type char.
     * @return A char equivalent of the passed argument.
     * @exception java.lang.NumberFormatException This exception is raised when the passed argument cannnot be converted to a char value.
     * Example: "Y" can be converted to a char value 'Y', but "AB" cannot be converted.
     */
    public static char toChar(String str) 
    { 
        return str.charAt(0); 
    }
     
    /**
     * Converts the argument String object str to a double value.
     * 
     * @param str A String object to convert to a value of data type double.
     * @return A double equivalent of the passed argument.
     * @exception java.lang.NumberFormatException This exception is raised when the passed argument cannnot be converted to an int value.
     * Example: "1234" can be converted to a double value 1234.0, but "ID345" cannot be converted.
     */
    public static double toDouble(String str) throws NumberFormatException 
    { 
        return Double.parseDouble(str); 
    }
    
    /**
     * Converts the argument String object str to a float value.
     * 
     * @param str A String object to convert to a value of data type float.
     * @return A float equivalent of the passed argument.
     * @exception java.lang.NumberFormatException This exception is raised when the passed argument cannnot be converted to an int value.
     * Example: "1234.34" can be converted to a float value 1234.34f, but "A34.5" cannot be converted.
     */    
    public static float toFloat(String str) throws NumberFormatException
    { 
        return Float.parseFloat(str); 
    }
    
    /**
     * Converts the argument String object str to an int value.
     * 
     * @param str A String object to convert to a value of data type int.
     * @return An int equivalent of the passed argument.
     * @exception java.lang.NumberFormatException This exception is raised when the passed argument cannnot be converted to an int value.
     * Example: "1234" can be converted to an int value 1234, but "45A" cannot be converted.
     */    
    public static int toInt(String str) throws NumberFormatException 
    { 
        return Integer.parseInt(str); 
    } 

    /**
     * Converts the argument String object str to a long value.
     * 
     * @param str A String object to convert to a value of data type long.
     * @return A long equivalent of the passed argument.
     * @exception java.lang.NumberFormatException This exception is raised when the passed argument cannnot be converted to a long value.
     * Example: "1234567" can be converted to a long value 1234567, but "45.98" cannot be converted.
     */ 
    public static long toLong(String str) throws NumberFormatException 
    { 
        return Long.parseLong(str); 
    } 
 
    /**
     * Converts the argument boolean value to a String value.
     * 
     * @param bool A boolean value to convert to a String.
     * @return A String equivalent of the passed argument.
     */    
    public static String toString(boolean bool) 
    { 
       return String.valueOf(bool);
    }
     
    /**
     * Converts the argument char value to a String value.
     * 
     * @param ch A char value to convert to a String.
     * @return A String equivalent of the passed argument.
     */ 	    
    public static String toString(char ch) 
    { 
       return String.valueOf(ch);
    }
	
    /**
     * Converts the argument double value to a String value. Use this method
     * to convert a float value to a String value; a float is type compatible 
     * with a double.
     * 
     * @param number A double value to convert to a String.
     * @return A String equivalent of the passed argument.
     */ 
    public static String toString(double number) 
    { 
       return String.valueOf(number);
    }    
  
    /**
     * Converts the argument long value to a String value. Use this method
     * to convert an int, short, or byte value to a String value; they are type 
     * compatible with a long.
     * 
     * @param number A long value to convert to a String.
     * @return A String equivalent of the passed argument.
     */
    public static String toString(long number) 
    { 
       return String.valueOf(number);
    } 
 
} 
