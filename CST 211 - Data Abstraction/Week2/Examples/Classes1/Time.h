//This defines the Interface of the Time class

#pragma once

class Time
{
public:
	Time(void);
	~Time(void);
	void setTime(int, int, int);
	void printMilitary();
	void printStandard();
private:
	int hour;
	int minute;
	int second;
};
