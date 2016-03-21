//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       GridMgr.h
//
// Overview:  This include contains the interface for the
//			  GridMgr class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_GRIDMGR_H__5505ED5A_20A5_47FD_B8B8_43B610D65111__INCLUDED_)
#define AFX_GRIDMGR_H__5505ED5A_20A5_47FD_B8B8_43B610D65111__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class GridMgr  
{
public:
	GridMgr();
	//This constructor should use some implementation to construct an appropriate
	//graphical-user interface.
	virtual ~GridMgr();

	const void Foreground() const;
	//Create and maintain the foreground display

	const void Background() const;
	//Create and maintain the background display

	const void RandomizeTerrain() const;
	//Randomize the currently displayed terrain

	const void HandleEvent() const;
	//This should implement some means to supply a reaction whenever a pre-defined
	//user action takes place within the CUI. I.E. a mouse click on a particular
	//thing including menu actions, a gardening tool is used on the graphical ground
	//display/seeds planted in the ground etc. Please keep in mind that all the 
	//different muteable material shapes within the shapeMaterials class interface
	//will all have their own predefined events.

	void setcellLOCATION(long &x, long &y, long &z);
	//This function call will set the location of where the cell will be placed within
	//our layout. Please note that the (x, y, z) coordinates is a point of the
	//cubic cell that is at the closest in, upper left-hand corner of the cube.

	inline long getxCoordinate() {return xCoordinate;};
	inline long getyCoordinate() {return yCoordinate;};
	inline long getzCoordinate() {return zCoordinate;}; //if applicable
private:
	long xCoordinate,
		 yCoordinate,
		 zCoordinate; //if applicable
};

#endif // !defined(AFX_GRIDMGR_H__5505ED5A_20A5_47FD_B8B8_43B610D65111__INCLUDED_)
