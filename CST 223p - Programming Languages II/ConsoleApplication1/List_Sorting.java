/*--------------------------------------------------------------------
 // Author:        Matthew Klump  mklump1@comcast.net
 //				   CST 223 Programming Languages II
 //				   Java Assignment
 // Date Created:  4 May 2003
 // Submission Date:  6 May 2003
 // Project:        List_Sort
 // Filename:       List_Sorting.java
 //
 // Overview:	Performs a bubble sort and an insertion sort on a
 //				linked list implemented as an array.
 //
 // Input:      Input is accepted from a file input.txt containing
 //				various state names.
 //
 // Output:		Output is printed to the screen
 //
 //------------------------------------------------------------------*/

package List_Sort;

import java.util.*;
import java.io.*;

/**
 * This is the core (and only) class of the List_Sort Package.
 * Contains the core implementation for the Bubble and Insertion Sort.
 */
public class List_Sort 
{
    
	public String inputfile, line;
	public String[] state;
	public BufferedReader iFile;
	static int List_Size = 0;
    
	public List_Sort() 
	{
		inputfile = new String("C:\\D Drive of Sony\\Accademic_Work\\" +
			"CST 223p - Programming Languages II\\Java Sorting " +
			"Assignment 4\\input.txt"); // Input file path specific for my machine. You will
										// have to change the path for your location
		line = new String();
		state = new String[256];
		for(int i = 0; i < 256; ++i)
			state[i] = new String("");
		try {
			iFile = new BufferedReader(new FileReader(inputfile)); 
		}
		catch( IOException except ) 
		{
			String error = new String("Failed on file " + except + " opening.");
			System.out.println(error);
		}
	}
    
	public void Set_Inputfile( String Inputfile )
	{
		try {
			iFile = new BufferedReader(new FileReader(inputfile));
		}
		catch( IOException except ) 
		{
			String error = new String("Failed on file " + except + " opening.");
			System.out.println(error);
		}
	}
    
	public void Read_File()
	{
		int i = 0;
		try	{
			while( (line = iFile.readLine()) != null ) // Read line, check for end-of-file
			{
				state[i] = line;	// Add to the linked list
				i++;
			}
			List_Size = i;
			iFile.close();
		}
		catch( IOException except )	{
			String error = new String("Failed on reading from input " + 
					"stream iFile with error: " + except);
			System.out.println( error );
		}
	}

	public void Bubble_Sort()
	{
		String temp;
		for (int i = 0; i < List_Size; ++i ) // pass i
		{
			for (int j = 1; j < List_Size - i; j++) // sort sub-array A[0...(N-i)]
			{
				if ( state[j-1].CompareTo(state[j]) > 0 )// sort to increasing order
				{
					temp = state[j-1];
					state[j-1] = state[j];
					state[j] = temp;
				}
			}
		}
	}
	public void Insertion_Sort()
	{
		String temp;
		try	{
			int k = 0;
			while( (line = iFile.readLine()) != null )
			{
				state[k] = line;
				for (int i = 0; i < k; ++i )
				{
					for (int j = 1; j < k - i; ++j)
					{
						if ( state[j-1].CompareTo(state[j]) > 0 )
						{
							temp = state[j-1];
							state[j-1] = state[j];
							state[j] = temp;
						}
					}
				}
				k++;
			}
			for (int i = 0; i < k; ++i )
			{
				for (int j = 1; j < k - i; ++j)
				{
					if ( state[j-1].CompareTo(state[j]) > 0 )
					{
						temp = state[j-1];
						state[j-1] = state[j];
						state[j] = temp;
					}
				}
			}
			iFile.close();
		}
		catch( IOException except )	{
			String error = new String("Failed on reading from input " + 
				"stream iFile with error: " + except);
			System.out.println( error );
		}
	}

	/** @attribute System.STAThread() */
	public static void main(String[] args)
	{
		List_Sort sortObject = new List_Sort();
		sortObject.Read_File();

		int i = 0;
		String msg = new String("List before bubble sort :");
		System.out.println( msg );
		while( !sortObject.state[i].Equals("") )
		{
			System.out.println( sortObject.state[i] );
			i++;
		}

		msg = new String("\nCalling Bubble_Sort().\n");
		System.out.println( msg );
		sortObject.Bubble_Sort();
		
		msg = new String("List after bubble sort :");
		System.out.println( msg );
		i = 0;
		while( !sortObject.state[i].Equals("") )
		{
			System.out.println( sortObject.state[i] );
			i++;
		}
		List_Sort sortObject2 = new List_Sort();

		i = 0;
		msg = new String("\nList before insertion sort :");
		System.out.println( msg );
		while( !sortObject2.state[i].Equals("") )
		{
			System.out.println( sortObject2.state[i] );
			i++;
		}
		msg = new String("(empty)");
		System.out.println( msg );

		msg = new String("\nCalling Insertion_Sort().\n");
		System.out.println( msg );
		sortObject2.Insertion_Sort();

		msg = new String("List after insertion sort :");
		System.out.println( msg );
		while( !sortObject2.state[i].Equals("") )
		{
			System.out.println( sortObject2.state[i] );
			i++;
		}
	}
};