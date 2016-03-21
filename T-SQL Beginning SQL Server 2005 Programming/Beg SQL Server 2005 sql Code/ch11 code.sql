USE Northwind
DECLARE @Ident int
INSERT INTO Orders
(CustomerID,OrderDate)
VALUES
('ALFKI', DATEADD(day,-1,GETDATE()))
SELECT @Ident = @@IDENTITY
INSERT INTO [Order Details]
(OrderID, ProductID, UnitPrice, Quantity)
VALUES
(@Ident, 1, 50, 25)
SELECT 'The OrderID of the INSERTed row is ' + CONVERT(varchar(8),@Ident)

SET @TotalCost = 10
SET @TotalCost = @UnitCost * 1.1
USE Northwind
DECLARE @Test money
SET @Test = MAX(UnitPrice) FROM [Order Details]
SELECT @Test
USE Northwind
DECLARE @Test money
SET @Test = (SELECT MAX(UnitPrice) FROM [Order Details])
SELECT @Test

USE Northwind
DECLARE @Test money
SELECT @Test = MAX(UnitPrice) FROM [Order Details]
SELECT @Test
CREATE TABLE TestIdent
(
IDCol   int   IDENTITY
PRIMARY KEY
)
CREATE TABLE TestChild1
(
IDcol   int
PRIMARY KEY
FOREIGN KEY
REFERENCES TestIdent(IDCol)
)
CREATE TABLE TestChild2
(
IDcol   int
PRIMARY KEY
FOREIGN KEY
REFERENCES TestIdent(IDCol)
)

/*****************************************
* This script illustrates how the identity
* value gets lost as soon as another INSERT
* happens
****************************************** */
DECLARE @Ident   int  -- This will be a holding variable
-- We'll use it to show how we can
-- move values from system functions
-- into a safe place.
INSERT INTO TestIdent
DEFAULT VALUES
SET @Ident = @@IDENTITY
PRINT 'The value we got originally from @@IDENTITY was ' +
CONVERT(varchar(2),@Ident)
PRINT 'The value currently in @@IDENTITY is ' + CONVERT(varchar(2),@@IDENTITY)
/* On this first INSERT using @@IDENTITY, we're going to get lucky.
** We'll get a proper value because there is nothing between our
** original INSERT and this one. You'll see that on the INSERT that
** will follow after this one, we won't be so lucky anymore. */
INSERT INTO TestChild1
VALUES
(@@IDENTITY)
PRINT 'The value we got originally from @@IDENTITY was ' +
CONVERT(varchar(2),@Ident)
IF (SELECT @@IDENTITY) IS NULL
PRINT 'The value currently in @@IDENTITY is NULL'
ELSE
PRINT 'The value currently in @@IDENTITY is ' + CONVERT(varchar(2),@@IDENTITY)
-- The next line is just a spacer for our print out
PRINT ''
/* The next line is going to blow up because the one column in
** the table is the primary key, and primary keys can't be set
** to NULL. @@IDENTITY will be NULL because we just issued an
** INSERT statement a few lines ago, and the table we did the
** INSERT into doesn't have an identity field. Perhaps the biggest
** thing to note here is when @@IDENTITY changed - right after
** the next INSERT statement. */
INSERT INTO TestChild2
VALUES
(@@IDENTITY)

/*****************************************
* This script illustrates how the identity
* value gets lost as soon as another INSERT
* happens
****************************************** */
DECLARE @Ident   int  -- This will be a holding variable
-- We'll use it to show how we can
-- move values from system functions
-- into a safe place.
INSERT INTO TestIdent
DEFAULT VALUES
SET @Ident = @@IDENTITY
PRINT 'The value we got originally from @@IDENTITY was ' +
CONVERT(varchar(2),@Ident)
PRINT 'The value currently in @@IDENTITY is ' + CONVERT(varchar(2),@@IDENTITY)
/* On this first INSERT using @@IDENTITY, we're going to get lucky.
** We'll get a proper value because there is nothing between our
** original INSERT and this one. You'll see that on the INSERT that
** will follow after this one, we won't be so lucky anymore. */
INSERT INTO TestChild1
VALUES
(@@IDENTITY)
PRINT 'The value we got originally from @@IDENTITY was ' +
CONVERT(varchar(2),@Ident)
IF (SELECT @@IDENTITY) IS NULL
PRINT 'The value currently in @@IDENTITY is NULL'
ELSE
PRINT 'The value currently in @@IDENTITY is ' + CONVERT(varchar(2),@@IDENTITY)
-- The next line is just a spacer for our print out
PRINT ''
/* This time all will go fine because we are using the value that
** we have placed in safekeeping instead of @@IDENTITY directly.*/
INSERT INTO TestChild2
VALUES
(@Ident)

USE Northwind
SELECT * FROM Categories

USE Northwind
GO
DECLARE @RowCount int -- Notice the single @ sign
SELECT * FROM Categories
SELECT @RowCount = @@ROWCOUNT
PRINT 'The value of @@ROWCOUNT was ' + CAST(@RowCount AS varchar(5))

SELECT * FROM Customers WHERE CustomerID = 'ALFKI' GO

USE AdventureWorks
DECLARE @MyVarchar varchar(50)  --This DECLARE only lasts for this batch!
SELECT @MyVarchar = 'Honey, I''m home...'
PRINT 'Done with first Batch...'
GO
PRINT @MyVarchar  --This generates an error since @MyVarchar
--isn't declared in this batch
PRINT 'Done with second Batch'
GO
PRINT 'Done with third batch'   -- Notice that this still gets executed
-- even after the error
GO

CREATE DATABASE Test
CREATE TABLE TestTable
(
col1   int,
col2   int
)

SELECT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='TestTable'

USE MASTER
DROP DATABASE Test
CREATE DATABASE Test
USE Test
CREATE TABLE TestTable
(
col1   int,
col2   int
)

CREATE DATABASE Test
GO
USE Test
CREATE TABLE TestTable
(
col1   int,
col2   int
)

USE Test
ALTER TABLE TestTable
ADD col3 int
INSERT INTO TestTable
(col1, col2, col3)
VALUES
(1,1,1)


USE Northwind
DECLARE @Ident int
INSERT INTO Orders
(CustomerID,OrderDate)
VALUES
('ALFKI', DATEADD(day,-1,GETDATE()))
SELECT @Ident = @@IDENTITY
INSERT INTO [Order Details]
(OrderID, ProductID, UnitPrice, Quantity)
VALUES
(@Ident, 1, 50, 25)
SELECT 'The OrderID of the INSERTed row is ' + CONVERT(varchar(8),@Ident)

USE Northwind
GO
--Create The Table. We'll pull info from here for our dynamic SQL
CREATE TABLE DynamicSQLExample
(
TableID   int   IDENTITY   NOT NULL
CONSTRAINT PKDynamicSQLExample
PRIMARY KEY,
TableName varchar(128)     NOT NULL
)
GO

/* Populate the table. In this case, We're grabbing every user
** table object in this database                             */
INSERT INTO DynamicSQLExample
SELECT TABLE_NAME
FROM Information_Schema.Tables
WHERE TABLE_TYPE = 'BASE TABLE'

/* First, declare a variable to hold the table name. Remember,
** object names can be 128 characters long
*/
DECLARE @TableName      varchar(128)
-- Now, grab the table name that goes with our ID
SELECT @TableName = TableName
FROM DynamicSQLExample
WHERE TableID = 14
-- Finally, pass that value into the EXEC statement
EXEC ('SELECT * FROM ' + @TableName)

USE Northwind
/* First, we'll declare to variables. One for stuff we're putting into
** the EXEC, and one that we think will get something back out (it won't)
*/
DECLARE @InVar   varchar(50)
DECLARE @OutVar  varchar(50)
-- Set up our string to feed into the EXEC command
SET @InVar = 'SELECT @OutVar = FirstName FROM Employees WHERE EmployeeID = 1'
-- Now run it
EXEC (@Invar)
-- Now, just to show there's no difference, run the select without using a in variable
EXEC ('SELECT @OutVar = FirstName FROM Employees WHERE EmployeeID = 1')
-- @OutVar will still be NULL because we haven't been able to put anything in it
SELECT @OutVar

USE Northwind
-- This time, we only need one variable. It does need to be longer though.
DECLARE @InVar	varchar(200)
/* Set up our string to feed into the EXEC command. This time we're going
** to feed it several statements at a time. They will all execute as one
** batch.
*/
SET @InVar = 'DECLARE @OutVar varchar(50)
SELECT @OutVar = FirstName FROM Employees WHERE EmployeeID = 1
SELECT ''The Value Is '' + @OutVar'
-- Now run it
EXEC (@Invar)

USE Northwind
EXEC('SELECT * FROM Customers')
SELECT 'The Rowcount is ' + CAST(@@ROWCOUNT as varchar)

USE Northwind
-- This won't work
DECLARE @NumberOfLetters int
SET @NumberOfLetters = 15
EXEC('SELECT LEFT(CompanyName,' + CAST(@NumberOfLetters AS varchar) + ') AS ShortName
FROM Customers')
GO
-- But this does
DECLARE @NumberOfLetters AS int
SET @NumberOfLetters = 15
DECLARE @str AS varchar(255)
SET @str = 'SELECT LEFT(CompanyName,' + CAST(@NumberOfLetters AS varchar) + ') AS
ShortName FROM Customers'
EXEC(@str)
