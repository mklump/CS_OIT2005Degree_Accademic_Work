USE master
GO
IF EXISTS (SELECT 'True' FROM INFORMATION_SCHEMA.SCHEMATA WHERE CATALOG_NAME = 'NorthwindBulk')
	DROP DATABASE NorthwindBulk
GO
DECLARE @FileDirectory NVARCHAR(520)
SELECT @FileDirectory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE  NorthwindBulk
			ON
			  (NAME = ''NorthwindBulk'',
			   FILENAME = ''' + @FileDirectory + 'NorthwindBulkData.mdf'',
			   SIZE = 50MB,
			   MAXSIZE = 125MB,
			   FILEGROWTH = 10MB)
			LOG ON
			  (NAME = ''NorthwindBulkLog'',
			   FILENAME = ''' + @FileDirectory + 'NorthwindBulkLog.ldf'',
			   SIZE = 5MB,
			   MAXSIZE = 25MB,
			   FILEGROWTH = 5MB)')

GO
USE NorthwindBulk

ALTER DATABASE NorthwindBulk
	SET RECOVERY SIMPLE

GO
SELECT * 
INTO Customers
FROM Northwind..Customers
WHERE 1=2

SELECT * 
INTO Orders
FROM Northwind..Orders
WHERE 1=2

SELECT *
INTO Products
FROM Northwind..Products
WHERE 1=2

SELECT *
INTO [Order Details]
FROM Northwind..[Order Details]
WHERE 1=2

GO
CREATE PROC spStringAdd
@str varchar(8000) = NULL OUTPUT
AS
BEGIN

declare @strAZ char(26)
declare @i int
declare @strC char(1)

set @strAZ = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'

if @str is null
 set @str = left(@strAZ,1)
else
 set @i = len(@str)

 while @i > 0
 begin
  set @strC = substring(@str, @i, 1)

  if @strC = right(@strAZ,1)
  begin
   set @str = stuff(@str, @i, 1, left(@strAZ,1))
   set @i = @i -1
  end
  else
  begin
   set @str = stuff(@str, @i, 1, substring(@strAZ, charindex(@strC, @strAZ)
+ 1,1))
   BREAK
  end
 end

 if @i = 0
  BEGIN
      if len(@str) = 8000 set @str = NULL
      ELSE set @str = left(@strAZ, 1) + @str
  END
END

GO

CREATE PROC spAddProducts
@NumberToAdd bigint = 1000
AS
BEGIN

	SET NOCOUNT ON
	DECLARE @Counter bigint

	SET @Counter = 1

	WHILE @Counter <= @NumberToAdd
	BEGIN
		INSERT INTO Products
			(
			 ProductName,
			 UnitPrice,
			 Discontinued
			 )
		VALUES
			(
			 'Product Number ' + CAST(@Counter AS nvarchar(25)),
			 ROUND(RAND() * 99 + 1,2),
			 0
			)
		SET @Counter = @Counter + 1
	END
END

GO

CREATE PROC spAddOrder
	@CustomerID char(5)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @OrderDate			datetime
	DECLARE @OrderID			int
	DECLARE @NumberOfLineItems	tinyint
	DECLARE @Counter			tinyint
	DECLARE @NumberOfProducts	int
	DECLARE @ProductID			int
	DECLARE @ProductWorking		table
		(
			OrderID		int	NOT NULL,
			ProductID	int	NOT NULL
		)

	SET @OrderDate = DATEADD(dd, ROUND(RAND() * 1461,0), '1996-01-01')
	INSERT INTO Orders
		(
		 CustomerID,
		 EmployeeID,
		 OrderDate,
		 RequiredDate,
		 ShippedDate,
		 Freight
		)
	VALUES
		(
		 @CustomerID,
		 ROUND(RAND() * 8 + 1,0),
		 @OrderDate,
		 DATEADD(dd, 1, @OrderDate),
		 CASE ROUND(RAND() * 3 + 1,0)
			WHEN 1 THEN @OrderDate
			WHEN 2 THEN DATEADD(dd, 1, @OrderDate)
			WHEN 3 THEN DATEADD(dd, ROUND(RAND() * 14 + 1,0), @OrderDate)
			ELSE NULL
		 END,
		 ROUND(RAND() * 25 + 1, 2)		
		)
	SET @OrderID = @@IDENTITY
		 
	SET @NumberOfLineItems = ROUND(RAND() * 10 + 1,0)
	SELECT @NumberOfProducts = COUNT(*) FROM Products
	SET @Counter = 1
	
	WHILE @Counter <= @NumberOfLineItems
	BEGIN
		SELECT @ProductID = ROUND(RAND() * @NumberOfProducts + 1,0)
		IF (SELECT COUNT(*) FROM @ProductWorking WHERE ProductID = @ProductID) = 0
		BEGIN
			INSERT INTO @ProductWorking
				SELECT @OrderID, @ProductID
			SET @Counter = @Counter + 1
		END
	END

	INSERT INTO [Order Details]
		SELECT @OrderID, 
				pw.ProductID, 
				p.UnitPrice,
				ROUND(RAND() * 50 + 1,0),
				0
		FROM @ProductWorking AS pw
		JOIN Products AS p
			ON pw.ProductID = p.ProductID

	DELETE @ProductWorking
END	

GO 

PRINT 'Done Preparing Working Sprocs.'

PRINT 'Inserting Product Records....'

EXEC spAddProducts 1000

PRINT 'Product Records Complete.'

GO


DECLARE @CustomerID char(5)
DECLARE @NumberOfOrders int
DECLARE @OrderCounter int
DECLARE @CustomerCounter int

SET NOCOUNT ON
SET @CustomerID = 'AAAAA'
SET @CustomerCounter = 1
PRINT 'Inserting Customer and Order Records - this could take a bit....'

WHILE @CustomerID <= 'AACZZ'
BEGIN
	INSERT INTO Customers
		(CustomerID,
		 CompanyName,
		 ContactName,
		 Address,
		 City,
		 PostalCode
		)
	VALUES
		(
		 @CustomerID,
		 @CustomerID + ' Company',
		 @CustomerID + ' Contact',
		 '1234 ' + @CustomerID + ' Street',
		 'Anytown',
		 '55555'
		)

	SET @NumberOfOrders = ROUND(RAND() * 25 + 1,0)
	SET @OrderCounter = 1

	WHILE @OrderCounter <= @NumberOfOrders
	BEGIN
		EXEC spAddOrder @CustomerID
		SET @OrderCounter = @OrderCounter + 1
	END

	EXEC spStringAdd @str=@CustomerID OUTPUT
	SET @CustomerCounter = @CustomerCounter + 1
	IF @CustomerCounter % 1000 = 0
		PRINT 'Inserted ' + CAST(@CustomerCounter AS varchar) + ' customer at ' + CAST(GETDATE() as varchar)

END

PRINT 'Finished Inserting Records.'
PRINT 'Creating Customers Primary Key and Index...'

ALTER TABLE Customers
ADD CONSTRAINT PKCustomerID PRIMARY KEY (CustomerID) 

PRINT 'Creating Products Primary Key and Index...'
ALTER TABLE Products
ADD CONSTRAINT PKProductID PRIMARY KEY (ProductID) 

PRINT 'Creating Orders Primary Key and Index...'
ALTER TABLE Orders
ADD CONSTRAINT PKOrderID PRIMARY KEY (OrderID) 

PRINT 'Creating Order Details Primary Key and Index...'
ALTER TABLE [Order Details]
ADD CONSTRAINT PKOrderIDProductID PRIMARY KEY (OrderID, ProductID) 

DROP PROC spStringAdd, spAddProducts, spAddOrder

