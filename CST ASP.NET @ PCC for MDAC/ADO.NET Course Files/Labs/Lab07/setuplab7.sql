/* WARNING */
/* This script should only be executed on the Instructor machine */

USE Northwind

/* Add EmployeesLatest table to Northwind */

SET NOCOUNT ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[EmployeesLatest]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [EmployeesLatest]
GO

CREATE TABLE [EmployeesLatest] (
	[EmployeeID] [int] IDENTITY (1, 1) NOT NULL ,
	[LastName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FirstName] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Title] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TitleOfCourtesy] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[BirthDate] [datetime] NULL ,
	[HireDate] [datetime] NULL ,
	[Address] [nvarchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[City] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Region] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PostalCode] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Country] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[HomePhone] [nvarchar] (24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Extension] [nvarchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Photo] [image] NULL ,
	[Notes] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ReportsTo] [int] NULL ,
	[PhotoPath] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	CONSTRAINT [PK_EmployeesLatest] PRIMARY KEY  CLUSTERED 
	(
		[EmployeeID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_EmployeesLatest_EmployeesLatest] FOREIGN KEY 
	(
		[ReportsTo]
	) REFERENCES [EmployeesLatest] (
		[EmployeeID]
	),
	CONSTRAINT [CK_BirthdateLatest] CHECK ([BirthDate] < getdate())
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO EmployeesLatest
(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, 
ReportsTo, PhotoPath)
SELECT LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, 
ReportsTo, PhotoPath
FROM Employees
GO

INSERT INTO EmployeesLatest(
LastName, FirstName)
VALUES('Smith', 'John')
GO

/* Add MaryJane login to Northwind */

if exists (select * from dbo.sysusers where name = N'MaryJane')
BEGIN
EXEC sp_revokedbaccess 'MaryJane'
EXEC sp_droplogin 'MaryJane'
END
GO

EXEC sp_addlogin 'MaryJane', 'secret', 'Northwind'
GO

EXEC sp_grantdbaccess 'MaryJane'
GO

GRANT SELECT ON EmployeesLatest TO MaryJane
GO