// MyShapeControllerFactory.java
// MyShapeControllerFactory uses the Factory Method design
// pattern to create an appropriate instance of MyShapeController
// for the given MyShape subclass. 
package com.deitel.advjhtp1.drawing.controller;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;

public class MyShapeControllerFactory {
   
   private static final String FACTORY_PROPERTY_KEY =
      "MyShapeControllerFactory";
   
   private static final String[] supportedShapes = 
      { "MyLine", "MyRectangle", "MyOval", "MyText" };
      
   // reference to Singleton MyShapeControllerFactory
   private static MyShapeControllerFactory factory;
      
   // MyShapeControllerFactory constructor
   protected MyShapeControllerFactory() {}
   
   // return Singleton instance of MyShapeControllerFactory
   public static final MyShapeControllerFactory getInstance()
   {
      // if factory is null, create new MyShapeControllerFactory
      if ( factory == null ) {
         
         // get System property that contains the factory
         // class name
         String factoryClassName = 
            System.getProperty( FACTORY_PROPERTY_KEY );
         
         // if the System property is not set, create a new
         // instance of the default MyShapeControllerFactory
         if ( factoryClassName == null )
            factory = new MyShapeControllerFactory();

         // create a new MyShapeControllerFactory using the
         // class name provided in the System property
         else {
            
            // create MyShapeControllerFactory subclass instance
            try {
               factory = ( MyShapeControllerFactory ) 
                  Class.forName( factoryClassName ).newInstance();     
            }
            
            // handle exception loading instantiating
            catch ( ClassNotFoundException classException ) {
               classException.printStackTrace();
            }      
            
            // handle exception instantiating factory
            catch ( InstantiationException exception ) {
               exception.printStackTrace();
            }
            
            // handle exception if no access to specified Class
            catch ( IllegalAccessException accessException ) {
               accessException.printStackTrace();
            }
         }
            
      } // end if
      
      return factory;      

   } // end method getInstance
   
   // create new MyShapeController subclass instance for given
   // suitable for controlling given MyShape subclass type
   public MyShapeController newMyShapeController( 
      DrawingModel model, String shapeClassName )
   {    
      // create Class instance for given class name and
      // construct appropriate MyShapeController
      try {
         
         // get Class object for selected MyShape subclass
         Class shapeClass = Class.forName( 
            MyShape.class.getPackage().getName() + "." + 
            shapeClassName );
         
         // return appropriate controller for MyShape subclass
         if ( shapeClassName.equals( "MyLine" ) ) 
            return new MyLineController( model, shapeClass );

         else if ( shapeClassName.equals( "MyText" ) )
            return new MyTextController( model, shapeClass );

         else
            return new BoundedShapeController( model, 
               shapeClass );
      }
      
      // handle exception if MyShape derived class not found
      catch ( ClassNotFoundException classException ) {
         classException.printStackTrace();
      }
      
      return null;
      
   }  // end method newMyShapeController      
   
   // get String array of MyShape subclass names for which this
   // factory can create MyShapeControllers
   public String[] getSupportedShapes() 
   {
      return supportedShapes;      
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
