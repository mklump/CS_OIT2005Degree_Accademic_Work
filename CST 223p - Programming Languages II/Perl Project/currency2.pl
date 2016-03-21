#!/usr/bin/perl
#currency2.plx
#By: Matthew Klump
#For CST 223 - Programming languages 2
#Perl Assignment #2
use warnings;

my $rate = 1;
my $yen1 = 1;
my $yen2 = 1;
my $yen3 = 1;

print "Currency converter\n";
do
{
	print "\nPlease enter the exchange rate: ";
	$rate = <STDIN>;
	print "\nPlease enter the first amount: ";
	$yen1 = <STDIN>;
	print "\nPlease enter the second amount: ";
	$yen2 = <STDIN>;
	print "\nPlease enter the third amount: ";
	$yen3 = <STDIN>;
	if(  $rate < 0 or $yen1 < 0
		or $yen2 < 0 or $yen3 < 0 )
	{
		print "\nYou have entered an invalid exchange rate or currency amount.";
		print "\nPlease try again."
	}
}while( $rate < 0 or $yen1 < 0
		or $yen2 < 0 or $yen3 < 0 );

print $yen1 " Yen is ", (49_518/$rate), " pounds\n";
print $yen2 " Yen is ", (   360/$rate), " pounds\n";
print $yen3 " Yen is ", (30_510/$rate), " pounds\n";

