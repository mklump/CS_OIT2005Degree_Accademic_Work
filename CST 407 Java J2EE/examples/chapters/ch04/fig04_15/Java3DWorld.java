// Java3DWorld.java
// Java3DWorld is a Java 3D Graphics display environment 
// that creates a SimpleUniverse and provides capabilities for
// allowing a user to control lighting, motion, and texture 
// of the 3D scene.
package com.deitel.advjhtp1.java3d;

// Java core packages
import java.awt.event.*;
import java.awt.*;
import java.net.*;

// Java extension packages
import javax.swing.event.*;
import javax.media.j3d.*;
import javax.vecmath.*;

// Java3D utility packages
import com.sun.j3d.utils.universe.*;
import com.sun.j3d.utils.image.*;
import com.sun.j3d.utils.geometry.*;
import com.sun.j3d.utils.behaviors.mouse.*;

public class Java3DWorld extends Canvas3D {
    
   private Appearance appearance; // 3D object's appearance
   private Light ambientLight; // ambient scene lighting
   private Box shape; // 3D object to manipulate
   private Color3f lightColor; // Light color
   private Light directionalLight; 
   private Material material; // 3D objects color object
   private SimpleUniverse simpleUniverse; // 3D scene environment
   private TextureLoader textureLoader; // 3D object's texture
   
   // holds 3D transformation information
   private TransformGroup transformGroup;  
   
   private String imageName; // texture image file name
   
   // Java3DWorld constructor
   public Java3DWorld( String imageFileName ) {
            
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
   
   } // end Java3DWorld constructor    

   // create 3D scene
   public BranchGroup createScene() 
   {
      BranchGroup scene = new BranchGroup();
      
      // initialize TransformGroup
      transformGroup = new TransformGroup();
      
      // set TransformGroup's WRITE permission
      transformGroup.setCapability( 
         TransformGroup.ALLOW_TRANSFORM_WRITE );
      
      transformGroup.setCapability( 
         TransformGroup.ALLOW_TRANSFORM_READ );
      
      // add TransformGroup to BranchGroup
      scene.addChild( transformGroup );
      
      // create BoundingSphere
      BoundingSphere bounds = new BoundingSphere(
         new Point3d( 0.0f, 0.0f, 0.0f ), 100.0 );
      
      appearance = new Appearance(); // create object appearance 
      material = new Material(); // create texture matieral
      appearance.setMaterial( material ); 
      
      String rgb = new String( "RGB" );
      
      // load texture for scene object
      textureLoader = new TextureLoader( 
         Java3DWorld.class.getResource( imageName ), rgb, this );
      
      // set capability bits for enabling texture 
      textureLoader.getTexture().setCapability( 
         Texture.ALLOW_ENABLE_WRITE );  
      
      // initial texture will not show
      textureLoader.getTexture().setEnable( false );
      
      // set object's texture 
      appearance.setTexture( textureLoader.getTexture() );
       
      // create object geometry
      Box shape = new Box( 0.3f, 0.3f, 0.3f, 
         Box.GENERATE_NORMALS | Box.GENERATE_TEXTURE_COORDS,  
         appearance );  
      
      // add geometry to TransformGroup
      transformGroup.addChild( shape );
      
      // initialize Ambient lighting
      ambientLight = new AmbientLight();
      ambientLight.setInfluencingBounds( bounds );
      
      // initialize directionalLight
      directionalLight = new DirectionalLight();
             
      lightColor = new Color3f(); // initialize light color
            
      // set initial DirectionalLight color
      directionalLight.setColor( lightColor );
            
      // set capability bits to allow DirectionalLight's
      // Color and Direction to be changed
      directionalLight.setCapability( 
         DirectionalLight.ALLOW_DIRECTION_WRITE );
      
      directionalLight.setCapability(
         DirectionalLight.ALLOW_DIRECTION_READ );
      
      directionalLight.setCapability(
         DirectionalLight.ALLOW_COLOR_WRITE );
      
      directionalLight.setCapability(
         DirectionalLight.ALLOW_COLOR_READ );
      
      directionalLight.setInfluencingBounds( bounds );
      
      // add light nodes to BranchGroup
      scene.addChild( ambientLight );
      scene.addChild( directionalLight );
      
      // initialize rotation behavior
      MouseRotate rotateBehavior = new MouseRotate();
      rotateBehavior.setTransformGroup( transformGroup );
      rotateBehavior.setSchedulingBounds( bounds );
      
      // initialize translation behavior  
      MouseTranslate translateBehavior = new MouseTranslate();
      translateBehavior.setTransformGroup( transformGroup );
      translateBehavior.setSchedulingBounds(
         new BoundingBox( new Point3d( -1.0f, -1.0f, -1.0f ), 
         new Point3d( 1.0f, 1.0f, 1.0f ) ) );
      
      // initialize scaling behavior
      MouseZoom scaleBehavior = new MouseZoom();
      scaleBehavior.setTransformGroup( transformGroup );
      scaleBehavior.setSchedulingBounds( bounds );
      
      // add behaviors to BranchGroup
      scene.addChild( scaleBehavior );  
      scene.addChild( rotateBehavior );
      scene.addChild( translateBehavior );
      
      scene.compile(); 
      
      return scene;
   
   } // end method createScene
   
   // change DirectionLight color
   public void changeColor( Color color )
   {
      lightColor.set( color );
      directionalLight.setColor( lightColor );
   }
   
   // change geometry surface to textured image or material color
   public void updateTexture( boolean textureValue )
   {
      textureLoader.getTexture().setEnable( textureValue );
   }

   // change image used for texture
   public void setImageName( String imageFileName )
   {
      imageName = imageFileName;
   }
   
   // get image file name
   public String getImageName() 
   {
      return imageName;
   }
   
    // return preferred dimensions of Container
    public Dimension getPreferredSize()
    {
       return new Dimension( 500, 500 );
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

