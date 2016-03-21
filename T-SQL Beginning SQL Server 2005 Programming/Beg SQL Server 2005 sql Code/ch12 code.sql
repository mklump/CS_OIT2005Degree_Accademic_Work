USE Northwind
GO
CREATE PROC spShippers
AS
SELECT * FROM Shippers

EXEC spShippers

USE Northwind
GO
CREATE PROC spInsertShipper
@CompanyName   nvarchar(40),
@Phone         nvarchar(24)
AS
INSERT INTO Shippers
VALUES
(@CompanyName, @Phone)

EXEC spInsertShipper 'Speedy Shippers, Inc.', '(503) 555-5566'

EXEC spShippers

EXEC spInsertShipper 'Speedy Shippers, Inc.'

USE Northwind
GO
CREATE PROC spInsertShipperOptionalPhone
@CompanyName   nvarchar(40),
@Phone         nvarchar(24) = NULL
AS
INSERT INTO Shippers
VALUES
(@CompanyName, @Phone)

EXEC spInsertShipperOptionalPhone 'Speedy Shippers, Inc'

EXEC spShippers

USE Northwind
GO
CREATE PROC spInsertOrder
@CustomerID       nvarchar(5),
@EmployeeID       int,
@OrderDate        datetime      = NULL,
@RequiredDate     datetime      = NULL,
@ShippedDate      datetime      = NULL,
@ShipVia          int,
@Freight          money,
@ShipName         nvarchar(40)  = NULL,
@ShipAddress      nvarchar(60)  = NULL,
@ShipCity         nvarchar(15)  = NULL,
@ShipRegion       nvarchar(15)  = NULL,
@ShipPostalCode   nvarchar(10)  = NULL,
@ShipCountry      nvarchar(15)  = NULL,
@OrderID          int      OUTPUT
AS
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@OrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY
USE Northwind
GO
DECLARE   @MyIdent   int

EXEC spInsertOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate = '5/1/1999',
@ShipVia = 3,
@Freight = 5.00,
@OrderID = @MyIdent OUTPUT

SELECT @MyIdent AS IdentityValue

SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent

IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7
SELECT @OrderDate = NULL

USE Northwind
GO
CREATE PROC spInsertDateValidatedOrder
@CustomerID       nvarchar(5),
@EmployeeID       int,
@OrderDate        datetime     = NULL,
@RequiredDate     datetime     = NULL,
@ShippedDate      datetime     = NULL,
@ShipVia          int,
@Freight          money,
@ShipName         nvarchar(40) = NULL,
@ShipAddress      nvarchar(60) = NULL,
@ShipCity         nvarchar(15) = NULL,
@ShipRegion       nvarchar(15) = NULL,
@ShipPostalCode   nvarchar(10) = NULL,
@ShipCountry      nvarchar(15) = NULL,
@OrderID               int      OUTPUT
AS
/* Test to see if supplied date is over seven days old, if so
replace with NULL value                                 */
IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7
SELECT @OrderDate = NULL
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@OrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY

USE Northwind
GO
DECLARE   @MyIdent   int

EXEC spInsertDateValidatedOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate = '5/1/1999',
@ShipVia = 3,
@Freight = 5.00,
@OrderID = @MyIdent OUTPUT
SELECT @MyIdent AS IdentityValue
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent

USE Northwind
GO

SELECT TOP 5 OrderID, OrderDate
FROM Orders
WHERE OrderDate IS NOT NULL
ORDER BY OrderDate

USE Northwind
GO
DECLARE   @MyIdent   int
DECLARE   @MyDate    smalldatetime
SELECT @MyDate = GETDATE()
EXEC spInsertDateValidatedOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate  = @MyDate,
@ShipVia    = 3,
@Freight = 5.00,
@OrderID = @MyIdent OUTPUT
SELECT @MyIdent AS IdentityValue
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent

USE Northwind
GO
ALTER PROC spInsertDateValidatedOrder
@CustomerID     nvarchar(5),
@EmployeeID     int,
@OrderDate      datetime     = NULL,
@RequiredDate   datetime     = NULL,
@ShippedDate    datetime     = NULL,
@ShipVia        int,
@Freight        money,
@ShipName       nvarchar(40) = NULL,
@ShipAddress    nvarchar(60) = NULL,
@ShipCity       nvarchar(15) = NULL,
@ShipRegion     nvarchar(15) = NULL,
@ShipPostalCode nvarchar(10) = NULL,
@ShipCountry    nvarchar(15) = NULL,
@OrderID        int      OUTPUT
AS
/* I don't like altering input parameters - I find that it helps in debugging
** if I can refer to their original values at any time. Therefore, I'm going
** to declare a separate variable to assign the end value we will be
** inserting into the table. */
DECLARE   @InsertedOrderDate   smalldatetime
/* Test to see if supplied date is over seven days old, if so
** replace with NULL value
** otherwise, truncate the time to be midnight */
IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7
SELECT @InsertedOrderDate = NULL
ELSE
SELECT @InsertedOrderDate =
CONVERT(datetime,(CONVERT(varchar,@OrderDate,112)))
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@InsertedOrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY

USE Northwind
GO
ALTER PROC spInsertDateValidatedOrder
@CustomerID              nvarchar(5),
@EmployeeID              int,
@OrderDate        datetime     = NULL,
@RequiredDate     datetime     = NULL,
@ShippedDate      datetime     = NULL,
@ShipVia          int,
@Freight          money,
@ShipName         nvarchar(40) = NULL,
@ShipAddress      nvarchar(60) = NULL,
@ShipCity         nvarchar(15) = NULL,
@ShipRegion       nvarchar(15) = NULL,
@ShipPostalCode   nvarchar(10) = NULL,
@ShipCountry      nvarchar(15) = NULL,
@OrderID          int      OUTPUT
AS
/* I don't like altering input paramters - I find that it helps in debugging
** if I can refer to their original value at any time. Therefore, I'm going
** to declare a separate variable to assign the end value we will be
** inserting into the table. */
DECLARE   @InsertedOrderDate   smalldatetime
/* Test to see if supplied date is over seven days old, if so
** replace with NULL value
** otherwise, truncate the time to be midnight*/
IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7
BEGIN
SELECT @InsertedOrderDate = NULL
PRINT 'Invalid Order Date'
PRINT 'Supplied Order Date was greater than 7 days old.'
PRINT 'The value has been reset to NULL'
END
ELSE
BEGIN
SELECT @InsertedOrderDate =
CONVERT(datetime,(CONVERT(varchar,@OrderDate,112)))
PRINT 'The Time of Day in Order Date was truncated'
END
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@InsertedOrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY
USE Northwind
GO
DECLARE   @MyIdent   int
DECLARE   @MyDate    smalldatetime
SELECT @MyDate = GETDATE()
EXEC spInsertDateValidatedOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate  = @MyDate,
@ShipVia    = 3,
@Freight    = 5.00,
@OrderID    = @MyIdent OUTPUT
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent

USE Northwind
GO
DECLARE  @MyIdent          int
EXEC spInsertDateValidatedOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate  = '1/1/1999',
@ShipVia    = 3,
@Freight    = 5.00,
@OrderID    = @MyIdent OUTPUT
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent

USE Northwind
GO
SELECT TOP 10 OrderID, OrderID % 10 AS 'Last Digit', Position =
CASE OrderID % 10
WHEN 1 THEN 'First'
WHEN 2 THEN 'Second'
WHEN 3 THEN 'Third'
WHEN 4 THEN 'Fourth'
ELSE 'Something Else'
END
FROM Orders

USE Northwind
GO
SELECT TOP 10 OrderID % 10 AS "Last Digit",
ProductID,
"How Close?" = CASE OrderID % 10
WHEN ProductID THEN 'Exact Match!'
WHEN ProductID - 1 THEN 'Within 1'
WHEN ProductID + 1 THEN 'Within 1'
ELSE 'More Than One Apart'
END
FROM [Order Details]
WHERE ProductID < 10
ORDER BY OrderID DESC

USE Northwind
GO
SELECT TOP 10 OrderID % 10 AS "Last Digit",
ProductID,
"How Close?" = CASE
WHEN (OrderID % 10) < 3 THEN 'Ends With Less Than Three'
WHEN ProductID = 6 THEN 'ProductID is 6'
WHEN ABS(OrderID % 10 - ProductID) <= 1 THEN 'Within 1'
ELSE 'More Than One Apart'
END
FROM [Order Details]
WHERE ProductID < 10
ORDER BY OrderID DESC

USE Northwind
GO
/* I'm setting up some holding variables here. This way, if we get asked
** to run the query again with a slightly different value, we'll only have
** to change it in one place.
*/
DECLARE @Markup     money
DECLARE @Multiplier money
SELECT @Markup = .10                -- Change the markup here
SELECT @Multiplier = @Markup + 1    -- We want the end price, not the amount
-- of the increase, so add 1
/* Now execute things for our results. Note that we're limiting things
** to the top 10 items for brevity - in reality, we either wouldn't do this
** at all, or we would have a more complex WHERE clause to limit the
** increase to a particular set of products
*/
SELECT TOP 10 ProductID, ProductName, UnitPrice,
UnitPrice * @Multiplier AS "Marked Up Price", "New Price" =
CASE WHEN FLOOR(UnitPrice * @Multiplier + .24)
> FLOOR(UnitPrice * @Multiplier)
THEN FLOOR(UnitPrice * @Multiplier) + .95
WHEN FLOOR(UnitPrice * @Multiplier + .5) >
FLOOR(UnitPrice * @Multiplier)
THEN FLOOR(UnitPrice * @Multiplier) + .75
ELSE FLOOR(UnitPrice * @Multiplier) + .49
END
FROM Products
ORDER BY ProductID DESC	      -- Just because the bottom's a better example
-- in this particular case
USE Northwind
GO
CREATE PROC spMarkupTest
@MarkupAsPercent   money
AS
DECLARE @Multiplier money
-- We want the end price, not the amount
SELECT @Multiplier = @MarkupAsPercent / 100 + 1 /*of the increase, so add 1
** Now execute things for our results. Note that we're limiting things
** to the top 10 items for brevity - in reality, we either wouldn't do this
** at all, or we would have a more complex WHERE clause to limit the
** increase to a particular set of products
*/
SELECT TOP 10 ProductId, ProductName, UnitPrice,
UnitPrice * @Multiplier AS "Marked Up Price", "New Price" =
CASE WHEN FLOOR(UnitPrice * @Multiplier + .24) > FLOOR(UnitPrice * @Multiplier)
THEN FLOOR(UnitPrice * @Multiplier) + .95
WHEN FLOOR(UnitPrice  * @Multiplier + .5) >
FLOOR(UnitPrice * @Multiplier)
THEN FLOOR(UnitPrice * @Multiplier) + .75
ELSE FLOOR(UnitPrice * @Multiplier) + .49
END
FROM Products
ORDER BY ProductID DESC   -- Just because the bottom's a better example
-- in this particular case

EXEC spMarkupTest 10

WHILE 1 = 1
BEGIN
WAITFOR TIME '01:00'
EXEC sp_updatestats
RAISERROR('Statistics Updated for Database', 1, 1) WITH LOG
END

WAITFOR DELAY '01:00'
WAITFOR TIME '01:00'

USE Northwind
GO
CREATE PROC spTestReturns
AS
DECLARE @MyMessage        varchar(50)
DECLARE @MyOtherMessage   varchar(50)
SELECT @MyMessage = 'Hi, it''s that line before the RETURN'
PRINT @MyMessage
RETURN
SELECT @MyOtherMessage = 'Sorry, but we won''t get this far'
PRINT @MyOtherMessage
RETURN
EXEC @ReturnVal = spMySproc
DECLARE @Return int
EXEC @Return = spTestReturns
SELECT @Return

USE Northwind
GO
ALTER PROC spTestReturns
AS
DECLARE @MyMessage        varchar(50)
DECLARE @MyOtherMessage   varchar(50)
SELECT @MyMessage = 'Hi, it''s that line before the RETURN'
PRINT @MyMessage
RETURN 100
SELECT @MyOtherMessage = 'Sorry, but we won''t get this far'
PRINT @MyOtherMessage
RETURN

USE Northwind
GO
INSERT INTO [Order Details]
(OrderID, ProductID, UnitPrice, Quantity, Discount)
VALUES
(999999,11,10.00,10, 0)

USE Northwind
GO
DECLARE   @Error   int
-- Bogus INSERT - there is no OrderID of 999999 in Northind
INSERT INTO [Order Details]
(OrderID, ProductID, UnitPrice, Quantity, Discount)
VALUES
(999999,11,10.00,10, 0)
-- Move our error code into safe keeping. Note that, after this statement,
-- @@Error will be reset to whatever error number applies to this statement
SELECT @Error = @@ERROR
-- Print out a blank separator line
PRINT ''
-- The value of our holding variable is just what we would expect
PRINT 'The Value of @Error is ' + CONVERT(varchar, @Error)
-- The value of @@ERROR has been reset - it's back to zero
PRINT 'The Value of @@ERROR is ' + CONVERT(varchar, @@ERROR)

USE Northwind
GO
DECLARE   @MyIdent   int
DECLARE   @MyDate           smalldatetime
SELECT @MyDate = GETDATE()
EXEC spInsertDateValidatedOrder
@CustomerID = 'ZXZXZ',
@EmployeeID = 5,
@OrderDate  = @MyDate,
@ShipVia    = 3,
@Freight    = 5.00,
@OrderID    = @MyIdent OUTPUT
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent

USE Northwind
GO
ALTER PROC spInsertDateValidatedOrder
@CustomerID       nvarchar(5),
@EmployeeID       int,
@OrderDate        datetime     = NULL,
@RequiredDate     datetime     = NULL,
@ShippedDate      datetime     = NULL,
@ShipVia          int,
@Freight          money,
@ShipName         nvarchar(40) = NULL,
@ShipAddress      nvarchar(60) = NULL,
@ShipCity         nvarchar(15) = NULL,
@ShipRegion       nvarchar(15) = NULL,
@ShipPostalCode   nvarchar(10) = NULL,
@ShipCountry      nvarchar(15) = NULL,
@OrderID          int      OUTPUT
AS
-- Declare our variables
DECLARE   @Error               int
DECLARE   @InsertedOrderDate   smalldatetime
/* Test to see if supplied date is over seven days old, if so
** replace with NULL value
** otherwise, truncate the time to be midnight*/
IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7
BEGIN
SELECT @InsertedOrderDate = NULL
PRINT 'Invalid Order Date'
PRINT 'Supplied OrderDate was greater than 7 days old.'
PRINT 'The value has been reset to NULL'
END
ELSE
BEGIN
SELECT @InsertedOrderDate =
CONVERT(datetime,(CONVERT(varchar,@OrderDate,112)))
PRINT 'The Time of Day in Order Date was truncated'
END
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@InsertedOrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
-- Move it to our local variable and check for an error condition
SELECT @Error = @@ERROR
IF @Error != 0
BEGIN
-- Uh, oh - something went wrong.
IF @Error = 547
-- The problem is a constraint violation. Print out some informational
-- help to steer the user to the most likely problem.
BEGIN
PRINT 'Supplied data violates data integrity rules'
PRINT 'Check that the supplied customer number exists'
PRINT 'in the system and try again'
END
ELSE
-- Oops, it's something we haven't anticipated, tell them that we
-- don't know, print out the error.
BEGIN
PRINT 'An unknown error occurred. Contact your System Administrator'
PRINT 'The error was number ' + CONVERT(varchar, @Error)
END
-- Regardless of the error, we're going to send it back to the calling
-- piece of code so it can be handled at that level if necessary.
RETURN @Error
END
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY
RETURN
USE Northwind
GO
DECLARE   @MyIdent   int
DECLARE   @MyDate           smalldatetime
DECLARE   @Return    int
SELECT @MyDate = GETDATE()
EXEC @Return = spInsertDateValidatedOrder
@CustomerID = 'ZXZXZ',
@EmployeeID = 5,
@OrderDate  = @MyDate,
@ShipVia    = 3,
@Freight    = 5.00,
@OrderID    = @MyIdent OUTPUT
IF @Return = 0
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent
ELSE
PRINT 'Value Returned was ' + CONVERT(varchar, @Return)

USE Northwind
GO
ALTER PROC spInsertDateValidatedOrder
@CustomerID       nvarchar(5),
@EmployeeID       int,
@OrderDate        datetime = NULL,
@RequiredDate     datetime = NULL,
@ShippedDate      datetime = NULL,
@ShipVia          int,
@Freight          money,
@ShipName         nvarchar(40) = NULL,
@ShipAddress      nvarchar(60) = NULL,
@ShipCity         nvarchar(15) = NULL,
@ShipRegion       nvarchar(15) = NULL,
@ShipPostalCode   nvarchar(10) = NULL,
@ShipCountry      nvarchar(15) = NULL,
@OrderID          int      OUTPUT
AS
-- Declare our variables
DECLARE   @Error               int
DECLARE   @InsertedOrderDate   smalldatetime
/* Here we're going to declare our constants. SQL Server doesn't really
** have constants in the classic sense, but I just use a standard
** variable in their place. These help your code be more readable
** - particularly when you match them up with a constant list in your
** client. */
DECLARE   @INVALIDDATE   int
/* Now that the constants are declared, we need to initialize them.
** Notice that SQL Server ignores the white space in between the
** variable and the "=" sign. Why I put in the spacing would be more
** obvious if we had several such constants - the constant values
** would line up nicely for readability
*/
SELECT @INVALIDDATE = -1000
/* Test to see if supplied date is over seven days old, if so
** it is no longer valid. Also test for NULL values.
** If either case is true, then terminate sproc with error
** message printed out.	 */
IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7 OR @OrderDate IS NULL
BEGIN
PRINT 'Invalid Order Date'
PRINT 'Supplied Order Date was greater than 7 days old '
PRINT 'or was NULL. Correct the date and resubmit.'
RETURN @INVALIDDATE
END
-- We made it this far, so it must be OK to go on with things.
SELECT @InsertedOrderDate =
CONVERT(datetime,(CONVERT(varchar,@OrderDate,112)))
PRINT 'The Time of Day in Order Date was truncated'
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@InsertedOrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
-- Move it to our local variable, and check for an error condition
SELECT @Error = @@ERROR
IF @Error != 0
BEGIN
-- Uh, oh - something went wrong.
IF @Error = 547
-- The problem is a constraint violation. Print out some informational
-- help to steer the user to the most likely problem.
BEGIN
PRINT 'Supplied data violates data integrity rules'
PRINT 'Check that the supplied customer number exists'
PRINT 'in the system and try again'
END
ELSE
-- Oops, it's something we haven't anticipated, tell them here that we
-- don't know, print out the error.
BEGIN
PRINT 'An unknown error occurred. Contact your System Administrator'
PRINT 'The error was number ' + CONVERT(varchar, @Error)
END
-- Regardless of the error, we're going to send it back to the calling
-- piece of code so it can be handled at that level if necessary.
RETURN @Error
END
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY
RETURN

USE Northwind
GO
DECLARE   @MyIdent   int
DECLARE   @MyDate           smalldatetime
DECLARE   @Return           int
SELECT @MyDate = '1/1/1999'
EXEC @Return = spInsertDateValidatedOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate = @MyDate,
@ShipVia = 3,
@Freight = 5.00,
@OrderID = @MyIdent OUTPUT
IF @Return = 0
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent
ELSE
PRINT 'Value Returned was ' + CONVERT(varchar, @Return)


RAISERROR ('Hi there, I''m an error', 1, 1)

RAISERROR ("This is a sample parameterized %s, along with a zero
padding and a sign%+010d",1,1, "string", 12121)
Msg 50000, Level 1, State 50000

sp_addmessage
@msgnum = 60000,
@severity = 10,
@msgtext = '%s is not a valid Order date.

USE Northwind
GO
ALTER PROC spInsertDateValidatedOrder
@CustomerID       nvarchar(5),
@EmployeeID       int,
@OrderDate        datetime     = NULL,
@RequiredDate     datetime     = NULL,
@ShippedDate      datetime     = NULL,
@ShipVia          int,
@Freight          money,
@ShipName         nvarchar(40) = NULL,
@ShipAddress      nvarchar(60) = NULL,
@ShipCity         nvarchar(15) = NULL,
@ShipRegion       nvarchar(15) = NULL,
@ShipPostalCode   nvarchar(10) = NULL,
@ShipCountry      nvarchar(15) = NULL,
@OrderID          int      OUTPUT
AS
-- Declare our variables
DECLARE   @Error               int
DECLARE   @BadDate             varchar(12)
DECLARE   @InsertedOrderDate   smalldatetime
/* Test to see if supplied date is over seven days old, if so
** it is no longer valid. Also test for null values.
** If either case is true, then terminate sproc with error
** message printed out.	 */
IF DATEDIFF(dd, @OrderDate, GETDATE()) > 7 OR @OrderDate IS NULL
BEGIN
--RAISERROR doesn't have a date data type, so convert it first
SELECT @BadDate = CONVERT(varchar, @OrderDate)
RAISERROR (60000,1,1, @BadDate) WITH SETERROR
RETURN @@ERROR
END
-- We made it this far, so it must be OK to go on with things.
SELECT @InsertedOrderDate =
CONVERT(datetime,(CONVERT(varchar,@OrderDate,112)))
PRINT 'The Time of Day in Order Date was truncated'
/* Create the new record */
INSERT INTO Orders
VALUES
(
@CustomerID,
@EmployeeID,
@InsertedOrderDate,
@RequiredDate,
@ShippedDate,
@ShipVia,
@Freight,
@ShipName,
@ShipAddress,
@ShipCity,
@ShipRegion,
@ShipPostalCode,
@ShipCountry
)
-- Move it to our local variable, and check for an error condition
SELECT @Error = @@ERROR
IF @Error != 0
BEGIN
-- Uh, Oh - something went wrong.
IF @Error = 547
-- The problem is a constraint violation. Print out some informational
-- help to steer the user to the most likely problem.
BEGIN
PRINT 'Supplied data violates data integrity rules'
PRINT 'Check that the supplied customer number exists'
PRINT 'in the system and try again'
END
ELSE
-- Oops, it's something we haven't anticipated, tell them that we
-- don't know, print out the error.
BEGIN
PRINT 'An unknown error occurred. Contact your System Administrator'
PRINT 'The error was number ' + CONVERT(varchar, @Error)
END
-- Regardless of the error, we're going to send it back to the calling
-- piece of code so it can be handled at that level if necessary.
RETURN @Error
END
/* Move the identity value from the newly inserted record into
our output variable */
SELECT @OrderID = @@IDENTITY
RETURN
What a Sproc Offers
USE Northwind
GO
CREATE PROC spTestInsert
@MyDate   smalldatetime
AS
DECLARE   @MyIdent   int
DECLARE   @Return           int
EXEC @Return = spInsertDateValidatedOrder
@CustomerID = 'ALFKI',
@EmployeeID = 5,
@OrderDate  = @MyDate,
@ShipVia    = 3,
@Freight    = 5.00,
@OrderID    = @MyIdent OUTPUT
IF @Return = 0
SELECT OrderID, CustomerID, EmployeeID, OrderDate, ShipName
FROM Orders
WHERE OrderID = @MyIdent
ELSE
PRINT 'Error Returned was ' + CONVERT(varchar, @Return)
DECLARE @Today smalldatetime
SELECT @Today = GETDATE()
EXEC spTestInsert
@MyDate = @Today

EXEC spTestInsert '1/1/2004

EXEC spTestInsert '1/1/2004'
WITH RECOMPILE

CREATE PROC spFactorial
@ValueIn int,
@ValueOut int OUTPUT
AS
DECLARE @InWorking int
DECLARE @OutWorking int
IF @ValueIn != 1
BEGIN
SELECT @InWorking = @ValueIn - 1
EXEC spFactorial @InWorking, @OutWorking OUTPUT
SELECT @ValueOut = @ValueIn * @OutWorking
END
ELSE
BEGIN
SELECT @ValueOut = 1
END
RETURN
GO

DECLARE @WorkingOut int
DECLARE @WorkingIn int
SELECT @WorkingIn = 5
EXEC spFactorial @WorkingIn, @WorkingOut OUTPUT
PRINT CAST(@WorkingIn AS varchar) + ' factorial is ' + CAST(@WorkingOut AS varchar)
5 factorial is 120

CREATE PROC spTriangular
@ValueIn int,
@ValueOut int OUTPUT
AS
DECLARE @InWorking int
DECLARE @OutWorking int
IF @ValueIn != 1
BEGIN
SELECT @InWorking = @ValueIn - 1
EXEC spTriangular @InWorking, @OutWorking OUTPUT
SELECT @ValueOut = @ValueIn + @OutWorking
END
ELSE
BEGIN
SELECT @ValueOut = 1
END
RETURN
GO
DECLARE @WorkingOut int
DECLARE @WorkingIn int
SELECT @WorkingIn = 5
EXEC spTriangular @WorkingIn, @WorkingOut OUTPUT
PRINT CAST(@WorkingIn AS varchar) + ' Triangular is ' + CAST(@WorkingOut AS varchar)

