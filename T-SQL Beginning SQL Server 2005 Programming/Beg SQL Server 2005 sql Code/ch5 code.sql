SELECT e.EmployeeID, c.FirstName, c.LastName, City
FROM HumanResources.Employee AS e
JOIN Person.Contact c
ON e.ContactID = c.ContactID
JOIN HumanResources.EmployeeAddress AS ea
ON e.EmployeeID = ea.EmployeeID
JOIN Person.Address AS a
ON ea.AddressID = a.AddressID

CREATE DATABASE Accounting
ON
(NAME = 'Accounting',
FILENAME = 'c:\Program Files\Microsoft SQL Server\@@ta MSSQL.1\mssql\data\AccountingData.mdf'
SIZE = 10,
MAXSIZE = 50,
FILEGROWTH = 5)
LOG ON
(NAME = 'AccountingLog',
FILENAME = 'c:\Program Files\Microsoft SQL Server\@@ta MSSQL.1\mssql\data\AccountingLog.ldf'
SIZE = 5MB,
MAXSIZE = 25MB,
FILEGROWTH = 5MB)
GO

EXEC sp_helpdb 'Accounting'

CREATE TABLE Customers
USE Accounting
CREATE TABLE Customers
(
CustomerNo    int         IDENTITY  NOT NULL,
CustomerName  varchar(30)                NOT NULL,
Address1      varchar(30)                NOT NULL,
Address2      varchar(30)                NOT NULL,
City          varchar(20)                NOT NULL,
State         char(2)                    NOT NULL,
Zip           varchar(10)                NOT NULL,
Contact       varchar(25)                NOT NULL,
Phone         char(15)                   NOT NULL,
FedIDNo       varchar(9)                 NOT NULL,
DateInSystem  smalldatetime              NOT NULL
)

EXEC sp_help Customers

CREATE TABLE Employees
(
EmployeeID       int          IDENTITY  NOT NULL,
FirstName        varchar(25)            NOT NULL,
MiddleInitial    char(1)                NULL,
LastName         varchar(25)            NOT NULL,
Title            varchar(25)            NOT NULL,
SSN              varchar(11)            NOT NULL,
Salary           money                  NOT NULL,
PriorSalary      money                  NOT NULL,
LastRaise AS Salary - PriorSalary,
HireDate         smalldatetime          NOT NULL,
TerminationDate  smalldatetime          NULL,
ManagerEmpID     int                    NOT NULL,
Department       varchar(25)            NOT NULL
)

USE Accounting
CREATE TABLE Employees
(
EmployeeID       int          IDENTITY  NOT NULL,
FirstName        varchar(25)            NOT NULL,
MiddleInitial    char(1)                NULL,
LastName         varchar(25)            NOT NULL,
Title            varchar(25)            NOT NULL,
SSN              varchar(11)            NOT NULL,
Salary           money                  NOT NULL,
PriorSalary      money                  NOT NULL,
LastRaise AS Salary - PriorSalary,
HireDate         smalldatetime          NOT NULL,
TerminationDate  smalldatetime          NULL,
ManagerEmpID     int                     NOT NULL,
Department       varchar(25)            NOT NULL
)


ALTER DATABASE Accounting
MODIFY FILE
(NAME = Accounting,
SIZE = 100MB)

EXEC sp_helpdb Accounting

EXEC sp_help Employees

ALTER TABLE Employees
ADD
PreviousEmployer   varchar(30)   NULL
ALTER TABLE Employees
ADD
DateOfBirth     datetime   NULL,
LastRaiseDate   datetime   NOT NULL
DEFAULT '2005-01-01'

EXEC sp_help Employees


USE Accounting
DROP TABLE Customers, Employees

USE master
DROP DATABASE Accounting
