USE ASPState
GO

DECLARE @s varchar(50)
SELECT @s = @@servername + '\ASPNET'
EXECUTE sp_grantlogin @s

EXECUTE sp_grantdbaccess @s, 'webuser'

GO

GRANT EXECUTE ON CreateTempTables TO webuser
GRANT EXECUTE ON DeleteExpiredSessions TO webuser
GRANT EXECUTE ON DropTempTables TO webuser
GRANT EXECUTE ON ResetData TO webuser
GRANT EXECUTE ON TempGetAppID TO webuser
GRANT EXECUTE ON TempGetStateItem TO webuser
GRANT EXECUTE ON TempGetStateItemExclusive TO webuser
GRANT EXECUTE ON TempInsertStateItemLong TO webuser
GRANT EXECUTE ON TempInsertStateItemShort TO webuser
GRANT EXECUTE ON TempReleaseStateItemExclusive TO webuser
GRANT EXECUTE ON TempRemoveStateItem TO webuser
GRANT EXECUTE ON TempResetTimeout TO webuser
GRANT EXECUTE ON TempUpdateStateItemLong TO webuser
GRANT EXECUTE ON TempUpdateStateItemLongNullShort TO webuser
GRANT EXECUTE ON TempUpdateStateItemShort TO webuser
GRANT EXECUTE ON TempUpdateStateItemShortNullLong TO webuser

GO


USE tempdb

GO

--DECLARE @s varchar(50)
--SELECT @s = @@servername + '\ASPNET'
--EXECUTE sp_grantlogin @s
--
--EXECUTE sp_grantdbaccess @s, 'webuser'

--GO

--GRANT EXECUTE ON DentistsByPostalCode TO webuser

--GO


GRANT SELECT, INSERT, UPDATE, DELETE ON ASPStateTempApplications TO guest
GRANT SELECT, INSERT, UPDATE, DELETE ON ASPStateTempSessions TO guest

GO