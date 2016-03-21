/*
 * Class.java
 *
 * Created on May 2, 2003, 2:41 PM
 */

/**
 *
 * @author  Matthew Klump
 */
package List_Sort;

import java.util.*;
import java.io.*;

public class List_Sort {
    
    public String inputfile;
    public LinkedList List;
    public FileReader iFile;
    
    public List_Sort() {
        inputfile = new String("C:\\D Drive of Sony\\Accademic_Work\\" +
        "CST 223p - Programming Languages II\\Java Sorting " +
        "Assignment 4\\input.txt");
        List = new LinkedList();
        try { iFile = new FileReader(inputfile);  }
        catch( FileNotFoundException except ) {
            String error = new String("Failed on file " + except + " opening.");
            System.out.println(error);
        }
    }
    
    public void Set_Inputfile( String Inputfile )
    {
        try { iFile = new FileReader(Inputfile);  }
        catch( FileNotFoundException except ) {
            String error = new String("Failed on file " + except + " opening.");
            System.out.println(error);
        }
    }
    
    public void Read_File()
    {
        while( List.add(iFile) )
        {
            System.out.println(iFile);
        }
    }
    public void Bubble_Sort()
    {
    }
    public void Insertion_Sort()
    {
    }
    
    public static void main(String[] args)
    {
        List_Sort object1 = new List_Sort();
        object1.Read_File();
        System.out.println();
    }
};
