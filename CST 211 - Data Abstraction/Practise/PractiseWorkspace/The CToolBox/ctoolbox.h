//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   April 7, 2002
// Last Change Date:  
// Project:        The CToolBox
// Filename:       ctoolbox.h
//
// Overview:  This include contains the interface for the
//			  Man on Moon program.
//     
//--------------------------------------------------------------------

#ifndef CTOOLBOX_H
#define CTOOLBOX_H

class CToolBox
{
public:
	CToolBox();		//constructor

	~CToolBox();	//deconstructor

private:
	string* items;
};

class CSaw
{
public:
	CSaw();

	~CSaw();

	CWood Cut_Wood(const CSaw& saw, const CWood& wood)
private:
	string csaw_type;
	int weight;
};

class CHammer
{
public:
	CHammer();

	~CHammer();

	CNail Strike_Nail(const CHammer& hammer, const CNail& nail);
private:
	string chammer_type;
	int weight;
};

class CNail
{
public:
	CNail();

	~CNail();

private:
	string cnail_type;
	int depth_driven;
};

class CWood
{
public:
	CWood();

	~CWood();

private:
	int length,
		width,
		depth;
};

#endif