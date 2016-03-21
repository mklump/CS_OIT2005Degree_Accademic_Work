// MyText.java
// MyText is a MyShape subclass that represents styled text
// in a drawing.
package com.deitel.advjhtp1.drawing.model.shapes;

// Java core packages
import java.awt.*;
import java.text.*;
import java.awt.font.*;
import java.awt.geom.*;

// third-party packages
import org.w3c.dom.*;

public class MyText extends MyShape {
   
   // MyText properties (font, font size, text, etc.)
   private String text;
   private AttributedString attributedString;
   private String fontName = "Serif";
   private int fontSize = 12;   
   private boolean underlined = false;
   private boolean boldSelected = false;
   private boolean italicSelected = false;

   // draw MyText on given Graphics2D context
   public void draw( Graphics2D g2D )
   {
      // configure Graphics2D (gradient, color, etc.)
      configureGraphicsContext( g2D );

      // create AttributedString for drawing text
      attributedString = new AttributedString( text );
      
      // set AttributedString Font
      attributedString.addAttribute( TextAttribute.FAMILY, 
         fontName );
      
      // set AttributedString Font size
      attributedString.addAttribute( TextAttribute.SIZE, 
         new Float( fontSize ) );
      
      // if selected, set bold, italic and underlined
      if ( boldSelected )
         attributedString.addAttribute( TextAttribute.WEIGHT, 
            TextAttribute.WEIGHT_BOLD );
      
      if ( italicSelected )
         attributedString.addAttribute( TextAttribute.POSTURE, 
            TextAttribute.POSTURE_OBLIQUE );
      
      if ( underlined )
         attributedString.addAttribute( TextAttribute.UNDERLINE, 
            TextAttribute.UNDERLINE_ON );
         
      // set AttributedString Color 
      attributedString.addAttribute( TextAttribute.FOREGROUND, 
         getColor() );
      
      // create AttributedCharacterIterator for AttributedString
      AttributedCharacterIterator characterIterator = 
         attributedString.getIterator();
      
      // draw string using AttributedCharacterIterator
      g2D.drawString( characterIterator, getX1(), getY1() );      
   }
   
   // return false because MyText objects contain no area
   public boolean contains( Point2D pt ) 
   {
      return false;
   }
   
   // set MyText text
   public void setText( String myText ) 
   { 
      text = myText; 
   }

   // get text contained in MyText
   public String getText() 
   { 
      return text; 
   }  

   // set MyText Font size
   public void setFontSize( int size ) 
   { 
      fontSize = size; 
   }

   // get MyText Font size
   public int getFontSize() 
   { 
      return fontSize; 
   }

   // set MyText Font name
   public void setFontName( String name ) 
   { 
      fontName = name; 
   }

   // get MyText Font name
   public String getFontName() 
   { 
      return fontName; 
   }

   // set MyText underlined property
   public void setUnderlineSelected( boolean textUnderlined ) 
   { 
      underlined = textUnderlined; 
   }

   // get MyText underlined property
   public boolean isUnderlineSelected() 
   { 
      return underlined; 
   }

   // set MyText bold property
   public void setBoldSelected( boolean textBold ) 
   { 
      boldSelected = textBold; 
   }

   // get MyText bold property
   public boolean isBoldSelected() 
   { 
      return boldSelected; 
   }

   // set MyText italic property
   public void setItalicSelected( boolean textItalic ) 
   { 
      italicSelected = textItalic; 
   }

   // get MyText italic property
   public boolean isItalicSelected() 
   { 
      return italicSelected; 
   }
   
   // get MyText XML representation
   public Element getXML( Document document )
   {
      Element shapeElement = super.getXML( document );
      shapeElement.setAttribute( "type", "MyText" );
      
      // create text Element
      Element temp = document.createElement( "text" );
      temp.appendChild( document.createTextNode( getText() ) );
      shapeElement.appendChild( temp );

      // create fontSize Element
      temp = document.createElement( "fontSize" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( fontSize ) ) );
      shapeElement.appendChild( temp );
      
      // create fontName Element
      temp = document.createElement( "fontName" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( fontName ) ) );
      shapeElement.appendChild( temp );
      
      // create underlined Element
      temp = document.createElement( "underlined" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( underlined ) ) );
      shapeElement.appendChild( temp );
      
      // create bold Element
      temp = document.createElement( "bold" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( boldSelected ) ) );
      shapeElement.appendChild( temp );
      
      // create italic Element
      temp = document.createElement( "italic" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( italicSelected ) ) );
      shapeElement.appendChild( temp );

      return shapeElement;    
      
   } // end method getXML    
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
