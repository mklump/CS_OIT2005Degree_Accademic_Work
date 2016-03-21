//This defines the Interface of the Time2 class

#pragma once

class Time2
{
public:				//Public usually precedes private
	Time2(int = 0, int = 0, int = 0);
	~Time2(void);
	void setTime(int, int, int);
	void setTime(int, int);
	void setTime(int);
	int getHour();
	int getMinute();
	int getSecond();
	void setHour(int);
	void setMinute(int);
	void setSecond(int);
	void printMilitary();
	void printStandard();
private:
	int hour;
	int minute;
	int second;
};
