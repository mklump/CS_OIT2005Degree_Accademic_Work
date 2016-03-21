package javabook;

import java.io.*;

/**
 * Provides a simple input routine for non-GUI programs. Supports reading
 * integers, real numbers, and strings.
 *
 */
public class SimpleInput
{
    
//------------------------------------
//    Data members
//------------------------------------

    /**
     * Provides readLine capability to System.in
     */
    private static BufferedReader keyboard;
    
    
//-------------------------------------
//    Static Initializer
//-------------------------------------
    static {
        
        keyboard = new BufferedReader( new InputStreamReader( System.in ) );
        
    }
    
//--------------------------------------------
//    Public Methods:
//    
//        static double getDouble     (            )
//        static double getDouble     ( String     )
//
//        static float  getFloat      (            )
//        static float  getFloat      ( String     )
//    
//        static int    getInteger    (            )
//        static int    getInteger    ( String     )
//
//        static String getString     (            )
//        static String getString     ( String     )
//
//---------------------------------------------

    /**
     * Reads in a <c>double</c> using a default prompt text. Does not terminate until
     * the user enters a valid double.
     *
     * @return a <c>double</c> value entered by the user.
     */    
    static public double getDouble()
    {
        return getFloat("Enter a double:");
    }
    
    /**
     * Reads in a <c>double</c> using the second parameter as its prompt text. Does not terminate until
     * the user enters a double.
     *
     * @return a <c>double</c> value entered by the user.
     */
    static public double getDouble(String text)
    {
        boolean done = false;
        double value = 0;
        
        Double doubleObject;

        do {
            try {
                
                prompt(text);
                
                doubleObject = Double.valueOf(getInputLine());
                value = doubleObject.doubleValue();
                done = true;
            }

            catch (NumberFormatException e) {
               promptLine("Not a double. Try again...");
            }
        } while (!done);

        return value;
    }
    
    /**
     * Reads in a <code>float</code> using a default prompt text. Does not terminate until
     * the user enters a valid float.
     *
     * @return a <code>float</code> value entered by the user.
     */
    static public float getFloat()
    {
        return getFloat("Enter a float:");
    }

    /**
     * Reads in a <c>float</c> using the second parameter as its prompt text. Does not terminate until
     * the user enters a valid float.
     *
     * @return a <c>float</c> value entered by the user.
     */
    static public float getFloat(String text)
    {
        boolean done = false;
        float value  = 0f;
        
        Float floatObject;

        do {
            try {
                prompt(text);

                floatObject = Float.valueOf(getInputLine());
                value = floatObject.floatValue();
                done = true;
            }

            catch (NumberFormatException e) {
               promptLine("Not a float. Try again...");
            }
        } while (!done);

        return value;
    }
    
    /**
     * Reads in an integer using a default prompt text. Does not terminate until
     * the user enters a valid integer.
     *
     * @return an <c>int</c> value entered by the user.
     */
    static public int getInteger()
    {
        return getInteger("Enter an integer:");
    }

    /**
     * Reads in an integer using the second parameter as its prompt text. Does not terminate until
     * the user enters a valid integer.
     *
     * @return an <c>int</c> value entered by the user.
     */
    static public int getInteger(String text)
    {
        boolean  done = false;
        int     value = 0;

        do {
            try {
                prompt(text);
        
                value = Integer.parseInt(getInputLine());
                done = true;
            }

            catch (NumberFormatException e) {
                promptLine("Not an integer. Try again...");
            }
        } while (!done);

        return value;
    }

    /**
     * Reads in a <c>String</c> using a default prompt text. 
     *
     * @return a <c>String</c> value entered by the user.
     */
    static public String getString()
    {
        return getString("Enter a string:");
    }

    /**
     * Reads in a <c>String</c> using the second parameter as its prompt text. 
     *
     * @return a <c>String</c> value entered by the user.
     */
    static public String getString(String text)
    {
        prompt(text);

        return (getInputLine());
    }  
  
  //------------------------------------------
  //
  //    Private Methods:
  //
  //        static String getInputLine  (           )
  //        static void   prompt        ( String    ) 
  //        static void   promptLine    ( String    )
  //
  //------------------------------------------ 

    /**
     * Reads in a single line of text. 
     *
     * @return a <c>String</c> value entered by the user.
     */    
    static private String getInputLine( )
    {
        String result = "";
        
        try {
            result = keyboard.readLine( );
        }
        catch (IOException e) {
            
        }
        
        return result;
    }  
 
    /**
     * Prompts the user with the parameter text. 
     *
     */     
    static private void prompt( String text )
    {
        System.out.print(text + " " );
        System.out.flush( );
    }
    
    /**
     * Prompts the user with the parameter text and
     * move to the new line. 
     *
     */     
    static private void promptLine( String text )
    {
        System.out.println(text + " " );
        System.out.flush( );
    }
}