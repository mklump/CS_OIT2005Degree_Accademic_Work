set JAVA_HOME=c:\usr\local\bin\jdk1.3

set PATH=%JAVA_HOME%\bin;%path%

set EXAMPLE_HOME=c:\advjhtp1\src

rem
rem Set this to where the path to the class files begins
rem
set CURDIR=%example_home%\com\deitel\jhtp4\idl\dii
cd %example_home%

java com.deitel.advjhtp1.idl.dii.SystemClockClient -ORBInitialPort 1050

rem
rem Take us back to where we started
rem
cd %curdir%