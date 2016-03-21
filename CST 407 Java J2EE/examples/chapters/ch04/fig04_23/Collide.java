// Class Collide implements collision-detection behavior
// for a Java 3D application. Collide switches scenes 
// when the armed object collides with another object. 
package com.deitel.advjhtp1.java3dgame;

// Core Java packages
import java.lang.*;
import java.util.*;

// Java extension packages
import javax.media.j3d.*;
import javax.vecmath.*;

// Java 3D utility packages
import com.sun.j3d.utils.geometry.*; 
import com.sun.j3d.utils.universe.*; 

public class Collide extends Behavior {
   
   // armed node generates WakeupOnCollisionEntry upon collision
   private Node armingNode; 
   
   // specifies to what WakeupEvents to react
   private WakeupCondition wakeupCondition;  
      
   private Switch switchScene; // Switch group contains 3D scenes
   private SimpleUniverse simpleUniverse;  

   // index of scene to switch to upon collision
   private static final int LOSER_SCENE = 1;
   
   // constructor method initializes members 
   public Collide( SimpleUniverse universe, Node node, 
      Switch tempSwitch )
   {
      armingNode = node;
      switchScene = tempSwitch;
      simpleUniverse = universe;
      
      // create WakeupOnCollisionEntry 
      WakeupOnCollisionEntry wakeupEvent = 
         new WakeupOnCollisionEntry( armingNode, 
         WakeupOnCollisionEntry.USE_GEOMETRY );
      
      // set of WakeupEvents to which Behavior reponds
      WakeupCriterion[] wakeupCriteria = { wakeupEvent };
      
      // Behavior responds when any WakeupEvent in 
      // WakeupCriterion occurs
      wakeupCondition = new WakeupOr( wakeupCriteria );
   
   } // end constructor
   
   // initialize Behavior's wakeup conditions 
   public void initialize()
   {
      // register WakeupCriterion to respond to collision events
      wakeupOn( wakeupCondition );
   }
   
   // handle WakeupEvents 
   public void processStimulus( Enumeration detected )
   {
      // loop to handle events
      while( detected.hasMoreElements() ) {
         
         // get next sequential element
         WakeupCriterion criterion = 
            ( WakeupCriterion ) detected.nextElement();
         
         // process event if WakeupOnCollisionEntry 
         if ( criterion instanceof WakeupOnCollisionEntry ) {
            processCollision();
            
            // re-register WakeupCriterion to respond to new
            // WakeonOnCollisionEntry event
            wakeupOn( wakeupCondition );
         }
      }
      
   } // end method processStimulus
   
   // process collision by moving camera view back and 
   // switching scenes in Switch group 
   private void processCollision()
   {
      Transform3D shiftViewBack = new Transform3D();
      
      // set Transform3D's Translation  
      shiftViewBack.setTranslation( 
         new Vector3f( 0.0f, 0.0f, 8.0f ) );
      
      // set Transform3D that determines View 
      ViewingPlatform viewPlatform = 
                     simpleUniverse.getViewingPlatform();
                  
      TransformGroup platformTransform = 
                     viewPlatform.getViewPlatformTransform();
                  
      platformTransform.setTransform( shiftViewBack );
                  
      
      // render scene in Switch group
      switchScene.setWhichChild( LOSER_SCENE );
      
   } // end method processCollision
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


