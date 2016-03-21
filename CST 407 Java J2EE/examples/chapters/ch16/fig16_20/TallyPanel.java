// TallyPanel.java
// TallPanel is the GUI component which displays
// the name and tally for a vote candidate.
package com.deitel.advjhtp1.jms.mdb;

// Java core packages
import java.awt.*;

// Java extension packages
import javax.swing.*;

public class TallyPanel extends JPanel {

   private JLabel nameLabel;
   private JTextField tallyField;
   private String name;
   private int tally;

   // TallyPanel constructor
   public TallyPanel( String voteName, int voteTally )
   {
      name = voteName;
      tally = voteTally;

      nameLabel = new JLabel( name );
      tallyField = 
         new JTextField( Integer.toString( tally ), 10 );
      tallyField.setEditable( false );
      tallyField.setBackground( Color.white );

      add( nameLabel );
      add( tallyField );

   } // end TallyPanel constructor

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