//This defines the Implementation of the Time class.

#include "StdAfx.h"
#include "Time3.h"
#include <iostream>

using namespace std;

Time3::Time3(int hr, int min, int sec)
{
	setTime(hr, min, sec);
}

Time3::~Time3(void)
{
}

//Note: This is a member of the Time3 class.

int Time3::operator- (Time3& t) {
	int t1 = hour*3600 + minute*60 + second;
	int t2 = t.hour*3600 + t.minute*60 + t.second;
	return t1 - t2;
}

Time3& Time3::operator+= (int x) {
	hour += x;
	if (hour >= 24)
		hour -= 24;
	return *this;
}

Time3::operator int () {
	return hour*3600 + minute*60 + second;	
};

//Note: This is NOT a member of the Time3 class.
//But it does need to be a friend.

ostream& operator<< (ostream& output, Time3& t) {
	output << (t.hour < 10 ? "0" : "") << t.hour << ":"
		 << (t.minute < 10 ? "0" : "") << t.minute << ":"
	     << (t.second < 10 ? "0" : "") << t.second;
	return output;	//enables chaining of <<
}

void Time3::setTime(int h, int m, int s) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = (m >= 0 && h < 60) ? m : 0;
	second = (s >= 0 && s < 60) ? s : 0;
}

//Note the overloaded functions setTime here.
void Time3::setTime(int h) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = 0;
	second = 0;
}

void Time3::setTime(int h, int m) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = (m >= 0 && h < 60) ? m : 0;
	second = 0;
}

int Time3::getHour() {
	return hour;
}

int Time3::getMinute() {
	return minute;
}

int Time3::getSecond() {
	return second;
}

void Time3::setHour(int h) {
	hour = (h >= 0 && h < 24) ? h : 0;
}

void Time3::setMinute(int m) {
	minute = (m >= 0 && m < 60) ? m : 0;
}

void Time3::setSecond(int s) {
	second = (s >= 0 && s < 60) ? s : 0;
}

void Time3::printMilitary() {
	cout << (hour < 10 ? "0" : "") << hour << ":"
		 << (minute < 10 ? "0" : "") << minute << ":"
	     << (second < 10 ? "0" : "") << second;
}

void Time3::printStandard() {
	cout << ((hour == 0 || hour == 12) ? 12 : hour % 12)
		 << ":" << (minute < 10 ? "0" : "") << minute
		 << ":" << (second < 10 ? "0" : "") << second
		 << (hour < 12 ? " AM" : " PM");
}
