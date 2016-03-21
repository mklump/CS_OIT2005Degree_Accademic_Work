// WeatherListModel.java
// WeatherListModel extends AbstractListModel to provide a 
// ListModel for storing a List of WeatherBeans.
package com.deitel.advjhtp1.rmi.weather;

// Java core packages
import java.util.*;

// Java extension packages
import javax.swing.AbstractListModel;

public class WeatherListModel extends AbstractListModel {
   
   // List of elements in ListModel
   private List list;
   
   // no-argument WeatherListModel constructor
   public WeatherListModel()
   {
      // create new List for WeatherBeans
      list = new ArrayList();
   }
   
   // WeatherListModel constructor
   public WeatherListModel( List itemList ) 
   {
      list = itemList;
   }
   
   // get size of List
   public int getSize() 
   {
      return list.size();
   }
   
   // get Object reference to element at given index
   public Object getElementAt( int index ) 
   {
      return list.get( index );
   }
   
   // add element to WeatherListModel
   public void add( Object element )
   {
      list.add( element );
      fireIntervalAdded( this, list.size(), list.size() );
   }
   
   // remove element from WeatherListModel
   public void remove( Object element )
   {
      int index = list.indexOf( element );
      
      if ( index != -1 ) {
         list.remove( element );
         fireIntervalRemoved( this, index, index );
      }
      
   } // end method remove
   
   // remove all elements from WeatherListModel
   public void clear()
   {
      // get original size of List
      int size = list.size();
      
      // clear all elements from List
      list.clear();
      
      // notify listeners that content changed
      fireContentsChanged( this, 0, size );
   }
}