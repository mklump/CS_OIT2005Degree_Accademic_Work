// Class GoalDetector defines a position-checking behavior that 
// checks to see if the position of a Node is equal to the target
// position. If the positions are equal, the game is over and
// a Java 3D Switch displays a different scene.
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

public class GoalDetector extends Behavior {
   
   // index of scene to display if goal detected
   private static final int WINNER_SCENE = 2;
   
   // TransformGroup associated with object
   private TransformGroup objectTransform; 
   
   private Switch switchScene; // Switch group that contains scenes
   private SimpleUniverse simpleUniverse;

   private float goalX, goalY, goalZ; // goal coordinates

   // radius of sphere at goal coordinates
   private float sphereRadius; 

   // Behavior's waking conditions
   private WakeupCondition wakeupCondition;

   // constructor method initializes members 
   // and creates WakeupCriterion
   public GoalDetector( SimpleUniverse universe, 
      TransformGroup transform, Switch switchGroup, 
      Vector3f goalVector, float radius )
   { 
      objectTransform = transform;
      switchScene = switchGroup;
      simpleUniverse = universe;

      // set goal coordinates to goalVector coordinates
      goalX = goalVector.x;
      goalY = goalVector.y;
      goalZ = goalVector.z;
      
      // set radius of sphere at goal coordinates
      sphereRadius = radius;

      // initialize WakeupOnAWTEvent to respond to 
      // AWT KeyEvent.KEY_PRESSED events
      WakeupOnAWTEvent wakeupEvent = 
         new WakeupOnAWTEvent( KeyEvent.KEY_PRESSED );

      // set of WakeupEvents to which Behavior responds
      WakeupCriterion[] wakeupArray = { wakeupEvent };

      // Behavior responds when WakeupEvent in 
      // WakeupCriterion occurs 
      wakeupCondition = new WakeupOr( wakeupArray ); 

   } // end constructor method

   // register Behavior's wakeup conditions
   public void initialize()
   { 
      // register WakeupCriterion to respond to AWTEvents 
      wakeupOn( wakeupCondition ); 
   }

   // handle WakeupEvents
   public void processStimulus( Enumeration detected )
   {
      // loop to handle events
      while ( detected.hasMoreElements() ) { 
         
         // get next sequential WakeupCriterion
         WakeupCriterion wakeupCriterion = 
            ( WakeupCriterion ) detected.nextElement();
         
         // handle if WakeupOnAWTEvent
         if ( wakeupCriterion instanceof WakeupOnAWTEvent ) {
               
            // ensure WakeupOnAWTEvent is KeyEvent.KEY_PRESSED 
            WakeupOnAWTEvent awtEvent = 
               ( WakeupOnAWTEvent ) wakeupCriterion;
            AWTEvent[] event = awtEvent.getAWTEvent();
            
            // check object position
            checkPosition( event );
         
            // re-register WakeupCriterion to respond to next 
            // key press
            wakeupOn( wakeupCondition ); 
         }
      }
      
   } // end method processStimulus

   // check position of object in objectTransform TransformGroup   
   private void checkPosition( AWTEvent[] awtEvents )
   {
      Vector3f translate = new Vector3f();
      Transform3D transform3d = new Transform3D();
      
      // get Transform3D associated with objectTransform
      objectTransform.getTransform( transform3d );
      
      // get Transform3D's translation vector
      transform3d.get( translate );
       
      // handle all key presses in awtEvents
      for ( int x = 0; x < awtEvents.length; x++ ) {
         
         // handle if AWTEvent is KeyEvent
         if ( awtEvents[ x ] instanceof KeyEvent ) {
            KeyEvent keyEvent = (KeyEvent) awtEvents[ x ];
            
            // handle if KeyEvent.KEY_PRESSED
            if ( keyEvent.getID() == KeyEvent.KEY_PRESSED ) {
      
               // if object position == goal coordinates
               if ( atGoal( translate ) ) {
                  Transform3D shiftBack = new Transform3D();
         
                  // set translation to 8.0 on +z-axis
                  shiftBack.setTranslation( 
                     new Vector3f( 0.0f, 0.0f, 8.0f ) );
         
                  // set Transform3D that determines view 
                  // in SimpleUniverse
                  ViewingPlatform viewPlatform = 
                     simpleUniverse.getViewingPlatform();
                  
                  TransformGroup platformTransform = 
                     viewPlatform.getViewPlatformTransform();
                  
                  platformTransform.setTransform( shiftBack );
                  
                  // render winner scene in SimpleUniverse
                  switchScene.setWhichChild( WINNER_SCENE );
               }
            }
         
         } // end if KeyEvent
      
      } // end for loop that handles key presses
            
   } // end method checkPosition

   // helper method returns true if current position is within
   // goal boundry
   private boolean atGoal( Vector3f currentPosition ) 
   { 
      // calculate difference between current location and goal 
      float x = Math.abs( currentPosition.x - goalX );
      float y = Math.abs( currentPosition.y - goalY );
      float z = Math.abs( currentPosition.z - goalZ );
      
      // return true if current position within sphereRadius of
      // goal coordinates
      return ( ( x < sphereRadius ) && ( y < sphereRadius ) && 
         ( z < sphereRadius ) ); 
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

