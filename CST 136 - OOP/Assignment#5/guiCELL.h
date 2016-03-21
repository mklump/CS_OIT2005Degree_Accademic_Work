//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       guiCELL.h
//
// Overview:  This include contains the interface for the
//			  guiCELL class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_GUICELL_H__AB511961_C8AB_4140_B9EA_5476E3551DC5__INCLUDED_)
#define AFX_GUICELL_H__AB511961_C8AB_4140_B9EA_5476E3551DC5__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "GridMgr.h"

class guiCELL : public GridMgr  
{
public:
	guiCELL() : dimentionLENGTH(0), dimentionWIDTH(0),
		dimentionDEPTH(0), occupancyFLAG(0) {};
	virtual ~guiCELL();

	bool CheckOccupancy(const bool &);
	//Used with ObjectPrecense function of the last item that used this cell
	//(check the occupancyFLAG), and if true print a message that this current
	//location is already occupied, and to choose another.

	const void AcceptOrRejectOBJECT() const;
	//Calls CheckOccupancy(), if returns true accept the object into cell
	//if it returns false, reject the object placement in current cell, and
	//print an error message to screen.

	inline void setoccupancyFLAG(bool &value) {occupancyFLAG = value;};
	inline bool getoccupancyFLAG() {return occupancyFLAG;};

	void setCELLSIZE(long &length, long &width, long &height);
	//Set the current cell's dimentions
	//(dimentionLENGTH, dimentionWIDTH, and dimentionDEPTH)

	inline long getdimentionLENGTH() {return dimentionLENGTH;};
	inline long getdimentionWIDTH() {return dimentionWIDTH;};
	inline long getdimentionDEPTH() {return dimentionDEPTH;}; //if applicable
private:
	long dimentionLENGTH,
		 dimentionWIDTH,
		 dimentionDEPTH; //if applicable
	bool occupancyFLAG;
};

#endif // !defined(AFX_GUICELL_H__AB511961_C8AB_4140_B9EA_5476E3551DC5__INCLUDED_)
