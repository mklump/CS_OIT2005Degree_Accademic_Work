//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       ShapeMaterial.h
//
// Overview:  This include contains the interface for the
//			  ShapeMaterial class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_SHAPEMATERIAL_H__A83B2F38_9367_49D7_9EB7_408969BBD537__INCLUDED_)
#define AFX_SHAPEMATERIAL_H__A83B2F38_9367_49D7_9EB7_408969BBD537__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "ooga.h"

class ShapeMaterial : public Ooga  
{
public:
	ShapeMaterial(); //Constructor definition set all the class bools to false/0.
	virtual ~ShapeMaterial();

	virtual bool Draw() const;
	//Overloaded Draw function for a ShapeMaterial object

	virtual bool Icon() const;
	//Overloaded Icon selector function for a ShapeMaterial object

	virtual bool Paint() const;
	//Overloaded Paint function for a ShapeMaterial object

	virtual bool Shapemgr() const;
	//Overloaded Shapemgr function for a ShapeMaterial object that
	//will define how a ShaperMaterial object will react to other
	//ShapeMaterial objects nearby, and with the overall created
	//environment.

	virtual bool ObjectPresence() const;
	//Sets the cell occupancy boolean variable in the GridMgr class

	void setShapeMaterial(const char *materialTYPE);
	//Set the bool that corresponds to the object asked for by the user & check 
	//to make sure it is of a supported type, if not print an error.

	bool getShapeMaterial(const char *materialTYPE);
	//Using switch logic on the char *materialTYPE, select and return the
	//appropriate ShaperMaterial object bool.

	const void Grow() const;
	//Makes use of a fractal algorithm to implement the appearance of
	//growth in an object. This will only be used for specific objects
	//that have a real world ability to grow such as a tree (determined
	//by a bool growable).

	const void Die() const;
	//Use the same or similar algorithm in the Grow() subroutine in a
	//reverse fashion to create the effect of something a living object
	//dying.
private:
	bool growable;
	bool abletodie; //If growable is set, this will always be set.

	bool oaktree,		 //The different material types listed here
		 douglasfirtree,
		 violets,
		 daisy,
		 redrose,
		 whiterose,
		 poisonoak,
		 monkeytailtree,
		 weepingwillow,
		 fern,
		 snakegrass,
		 rhododendron;
};

#endif // !defined(AFX_SHAPEMATERIAL_H__A83B2F38_9367_49D7_9EB7_408969BBD537__INCLUDED_)
