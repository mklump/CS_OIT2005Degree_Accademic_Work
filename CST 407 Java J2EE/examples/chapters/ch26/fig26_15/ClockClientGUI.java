// Fig. 23.16: ClockClientGUI.java
// GUI used by the AlarmClockClient.

package com.deitel.advjhtp1.idl.alarm;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public class ClockClientGUI extends JFrame {
   private JLabel outputLabel;

   // set up GUI
   public ClockClientGUI()
   {
      super( "Clock GUI" );

      outputLabel = 
         new JLabel(  "The alarm has not gone off..." );
      getContentPane().add( outputLabel, BorderLayout.NORTH );

      setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
      setResizable( false );
      Dimension screenSize =
         Toolkit.getDefaultToolkit().getScreenSize();
      setSize( new Dimension( 450, 100 ) );
      setLocation( ( screenSize.width - 450 ) / 2,
         ( screenSize.height - 100 ) / 2 );
   }

   // set label's text
   public void setText( String message )
   {
      outputLabel.setText( message );
   }

} // end of class ClockClientGUI

/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
