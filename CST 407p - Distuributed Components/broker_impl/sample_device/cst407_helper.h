/***** Class :- cst407
*	Winter 2003.
*	Implementation of the cst407 Broker interface.
*	This interface allows for a peaceful negotiation
*	between clients and devices. 
*
*	This is a DCOM compliant interface.
*
*	See http://capital.ous.edu/~rksaripa/cst407dcom.
*	for more information.
*
*/

#ifndef	_cst407_helper_h
#define	_cst407_helper_h

#include	<iostream>

static
inline
ostream &
_display_guid(
			ostream	&out,
			const	GUID	&guid
			)
{
	int	*array = (int *)&guid;

	out << hex << 
		array[0] <<
		array[1] <<
		array[2] <<
		array[3] << 
		dec << endl;

	return	out;
}

#endif