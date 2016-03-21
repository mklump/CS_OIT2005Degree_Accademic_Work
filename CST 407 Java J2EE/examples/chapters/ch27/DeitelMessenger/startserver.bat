set JAVA_HOME=c:\usr\local\bin\jdk1.3

set PATH=%JAVA_HOME%\bin;%path%

set EXAMPLE_HOME=c:\advjhtp1\src

rem
rem Set this to where the path to the class files begins
rem
set CURDIR=%example_home%\com\deitel\messenger\rmi_iiop

cd %example_home%

java -Djava.naming.factory.initial=com.sun.jndi.cosnaming.CNCtxFactory -Djava.naming.provider.url=iiop://localhost:1050 com.deitel.messenger.rmi_iiop.server.ChatServerAdministrator start

rem
rem Take us back
rem

cd %CUR_DIR%
