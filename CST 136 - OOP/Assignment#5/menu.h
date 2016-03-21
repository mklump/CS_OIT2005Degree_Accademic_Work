//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       menu.h
//
// Overview:  This include contains the interface for the
//			  menu class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_MENU_H__03A3274E_C15A_4F8F_B579_BAAE02ABD6FB__INCLUDED_)
#define AFX_MENU_H__03A3274E_C15A_4F8F_B579_BAAE02ABD6FB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "GridMgr.h"

class menu : public GridMgr  
{
public:
	menu();
	virtual ~menu();

	const void MenuBar() const;
	//Display a menubar for which the user will use to communicate easier with
	//the OOGA application.

	const void Open() const;
	//Open a user file.

	const void Save() const;
	//Write to a user file.

	const void About() const;
	//Present to the user a message diplaying the version and contact info for
	//bug reporting (This will more than likely be simply freeware).

	const void EditPreferences() const;
	//Edit the OOGA game preferences

	const void ToolBar_ShapeMaterial() const;
	//Displays a toolbar for the different plants and flowers you can grow

	const void ToorBar_ShapeTools() const;
	//Display a toolbar for the different gardening tools you can use on your
	//garden.

};

#endif // !defined(AFX_MENU_H__03A3274E_C15A_4F8F_B579_BAAE02ABD6FB__INCLUDED_)
