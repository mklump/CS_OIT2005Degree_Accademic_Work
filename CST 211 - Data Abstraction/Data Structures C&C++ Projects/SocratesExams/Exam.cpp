//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   May 17, 2002
// Last Change Date:  May 17, 2002
// Project:        SocratesExams
// Filename:       Exam.cpp
//
// Overview:  This include contains the implentation of the
//			  CExam class.
//     
//--------------------------------------------------------------------

#include "Exam.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CExam::CExam()
{
	selector = 0;
}

CExam::~CExam()
{
}

void CExam::input()
{
	ifstream iFile(fileName.c_str());
	switch (selector)
	{
	case 1:
		MAX_ROW = 3;
		MAX_COL = 5;
		break;
	case 2:
		MAX_ROW = 4;
		MAX_COL = 6;
		break;
	case 3:
		MAX_ROW = 5;
		MAX_COL = 7;
		break;
	case 4:
		MAX_ROW = 2;
		MAX_COL = 4;
		break;
	default:
		break;
	}
	for (int x=0; x < MAX_ROW; x++)
	{
		for (int y=0; y < MAX_COL; y++)
		{
			iFile >> tmpBuf[x][y];
		}
	}
	operator=(tmpBuf);
	iFile.close();
}

istream& operator >> (istream &lhs, CExam &rhs)
{
	rhs.input();
	return lhs;
}

void CExam::operator = (string tmpBuf[5][7])
{
	int x = 0, y = 0, z = 0;
	switch (selector)
	{
	case 0:
		break;
	case 1:
		for (x = 0; x < MAX_ROW; x++)
		{
			for (y = 0; y < MAX_COL; y++)
			{
				examCPlusPlus[x][y] = tmpBuf[x][y]; //set the examdata

				for (z = 0; z < examCPlusPlus[x][y].length(); z++)
				{
					if (examCPlusPlus[x][y].at(z) == '_')
						examCPlusPlus[x][y].at(z) = ' ';
				}
				tmpBuf[x][y] = examCPlusPlus[x][y]; //copy back the data into temporary
			}
		}
		break;
	case 2:
		for (x = 0; x < MAX_ROW; x++)
		{
			for (y = 0; y < MAX_COL; y++)
			{
				examDrivesLicense[x][y] = tmpBuf[x][y];

				for (z = 0; z < examDrivesLicense[x][y].length(); z++)
				{
					if (examDrivesLicense[x][y].at(z) == '_')
						examDrivesLicense[x][y].at(z) = ' ';
				}
				tmpBuf[x][y] = examDrivesLicense[x][y];
			}
		}
		break;
	case 3:
		for (x = 0; x < MAX_ROW; x++)
		{
			for (y = 0; y < MAX_COL; y++)
			{
				examMovieQuiz[x][y] = tmpBuf[x][y];

				for (z = 0; z < examMovieQuiz[x][y].length(); z++)
				{
					if (examMovieQuiz[x][y].at(z) == '_')
						examMovieQuiz[x][y].at(z) = ' ';
				}
				tmpBuf[x][y] = examMovieQuiz[x][y];
			}
		}
		break;
	case 4:
		for (x = 0; x < MAX_ROW; x++)
		{
			for (y = 0; y < MAX_COL; y++)
			{
				examTrueFalse[x][y] = tmpBuf[x][y];

				for (z = 0; z < examTrueFalse[x][y].length(); z++)
				{
					if (examTrueFalse[x][y].at(z) == '_')
						examTrueFalse[x][y].at(z) = ' ';
				}
				tmpBuf[x][y] = examTrueFalse[x][y];
			}
		}
		break;
	default:
		break;
	}
}
