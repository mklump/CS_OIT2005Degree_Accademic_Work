rem
rem Filename: compileRMI_IIOP.bat
rem
rem Description: compile the code in this directory.  This assumes
rem           the JDK is already in your path.
rem

set JAVAHOME=c:\usr\local\bin\jdk1.3
set PATH= %JAVAHOME%\bin;%path%

set EXAMPLE_HOME=C:\home\EinTech\Clients\Active\Deitel\Books\AdvancedJava\FinalCode

set CUR_DIR=%EXAMPLE_HOME%\com\deitel\messenger\rmi_iiop

rem
rem Compile the IDL file.  Write it to %example_home% and take the
rem module name and expand it to the full package name
rem
cd %example_home%
rmic -iiop -d %EXAMPLE_HOME% com.deitel.messenger.rmi_iiop.server.ChatServerImpl
rmic -iiop -d %EXAMPLE_HOME% com.deitel.messenger.rmi_iiop.client.RMIIIOPMessageManager

cd %cur_dir%