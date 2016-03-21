//
//------------------------------------------------------------------------------
// Module: RedBlack Binary Search Tree
// Date:   January 6, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump with much needed help from Introduction
//		   To Algorithms Hardcover Text Book.
//		   Please note that for the purposes of the code for this module, I must
//		   give complete credit to Introduction to Algorithms, Second Edition
//		   by Thomas H. Cormen, et al (Hardcover) for providing the much needed
//		   Pseudo Code for which the code was built for this RedBlack Binary
//         Search Tree Data Structure.
//-------------------------------------------------------------------------------
//

using System;
using NUnit.Framework;
using System.IO;
using System.Diagnostics;

namespace ns_RedBlack
{
	/// <summary>
	/// This object encapsulates the characteristics and operations of
	/// a RedBlack Binary Search Tree node. First create a head node with
	/// one of the provided constructors, and then calling one of the insert
	/// methods to begin building your RedBlack Binary Search Tree.
	/// Please note that for the purposes of the code for this module, I must
	/// give complete credit to Introduction to Algorithms, Second Edition
	/// by Thomas H. Cormen, et al (Hardcover) for providing the much needed
	/// Pseudo Code for which code be built this RedBlack Binary Search Tree
	/// Data Structure.
	/// </summary>
	[Serializable]
	public class RedBlack
	{
		// Here are our five data fields:
		private string color;
		private object key;

		private RedBlack left;
		private RedBlack right;
		private RedBlack parent;

		/// <summary>
		/// RedBlack default constructor
		/// </summary>
		public RedBlack()
		{
			color = "black";
			key = null;

			left = null;
			right = null;
			parent = null;
		}
		/// <summary>
		/// Provides a mean to execute a deep copy from one RedBlack Tree
		/// to Another.
		/// </summary>
		/// <param name="treeSource">The source RedBlack Binary Search Tree
		/// to copy from.</param>
		/// <param name="treeDestination">The destination RedBlack Binary Search
		/// Tree to send the copy to.</param>
		/// <returns>The root node reference to the deep copied tree.</returns>
		public void DeepCopy( RedBlack treeSource, ref RedBlack treeDestination )
		{
			if( treeDestination == null )
				treeDestination = new RedBlack();
			else if( treeSource != Sentinel.Node )
			{
				DeepCopy( treeSource.left, ref treeDestination );
				treeDestination.RB_Insert( ref treeDestination, treeSource.Key );
				DeepCopy( treeSource.right, ref treeDestination );
			}
		}
		/// <summary>
		/// Property Parent (RedBlack) Read access and Write access
		/// </summary>
		public RedBlack Parent
		{
			get{ return parent;	}
			set{ parent = value; }
		}
		/// <summary>
		/// Property Right (RedBlack) Read access and Write access
		/// </summary>
		public RedBlack Right
		{
			get{ return right; }
			set{ right = value; }
		}
		/// <summary>
		/// Property Left (RedBlack) Read access and Write access
		/// </summary>
		public RedBlack Left
		{
			get{ return left; }
			set{ left = value; }
		}
		/// <summary>
		/// Property Color (string)	Read access and Write access
		/// </summary>
		public string Color
		{
			get{ return color; }
			set{ color = value; }
		}
		/// <summary>
		/// Property Key (object) Read and Write access
		/// </summary>
		public object Key
		{
			get{ return key; }
			set{ key = value; }
		}
		/// <summary>
		/// This two arguement operation accepts a System.object value and creates
		/// a new RedBlack node by first calling the default RedBlack() default 
		/// constructor then inserting the resultant new node.
		/// Please note that RB_Insert() operation will return any duplicates
		/// attempted as a RedBlack node back to the caller.
		/// </summary>
		/// <param name="T">The root/head of the RedBlack Tree to insert char [] value.</param>
		/// <param name="valueToInsert">The object value to insert.</param>
 		/// <returns>Returns the duplicate node compared to the node to be
		/// inserted, other wise inserts the node.</returns>
		public RedBlack RB_Insert( ref RedBlack T, object valueToInsert )
		{
			RedBlack x = new RedBlack();
			if( Sentinel.Node == null )
				Sentinel.Create();
			if( T.Key == null )
				T = Sentinel.Node;
			if( valueToInsert is string )
				x.key = (string)valueToInsert;
			else if( valueToInsert is char[] )
				x.key = (char[])valueToInsert;
			else
				x.key = valueToInsert;

			if( Iterative_Tree_Search( T, x.key ) != Sentinel.Node )
				return x;
			else
				return x.Insert( ref T, x );
		}
		/// <summary>
		/// The purpose of this method is to find the root node of any given
		/// RedBlack Binary Search Tree.
		/// </summary>
		/// <param name="T">An arbitrary RedBlack Tree to find the root.</param>
		/// <returns>This method returns the root of a given RedBlack Tree T.</returns>
		private RedBlack GetRoot( RedBlack T )
		{
			// The root node's parent will always refer back to Sentinel node.
			while( T.parent != Sentinel.Node )
			{
				if( T.parent == null )
					return T; // T == Sentinel.Node, return T
				if( T.key == null && T.parent.key != null
					&& T.left == null && T.Right == null )
					return T; // T == Sentinel.Node, return T
				else
					T = T.parent;
			}
			Assert.IsTrue( T.parent == Sentinel.Node );
			return T;
		}
		/// <summary>
		/// Less Than Operator for RedBlack object key comparisons.
		/// Please note that support is only provided for the System.String
		/// or the char [] type comparisons, otherwise you must derive from
		/// this class, and overload this method for a "yourType" comparison.
		/// The types of both objects being compared must exactly match.
		/// </summary>
		/// <param name="leftArguement">The RedBlack node whose reference will
		/// be used for the right comparison.</param>
		/// <param name="rightArguement">The RedBlack node whose reference will
		/// be used for the left comparison.</param>
		/// <example> bool result = objectA lessthan objectB </example>
		public virtual bool RB_LessThanOperator( object leftArguement, object rightArguement )
		{
			if( leftArguement is string && rightArguement is string )
				return string.Compare((string)leftArguement , (string)rightArguement) < 0;
			else if( leftArguement is char[] && rightArguement is char[] )
			{
//				char[] x = (char[])leftArguement, y = (char[])rightArguement;
//				for( int z = 0; z < y.Length; z++ ) 
//				{
//					if( z == x.Length || x[z] < y[z] )
//						return true;
//				}				// This implementation is taking 100 times longer than string.Compare()
//				return false;
				string x = new string((char[])leftArguement),
					   y = new string((char[])rightArguement);
				return string.Compare( x, y ) < 0;
			}
			Assert.IsTrue( leftArguement.GetType().IsInstanceOfType(rightArguement),
				"The key System.Type of the root node " + 
				"and all the keys' System.Type of the nodes " + 
				"underneath the root node must exactly match."
				);
			return false;
		}
		/// <summary>
		/// Equality Operator for RedBlack object key comparisons.
		/// Please note that support is only provided for the System.String
		/// or the char [] type comparisons, otherwise you must derive from
		/// this class, and overload this method for a "yourType" comparison.
		/// The types of both objects being compared must exactly match.
		/// </summary>
		/// <param name="leftArguement">The RedBlack node whose reference will
		/// be used for the right comparison.</param>
		/// <param name="rightArguement">The RedBlack node whose reference will
		/// be used for the left comparison.</param>
		/// <example> bool result = objectA == objectB; </example>
		public virtual bool RB_EqualityOperator( object leftArguement, object rightArguement )
		{
			if( leftArguement is string && rightArguement is string )
				return string.Compare((string)leftArguement , (string)rightArguement) == 0;
			else if( leftArguement is char[] && rightArguement is char[] )
			{
//				char[] x = (char[])leftArguement, y = (char[])rightArguement;
//				if( x.Length != y.Length )
//					return false; // Different lengths, not equal
//				for( int z = 0; z < y.Length; z++ )
//				{// This implementation is also taking ten times longer than overloader string Class ==
//					if( x[z] != y[z] )
//						return false; // Different values, not equal
//				}
//				return true; // character arrays are identical
				string x = new string((char[])leftArguement),
					   y = new string((char[])rightArguement);
				return x == y;
			}
			Assert.IsTrue( leftArguement.GetType().IsInstanceOfType(rightArguement),
				"The key System.Type of the root node " + 
				"and all the keys' System.Type of the nodes " + 
				"underneath the root node must exactly match."
				);
			return false;
		}
		/// <summary>
		/// The helper method will walk through a given tree, in order, and
		/// count the actual number of words in the tree.
		/// </summary>
		/// <param name="next">The root RedBlack node of the RedBlack Tree.</param>
		/// <param name="actualSize">The integer counter used to do the counting.</param>
		public void GetActualSize( RedBlack next, ref int actualSize )
		{
			if( next != Sentinel.Node )
			{
				GetActualSize( next.Left, ref actualSize );
				actualSize = actualSize + 1;
				GetActualSize( next.Right, ref actualSize );
			}
		}
		/// <summary>
		/// This method will correctly and in order access each key
		/// in the binary search red-black tree, and in sorted order.
		/// </summary>
		/// <param name="x">Node to start accessing keys in the subtree of this node. </param>
		public void Inorder_Tree_Walk( RedBlack x )
		{
			Assert.IsNotNull( x.color );
			if( x != Sentinel.Node )
			{
				Inorder_Tree_Walk( x.left );
				string Value = ( x.key is char[] ) ?
					new string( (char[]) x.key ) :
					(string) x.key;
				Trace.WriteLine( "key value=\"" + Value + "\" color = \"" + x.color + "\"");
				Inorder_Tree_Walk( x.right );
			}
		}
		/// <summary>
		/// This method will correctly find the RedBlack node with key k
		/// in the tree whose reference is x.
		/// </summary>
		/// The RedBlack node <param name="x"> is the root node to search through. </param>
		/// The key <param name="k"> to search for in the tree on or under node x. </param>
		/// <returns> The RedBlack node in the tree on or under node x with key k. 
		/// If not found, the Sentinel node is returned.</returns>
		public RedBlack Tree_Search( RedBlack x, object k )
		{
			Assert.IsTrue( x.color == "black" || x.color == "red" );
			if( x == Sentinel.Node || RB_EqualityOperator( k, x.key ) )
					return x;
			if( RB_LessThanOperator( k , x.key ) )
				return Tree_Search( x.left, k );
			else
				return Tree_Search( x.right, k );
		}
		/// <summary>
		/// This method will correctly find the RedBlack node with key k in the tree
		/// whose reference is x. This search will always be more efficient since this
		/// is not making recursive calls, except just moving memory references.
		/// </summary>
		/// The RedBlack node <param name="x"> is the root node to search through. </param>
		/// The key <param name="k"> to search for in the tree on or under node x. </param>
		/// <returns> The RedBlack node in the tree on or under node x with key k, but
		/// performs the search more efficiently by "unrolling" the recursion into a
		/// while loop. If not found, the Sentinel node is returned.
		/// If not found, the Sentinel node is returned.</returns>
		public RedBlack Iterative_Tree_Search( RedBlack x, object k )
		{
			while( x != Sentinel.Node && !RB_EqualityOperator( k, x.key ) )
			{
				if( RB_LessThanOperator( k , x.key ) )
					x = x.left;
				else
					x = x.right;
			}
			if( x != Sentinel.Node )
				// Did the search succeed?
				Assert.IsTrue( RB_EqualityOperator( x.key, k ) );
			return x;
		}
		/// <summary>
		/// This method finds the minimum node whose value is the smallest beneath
		/// a given root node x by following the left most node of that tree on and
		/// under the root node x.
		/// </summary>
		/// The RedBlack node <param name="x"> is the root node of the subtree.</param>
		/// <returns>The node whose key is the smallest value under node x.</returns>
		public RedBlack Tree_Minimum( RedBlack x )
		{
			while( x.left != Sentinel.Node )
				x = x.left;

			Assert.IsTrue( x.left == Sentinel.Node );
			return x;
		}
		/// <summary>
		/// This method returns the node with the maximum value on and under a given
		/// root RedBlack node x. The key with the maximum value is always found by
		/// following the right child references is that subtree. This exists as a
		/// characteristic property of a binary search tree.
		/// </summary>
		/// The RedBlack node <param name="x"> is the root node of the tree to find
		/// the maximum valued node. </param>
		/// <returns>The RedBlack node on or under x with the maximum key value.</returns>
		public RedBlack Tree_Maximum( RedBlack x )
		{
			while( x.right != Sentinel.Node )
				x = x.right;

			Assert.IsTrue( x.right == Sentinel.Node );
			return x;
		}
		/// <summary>
		/// This method finds the smallest key greater than the key of node x.
		/// </summary>
		/// <param name="x">Is any given RedBlack node of which ever root node.</param>
		/// <returns>This method returns the RedBlack node whose key is the smallest
		/// key greater than the key of node x.</returns>
		public RedBlack Tree_Successor( RedBlack x )
		{
			if( x.right != Sentinel.Node )
				return Tree_Minimum( x.right );
			RedBlack y = x.parent;
			while( y != Sentinel.Node && x == y.right )
			{
				x = y;
				y = y.parent;
			}
			Assert.IsTrue( y == Sentinel.Node && x != y.right );
			return y;
		}
		/// <summary>
		/// This method finds the largest key smaller than the key of node x.
		/// </summary>
		/// <param name="x">Is any given RedBlack node of which ever root node.</param>
		/// <returns>This method returns the RedBlack node whose key is the largest
		/// key smaller than the key of node x.</returns>
		public RedBlack Tree_Predecessor( RedBlack x )
		{
			if( x.left != Sentinel.Node )
				return Tree_Maximum( x.left );
			RedBlack y = x.parent;
			while( y != Sentinel.Node && x == y.left )
			{
				x = y;
				y = y.parent;
			}

			Assert.IsTrue( y != Sentinel.Node && x == y.left );
			return y;
		}
		/// <summary>
		/// After this method executes, the subnode x at or under the absolute
		/// root node T will rotate references with x's right child node.
		/// </summary>
		/// <param name="T">This is the absolute root node containing or is
		/// the RedBlack node x.</param>
		/// <param name="x">This is the RedBlack node that will be rotated
		/// left with x's right child node</param>
		private void Left_Rotate( ref RedBlack T, RedBlack x )
		{
			RedBlack y = x.right;
			if( y != null )
				x.right = y.left;

			if( y != null && y.Left != Sentinel.Node )
				y.left.parent = x;
			if( y != null && y != Sentinel.Node )
				y.parent = x.parent;

			if( x != null && x.parent != null && x.parent != Sentinel.Node )
			{
				if( x == x.parent.left )
					x.parent.left = y;
				else
					x.parent.right = y;
			}
			else
			{
				T = GetRoot( T );
				if( y != null )
					T = y;
			}
			if( y != null )
				y.left = x;
			if( x != null && x != Sentinel.Node )
				x.parent = y;
			// Assert.IsTrue( x.parent == y && y.left == x );
		}
		/// <summary>
		/// After this method executes, the subnode x at or under the absolute
		/// root node T will rotate references with x's left child node.
		/// </summary>
		/// <param name="T">This is the absolute root node containing or is
		/// the RedBlack node x.</param>
		/// <param name="x">This is the RedBlack node that will be rotated
		/// left with x's right child node</param>
		private void Right_Rotate( ref RedBlack T, RedBlack x )
		{
			RedBlack y = x.left;
			if( y != null )
				x.left = y.right;

			if( y != null && y.right != Sentinel.Node)
				y.right.parent = x;
			if( y != null && y != Sentinel.Node )
				y.parent = x.parent;

			if( x != null && x.parent != null && x.parent != Sentinel.Node )
			{
				if( x == x.parent.right )
					x.parent.right = y;
				else
					x.parent.left = y;
			}
			else
			{
				T = GetRoot( T );
				if( y != null )
					T = y;
			}
			if( y != null )
				y.right = x;
			if( x != null && x != Sentinel.Node )
				x.parent = y;
			// Assert.IsTrue( x.parent == y && y.right == x );
		}
		/// <summary>
		/// This method accepts a reference to the root or head of the RedBlack Tree T
		/// and a reference to the RedBlack node to insert z, whose key fill must filled
		/// in with sortable data. Lastly this method calls RB_Insert_Fixup( T, z ) to
		/// maintain properly the five properties of the RedBlack Tree.
		/// </summary>
		/// <param name="T">A reference to the root or head of the RedBlack Tree T.</param>
		/// <param name="z">A reference to the RedBlack node we'll insert z.</param>
		/// <returns>Returns the node just inserted.</returns>
		private RedBlack Insert( ref RedBlack T, RedBlack z )
		{
			RedBlack y = Sentinel.Node;
			RedBlack x = GetRoot( T );
			while( x != Sentinel.Node )
			{
				y = x;
				if( RB_LessThanOperator( z.key, x.key ) )
					x = x.left;
				else
					x = x.right;
			}
			z.parent = y;
			if( y == Sentinel.Node )
			{
				T = GetRoot( T );
				T = z;
			}
			else if( RB_LessThanOperator( z.key, y.key ) )
				y.left = z;
			else
				y.right = z;

			z.left = Sentinel.Node;
			z.right = Sentinel.Node;
			z.color = "red";
			RB_Insert_Fixup( ref T, z );
			Assert.IsTrue( T.left != null || T.right != null );
			return z;
		}
		/// <summary>
		/// This is primarily a helper method/operation meant to maintain the
		/// five properties of the RedBlack Binary Search Tree.
		/// </summary>
		/// <param name="T">Root or Head of the RedBlack tree we're working with.</param>
		/// <param name="z">RedBlack node being inserted.</param>
		private void RB_Insert_Fixup( ref RedBlack T, RedBlack z )
		{
			RedBlack y;
			while( z.parent.color == "red" )
			{
				if( z.parent == z.parent.parent.left )
				{
					y = z.parent.parent.right;
					if(y != null && y.color == "red" )
					{
						z.parent.color = "black";
						y.color = "black";
						z.parent.parent.color = "red";
						z = z.parent.parent;
					}
					else 
					{
						if( z == z.parent.right )
						{
							z = z.parent;
							Left_Rotate( ref T, z );
						}
						z.parent.color = "black";
						z.parent.parent.color = "red";
						Right_Rotate( ref T, z.parent.parent );
					}
				}
				else
				{
					y = z.parent.parent.left;
					if( y != null && y.color == "red" )
					{
						z.parent.color = "black";
						y.color = "black";
						z.parent.parent.color = "red";
						z = z.parent.parent;
					}
					else 
					{
						if( z == z.parent.left )
						{
							z = z.parent;
							Right_Rotate( ref T, z );
						}
						z.parent.color = "black";
						z.parent.parent.color = "red";
						Left_Rotate( ref T, z.parent.parent );
					}
				} // end else clause
			} // end while loop
			T = GetRoot( T );
			T.color = "black";
		} // end RB_Insert_Fixup()
		/// <summary>
		/// The method must be provided to properly delete a given RedBlack node
		/// from the RedBlack Tree that we're working with to properly maintain
		/// the five properties of the Red Black Binary Search Tree.
		/// </summary>
		/// <param name="T">Head or Root of the RedBlack Tree we're working with.</param>
		/// <param name="Value">The RedBlack node whose key is specified by this
		/// paramenter that we're going to delete.</param>
		/// <returns>The last RedBlack node worked with.</returns>
		public RedBlack RB_Delete( ref RedBlack T, object Value )
		{
			RedBlack x, y, z;
			if( (z = this.Iterative_Tree_Search( T, Value )) == Sentinel.Node )
				return z;
			else if( z.left == Sentinel.Node || z.right == Sentinel.Node )
				y = z;
			else
				y = Tree_Successor( z );

			if( y.left != Sentinel.Node )
				x = y.left;
			else
				x = y.right;

			x.parent = y.parent;
			if( y.parent != null && y.parent != Sentinel.Node )
			{
				if( y == y.parent.left )
					y.parent.left = x;
				else
					y.parent.right = x;
			}
			else
			{
				T = GetRoot( T );
				T = x;
			}

			if( y != z )
			{
				// Member-wise copy for all satellie data
				z.key = y.key;
			}
			if( y.color == "black" )
				RB_Delete_Fixup( ref T, x );

			Assert.IsTrue( y != null && y.key != null );
			return y;
		}
		/// <summary>
		/// This helper method/operation is meant to provide support for maintaining
		/// the neccessary five RedBlack Tree properties after having called RB_Delete()
		/// </summary>
		/// <param name="T">Head or Root of the RedBlack Tree we're working with.</param>
		/// <param name="x">RedBlack node we're going to "fixup".</param>
		private void RB_Delete_Fixup( ref RedBlack T, RedBlack x )
		{
			RedBlack w;
			while( x != ( T = GetRoot( T ) ) && x.color == "black" )
			{
				if( x.parent.left != null && x == x.parent.left )
				{
					w = x.parent.right;
					if( w != null && w.color == "red" )
					{
						w.color = "black";
						x.parent.color = "red";
						Left_Rotate( ref T, x.parent );
						w = x.parent.right;
					}
					if( w != null && w.right != null && w.left != null &&
						w.left.color == "black" && w.right.color == "black" )
					{
						w.color = "red";
						x = x.parent;
					}
					else 
					{
						if( w != null && w.right != null && w.right.color == "black" )
						{
							w.left.color = "black";
							w.color = "red";
							Right_Rotate( ref T, w );
							w = x.parent.right;
						}
						if( w != null && x != null && x.parent != null )
							w.color = x.parent.color;
						if( x != null && x.parent != null )
							x.parent.color = "black";
						if( w != null && w.right != null )
							w.right.color = "black";
						Left_Rotate( ref T, x.parent );
						x = GetRoot( T );
					}
				} // End if( x == x.parent.left ) {}
				else
				{
					w = x.parent.left;
					if( w != null && w.color == "red" )
					{
						w.color = "black";
						x.parent.color = "red";
						Right_Rotate( ref T, x.parent );
						w = x.parent.left;
					}
					if( w != null && w.right != null && w.left != null &&
						w.right.color == "black" && w.left.color == "black" )
					{
						w.color = "red";
						x = x.parent;
					}
					else
					{
						if( w != null && w.left != null && w.left.color == "black" )
						{
							w.right.color = "black";
							w.color = "red";
							Left_Rotate( ref T, w );
							w = x.parent.left;
						}
						if( w != null && x != null && x.parent != null )
							w.color = x.parent.color;
						if( x != null && x.parent != null )
							x.parent.color = "black";
						if( w != null && w.left != null )
							w.left.color = "black";
						Right_Rotate( ref T, x.parent );
						x = GetRoot( T );
					} // End if( w.right.color == "black" && w.left.color == "black" ) {}
				} // End else clause
			} // End while( x != GetRoot( T ) && x.color == "black" ) {}
			x.color = "black";
		} // End private void RB_Delete_Fixup( ref RedBlack T, RedBlack x ) {}

	} // End Class RedBlack

	/// <summary>
	/// The intent of this class is to provide a Sentinel node nil[T],
	/// for which is very much needed for the RedBlack Tree's inferstructional
	/// support. This the class is abstract, it cannot be instanciated, and
	/// with all the member's being static, they must be used through the
	/// class's name.
	/// </summary>
	public abstract class Sentinel
	{
		// Two Data Fields
		private static RedBlack node;

		/// <summary>
		/// Set up the Sentinel Node.
		/// </summary>
		public static void Create()
		{
			node = new RedBlack();
		}
		/// <summary>
		/// Property Node (RedBlack)
		/// Read access only.
		/// </summary>
		public static RedBlack Node
		{
			get{ return node; }
		}
	}

	/// <summary>
	/// Test Class for the RedBlack Binary Search Tree
	/// </summary>
	[TestFixture]
	public class RedBlack_TestClass
	{
		private RedBlack root;
		private string val;
		private string myString;
		private char [] chars;
		private int counter;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public RedBlack_TestClass()
		{
			SetUpTests();
		}
		/// <summary>
		/// SetUp
		/// </summary>
		[SetUp]
		public void SetUpTests()
		{
			root = new RedBlack();
			val = "";
			myString = "";
			counter = 0;
		}
		/// <summary>
		/// Test 1
		/// </summary>
		[Test]
		public void Test1()
		{	
			root.RB_Insert( ref root, new char[] { 'k' } );
		}
		/// <summary>
		/// Test 2
		/// </summary>
		[Test]
		public void Test2()
		{
			chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
			root.RB_Insert( ref root, chars );
		}
		/// <summary>
		/// Test 3
		/// </summary>
		[Test]
		public void Test3()
		{
			myString = "ghijkl and then some other unknown string charater values";
			root.RB_Insert( ref root, myString.ToCharArray() );
		}
		/// <summary>
		/// Test 4
		/// </summary>
		[Test]
		public void Test4()
		{
			myString = "A new put then slightly different test string value.";
			root.RB_Insert( ref root, myString.ToCharArray() );
		}
		/// <summary>
		/// Test 5
		/// </summary>
		[Test]
		public void Test5()
		{
			char [] myChars2 = { 'd','g','e','g','j','k','l','l','j','h','v','f','d','d','f','g','j','k','l','l','j','h','g','f','f','f','g','j','k','k' };
			root.RB_Insert( ref root, myChars2 );
		}
		/// <summary>
		/// Test 6
		/// </summary>
		[Test]
		public void Test6()
		{
			myString = "Yet another one final string value.";
			root.RB_Insert( ref root, myString.ToCharArray() );
		}
		/// <summary>
		/// Test 7
		/// </summary>
		[Test]
		public void Test7()
		{
			root.Inorder_Tree_Walk( root );
		}
		/// <summary>
		/// Test 8
		/// </summary>
		[Test]
		public void Test8()
		{
			val = "A new put then slightly different test string value.";
			chars = (char[])root.Tree_Search( root, val.ToCharArray() ).Key;
			foreach( char val_ in chars )
				Trace.Write( val_ );
			Trace.Write( '\n' );
		}
		/// <summary>
		/// Test 9
		/// </summary>
		[Test]
		public void Test9()
		{
			val = "Yet another one final string value.";
			chars = (char[])root.Iterative_Tree_Search(root, val.ToCharArray()).Key;
			foreach( char val_ in chars )
				Trace.Write( val_ );
			Trace.Write( '\n' );
		}
		/// <summary>
		/// Test 10
		/// </summary>
		[Test]
		public void Test10()
		{
			val = "Yet another one final string value.";
			root.RB_Delete( ref root, val.ToCharArray() );
			root.Inorder_Tree_Walk( root );
		}
		/// <summary>
		/// Test 11
		/// </summary>
		[Test]
		public void Test11()
		{
			val = "A new put then slightly different test string value.";
			root.RB_Delete( ref root, val.ToCharArray() );
			root.Inorder_Tree_Walk( root );
		}
		/// <summary>
		/// Test 12
		/// </summary>
		[Test]
		public void Test12()
		{
			root.RB_Insert( ref root, new char[] {'b'} ); 
			root.RB_Insert( ref root, new char[] {'c'} ); 
			root.RB_Insert( ref root, new char[] {'d'} ); 
			root.RB_Insert( ref root, new char[] {'e'} ); 
			root.RB_Insert( ref root, new char[] {'f'} ); 
			root.RB_Insert( ref root, new char[] {'g'} ); 
			root.RB_Insert( ref root, new char[] {'h'} ); 
			root.RB_Insert( ref root, new char[] {'i'} ); 
			root.RB_Insert( ref root, new char[] {'j'} ); 
			root.RB_Insert( ref root, new char[] {'k'} ); 
			root.RB_Insert( ref root, new char[] {'l'} ); 
			root.RB_Insert( ref root, new char[] {'m'} ); 
			root.RB_Insert( ref root, new char[] {'l'} ); 
			root.RB_Insert( ref root, new char[] {'o'} ); 
			root.RB_Insert( ref root, new char[] {'p'} ); 
			root.RB_Insert( ref root, new char[] {'q'} ); 
			root.RB_Insert( ref root, new char[] {'r'} ); 
			root.RB_Insert( ref root, new char[] {'s'} ); 
			root.RB_Insert( ref root, new char[] {'t'} ); 
			root.RB_Insert( ref root, new char[] {'u'} ); 
			root.RB_Insert( ref root, new char[] {'v'} ); 
			root.RB_Insert( ref root, new char[] {'w'} ); 
			root.RB_Insert( ref root, new char[] {'x'} ); 
			root.RB_Insert( ref root, new char[] {'y'} ); 
			root.RB_Insert( ref root, new char[] {'z'} ); 
			root.Inorder_Tree_Walk( root );
		}
		/// <summary>
		/// This test will perform 100000 nodal element RB_Insert() operations and then
		/// attempt to call RB_Delete() on all 100000 elements leaving only the Sentinel.Node
		/// left in the test root RedBlack Tree and the same thing done on a second RedBlack
		/// Binary Search Tree.
		/// </summary>
		public void Test13()
		{
			root = new RedBlack();
			RedBlack test2 = new RedBlack();
			for(int y = 0; y < 2; y++ )
			{
				for( int x = 0; x < 100000; x++ )
				{
					char [] next = Convert.ToString( x ).ToCharArray();
					if( y == 0 )
						root.RB_Insert( ref root, next );
					else
						test2.RB_Insert( ref test2, next );
				}
				for( int x = 99999; x > -1; x-- )
				{
					char [] next = Convert.ToString( x ).ToCharArray();
					counter = counter + 1;
					if( y == 0 )
						root.RB_Delete( ref root, next );
					else
						test2.RB_Delete( ref test2, next );
				}
				Assert.IsTrue( root == Sentinel.Node || test2 == Sentinel.Node );
			}
			root.Inorder_Tree_Walk( root );
			test2.Inorder_Tree_Walk( test2 );
		}
		/// <summary>
		/// Main program entry point
		/// </summary>
		/// <param name="args">string arguements</param>
		public static void Main( string [] args )
		{
			StreamWriter stream = new StreamWriter("./output.txt", false);
			TextWriterTraceListener writer = new TextWriterTraceListener( stream ); 
			Trace.Listeners.Add( writer );
			RedBlack_TestClass test = new RedBlack_TestClass();
			test.Test1();
			test.Test2();
			test.Test3();
			test.Test4();
			test.Test5();
			test.Test6();
			test.Test7();
			test.Test8();
			test.Test9();
			test.Test10();
			test.Test11();
			test.Test12();
			test.Test13();
		}
	} // End Test Class
} // End ns_RedBlack
