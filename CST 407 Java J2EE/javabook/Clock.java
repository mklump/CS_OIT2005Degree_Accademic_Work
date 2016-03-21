package javabook;

import java.util.*;

/**
 * This class supports some basic clock functions such as reading the current time,
 * getting today's date, and stop watch function. This class also supports a convenient
 * function to pause the program execution. 
 * <p>
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * <p>
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class Clock
{

//----------------------------------
//    Data Members:
//----------------------------------

    /**
     * Designates the long format for date
     */
    public static final  int     LONG_FORMAT  = 0;
    
    /**
     * Designates the short format for date
     */
    public static final  int     SHORT_FORMAT = 1;

    /**
     * Designates the 12-hr format for time
     */
    public static final  int     TIME_12HR_FORMAT  = 0;
    
    /**
     * Designates the 24-hr format for time
     */
    public static final  int     TIME_24HR_FORMAT = 1;
    
    /**
     * Month names for long format display
     */
    private static final String[] MONTH_NAME =
       { "January", "February", "March", "April", "May", "June",
         "July", "August", "September","October", "November", "December"};

    /**
     * True when the stop watch is running
     */
    private boolean clockRunning;
    
    /**
     * Elapsed time from the first start to the last stop or current time
     */
    private long    totalElapsedTime;
    
    /**
     * Elapsed time from the most recent start to the last stop
     */
    private long    elapsedTime;
    
    /**
     * The most recent start time of the stop watch function
     */    
    private long    startTime;
    
    /**
     * The most recent stop time (i.e., the last) of the stop watch function
     */
    private long    stopTime;


//-----------------------------------
//    Constructors
//-----------------------------------
    
    /**
     * Default constructor.
     */
    public Clock( )
    {
        reset( ); 
    }
    

//-----------------------------------------------
//    Public Methods:
//
//        String    getCurrentDate      (           )
//        String    getCurrentDate      ( int       )
//        
//        String    getCurrentTime      (           )
//        String    getCurrentTime      ( int       )
//
//        double    getElapsedTime      (           )
//        double    getTotalElapsedTime (           )
//
//        void      pause               ( double    )
//        void      start               (           )
//        void      stop                (           )
//
//-------------------------------------------------
 
    /**
     * Returns the current (today's) date in the mm/dd/yyyy
     * format. 
     *
     * @return today's date in either the mm/dd/yyyy format
     */
    public String getCurrentDate( )
    {
        return this.getCurrentDate( SHORT_FORMAT );
    }
   
    /**
     * Returns the current (today's) date in short or long format.
     * The short format has the standard mm/dd/yyyy. The long format
     * spells out the month name.
     *
     * @param format specify LONG_FORMAT or SHORT_FORMAT 
     *
     * @return today's date in either short or long format
     */
    public String getCurrentDate(int format)
    {
        String dateString = "";
        int month, day, year;
        
        GregorianCalendar   date   = new GregorianCalendar( );
        
        month = date.get(Calendar.MONTH);
        day   = date.get(Calendar.DAY_OF_MONTH);
        year  = date.get(Calendar.YEAR);     
                   
        switch (format) {
            
            case LONG_FORMAT:
                
                dateString = MONTH_NAME[month] + " " + day + ", " + year;
                
                break;
                
            case SHORT_FORMAT:
            default:
 
                dateString = Format.rightAlign(2, month+1) + "/" +
                             Format.rightAlign(2, day)     + "/" +
                                                  year;  
                break;
        }
        
        return dateString;
    }
    
    /**
     * Returns the current time in the 12-hr format.
     *
     * @return current time in the 12-hr format
     */
    public String getCurrentTime( )
    {
        return this.getCurrentTime( TIME_12HR_FORMAT );
    }
    
    /**
     * Returns the current time in 24-hr or 12-hr format.
     * The 12-hr format will include the AM/PM designation.
     *
     * @param format specify TIME_12HR_FORMAT or TIME_24HR_FORMAT 
     *
     * @return current time in either 12-hr or 24-hr format
     */
    public String getCurrentTime(int format)
    {
        String timeString, hourStr, minuteStr, secondStr, am_pm_Str;
        
        int    hour, minute, second, hourOfDay;
        
        GregorianCalendar   date  = new GregorianCalendar( );
        
        minute = date.get(Calendar.MINUTE);
        second = date.get(Calendar.SECOND); 
        
        if (format == TIME_12HR_FORMAT) {
                
            hour   = date.get(Calendar.HOUR);
                
            if (date.get(Calendar.AM_PM) == Calendar.AM) {
                 am_pm_Str = " AM";
            }
            else {
                 am_pm_Str = " PM";
            }                
        }
        else {              
            hour   = date.get(Calendar.HOUR_OF_DAY); 
                
            am_pm_Str = "";              
        }

        //prepend "0" for the value < 10 so we will have 08:05:10
        //instead of 8:5:10
        if (hour < 10 ) {
            hourStr = "0" + hour;
        }
        else {
            hourStr = "" + hour;
        }
        
        if (minute < 10) {
            minuteStr = "0" + minute;
        }
        else {
            minuteStr = "" + minute;
        }
        
        if (second < 10) {
            secondStr = "0" + second;
        }
        else {
            secondStr = "" + second;
        }
               
        timeString = hourStr + ":" + minuteStr + ":" + secondStr + " " + am_pm_Str;
                                        
        return timeString;
    }
    
    /**
     * Returns the elapsed time of the stop watch function.
     * The elapsed time is the time interval between the most recent start and stop. 
     * If the stop watch is still running, then this method returns the elapsed time from
     * the most recent call to the start method until this method is called. 
     * The stop watch will keep on running. 
     *
     * @return elapsed time (unit is seconds)
     */
    public double getElapsedTime( )
    {
        double timeInterval;
        
        if (clockRunning) {
            //get the current time and compute the elapsed time
            //and keep the clock running
            
            timeInterval = (System.currentTimeMillis( ) - startTime)  / 1000.0;                      
        }
        else {
            timeInterval = elapsedTime / 1000.0;
        }
        
        return timeInterval; //the unit is in seconds
    }

     
    /**
     * Returns the total elapsed time of the stop watch function.
     * The total elapsed time is the time interval between the first start and the last stop. 
     * If the stop watch is still running, then this method returns the elapsed time
     * from the first time the stop watch is started till the time this method is called. 
     * The stop watch will keep on running. 
     *
     * @return elapsed time (unit is seconds)
     */ 
    public double getTotalElapsedTime( )
    {
        double timeInterval;
        
        if (clockRunning) {
            //get the current time and compute the totalElapsedTime
            //and keep the clock running
            long currentTime = System.currentTimeMillis( );
            long currentElapsedTime = totalElapsedTime + (currentTime - startTime);
            
            timeInterval = currentElapsedTime / 1000.0;            
            
        }
        else {
            timeInterval = totalElapsedTime  / 1000.0;
        }
                
        return timeInterval; //the unit is in seconds
    }
            
    /**
      * Pauses the program execution.
      * If the clock is running, then the timer keeps on
      * counting while the program execution is paused.
      * If the clock is not running, then this method simply pauses the
      * program execution.
      *
      * @param duration the amount to time (in seconds) to pause the program execution
      */
    public void pause( double duration )
    {      
        long pauseTime;
        
        pauseTime = (long) (duration * 1000);
              
        try {
            Thread.sleep( pauseTime );
        }
        catch (Exception e) { }
    }
    
    /**
     * Resets the stop watch to its initial state.
     */
    public void reset( )
    {
        clockRunning = false;
        
        totalElapsedTime  = 0;       
    }
    
    /**
     * Starts the clock's stop watch.
     * If the stop watch is already running, then this method is imply ignored.
     */
    public void start( )
    {
        if (!clockRunning) { //ignore if the clock is already running
                             
            clockRunning = true;
            
            startTime = System.currentTimeMillis();
        }
    }
    
    /** 
     * Stops the clock's stop watch.
     * If the stop watch is not running, then this method is simply ignored.
     */
    public void stop( )
    {
        if (clockRunning) { //ignore if not running
        
            clockRunning = false;
            
            stopTime = System.currentTimeMillis( );
            
            elapsedTime = (stopTime - startTime);

            totalElapsedTime += elapsedTime; 
        }
    }
    
    
}