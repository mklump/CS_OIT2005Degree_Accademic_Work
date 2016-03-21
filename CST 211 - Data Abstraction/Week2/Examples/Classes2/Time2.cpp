//This defines the Implementation of the Time class.

#include "StdAfx.h"
#include "Time2.h"
#include <iostream>

using namespace std;

Time2::Time2(int hr, int min, int sec)
{
	setTime(hr, min, sec);
}

Time2::~Time2(void)
{
}

void Time2::setTime(int h, int m, int s) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = (m >= 0 && h < 60) ? m : 0;
	second = (s >= 0 && s < 60) ? s : 0;
}

//Note the overloaded functions setTime here.
void Time2::setTime(int h) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = 0;
	second = 0;
}

void Time2::setTime(int h, int m) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = (m >= 0 && h < 60) ? m : 0;
	second = 0;
}

int Time2::getHour() {
	return hour;
}

int Time2::getMinute() {
	return minute;
}

int Time2::getSecond() {
	return second;
}

void Time2::setHour(int h) {
	hour = (h >= 0 && h < 24) ? h : 0;
}

void Time2::setMinute(int m) {
	minute = (m >= 0 && m < 60) ? m : 0;
}

void Time2::setSecond(int s) {
	second = (s >= 0 && s < 60) ? s : 0;
}

void Time2::printMilitary() {
	cout << (hour < 10 ? "0" : "") << hour << ":"
		 << (minute < 10 ? "0" : "") << minute << ":"
	     << (second < 10 ? "0" : "") << second;
}

void Time2::printStandard() {
	cout << ((hour == 0 || hour == 12) ? 12 : hour % 12)
		 << ":" << (minute < 10 ? "0" : "") << minute
		 << ":" << (second < 10 ? "0" : "") << second
		 << (hour < 12 ? " AM" : " PM");
}
