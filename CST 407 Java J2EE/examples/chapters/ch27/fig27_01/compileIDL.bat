rem
rem Filename: compileIDL.bat
rem
rem Description: compile the code in this directory.  This assumes
rem           the JDK is already in your path.
rem

set JAVAHOME=c:\usr\local\bin\jdk1.3
set PATH= %JAVAHOME%\bin;%path%

set EXAMPLE_HOME=C:\advjhtp1\src

rem
rem Compile the IDL file.  Write it to %example_home% and take the
rem module name and expand it to the full package name
rem
idlj -td %EXAMPLE_HOME% -pkgPrefix dii com.deitel.advjhtp1.idl -fserver systemclock.idl

