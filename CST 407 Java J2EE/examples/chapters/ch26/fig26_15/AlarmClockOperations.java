package com.deitel.advjhtp1.idl.alarm;


/**
* com/deitel/advjhtp1/idl/alarm/AlarmClockOperations.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from alarmclock2.idl
* Sunday, July 1, 2001 11:48:23 PM PDT
*/

public interface AlarmClockOperations 
{
  void addAlarmListener (String listenerName, com.deitel.advjhtp1.idl.alarm.AlarmListener listener) throws com.deitel.advjhtp1.idl.alarm.DuplicateNameException;
  void setAlarm (String listenerName, long seconds);
} // interface AlarmClockOperations
