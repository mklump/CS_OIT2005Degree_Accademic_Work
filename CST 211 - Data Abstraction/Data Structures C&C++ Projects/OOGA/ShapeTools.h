//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       ShapeTools.h
//
// Overview:  This include contains the interface for the
//			  ShapeTools class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_SHAPETOOLS_H__4F5A1AA5_B797_4CF1_BDFC_B26D915198D3__INCLUDED_)
#define AFX_SHAPETOOLS_H__4F5A1AA5_B797_4CF1_BDFC_B26D915198D3__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "ooga.h"

class ShapeTools : public Ooga  
{
public:
	ShapeTools();
	virtual ~ShapeTools();

	virtual bool Draw() const;
	//Overloaded Draw function for a ShapeTools object

	virtual bool Icon() const;
	//Overloaded Icon selector function for a ShapeTools object

	virtual bool Paint() const;
	//Overloaded Paint function for a ShapeTools object

	virtual bool Shapemgr() const;
	//Overloaded Shapemgr function for a ShapeTools object that
	//will define how a ShapeTools object (a tool) will react to/on other
	//ShapeMaterial objects(a plant), and with the overall created
	//environment.

	virtual bool ObjectPresence() const;
	//Sets the cell occupancy boolean variable in the GridMgr class

	bool setShapeTool(const char *toolTYPE);
	//Set the bool that corresponds to the object asked for by the user & check 
	//to make sure it is of a supported type, if not print an error.

	bool getShapeTool(const char *toolTYPE);
	//Using switch logic on the char *toolTYPE, select and return the
	//appropriate ShapeTools object bool.
private:
	bool wateringcan,		//Here is the list of supported
		 seedplantertool,	//tools within this version of OOGA:
		 sunplacementtool,
		 weatherconditiontool,
		 shovel,
		 hamer,
		 weedkillerspraycan,
		 supergrowthtool;
};

#endif // !defined(AFX_SHAPETOOLS_H__4F5A1AA5_B797_4CF1_BDFC_B26D915198D3__INCLUDED_)
