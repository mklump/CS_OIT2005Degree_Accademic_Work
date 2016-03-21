// PrinterErrorEvent.java
// This class defines the events issued by a printer.
package com.deitel.advjhtp1.jiro.DynamicService.printer;

// Jiro package
import javax.fma.services.event.Event;

public class PrinterErrorEvent
   extends Event implements Cloneable {

   // PrinterErrorEvent constructor
   public PrinterErrorEvent( Object source, String topic )
   {
      super ( source, topic );
   }

   // clone event
   public Object clone()
   {
      return new PrinterErrorEvent( source, getTopic() );
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