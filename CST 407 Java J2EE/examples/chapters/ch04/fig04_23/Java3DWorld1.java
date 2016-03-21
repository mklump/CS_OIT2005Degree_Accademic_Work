// Class Java3DWorld1 is a Java 3D game.
// The goal is to navigate the small red ball in the bottom right 
// corner to the screen's top-left corner without colliding with 
// any of the flying objects. The user can specify the number of 
// flying objects to make the game more difficult.
package com.deitel.advjhtp1.java3dgame;

// Java core packages
import java.awt.*;
import java.net.*;
import java.util.BitSet;

// Java extension packages
import javax.media.j3d.*;
import javax.vecmath.*;

// Java3D utility packages
import com.sun.j3d.utils.geometry.*;
import com.sun.j3d.utils.image.*;
import com.sun.j3d.utils.universe.*;

public class Java3DWorld1 extends Canvas3D {
    
   // container dimensions
   private static final int CONTAINER_WIDTH = 600;
   private static final int CONTAINER_HEIGHT = 600;
      
   // constants that specify number of shapes
   private static final int NUMBER_OF_SHAPES = 20;
   private static final int NUMBER_OF_PRIMITIVES = 4;
   
   // initial scene to display in Switch
   private static final int DEFAULT_SCENE = 0;
   
   // constants for animating rotation
   private static final int MAX_ROTATION_SPEED = 25000;
   private static final int MIN_ROTATION_SPEED = 20000;
   private static final float MIN_ROTATION_ANGLE = 0.0f;
   private static final float MAX_ROTATION_ANGLE = 
      ( float ) Math.PI * 8.0f;
   
   // constants for animating translation
   private static final int MAX_TRANSLATION_SPEED = 7500; 
   private static final int MIN_TRANSLATION_SPEED = 2500;
   
   // maximum time until animations begins
   public static final int MAX_PHASE_DELAY = 20000;
   
   // 3D shape information
   private static final float MAX_RADIUS = 0.15f;
   private static final float MAX_LENGTH = 0.2f;
   private static final float MAX_SHININESS = 128.0f;
   private static final float SPHERE_RADIUS = 0.15f;
   private static final float BOUNDING_RADIUS = 100.0f;
   
   private Switch shapeSwitch; // contains flying shapes
   private BoundingSphere bounds; // bounds for nodes and groups
   
   private SimpleUniverse simpleUniverse; // 3D environment
     
   private String imageName; // texture image file name
   
   // Java3DWorld1 constructor
   public Java3DWorld1( String imageFileName ) {
             
      super( SimpleUniverse.getPreferredConfiguration() );
      
      imageName = imageFileName;
      
      // create SimpleUniverse ( 3D Graphics environment )
      simpleUniverse = new SimpleUniverse( this );
      
      // set viewing distance for 3D scene
      ViewingPlatform viewPlatform = 
         simpleUniverse.getViewingPlatform();
         
      viewPlatform.setNominalViewingTransform();
      
      // create 3D scene 
      BranchGroup branchGroup = createScene();
      
      // attach BranchGroup to SimpleUniverse
      simpleUniverse.addBranchGraph( branchGroup );
   
   } // end Java3DWorld1 constructor    

   // create 3D scene
   public BranchGroup createScene() 
   {
      BranchGroup sceneBranchGroup = new BranchGroup();
      
      // create scene Switch group 
      Switch sceneSwitch = initializeSwitch( DEFAULT_SCENE );
      
      // create Switch group containing shapes
      shapeSwitch = initializeSwitch( DEFAULT_SCENE );
      
      // initialize BranchGroup that contains only elements
      // in game scene 
      BranchGroup gameBranchGroup = new BranchGroup();
      
      // add shapeSwitch to gameBranchGroup
      gameBranchGroup.addChild( shapeSwitch ); 
      
      // add gameBranchGroup to sceneSwitch
      sceneSwitch.addChild( gameBranchGroup );
      
      // add sceneSwitch to sceneBranchGroup
      sceneBranchGroup.addChild( sceneSwitch );
      
      // create BoundingSphere for 3D objects and behaviors
      bounds = new BoundingSphere(
         new Point3d( 0.0f, 0.0f, 0.0f ), BOUNDING_RADIUS );
               
      // create rotation TransformGroup array
      TransformGroup[] spinTransform = 
         createTransformGroupArray( NUMBER_OF_SHAPES );
      
      // create translation TransformGroup array
      TransformGroup[] pathTransform = 
         createTransformGroupArray( NUMBER_OF_SHAPES );
      
      // create RotationInterpolators
      createRotationInterpolators( spinTransform, 
         NUMBER_OF_SHAPES );
      
      // create PositonInterpolators
      createPositionInterpolators( pathTransform, 
         NUMBER_OF_SHAPES );
                
      // create Appearance objects for Primitives
      Appearance[] shapeAppearance = 
         createAppearance( NUMBER_OF_SHAPES );
      
      // create shapes
      Primitive[] shapes = 
         createShapes( shapeAppearance, NUMBER_OF_SHAPES ); 
      
      // add shapes to scene structure
      for ( int x = 0; x < NUMBER_OF_SHAPES; x++ ) {
         
         // add primitive to spinTransform group
         spinTransform[ x ].addChild( shapes[ x ] );
         
         // add spinTransform group to pathTransform group
         pathTransform[ x ].addChild( spinTransform[ x ] );
      
         // add pathTransform group to shapeSwitch group
         shapeSwitch.addChild( pathTransform[ x ] );
      }
            
      // create and set scene lighting
      setLighting( sceneBranchGroup, bounds );  
      
      // create scene to display if user loses
      TransformGroup loserTransformGroup = 
         createEndScene( "You Lose!" );
      
      // add loser scene to sceneSwitch
      sceneSwitch.addChild( loserTransformGroup );  
      
      // create scene to display if user winss
      TransformGroup winnerTransformGroup = 
         createEndScene( "You Win!" );
      
      // add winner scene to sceneSwitch
      sceneSwitch.addChild( winnerTransformGroup ); 
      
      // create shiny red Appearance for navigating shape
      Appearance flyingAppearance = createAppearance( 
         new Color3f( 1.0f, 0.0f, 0.0f ) );
      
      // initialize navigable sphere 
      Primitive flyingBall = new Sphere( 
         0.03f,  Sphere.GENERATE_NORMALS, flyingAppearance );
      
      // set capability bits to enable collision detection and 
      // allow for read/write of bounds
      flyingBall.setCollidable( true );
        flyingBall.setCapability( Node.ENABLE_COLLISION_REPORTING );
      flyingBall.setCapability( Node.ALLOW_BOUNDS_READ );
      flyingBall.setCapability( Node.ALLOW_BOUNDS_WRITE );
      
      // create TransformGroup to translate shape position
      TransformGroup startTransform = createTransform( 
         new Vector3f( 0.9f, -0.9f, 0.0f ) );
           
      startTransform.addChild( flyingBall );
      gameBranchGroup.addChild( startTransform );
       
      // create Material for Appearance for target sphere
      Appearance targetAppearance = createAppearance(
         new Color3f( 0.0f, 1.0f, 0.0f ) );
      
      // obtain textured image for target sphere
      String rgb = new String( "RGB" );
      TextureLoader textureLoader = new TextureLoader( 
         Java3DWorld1.class.getResource( imageName ), rgb, this );
      textureLoader.getTexture().setEnable( true );
      targetAppearance.setTexture( textureLoader.getTexture() );
      
      // initialize target sphere
      Primitive targetSphere = new Sphere( SPHERE_RADIUS, 
         Sphere.GENERATE_TEXTURE_COORDS | Sphere.GENERATE_NORMALS, 
         targetAppearance );
      
      // disable collision detection for sphere
      targetSphere.setCollidable( false );
           
      // create vector to target point
      Vector3f target = new Vector3f( -1.0f, 1.0f, -1.0f );
      
      // create TransformGroup that translates sphere position
      TransformGroup targetTransform = createTransform( target );
      targetTransform.addChild( targetSphere );
      gameBranchGroup.addChild( targetTransform );
            
      // create Navigator behavior
      Navigator navigator = new Navigator( startTransform );
      navigator.setSchedulingBounds( bounds );
      
      // create Collide behavior
      Collide collider = new Collide(  
         simpleUniverse, flyingBall, sceneSwitch );
      collider.setSchedulingBounds( bounds );
      
      // create GoalDetector behavior
      GoalDetector goalDetector = new GoalDetector( 
         simpleUniverse, startTransform, sceneSwitch, 
         target, SPHERE_RADIUS );
      goalDetector.setSchedulingBounds( bounds );
      
      // add Behaviors to scene
      sceneBranchGroup.addChild( goalDetector );
      sceneBranchGroup.addChild( collider );
      sceneBranchGroup.addChild( navigator );
      
      // create Background for scene
      Background background = new Background();
      background.setColor( 0.65f, 0.75f, 1.0f );
      background.setApplicationBounds( bounds );
      sceneBranchGroup.addChild( background );
      
      sceneBranchGroup.compile(); 
      
      return sceneBranchGroup;
   
   } // end method createScene
   
   // create Appearance object for Primitive in scene
   private Appearance createAppearance( Color3f diffuseColor )
   {
      Appearance appearance = new Appearance();
      Material material = new Material();
      material.setShininess( MAX_SHININESS );
      material.setDiffuseColor( diffuseColor );
      material.setAmbientColor( 0.0f, 0.0f, 0.0f );
      appearance.setMaterial( material );
      return appearance;
   
   } // end method createAppearance
      
   
   // create TransformGroup for placing an object in scene
   private TransformGroup createTransform( 
      Vector3f positionVector )
   {
      // initialize a TransformGroup and set capability bits
      TransformGroup transformGroup = new TransformGroup();
      transformGroup.setCapability( 
         TransformGroup.ALLOW_TRANSFORM_READ );
      transformGroup.setCapability( 
         TransformGroup.ALLOW_TRANSFORM_WRITE );
      
      // translate starting position to bottom right of scene
      Transform3D location = new Transform3D();
      location.setTranslation( positionVector );
      transformGroup.setTransform( location );
   
      return transformGroup;
      
   } // end method createTransform
   
   // initialize Switch group and set capability bits
   private Switch initializeSwitch( int sceneNumber )
   {
      Switch switchGroup = new Switch( sceneNumber );
      switchGroup.setCollidable( true );
      switchGroup.setCapability( Switch.ALLOW_SWITCH_WRITE );
      switchGroup.setCapability( Switch.ALLOW_SWITCH_READ );
      switchGroup.setCapability( Group.ALLOW_CHILDREN_WRITE );
      switchGroup.setCapability( Group.ALLOW_CHILDREN_READ );
      switchGroup.setCapability( 
         Group.ENABLE_COLLISION_REPORTING );
      return switchGroup;
   
   } // end method initializeSwitch
   
   private TransformGroup[] createTransformGroupArray( 
      int size )
   {
      TransformGroup[] transformGroup = 
         new TransformGroup[ size ];
      
      // set TransformGroup's WRITE and READ permissions
      // and enable collision reporting
      for ( int i = 0; i < size; i++ ) {
         
         // create TransformGroups
         transformGroup[ i ] = new TransformGroup();
        
         // enable collision reporting
         transformGroup[ i ].setCapability(
            Group.ENABLE_COLLISION_REPORTING );
         
         // enable WRITE permission
         transformGroup[ i ].setCapability(
            TransformGroup.ALLOW_TRANSFORM_WRITE );
         
         // enable READ permission
         transformGroup[ i ].setCapability( 
            TransformGroup.ALLOW_TRANSFORM_READ );
      }
      
      return transformGroup;
      
   } // end method createTransformGroupArray
   
   // create RotationInterpolators for scene
   private void createRotationInterpolators( 
      TransformGroup[] transformGroup, int size )
   {
      // declare structures for creating RotationInterpolators
      Alpha[] alphaSpin = new Alpha[ size ];
      
      Transform3D[] spinAxis = 
         new Transform3D[ size ];
      
      RotationInterpolator[] spinner = 
         new RotationInterpolator[ size ];
      
      // create RotationInterpolator for each shape
      for ( int x = 0; x < size; x++ ) {
         
         // initialize Alpha
         alphaSpin[ x ] = new Alpha();
         
         // set increasing time for Alpha to random number
         alphaSpin[ x ].setIncreasingAlphaDuration( 
            MIN_ROTATION_SPEED + ( ( int ) ( Math.random() * 
               MAX_ROTATION_SPEED ) ) );
         
         // initialize RotationInterpolator using appropriate
         // Alpha and TransformGroup
         spinner[ x ] = new RotationInterpolator( 
            alphaSpin[ x ], transformGroup[ x ] );
         
         spinAxis[ x ] = new Transform3D();
         
         // set random X-axis rotation
         spinAxis[ x ].rotX( 
            ( float ) ( Math.PI * ( Math.random() * 2 ) ) );
         spinner[ x ].setAxisOfRotation( spinAxis[ x ] );
         
         // set minimum and maximum rotation angles
         spinner[ x ].setMinimumAngle( MIN_ROTATION_ANGLE );
         spinner[ x ].setMaximumAngle( MAX_ROTATION_ANGLE );
         
         spinner[ x ].setSchedulingBounds( bounds );
         
         // add RotationInterpolator to appropriate TransformGroup
         transformGroup[ x ].addChild( spinner[ x ] );
      }
      
   } // end method createRotationInterpolators
   
   // create PositionInterpolators
   private void createPositionInterpolators( 
      TransformGroup[] transformGroup, int size )
   {
      // create structures for PositionInterpolators
      Alpha[] alphaPath = new Alpha[ size ];
      
      PositionInterpolator[] mover = 
         new PositionInterpolator[ size ];
      
      Transform3D[] pathAxis = 
         new Transform3D[ size ];
                 
      // create PositionInterpolator for each shape
      for ( int x = 0; x < size; x++ ) {
         
         // initialize Alpha
         alphaPath[ x ] = new Alpha();
         
         // set mode to increase and decrease interpolation
         alphaPath[ x ].setMode( 
            Alpha.INCREASING_ENABLE | Alpha.DECREASING_ENABLE );
         
         // set random phase delay
         alphaPath[ x ].setPhaseDelayDuration( 
            ( ( int ) ( Math.random() * MAX_PHASE_DELAY ) ) );
         
         // randomize translation speed
         int speed = MIN_TRANSLATION_SPEED + 
            ( int ) ( Math.random() * MAX_TRANSLATION_SPEED );
         
         // set increasing and decreasing durations
         alphaPath[ x ].setIncreasingAlphaDuration( speed );
         alphaPath[ x ].setDecreasingAlphaDuration( speed );
         
         // randomize translation axis
         pathAxis[ x ] = new Transform3D();
         pathAxis[ x ].rotX( 
            ( float ) ( Math.PI * ( Math.random() * 2 ) ) );
         pathAxis[ x ].rotY( 
            ( float ) ( Math.PI * ( Math.random() * 2 ) ) );
         pathAxis[ x ].rotZ( 
            ( float ) ( Math.PI * ( Math.random() * 2 ) ) );
         
         // initialize PositionInterpolator
         mover[ x ] = new PositionInterpolator( alphaPath[ x ], 
            transformGroup[ x ], pathAxis[ x ], 1.0f, -1.0f );
         
         mover[ x ].setSchedulingBounds( bounds );
         
         // add PostionInterpolator to appropriate TransformGroup
         transformGroup[ x ].addChild( mover[ x ] );
      }
      
   } // end method createPositionInterpolators
   
   // create appearance and material arrays for Primitives
   private Appearance[] createAppearance( int size )
   {
      // create Appearance objects for each shape
      Appearance[] appearance = 
         new Appearance[ size ];
      
      Material[] material = new Material[ size ];
      
      // set material and appearance properties for each shape
      for( int i = 0; i < size; i++ ) {
         appearance[ i ] = new Appearance();
         material[ i ] = new Material();
         
         // set material ambient color 
         material[ i ].setAmbientColor( 
            new Color3f( 0.0f, 0.0f, 0.0f ) );
         
         // set material Diffuse color
         material[ i ].setDiffuseColor( new Color3f(
            ( float ) Math.random(), ( float ) Math.random()*0.5f, 
            ( float ) Math.random() ) );
         
         // set Material for appropriate Appearance object
         appearance[ i ].setMaterial( material[ i ] );
      }
      return appearance;
      
   } // end method createAppearance
      
   // create Primitives shapes
   private Primitive[] createShapes( Appearance[] appearance, 
      int size )
   {
      Primitive[] shapes = new Primitive[ size ];
      
      // random loop to get index
      for ( int x = 0; x < size; x++ ) {
         
        // generate random shape index
        int index = ( int ) ( Math.random() * NUMBER_OF_PRIMITIVES );
         
        // create shape based on random index
        switch( index ) {
           
           case 0: // create Box
              shapes[ x ] = new Box( 
                 ( ( float ) Math.random() * MAX_LENGTH ), 
                 ( ( float ) Math.random() * MAX_LENGTH ), 
                 ( ( float ) Math.random() * MAX_LENGTH ), 
                 Box.GENERATE_NORMALS, appearance[ x ] );
              break;
           
           case 1: // create Cone
              shapes[ x ] = new Cone( 
                 ( ( float ) Math.random() * MAX_RADIUS ), 
                 ( ( float ) Math.random() * MAX_LENGTH ), 
                 Cone.GENERATE_NORMALS, appearance[ x ] );
              break;
              
           case 2: // create Cylinder
              shapes[ x ] = new Cylinder( 
                 ( ( float ) Math.random() * MAX_RADIUS ), 
                 ( ( float ) Math.random() * MAX_LENGTH ), 
                 Cylinder.GENERATE_NORMALS, appearance[ x ] );
              break;
           
           case 3: // create Sphere
              shapes[ x ] =  new Sphere( 
                 ( ( float ) Math.random() * MAX_RADIUS ), 
                 Sphere.GENERATE_NORMALS, appearance[ x ] );
              break;
      
        } // end switch statement
         
        // set capability bits to enable collisions and to set 
        // read/write permissions of bounds 
        shapes[ x ].setCapability( 
           Node.ENABLE_COLLISION_REPORTING );
        shapes[ x ].setCapability( 
           Node.ALLOW_BOUNDS_READ );
        shapes[ x ].setCapability( 
           Node.ALLOW_BOUNDS_WRITE );
        shapes[ x ].setCollidable( true );
         
      }
      
      return shapes;
      
   } // end method createShapes
   
   // initialize ambient and directional lighting
   private void setLighting( BranchGroup scene, 
      BoundingSphere bounds )
   {
      // initialize ambient lighting
      AmbientLight ambientLight = new AmbientLight();
      ambientLight.setInfluencingBounds( bounds );
      
      // initialize directional lighting
      DirectionalLight directionalLight = new DirectionalLight();
      directionalLight.setColor( 
         new Color3f( 1.0f, 1.0f, 1.0f ) );
      directionalLight.setInfluencingBounds( bounds );
      
      // add lights to scene
      scene.addChild( ambientLight );
      scene.addChild( directionalLight );
   
   } // end method setLighting
   
   // update scene by rendering different shapes in shapeSwitch 
   public void switchScene( int numberChildren, int size )
   {
      // create a new BitSet of size NUMBER_OF_SHAPES
      BitSet bitSet = new BitSet( size );
      
      // set BitSet values
      for ( int i = 0; i < numberChildren; i++ ) 
         bitSet.set( i );
            
      // instruct switchShape to render Mask of objects
      shapeSwitch.setWhichChild( Switch.CHILD_MASK );
      shapeSwitch.setChildMask( bitSet );
   
   } // end method switchScene
   
   // create end scene when user wins or loses
   private TransformGroup createEndScene( String text ) 
   {
      TransformGroup transformGroup = new TransformGroup();
      transformGroup.setCapability( 
         TransformGroup.ALLOW_TRANSFORM_WRITE );
      
      // disable scene collision detection
      transformGroup.setCollidable( false );
      
      // create Alpha object
      Alpha alpha = new Alpha();
         alpha.setIncreasingAlphaDuration( MAX_ROTATION_SPEED );
      
      // create RotationInterpolator for scene
      RotationInterpolator rotation = 
      new RotationInterpolator( alpha, transformGroup );
      
      // set axis of rotation
      Transform3D axis = new Transform3D();
      axis.rotY( ( float ) ( Math.PI / 2.0 ) );
      rotation.setAxisOfRotation( axis );
      
      // set minimum and maximum rotation angles
      rotation.setMinimumAngle( 0.0f );
      rotation.setMaximumAngle( ( float ) ( Math.PI * 8.0 ) );
      
      rotation.setSchedulingBounds( bounds );
      transformGroup.addChild( rotation );
      
      // create scene geometry
      Appearance appearance = new Appearance(); 
      Material material = new Material(); 
      appearance.setMaterial( material ); 
      
      // set diffuse color of material 
      material.setDiffuseColor( 
         new Color3f( 0.0f, 0.8f, 1.0f ) );
      
      // create Font3D object
      Font3D font3d = new Font3D(
         new Font( "Helvetica", Font.ITALIC, 1 ), 
         new FontExtrusion() );
      
      // create Text3D object from Font3D object
      Text3D text3d = new Text3D( font3d, text, 
         new Point3f( -2.0f, 0.0f, 0.0f ) );
      
      // create Shape3D object from Text3D object
      Shape3D textShape = new Shape3D( text3d );
      
      textShape.setAppearance( appearance );
      
      // disable collision detection
      textShape.setCollidable( false );
      
      transformGroup.addChild( textShape );
      
      return transformGroup;
   
   } // end method createEndScene
   
   
   // return preferred dimensions of Container
   public Dimension getPreferredSize()
   {
      return new Dimension( CONTAINER_WIDTH, CONTAINER_HEIGHT );
   } 
    
    // return minimum size of Container
   public Dimension getMinimumSize()
   {
      return getPreferredSize();
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

