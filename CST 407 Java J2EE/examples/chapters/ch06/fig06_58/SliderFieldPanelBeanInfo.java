// Fig. 6.56 SliderFieldPanelBeanInfo.java
// SliderFieldPanelBeanInfo is the BeanInfo class for 
// SliderFieldPanel
package com.deitel.advjhtp1.beans;

// Java core packages
import java.beans.*;
import java.awt.Image;

// Java extension packages
import javax.swing.*;

public class SliderFieldPanelBeanInfo extends SimpleBeanInfo {

   public static final Class beanClass = 
      SliderFieldPanel.class;

   // return general description of bean
   public BeanDescriptor getBeanDescriptor()
   {
      BeanDescriptor descriptor = new BeanDescriptor( 
         beanClass, SliderFieldPanelCustomizer.class );
      descriptor.setDisplayName( "Slider Field" );
      descriptor.setShortDescription( 
         "A slider bar to change a numerical property." );
 
      return descriptor;
   }

   // return bean icon
   public Image getIcon( int iconKind )
   {
      Image image = null;
      
      switch( iconKind ) {

         case ICON_COLOR_16x16:
            image = loadImage( "icon1.gif" );
            break;

         case ICON_COLOR_32x32:
            image = loadImage( "icon2.gif" );
            break;

         case ICON_MONO_16x16:
            image = loadImage( "icon3.gif" );
            break;

         case ICON_MONO_32x32:
            image = loadImage( "icon4.gif" );
            break;

         default:
            break;
      }
      
      return image;
   }
   
   // return array of MethodDescriptors for public get methods
   // of class SliderFieldPanel
   public MethodDescriptor[] getMethodDescriptors()
   {      
      // create array of MethodDescriptors
      try {
         MethodDescriptor getMinimumValue = new 
            MethodDescriptor( beanClass.getMethod( 
               "getMinimumValue", null ) );
         
         MethodDescriptor getMaximumValue = new 
            MethodDescriptor( beanClass.getMethod( 
               "getMaximumValue", null ) );
         
         MethodDescriptor getCurrentValue = new 
            MethodDescriptor( beanClass.getMethod( 
               "getCurrentValue", null ) );
         
         MethodDescriptor getFieldWidth = new 
            MethodDescriptor( beanClass.getMethod( 
               "getFieldWidth", null ) );           
         MethodDescriptor[] descriptors = { getMinimumValue, 
            getMaximumValue, getCurrentValue, getFieldWidth };
         
         return descriptors;
      }
      
      // printStackTrace if NoSuchMethodException thrown
      catch ( NoSuchMethodException methodException ) {
         methodException.printStackTrace();
      }
      
      // printStackTrace if SecurityException thrown
      catch ( SecurityException securityException ) {
         securityException.printStackTrace();
      }
      
      return null;
   }

   // return PropertyDescriptor array
   public PropertyDescriptor[] getPropertyDescriptors()
      throws RuntimeException
   {
      // create array of PropertyDescriptors
      try {
         
         // fieldWidth property
         PropertyDescriptor fieldWidth = new 
            PropertyDescriptor( "fieldWidth", beanClass );
         fieldWidth.setShortDescription( 
            "Width of the text field." );
         
         // currentValue property
         PropertyDescriptor currentValue = new 
            PropertyDescriptor( "currentValue", beanClass );
         currentValue.setShortDescription( 
            "Current value of slider." );
         
         // maximumValue property
         PropertyDescriptor maximumValue = new 
            PropertyDescriptor( "maximumValue", beanClass );
         maximumValue.setPropertyEditorClass( 
            MaximumValueEditor.class );
         maximumValue.setShortDescription( 
            "Maximum value of slider." );
         
         // minimumValue property
         PropertyDescriptor minimumValue = new 
            PropertyDescriptor( "minimumValue", beanClass );
         minimumValue.setShortDescription( 
            "Minimum value of slider." );
         minimumValue.setPropertyEditorClass( 
            MinimumValueEditor.class );

         // ensure PropertyChangeEvent occurs for this property
         currentValue.setBound( true );

         PropertyDescriptor descriptors[] = { fieldWidth,
            currentValue, maximumValue, minimumValue };

         return descriptors;
      }
      
      // throw RuntimeException if IntrospectionException
      // thrown
      catch ( IntrospectionException exception ) {
         throw new RuntimeException( exception.getMessage() );
      }
   }

   // get currentValue property index
   public int getDefaultPropertyIndex()
   {
      return 1;
   }

   // return EventSetDescriptors array
   public EventSetDescriptor[] getEventSetDescriptors() 
      throws RuntimeException
   {
      // create array of EventSetDescriptors
      try {
         EventSetDescriptor changed = new 
            EventSetDescriptor( beanClass, "propertyChange", 
               java.beans.PropertyChangeListener.class, 
                  "propertyChange");

         // set event description and name
         changed.setShortDescription(
            "Property change event for currentValue." );
         changed.setDisplayName( 
            "SliderFieldPanel value changed" );
 
         EventSetDescriptor[] descriptors = { changed };

         return descriptors;
      }
      
      // throw RuntimeException if IntrospectionException
      // thrown
      catch ( IntrospectionException exception ) {
         throw new RuntimeException( exception.getMessage() );
      }
   }
   
   // get PropertyChange event index
   public int getDefaultEventIndex()
   {
      return 0;
   }

}  // end class SliderFieldPanelBeanInfo

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
