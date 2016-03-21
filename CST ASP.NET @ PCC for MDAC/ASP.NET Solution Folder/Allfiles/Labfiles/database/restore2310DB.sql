restore database doctors
from disk='c:\Program Files\Msdntrain\2310\Labfiles\database\doctors.bak'
with recovery,
move 'doctors' to 'c:\Program Files\Microsoft SQL Server\MSSQL\Data\doctors.mdf',
move 'doctors_log' to 'c:\Program Files\Microsoft SQL Server\MSSQL\Data\doctors.ldf'

GO

restore database dentists
from disk='c:\Program Files\Msdntrain\2310\Labfiles\database\dentists.bak'
with recovery,
move 'dentists_data' to 'c:\Program Files\Microsoft SQL Server\MSSQL\Data\dentists.mdf',
move 'dentists_log' to 'c:\Program Files\Microsoft SQL Server\MSSQL\Data\dentists.ldf'

GO

restore database Coho
from disk='c:\Program Files\Msdntrain\2310\Labfiles\database\coho.bak'
with recovery,
move 'coho_data' to 'c:\Program Files\Microsoft SQL Server\MSSQL\Data\coho.mdf',
move 'coho_log' to 'c:\Program Files\Microsoft SQL Server\MSSQL\Data\coho.ldf'

GO
---Configure Doctors
USE doctors

GO

DECLARE @s varchar(50)
SELECT @s = @@servername + '\ASPNET'
EXECUTE sp_grantlogin @s

EXECUTE sp_grantdbaccess @s, 'webuser'

GO

GRANT EXECUTE ON [getUniqueCities] TO webuser
GRANT EXECUTE ON [getDrSpecialty] TO webuser

GO


GRANT SELECT ON [specialties] TO webuser
GRANT SELECT ON [doctors] TO webuser
GRANT SELECT ON [drspecialties] TO webuser

GO

--Now do the same for Dentists

USE Dentists


GO

DECLARE @s varchar(50)
SELECT @s = @@servername + '\ASPNET'
EXECUTE sp_grantlogin @s

EXECUTE sp_grantdbaccess @s, 'webuser'

GO

GRANT EXECUTE ON [DentistsByPostalCode] TO webuser

GO


GRANT SELECT ON [Dentists] TO webuser

GO

---Configure Coho---------------

USE Coho

GO

DECLARE @s varchar(50)
SELECT @s = @@servername + '\ASPNET'
EXECUTE sp_grantlogin @s

EXECUTE sp_grantdbaccess @s, 'webuser'

GO

GRANT EXECUTE ON [EmployeeAdd] TO webuser
GRANT EXECUTE ON [EmployeeLogin] TO webuser

GO

---For the Demos-------

USE Northwind
GO
DECLARE @s varchar(50)
SELECT @s = @@servername + '\ASPNET'
EXECUTE sp_grantlogin @s
EXECUTE sp_grantdbaccess @s, 'webuser'

GRANT EXECUTE ON [Sales by Year] TO webuser
GRANT EXECUTE ON [Ten Most Expensive Products] TO webuser

GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [Customers] TO webuser
GRANT SELECT, INSERT, UPDATE, DELETE ON [Orders] TO webuser
GRANT SELECT, INSERT, UPDATE, DELETE ON [Products] TO webuser

GO
-------more demos-------------
USE Pubs
GO
DECLARE @s varchar(50)
SELECT @s = @@servername + '\ASPNET'
EXECUTE sp_grantlogin @s
EXECUTE sp_grantdbaccess @s, 'webuser'

GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [authors] TO webuser
GRANT SELECT, INSERT, UPDATE, DELETE ON [titles] TO webuser
GRANT SELECT, INSERT, UPDATE, DELETE ON [publishers] TO webuser
GRANT SELECT, INSERT, UPDATE, DELETE ON [stores] TO webuser

GO

