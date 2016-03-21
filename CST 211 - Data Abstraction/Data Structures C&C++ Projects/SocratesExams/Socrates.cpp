// Socrates.cpp: implementation of the CSocrates class.
//
//////////////////////////////////////////////////////////////////////

#include "Socrates.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSocrates::CSocrates()
{
	entryBuf = "";
	score = 0;
	grade = 0;
	for (int x=0; x < 7; x++)
		expertFlags[x] = false;
}

CSocrates::~CSocrates()
{
}

void CSocrates::PresentExam(menuItem m)
{
	while (m != EXIT)
	{
		cout << "\n*** Socrates Main Menu ***" << endl;
		cout << "Which exam would you like to take?" << endl;
		cout << "1. C++" << endl;
		cout << "2. Driver's License" << endl;
		cout << "3. Movie Quiz" << endl;
		cout << "4. True of False Quiz" << endl;
		cout << endl;
		cout << "0. Exit Socrates Program" << endl;
		m = getInput();
		switch (m)
		{
		case EXIT:
			if (grade <= 14)
				cout << "Your total score is " << grade << " out of 14 possible questions.";
			else
				cout << "You've taken one of the exams more than once.";

			cout << "\n\nThank you for using Socrates." << endl
				 << endl;
			break;
		case TAKE_CPLUSPLUSS_EXAM:
			fileName = "c++ test.txt";
			input();
			showExam();
			break;
		case TAKE_DRIVER_EXAM:
			fileName = "driver's license.txt";
			input();
			showExam();
			break;
		case TAKE_MOVIE_QUIZ:
			fileName = "Movie Quiz.txt";
			input();
			showExam();
			break;
		case TAKE_TRUE_OR_FALSE_QUIZ:
			fileName = "True or False.txt";
			input();
			showExam();
			break;
		case MAIN_MENU:
			CSocrates::PresentExam(MAIN_MENU);
			break;
		default:
			break;
		}
	}
}

menuItem CSocrates::getInput()
{
	cout << endl;
	cout << "Entry? > " << flush;
	cin >> entryBuf;
	cout << endl;
	cout << endl;
	if (entryBuf != "0")
		firstEntry = entryBuf;

	if (!isdigit(entryBuf[0]))
	{
		cout << "Please enter a number, not a letter. Please try again\n\n";
		CSocrates::PresentExam(MAIN_MENU);
	}
	else
	{
		selector = atoi(entryBuf.c_str());
		switch (selector)
		{
		case 0:
			return EXIT;
			break;
		case 1:
			return TAKE_CPLUSPLUSS_EXAM;
			break;
		case 2:
			return TAKE_DRIVER_EXAM;
			break;
		case 3:
			return TAKE_MOVIE_QUIZ;
			break;
		case 4:
			return TAKE_TRUE_OR_FALSE_QUIZ;
			break;
		default:
			cout << endl;
			cout << "Please choose a number 0-4";
			cout << endl;
			CSocrates::getInput();
			break;
		}
	}
	return MAIN_MENU;
}

void CSocrates::setName_and_Skill()
{
	char charTmp;
	cout << "*** Welcome to Socrates ***\n"
		 << "\nPlease enter your name -> ";
	gets(name);
	cout << endl << "Please enter your skill level: \n"
						<< "(e for expert or n for novice) -> ";
	cin >> charTmp;
	switch (charTmp)
	{
	case 'n':
		level = NOVICE;
		break;
	case 'e':
		level = EXPERT;
		break;
	default:
		break;
	}
}

void CSocrates::showExam()
{
	switch (selector)
	{
	case 0:
		break;
	case 1:
		cout << endl << examCPlusPlus[0][0] << endl
			<< "Is the Answer: " << endl
			<< examCPlusPlus[0][1] << endl 
			<< examCPlusPlus[0][2] << endl
			<< examCPlusPlus[0][3] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "b" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examCPlusPlus[0][4] << endl;

		cout << endl << examCPlusPlus[1][0] << endl
			<< "Is the Answer: " << endl
			<< examCPlusPlus[1][1] << endl
			<< examCPlusPlus[1][2] << endl
			<< examCPlusPlus[1][3] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "a" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examCPlusPlus[1][4] << endl;
		
		if (level == EXPERT)
		{
			cout << endl << examCPlusPlus[2][0] << endl
				<< "Is the Answer: " << endl
				<< examCPlusPlus[2][1] << endl
				<< examCPlusPlus[2][2] << endl
				<< examCPlusPlus[2][3] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "c" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[0] = true;
			}
			else
			{
				expertFlags[0] = false;
				//cout << "The correct answer is: " << examCPlusPlus[2][4] << endl;
			}
		}

		cout << "\nYour score for this exam is: " << score << " out of 3\n\n";
		grade += score;

		break;
	case 2:
		score = 0;
		cout << endl << examDrivesLicense[0][0] << endl
			<< "Is the Answer: " << endl
			<< examDrivesLicense[0][1] << endl 
			<< examDrivesLicense[0][2] << endl
			<< examDrivesLicense[0][3] << endl
			<< examDrivesLicense[0][4] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "b" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examDrivesLicense[0][5] << endl;

		cout << endl << examDrivesLicense[1][0] << endl
			<< "Is the Answer: " << endl
			<< examDrivesLicense[1][1] << endl
			<< examDrivesLicense[1][2] << endl
			<< examDrivesLicense[1][3] << endl
			<< examDrivesLicense[1][4] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "c" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examDrivesLicense[1][5] << endl;
		
		if (level == EXPERT)
		{
			cout << endl << examDrivesLicense[2][0] << endl
				<< "Is the Answer: " << endl
				<< examDrivesLicense[2][1] << endl
				<< examDrivesLicense[2][2] << endl
				<< examDrivesLicense[2][3] << endl
				<< examDrivesLicense[2][4] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "a" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[1] = true;
			}
			else
			{
				expertFlags[1] = false;
				//cout << "The correct answer is: " << examDrivesLicense[2][5] << endl;
			}

			cout << endl << examDrivesLicense[3][0] << endl
				<< "Is the Answer: " << endl
				<< examDrivesLicense[3][1] << endl
				<< examDrivesLicense[3][2] << endl
				<< examDrivesLicense[3][3] << endl
				<< examDrivesLicense[3][4] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "a" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[2] = true;
			}
			else
			{
				//cout << "The correct answer is: " << examDrivesLicense[3][5] << endl;
				expertFlags[2] = false;
			}
		}

		cout << "\nYour score for this exam is: " << score << " out of 4\n\n";
		grade += score;
		break;
	case 3:
		score = 0;
		cout << endl << examMovieQuiz[0][0] << endl
			<< "Is the Answer: " << endl
			<< examMovieQuiz[0][1] << endl 
			<< examMovieQuiz[0][2] << endl
			<< examMovieQuiz[0][3] << endl
			<< examMovieQuiz[0][4] << endl
			<< examMovieQuiz[0][5] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "c" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examMovieQuiz[0][6] << endl;

		cout << endl << examMovieQuiz[1][0] << endl
			<< "Is the Answer: " << endl
			<< examMovieQuiz[1][1] << endl
			<< examMovieQuiz[1][2] << endl
			<< examMovieQuiz[1][3] << endl
			<< examMovieQuiz[1][4] << endl
			<< examMovieQuiz[1][5] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "e" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examMovieQuiz[1][6] << endl;

		if (level == EXPERT)
		{
			cout << endl << examMovieQuiz[2][0] << endl
				<< "Is the Answer: " << endl
				<< examMovieQuiz[2][1] << endl
				<< examMovieQuiz[2][2] << endl
				<< examMovieQuiz[2][3] << endl
				<< examMovieQuiz[2][4] << endl
				<< examMovieQuiz[2][5] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "b" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[3] = true;
			}
			else
			{
				//cout << "The correct answer is: " << examMovieQuiz[2][6] << endl;
				expertFlags[3] = false;
			}

			cout << endl << examMovieQuiz[3][0] << endl
				<< "Is the Answer: " << endl
				<< examMovieQuiz[3][1] << endl
				<< examMovieQuiz[3][2] << endl
				<< examMovieQuiz[3][3] << endl
				<< examMovieQuiz[3][4] << endl
				<< examMovieQuiz[3][5] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "a" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[4] = true;
			}
			else
			{
				//cout << "The correct answer is: " << examMovieQuiz[3][6] << endl;
				expertFlags[4] = false;
			}

			cout << endl << examMovieQuiz[4][0] << endl
				<< "Is the Answer: " << endl
				<< examMovieQuiz[4][1] << endl
				<< examMovieQuiz[4][2] << endl
				<< examMovieQuiz[4][3] << endl
				<< examMovieQuiz[4][4] << endl
				<< examMovieQuiz[4][5] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "d" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[5] = true;
			}
			else
			{
				//cout << "The correct answer is: " << examMovieQuiz[4][6] << endl;
				expertFlags[5] = false;
			}
		}

		cout << "\nYour score for this exam is: " << score << " out of 5\n\n";
		grade += score;
		break;
	case 4:
		score = 0;
		cout << endl << examTrueFalse[0][0] << endl
			<< "Is the Answer: " << endl
			<< examTrueFalse[0][1] << endl 
			<< examTrueFalse[0][2] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "b" )
			cout << "Correct! Your score is: " << (score += 1) << endl;
		else
			cout << "The correct answer is: " << examTrueFalse[0][3] << endl;

		if (level == EXPERT)
		{
			cout << endl << examTrueFalse[1][0] << endl
				<< "Is the Answer: " << endl
				<< examTrueFalse[1][1] << endl
				<< examTrueFalse[1][2] << endl
				<< "Entry? > " << flush;
			cin >> entryBuf;
			cout << endl;
			if ( entryBuf == "a" )
			{
				cout << "Correct! Your score is: " << (score += 1) << endl;
				expertFlags[6] = true;
			}
			else
			{
				//cout << "The correct answer is: " << examTrueFalse[1][3] << endl;
				expertFlags[6] = false;
			}
		}

		cout << "\nYour score for this exam is: " << score << " out of 2\n";
		grade += score;
		break;
	case 5:
		break;
	}
}

void CSocrates::DisplayMissedQuestions()
{
	cout << "\nThe correct answers are: \n\n";
	if (expertFlags[0] == false)
		cout << examCPlusPlus[2][0] << "\n\t\t" << examCPlusPlus[2][4] << endl;
	if (expertFlags[1] == false)
		cout << examDrivesLicense[2][0] << "\n\t\t" << examDrivesLicense[2][5] << endl;
	if (expertFlags[2] == false)
		cout << examDrivesLicense[3][0] << "\n\t\t" << examDrivesLicense[3][5] << endl;
	if (expertFlags[3] == false)
		cout << examMovieQuiz[2][0] << "\n\t\t" << examMovieQuiz[2][6] << endl;
	if (expertFlags[4] == false)
		cout << examMovieQuiz[3][0] << "\n\t\t" << examMovieQuiz[3][6] << endl;
	if (expertFlags[5] == false)
		cout << examMovieQuiz[4][0] << "\n\t\t" << examMovieQuiz[4][6] << endl;
	if (expertFlags[6] == false)
		cout << examTrueFalse[1][0] << "\n\t\t" << examTrueFalse[1][3] << endl;
}

void CSocrates::RetakeExpertQuestions()
{
	char entryBuf[2] = "";
	cout << "\nAs an expert, you will now retake the exam questions you missed.\n\n";
	if (expertFlags[0] == false)
	{
		cout << endl << examCPlusPlus[2][0] << endl
			<< "Is the Answer: " << endl
			<< examCPlusPlus[2][1] << endl
			<< examCPlusPlus[2][2] << endl
			<< examCPlusPlus[2][3] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( strcmp( entryBuf, "c" ) )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[0] = true;
		}
		else
		{
			expertFlags[0] = false;
			//cout << "The correct answer is: " << examCPlusPlus[2][4] << endl;
		}
	}
	if (expertFlags[1] == false)
	{
		cout << endl << examDrivesLicense[2][0] << endl
			<< "Is the Answer: " << endl
			<< examDrivesLicense[2][1] << endl
			<< examDrivesLicense[2][2] << endl
			<< examDrivesLicense[2][3] << endl
			<< examDrivesLicense[2][4] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( strcmp(entryBuf, "a" ) )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[1] = true;
		}
		else
		{
			expertFlags[1] = false;
			//cout << "The correct answer is: " << examDrivesLicense[2][5] << endl;
		}
	}
	if (expertFlags[2] = false)
	{
		cout << endl << examDrivesLicense[3][0] << endl
			<< "Is the Answer: " << endl
			<< examDrivesLicense[3][1] << endl
			<< examDrivesLicense[3][2] << endl
			<< examDrivesLicense[3][3] << endl
			<< examDrivesLicense[3][4] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( strcmp( entryBuf, "a" ) )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[2] = true;
		}
		else
		{
			//cout << "The correct answer is: " << examDrivesLicense[3][5] << endl;
			expertFlags[2] = false;
		}
	}
	if (expertFlags[3] == false)
	{
		cout << endl << examMovieQuiz[2][0] << endl
			<< "Is the Answer: " << endl
			<< examMovieQuiz[2][1] << endl
			<< examMovieQuiz[2][2] << endl
			<< examMovieQuiz[2][3] << endl
			<< examMovieQuiz[2][4] << endl
			<< examMovieQuiz[2][5] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( strcmp( entryBuf, "b" ) )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[3] = true;
		}
		else
		{
			//cout << "The correct answer is: " << examMovieQuiz[2][6] << endl;
			expertFlags[3] = false;
		}
	}
	if (expertFlags[4] == false)
	{
		cout << endl << examMovieQuiz[3][0] << endl
			<< "Is the Answer: " << endl
			<< examMovieQuiz[3][1] << endl
			<< examMovieQuiz[3][2] << endl
			<< examMovieQuiz[3][3] << endl
			<< examMovieQuiz[3][4] << endl
			<< examMovieQuiz[3][5] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( strcmp( entryBuf, "a" ) )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[4] = true;
		}
		else
		{
			//cout << "The correct answer is: " << examMovieQuiz[3][6] << endl;
			expertFlags[4] = false;
		}
	}
	if (expertFlags[5] == false)
	{
		cout << endl << examMovieQuiz[4][0] << endl
			<< "Is the Answer: " << endl
			<< examMovieQuiz[4][1] << endl
			<< examMovieQuiz[4][2] << endl
			<< examMovieQuiz[4][3] << endl
			<< examMovieQuiz[4][4] << endl
			<< examMovieQuiz[4][5] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( strcmp( entryBuf, "d" ) )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[5] = true;
		}
		else
		{
			//cout << "The correct answer is: " << examMovieQuiz[4][6] << endl;
			expertFlags[5] = false;
		}
	}
	if (expertFlags[6] == false)
	{
		cout << endl << examTrueFalse[1][0] << endl
			<< "Is the Answer: " << endl
			<< examTrueFalse[1][1] << endl
			<< examTrueFalse[1][2] << endl
			<< "Entry? > " << flush;
		cin >> entryBuf;
		cout << endl;
		if ( entryBuf == "a" )
		{
			cout << "Correct! Your score is: " << (score += 1) << endl;
			expertFlags[6] = true;
		}
		else
		{
			//cout << "The correct answer is: " << examTrueFalse[1][3] << endl;
			expertFlags[6] = false;
		}
	}
}

ostream& operator << (ostream &lhs, CSocrates &rhs)
{

	time_t ltime;

    time( &ltime );
    /*printf( "The time is %s\n", ctime( &ltime ) ); */

	int temp;
	ofstream oFile;
	oFile.open("socrates.log", ios::out | ios::app);
	temp = atoi(rhs.firstEntry.c_str());
	switch (temp)
	{
	case 0:
		break;
	case 1:
		oFile.width(5);
		oFile << ctime( &ltime ) << ' ' << rhs.name << ' ' 
			<< rhs.level << " for examCPlusPlus scored " 
			<< rhs.grade << " out of 3." << endl;
		break;
	case 2:
		oFile << ctime( &ltime ) << ' ' << rhs.name << ' ' 
			<< rhs.level << " for examDrivesLicense scored " 
			<< rhs.grade << " out of 4." << endl;
		break;
	case 3:
		oFile << ctime( &ltime ) << ' ' << rhs.name << ' ' 
			<< rhs.level << " for examMovieQuiz scored " 
			<< rhs.grade << " out of 5." << endl;
		break;
	case 4:
		oFile << ctime( &ltime ) << ' ' << rhs.name << ' ' 
			<< rhs.level << " for examTrueFalse scored " 
			<< rhs.grade << " out of 2." << endl;
		break;
	default:
		break;
	}
	oFile.close();
	return lhs;
}

void CSocrates::RandomizeQuestions()
{
	typedef string ptr[];
	int temp1 = 0 + rand() % 3,
		temp2 = 0 + rand() % 3,
		temp3 = 0 + rand() % 3;

	ptr p1 = { examCPlusPlus[0][0], examCPlusPlus[0][1], examCPlusPlus[0][2],
		examCPlusPlus[0][3], examCPlusPlus[0][4] },
		p2 = { examCPlusPlus[1][0], examCPlusPlus[1][1], examCPlusPlus[1][2],
		examCPlusPlus[1][3], examCPlusPlus[1][4] },
		p3 = {examCPlusPlus[2][0], examCPlusPlus[2][1], examCPlusPlus[2][2],
		examCPlusPlus[2][3], examCPlusPlus[2][4] };
	if (temp1 == 0)
	{
		examCPlusPlus[0][0]=p2[0];
		examCPlusPlus[0][1]=p2[1];
		examCPlusPlus[0][2]=p2[2];
		examCPlusPlus[0][3]=p2[3];
		examCPlusPlus[0][4]=p2[4];
	}
	if (temp1 == 1)
	{
		examCPlusPlus[0][0]=p3[0];
		examCPlusPlus[0][1]=p3[1];
		examCPlusPlus[0][2]=p3[2];
		examCPlusPlus[0][3]=p3[3];
		examCPlusPlus[0][4]=p3[4];
	}
	if (temp1 == 2)
	{
		examCPlusPlus[0][0]=p1[0];
		examCPlusPlus[0][1]=p1[1];
		examCPlusPlus[0][2]=p1[2];
		examCPlusPlus[0][3]=p1[3];
		examCPlusPlus[0][4]=p1[4];
	}
	//
	if (temp2 == 0)
	{
		examCPlusPlus[1][0]=p3[0];
		examCPlusPlus[1][1]=p3[1];
		examCPlusPlus[1][2]=p3[2];
		examCPlusPlus[1][3]=p3[3];
		examCPlusPlus[1][4]=p3[4];
	}
	if (temp2 == 1)
	{
		examCPlusPlus[1][0]=p1[0];
		examCPlusPlus[1][1]=p1[1];
		examCPlusPlus[1][2]=p1[2];
		examCPlusPlus[1][3]=p1[3];
		examCPlusPlus[1][4]=p1[4];
	}
	if (temp2 == 2)
	{
		examCPlusPlus[1][0]=p2[0];
		examCPlusPlus[1][1]=p2[1];
		examCPlusPlus[1][2]=p2[2];
		examCPlusPlus[1][3]=p2[3];
		examCPlusPlus[1][4]=p2[4];
	}
	//
	if (temp3 == 0)
	{
		examCPlusPlus[2][0]=p1[0];
		examCPlusPlus[2][1]=p1[1];
		examCPlusPlus[2][2]=p1[2];
		examCPlusPlus[2][3]=p1[3];
		examCPlusPlus[2][4]=p1[4];
	}
	if (temp3 == 1)
	{
		examCPlusPlus[2][0]=p2[0];
		examCPlusPlus[2][1]=p2[1];
		examCPlusPlus[2][2]=p2[2];
		examCPlusPlus[2][3]=p2[3];
		examCPlusPlus[2][4]=p2[4];
	}
	if (temp3 == 2)
	{
		examCPlusPlus[2][0]=p3[0];
		examCPlusPlus[2][1]=p3[1];
		examCPlusPlus[2][2]=p3[2];
		examCPlusPlus[2][3]=p3[3];
		examCPlusPlus[2][4]=p3[4];
	}
	ptr p4 = { examDrivesLicense[0][0], examDrivesLicense[0][1], examDrivesLicense[0][2],
		examDrivesLicense[0][3], examDrivesLicense[0][4], examDrivesLicense[0][5] },
		p5 = { examDrivesLicense[1][0], examDrivesLicense[1][1], examDrivesLicense[1][2],
		examDrivesLicense[1][3], examDrivesLicense[1][4], examDrivesLicense[1][5] },
		p6 = {examDrivesLicense[2][0], examDrivesLicense[2][1], examDrivesLicense[2][2],
		examDrivesLicense[2][3], examDrivesLicense[2][4], examDrivesLicense[2][5] },
		p7 = {examDrivesLicense[3][0], examDrivesLicense[3][1], examDrivesLicense[3][2],
		examDrivesLicense[3][3], examDrivesLicense[3][4], examDrivesLicense[3][5] };
	if (temp1 == 0)
	{
		examDrivesLicense[0][0]=p6[0];
		examDrivesLicense[0][1]=p6[1];
		examDrivesLicense[0][2]=p6[2];
		examDrivesLicense[0][3]=p6[3];
		examDrivesLicense[0][4]=p6[4];
		examDrivesLicense[0][5]=p6[5];

	}
	if (temp1 == 1)
	{
		examDrivesLicense[0][0]=p5[0];
		examDrivesLicense[0][1]=p5[1];
		examDrivesLicense[0][2]=p5[2];
		examDrivesLicense[0][3]=p5[3];
		examDrivesLicense[0][4]=p5[4];
		examDrivesLicense[0][5]=p5[5];
	}
	if (temp1 == 2)
	{
		examDrivesLicense[0][0]=p4[0];
		examDrivesLicense[0][1]=p4[1];
		examDrivesLicense[0][2]=p4[2];
		examDrivesLicense[0][3]=p4[3];
		examDrivesLicense[0][4]=p4[4];
		examDrivesLicense[0][5]=p4[5];
	}
	//
	if (temp2 == 0)
	{
		examDrivesLicense[1][0]=p5[0];
		examDrivesLicense[1][1]=p5[1];
		examDrivesLicense[1][2]=p5[2];
		examDrivesLicense[1][3]=p5[3];
		examDrivesLicense[1][4]=p5[4];
		examDrivesLicense[1][5]=p5[5];
	}
	if (temp2 == 1)
	{
		examDrivesLicense[1][0]=p4[0];
		examDrivesLicense[1][1]=p4[1];
		examDrivesLicense[1][2]=p4[2];
		examDrivesLicense[1][3]=p4[3];
		examDrivesLicense[1][4]=p4[4];
		examDrivesLicense[1][5]=p4[5];
	}
	if (temp2 == 2)
	{
		examDrivesLicense[1][0]=p6[0];
		examDrivesLicense[1][1]=p6[1];
		examDrivesLicense[1][2]=p6[2];
		examDrivesLicense[1][3]=p6[3];
		examDrivesLicense[1][4]=p6[4];
		examDrivesLicense[1][5]=p6[5];
	}
	//
	if (temp3 == 0)
	{
		examDrivesLicense[2][0]=p4[0];
		examDrivesLicense[2][1]=p4[1];
		examDrivesLicense[2][2]=p4[2];
		examDrivesLicense[2][3]=p4[3];
		examDrivesLicense[2][4]=p4[4];
		examDrivesLicense[2][5]=p4[5];
	}
	if (temp3 == 1)
	{
		examDrivesLicense[2][0]=p5[0];
		examDrivesLicense[2][1]=p5[1];
		examDrivesLicense[2][2]=p5[2];
		examDrivesLicense[2][3]=p5[3];
		examDrivesLicense[2][4]=p5[4];
		examDrivesLicense[2][5]=p5[5];
	}
	if (temp3 == 2)
	{
		examDrivesLicense[2][0]=p6[0];
		examDrivesLicense[2][1]=p6[1];
		examDrivesLicense[2][2]=p6[2];
		examDrivesLicense[2][3]=p6[3];
		examDrivesLicense[2][4]=p6[4];
		examDrivesLicense[2][5]=p6[5];
	}
	ptr p8 = { examTrueFalse[0][0], examTrueFalse[0][1], examTrueFalse[0][2],
		examTrueFalse[0][3] },
		p9 = { examTrueFalse[1][0], examTrueFalse[1][1], examTrueFalse[1][2],
		examCPlusPlus[1][3] };

	if (temp1 == 0)
	{
		examTrueFalse[0][0]=p9[0];
		examTrueFalse[0][1]=p9[1];
		examTrueFalse[0][2]=p9[2];
		examTrueFalse[0][3]=p9[3];
	}
	if (temp1 == 1)
	{
		examTrueFalse[0][0]=p8[0];
		examTrueFalse[0][1]=p8[1];
		examTrueFalse[0][2]=p8[2];
		examTrueFalse[0][3]=p8[3];
		examTrueFalse[0][4]=p8[4];
	}
	//
	if (temp2 == 0)
	{
		examTrueFalse[1][0]=p8[0];
		examTrueFalse[1][1]=p8[1];
		examTrueFalse[1][2]=p8[2];
		examTrueFalse[1][3]=p8[3];
	}
	if (temp2 == 1)
	{
		examTrueFalse[1][0]=p9[0];
		examTrueFalse[1][1]=p9[1];
		examTrueFalse[1][2]=p9[2];
		examTrueFalse[1][3]=p9[3];
	}
}