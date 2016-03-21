//--------------------------------------------------------------------
//
//  Laboratory 8, In-lab Exercise 1                        puzzle.cpp
//
//  (Shell) Anagram puzzle
//
//--------------------------------------------------------------------

// Simulates a puzzle in which a player attempts to unscramble a
// set of letters to form a word.

#include "stdafx.h"
#include <iostream>
#include "listdbl.h"

using namespace std;

//--------------------------------------------------------------------
//
//  Class declaration for the Anagram Puzzle ADT
//
//--------------------------------------------------------------------

class AnagramPuzzle
{
  public:

    AnagramPuzzle( char answ[], char init[] );   // Construct puzzle
    void shiftLeft();                            // Shift letters left
    void swapEnds();                             // Swap end letters
    void display();                              // Display puzzle
    int solved();                                // Puzzle solved

  private:

    // Data members
    List<char> solution,   // Solution to puzzle
               puzzle;     // Current puzzle configuration
};

//--------------------------------------------------------------------

// The main() function provides the user interface to the puzzle.

void main ()
{
    AnagramPuzzle mysteryWord("yes","yse");   // Puzzle
    char move,                                // User input move
         userQuit;                            // User quits puzzle

    // Display the initial puzzle.

    mysteryWord.display();

    // Loop until puzzle solved or user quits

    userQuit = 0;
    while ( !mysteryWord.solved() && !userQuit )
    {
        cout << "Enter move ( L/S/Q ): ";   // Get user move
        cin >> move;
        switch ( move )                     // Process move
        {
          case 'L' : case 'l' :  mysteryWord.shiftLeft();  break;
          case 'S' : case 's' :  mysteryWord.swapEnds();   break;
          case 'Q' : case 'q' :  userQuit = 1;             break;
          default:  cout << "Invalid move" << endl;
        }
        mysteryWord.display();              // Display puzzle
    }
    if ( mysteryWord.solved() )
       cout << "Congratulations!" << endl;
}

//--------------------------------------------------------------------
//
//  Implementation of the Anagram Puzzle ADT
//
//--------------------------------------------------------------------

AnagramPuzzle:: AnagramPuzzle ( char answ[], char init[] )

// Constructs an anagram puzzle. String answ is the solution to the
// puzzle and string init is the initial scrambled letter sequence.

{

}

//--------------------------------------------------------------------

void AnagramPuzzle:: shiftLeft ()

// Shifts the letters left one position, the leftmost letter is moved
// to the right end of the puzzle.

{

}

//--------------------------------------------------------------------

void AnagramPuzzle:: swapEnds ()

// Swaps the letters at the left and right ends of the puzzle.

{

}

//--------------------------------------------------------------------

void AnagramPuzzle:: display ()

// Displays an anagram puzzle.

{

}

//--------------------------------------------------------------------

int AnagramPuzzle:: solved ()

// Returns 1 if a puzzle is solved. Otherwise returns 0.

{

}