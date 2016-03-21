rem
rem Filename: compileIDL.bat
rem
rem Description: compile the IDL in this directory.
rem

set JAVAHOME=c:\usr\local\bin\jdk1.3
set PATH= %JAVAHOME%\bin;%path%

set EXAMPLE_HOME=C:\advjhtp1\src

rem
rem Compile the IDL file.  Write it to %example_home% and take the
rem module name and expand it to the full package name
rem
idlj -td %EXAMPLE_HOME% -pkgPrefix alarm com.deitel.advjhtp1.idl -fall alarmclock2.idl

