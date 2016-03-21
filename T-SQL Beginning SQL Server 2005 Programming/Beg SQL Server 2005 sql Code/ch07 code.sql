SELECT DISTINCT o.OrderDate, od.ProductID
FROM Orders o
JOIN [Order Details] od
ON o.OrderID = od.OrderID
WHERE OrderDate = '7/4/1996'  --This is first OrderDate in the system

SELECT DISTINCT o.OrderDate, od.ProductID
FROM Orders o
JOIN [Order Details] od
ON o.OrderID = od.OrderID
WHERE o.OrderDate = (SELECT MIN(OrderDate) FROM Orders)

USE PUBS
SELECT stor_id AS "Store ID", stor_name AS "Store Name"
FROM Stores
WHERE stor_id IN (SELECT stor_id FROM Discounts)

SELECT s.stor_id AS "Store ID", stor_name AS "Store Name"
FROM Stores s
JOIN Discounts d
ON s.stor_id = d.stor_id

USE Pubs
SELECT s.Stor_Name AS "Store Name"
FROM Discounts d
RIGHT OUTER JOIN Stores s
ON d.Stor_ID = s.Stor_ID
WHERE d.Stor_ID IS NULL

SELECT stor_id AS "Store ID", stor_name AS "Store Name"
FROM Stores
WHERE stor_id NOT IN
(SELECT stor_id FROM Discounts WHERE stor_id IS NOT NULL)

USE Northwind
-- Get a list of customers and the date of their first order
SELECT CustomerID, MIN((OrderDate)) AS OrderDate
INTO #MinOrderDates
FROM Orders
GROUP BY CustomerID
ORDER BY CustomerID
-- Do something additional with that information
SELECT o.CustomerID, o.OrderID, o.OrderDate
FROM Orders o
JOIN #MinOrderDates t
ON o.CustomerID = t.CustomerID
AND o.OrderDate = t.OrderDate
ORDER BY o.CustomerID
DROP TABLE #MinOrderDates

SELECT o1.CustomerID, o1.OrderID, o1.OrderDate
FROM Orders o1
WHERE o1.OrderDate = (SELECT Min(o2.OrderDate)
FROM Orders o2
WHERE o2.CustomerID = o1.CustomerID)
ORDER BY CustomerID

SELECT cu.CompanyName,
(SELECT Min(OrderDate)
FROM Orders o
WHERE o.CustomerID = cu.CustomerID)
AS "Order Date"
FROM Customers cu

SELECT cu.CompanyName,
ISNULL(CAST ((SELECT MIN(o.OrderDate)
FROM Orders o
WHERE o.CustomerID = cu.CustomerID)AS varchar), '  NEVER ORDERED')
AS "Order Date"
FROM Customers cu

SELECT c.CompanyName
FROM Customers AS c
JOIN Orders AS o
ON c.CustomerID = o.CustomerID
JOIN [Order Details] AS od
ON o.OrderID = od.OrderID
JOIN Products AS p
ON od.ProductID = p.ProductID
WHERE p.ProductName = 'Chocolade'
-- WHERE p.ProductName = 'Chocolade' AND p.ProductName = 'Vegie-spread'


SELECT DISTINCT c.CompanyName
FROM Customers AS c
JOIN
(SELECT CustomerID
FROM Orders o
JOIN [Order Details] od
ON o.OrderID = od.OrderID
JOIN Products p
ON od.ProductID = p.ProductID
WHERE p.ProductName = 'Chocolade') AS spen
ON c.CustomerID = spen.CustomerID
JOIN
(SELECT CustomerID
FROM Orders o
JOIN [Order Details] od
ON o.OrderID = od.OrderID
JOIN Products p
ON od.ProductID = p.ProductID
WHERE ProductName = 'Vegie-spread') AS spap
ON c.CustomerID = spap.CustomerID

SELECT CustomerID, CompanyName
FROM Customers cu
WHERE EXISTS
(SELECT OrderID
FROM Orders o
WHERE o.CustomerID = cu.CustomerID)

SELECT DISTINCT cu.CustomerID, cu.CompanyName
FROM Customers cu
JOIN Orders o
ON cu.CustomerID = o.CustomerID

USE Northwind
SELECT c.CustomerID, CompanyName
FROM Customers c
LEFT OUTER JOIN Orders o
ON c.CustomerID = o.CustomerID
WHERE o.CustomerID IS NULL

SELECT CustomerID, CompanyName
FROM Customers cu
WHERE NOT EXISTS
(SELECT OrderID
FROM Orders o
WHERE o.CustomerID = cu.CustomerID)

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[Shippers]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
DROP TABLE [dbo].[Shippers]
GO
CREATE TABLE [dbo].[Shippers] (
[ShipperID] [int] IDENTITY (1, 1) NOT NULL ,
[CompanyName] [nvarchar] (40) NOT NULL ,
[Phone] [nvarchar] (24) NULL
)
GO
USE master
GO
IF NOT EXISTS (SELECT 'True' FROM sys.databases WHERE name = 'NorthwindCreate')
BEGIN
CREATE DATABASE NorthwindCreate
END
ELSE
BEGIN
PRINT 'Database already exists. Skipping CREATE DATABASE Statement'
END
GO

SELECT 'The Customer has an Order numbered ' + OrderID
FROM Orders
WHERE CustomerID = 'ALFKI'

SELECT 'The Customer has an Order numbered ' + CAST(OrderID AS varchar)
FROM Orders
WHERE CustomerID = 'ALFKI'

CREATE TABLE ConvertTest
(
ColID   int   IDENTITY,
ColTS   timestamp
)
INSERT INTO ConvertTest
DEFAULT VALUES
SELECT ColTS AS "Uncoverted", CAST(ColTS AS int) AS "Converted" FROM ConvertTest

SELECT OrderDate, CAST(OrderDate AS varchar) AS "Converted"
FROM Orders
WHERE OrderID = 11050

SELECT OrderDate, CONVERT(varchar(12), OrderDate, 111) AS "Converted"
FROM Orders
WHERE OrderID = 11050

SELECT OrderDate, CONVERT(varchar(12), OrderDate, 5) AS "Converted"
FROM Orders
WHERE OrderID = 11050

