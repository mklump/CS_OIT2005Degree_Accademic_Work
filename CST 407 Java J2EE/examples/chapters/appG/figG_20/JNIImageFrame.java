// JNIImageFrame.cpp extends JFrame, adds a scroll pane
// and serves as an entry point for the application

// Java core headers
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class JNIImageFrame extends JFrame
{
   // serves as an entry point, creates new JNIImageFrame
   public static void main( String[] args )
   {
      JNIImageFrame imageFrame = new JNIImageFrame();
   }
   
   // constructs a new JNIImageFrame containing JNIPanel
   public JNIImageFrame()
   {
      super( "Deitel Image Processing" );
      
      getContentPane().setLayout( new BorderLayout() );
      
      // adds a new JNIPanel and defines image to process
      getContentPane().add(
         new JScrollPane( new JNIPanel(
            "advjhtp1_small.jpg" , new FlowLayout() ) ), BorderLayout.CENTER );

      addWindowListener( new WindowAdapter() {
         public void windowClosing( WindowEvent evt ) {
            dispose();
            System.exit( 0 );
            }
         }
      );
   this.setResizable( false );
   setSize( 670, 500 );
   setVisible( true );
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

