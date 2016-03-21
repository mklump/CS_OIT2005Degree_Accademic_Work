// Fig. 6.59 MinimumValueEditor.java
// MinimumValueEditor is the PropertyEditor for the 
// minimumValue property of the SliderFieldPanel bean.
package com.deitel.advjhtp1.beans;

// Java core packages
import java.beans.*;

public class MinimumValueEditor extends PropertyEditorSupport {

   protected Integer minimumValue;

   // set minimumValue property
   public void setValue( Object value ) 
   {
      minimumValue = ( Integer ) value;
      firePropertyChange();
   }
   
   // get value of property minimum
   public Object getValue()
   {
      return minimumValue;
   }
   
   // set maximumValue property from text string
   public void setAsText( String string )
   {
      // decode may throw NumberFormatException
      try {
         minimumValue = Integer.decode( string );
         firePropertyChange();
      }

      // throw IllegalArgumentException if decode throws
      // NumberFormatException
      catch ( NumberFormatException numberFormatException ) {
         throw new IllegalArgumentException();
      }
   }

   // string array for pull-down menu
   public String[] getTags()
   {
      return new String[] { "50", "100", "150", "200", "250", 
         "300", "350", "400", "450", "500" };
   }
   
   // get minimumValue property as string
   public String getAsText() 
   {
      return getValue().toString();
   }
   
   // get initialization string for Java code
   public String getJavaInitializationString() 
   {
      return getValue().toString();
   }

}  // end class MinimumValueEditor

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
