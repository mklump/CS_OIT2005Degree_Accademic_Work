//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #4 Part 1
// Date Created:   May 17, 2002
// Last Change Date:  May 17, 2002
// Project:        SocratesExams
// Filename:       CExam.h
//
// Overview:  This include contains the interface for the
//			  CExam class.
//     
//-------------------------------------------------------------------



#if !defined(AFX_EXAM_H__FC7E5E43_02E7_43EF_A5C1_B6D87083682F__INCLUDED_)
#define AFX_EXAM_H__FC7E5E43_02E7_43EF_A5C1_B6D87083682F__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <fstream>
#include <iostream>
#include <string>
using namespace std;

class CExam
{
public:
	CExam();
	virtual ~CExam();

	void input();
	friend istream& operator >> (istream &, CExam &);

	void operator = (string tmpBuf[5][7]);

protected:
	string examCPlusPlus[3][5],
		   examDrivesLicense[4][6],
		   examMovieQuiz[5][7],
		   examTrueFalse[2][4],
		   tmpBuf[5][7];

	int selector, MAX_ROW, MAX_COL;
	string fileName;
};

#endif // !defined(AFX_EXAM_H__FC7E5E43_02E7_43EF_A5C1_B6D87083682F__INCLUDED_)