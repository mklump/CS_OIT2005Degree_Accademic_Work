// DrawingFileFilter.java
// DrawingFileFilter is a FileFilter subclass for selecting 
// DeitelDrawing files in a JFileChooser dialog.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.io.File;

// Java extension packages
import javax.swing.filechooser.*;

public class DrawingFileFilter extends FileFilter {
   
   // String to use in JFileChooser description
   private String DESCRIPTION = "DeitelDrawing Files (*.dd)";
   
   // file extensions for DeitelDrawing files
   private String EXTENSION = ".dd";

   // get description for DeitelDrawing files
   public String getDescription() 
   {
      return DESCRIPTION;
   }

   // return true if given File has proper extension
   public boolean accept( File file ) 
   {
      return ( file.getName().toLowerCase().endsWith( 
         EXTENSION ) );
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
