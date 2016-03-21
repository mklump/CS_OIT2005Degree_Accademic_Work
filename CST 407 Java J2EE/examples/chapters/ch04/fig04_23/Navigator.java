// Class Navigator is a subclass of Behavior that implements a 
// keyboard translation navigator. Navigator responds to certain 
// key presses by translating an object in a 3D scene.
package com.deitel.advjhtp1.java3dgame;

// Core Java packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;

// Java extension packages
import javax.media.j3d.*;
import javax.vecmath.*;

// Java 3D utility packages
import com.sun.j3d.utils.universe.*;

public class Navigator extends Behavior {

   // TransformGroup associated with object controlled 
   // by keyboard navigator
   private TransformGroup objectTransform; 
    
   // translation amounts  
   private static final float LEFT = -0.02f;
   private static final float RIGHT = 0.02f;
   private static final float UP = 0.02f;
   private static final float DOWN = -0.02f;
   private static final float FORWARD = 0.02f;
   private static final float BACKWARD = -0.02f;

   // waking conditions for Behavior
   private WakeupCondition wakeupCondition;

   // constructor method
   public Navigator( TransformGroup transform )
   { 
      objectTransform = transform;
      
      // initialize WakeupOnAWTEvent to repond to 
      // AWT KeyEvent.KEY_PRESSED events
      WakeupOnAWTEvent wakeupEvent = 
         new WakeupOnAWTEvent( KeyEvent.KEY_PRESSED );
   
      // set of WakeupEvents to which Behavior responds 
      WakeupCriterion[] wakeupCriteria = { wakeupEvent };
      
      // Behavior responds when WakeupEvent in the 
      // WakeupCriterion occurs
      wakeupCondition = new WakeupOr( wakeupCriteria );
   
   } // end constructor

   // initialize Behavior's wakeup conditions
   public void initialize()
   { 
      // register WakeupCriterion to generate WakeupEvents
      // when AWT events occur
      wakeupOn( wakeupCondition ); 
   }

   // handle WakeupEvents
   public void processStimulus( Enumeration detected )
   { 
      // loop to handle events
      while ( detected.hasMoreElements() ) { 
         
         // get next WakeupCriterion
         WakeupCriterion wakeupCriterion = 
            ( WakeupCriterion ) detected.nextElement();
         
         // handle WakeupCriterion if WakeupOnAWTEvent
         if ( wakeupCriterion instanceof WakeupOnAWTEvent ) { 
            WakeupOnAWTEvent awtEvent = 
               (WakeupOnAWTEvent) wakeupCriterion;
            AWTEvent[] events = awtEvent.getAWTEvent();
            
            // invoke method moveObject with AWTEvent
            moveShape( events ); 
         } 
      }
      
      // re-register wakeupCondition to respond to next key press
      wakeupOn( wakeupCondition ); 
   
   } // end method processStimulus
   
   // handle AWT KeyEvents by translating an object in 3D scene
   private void moveShape( AWTEvent[] awtEvents )
   { 
      // handle all events in AWTEvent array 
      for ( int x = 0; x < awtEvents.length; x++)
      { 
         // handle if AWTEvent is KeyEvent
         if ( awtEvents[ x ] instanceof KeyEvent ) {
            
            // get cooresponding KeyEvent
            KeyEvent keyEvent = ( KeyEvent ) awtEvents[ x ];
            
            // respond only if KeyEvent is of type KEY_PRESSED 
            if ( keyEvent.getID() == KeyEvent.KEY_PRESSED ) { 
               
               // get KeyCode associated with KeyEvent
               int keyCode = keyEvent.getKeyCode();
               
               Transform3D transform3D = new Transform3D();
               
               // get Transform3D from TransformGroup of 
               // navigable object
               objectTransform.getTransform( transform3D );
               
               Vector3f translateVector = new Vector3f();
               
               // retrieve translation vector associated with 
               // Transform3D
               transform3D.get( translateVector );
               
               // update x, y, or z component of translation 
               // vector based on keypress
               switch ( keyCode ) { 
                  
                  case KeyEvent.VK_A:  // move left 
                     translateVector.x += LEFT; 
                     break;

                  case KeyEvent.VK_D: // move right
                     translateVector.x += RIGHT; 
                     break; 

                  case KeyEvent.VK_W: // move up
                     translateVector.y += UP; 
                     break;

                  case KeyEvent.VK_S: // move down
                     translateVector.y += DOWN; 
                     break;

                  case KeyEvent.VK_UP: // move backwards
                     translateVector.z += BACKWARD; 
                     break;

                  case KeyEvent.VK_DOWN: // move forwards
                     translateVector.z += FORWARD; 
                     break;

               } // end switch
               
               // set translational component of Transform3D 
               // with updated translation Vector3f
               transform3D.setTranslation( translateVector );
               
               // set TransformGroup's Transform3D
               objectTransform.setTransform( transform3D ); 
            
            } // end if KeyEvent.KEY_PRESSED 
         } 

      } // end for loop that handles key presses
      
   } // end method moveShape
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


