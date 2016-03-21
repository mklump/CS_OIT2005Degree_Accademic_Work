(*
//--------------------------------------------------------------------
// Author:        Matthew Klump  mklump1@qwest.net
//				  CST 223 Languages II	
// Date Created:  14 April 2003
// Submission Date:  19 April 2003
// Project:        prime numbers
// Filename:       _prime_numbers.pas
//
// Overview:   Calculates and displays the first five hundred prime
//             numbers. This program was compiled and tested on:
//             Bloodshed Dev-Pascal v1.9.2, GNU Pascal Compiler v2.1
//             and GNU Debugger v4.18(GDB).
//   
// Input:      None required on the part of the user.
//   
// Output:    Displays the first five hundred prime numbers in four
//            formated columns of 125 prime numbers
//   
//--------------------------------------------------------------------
*)
program PrimeNumbers;

VAR prime :ARRAY[1..500] OF INTEGER;
VAR indexx, indexy, prime_count :INTEGER;
VAR bPrime :BOOLEAN;

PROCEDURE calculate_prime_numbers;
BEGIN
indexx := 3;
indexy := 0;
prime_count := 2;
prime[1] := 2;
     WHILE prime_count <= 500 DO
     BEGIN
     bPrime := false;
          FOR indexy := (indexx - 1) DOWNTO 2 DO
          BEGIN
              IF (indexx mod indexy) = 0 THEN
                 BEGIN
                      bPrime := true;
                 END
          END;
          if( not(bPrime) ) THEN
              BEGIN
                   prime[prime_count] := indexx;
                   prime_count := prime_count + 1;
              END;
          indexx := indexx + 1;
     END;
END;

PROCEDURE display_prime_numbers;
BEGIN
     FOR prime_count := 1 TO 125 DO
     BEGIN
          WRITELN('prime #',prime_count,' ',prime[prime_count],'        ',
          'prime #',prime_count+125,' ',prime[prime_count+125],'        ',
          'prime #',prime_count+250,' ',prime[prime_count+250],'        ',
          'prime #',prime_count+375,' ',prime[prime_count+375] );
     END;
END;

BEGIN (* main program *)
      calculate_prime_numbers;
      display_prime_numbers;
END. (* of main program *)

