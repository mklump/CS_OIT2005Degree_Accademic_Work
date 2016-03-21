//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       ooga.h
//
// Overview:  This include contains the interface for the
//			  Ooga class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_Ooga_H__F7005D6E_3885_4155_A232_B518FC022652__INCLUDED_)
#define AFX_Ooga_H__F7005D6E_3885_4155_A232_B518FC022652__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
#include <iostream>

#include "GridMgr.h"
#include "guiCELL.h"
#include "menu.h"

class Ooga
{
public:
	Ooga();
	virtual ~Ooga();
	inline const GridMgr* getGridMgr() const {return gridmgr;};
	//Make available to the derived classes the grid manager

	inline const guiCELL* getguiCELL() const {return guicell;};
	//Make available to the derived classes the GUI cell manager

	inline const menu* getMENU() const {return MENU;};

	virtual bool Draw() const = 0;
	//This virtual pure funtion will be overloaded in the derived classes
	//so that each of the two main shape entity types know how to draw itself,
	//this function must communicate with the object presence function.

	virtual bool Icon() const = 0;
	//This virtual pure funtion will be overloaded in the derived classes
	//so that each of the two main shape entity types know how to select
	//their own shape subcategories

	virtual bool Paint() const = 0;
	//This virtual pure funtion will be overloaded in the derived classes
	//so that each of the two main shape entity types know how to correctly
	//apply their own colors, shading/lighting, 2d/3d-effects.

	virtual bool Shapemgr() const = 0;
	//This virtual pure funtion will be overloaded in the derived classes
	//so that each of the two main shape entity types know their own textures,
	//dimentions, this function will also contain a switch structure that will
	//manage how a given object reacts in specifically defined events.

	virtual bool ObjectPresence() const = 0;
	//This virtual pure funtion will be overloaded in the derived classes
	//so that each of the two main shape entity types know can communicate
	//with other objects on the in the grid (by way of setting or resetting
	//a boolean flag) whether or not itself is occupying a particular location
	//within how we finally decide to implement the graphical layout/viewing
	//area for the garden.
private:
	GridMgr *gridmgr; //pointer to the grid manager
	guiCELL *guicell; //pointer to the guiCELL manager
	menu *MENU;		  //pointer to the menu manager
};

#endif //!defined(AFX_Ooga_H__F7005D6E_3885_4155_A232_B518FC022652__INCLUDED_)
