// Name: Dom Virgilio
// Class: CST 136
// Assignment #2

A new music swapping system, Muzix, will use an 
object-oriented database (MOOD) to manage (a) free, 
30 second (teaser) cuts and (b) secure, for-pay, complete songs.  

Use independent headers for the song information base class 
(CSongInfo) and the derived classes CPromoSongInfo and CSecureSongInfo.  

Use private data and public set/get member functions.  
Choose appropriate defaults in your Constructors.

The base class should include:
song title
album title
name of artist
file size
whether the song is streamable, downloadable, or both
date of entry to the MOOD system

CPromoSongInfo should include:
price of the full song
the Muzix Store web link (to buy the song)
the number of days remaining in the promotion

CSecureSongInfo should include:
song duration
encryption type (enum: SECURE_1, SECURE_2, or SECURE_3)
a unique product identifier.

PART I:

Create a CMoodMgr class that allows a user to:

1.Input MOOD data from the command line.
2.Edit MOOD data from the command line.
3.Read MOOD data from a MOOD data file.
4.Write MOOD data to a MOOD data file.
5.Sort data by Artist, Song Title, or Song Duration.

PART II:

Implement A or B:

A: Create a CInternetRadio class with a member function that 
walks your in-memory MOOD and "streams" all streamable Secure and 
Promo songs.  Add a Stream member function to your song class 
hierarchy that outputs the song title, album title, and name of 
artist to the console.  (Note: An ideal implementation would place 
Promos "intelligently" throughout the play list, much like 
commercials are used in Radio.)

OR

B: Create a CSecureDownloadMgr class with a member function that 
walks your in-memory MOOD and outputs the list of all SECURE_2 
and SECURE_3 songs that are available for download.  The output 
should go to the console and should be ordered by file size from 
smallest to largest.  Include song title, security_type, and 
file size in your output.
