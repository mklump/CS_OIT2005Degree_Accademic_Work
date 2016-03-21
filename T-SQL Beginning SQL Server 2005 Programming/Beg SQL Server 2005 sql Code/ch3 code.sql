SELECT * FROM INFORMATION_SCHEMA.TABLES

SELECT * FROM Sales.Customer

SELECT LastName FROM Person.Contact

SELECT Name FROM Production.Product

SELECT Name, ProductNumber, ReorderPoint
FROM Production.Product

SELECT Name, ProductNumber, ReorderPoint
FROM Production.Product
WHERE ProductID = 356

SELECT Name, ProductNumber, ReorderPoint
FROM Production.Product

SELECT Name, ProductNumber, ReorderPoint
FROM Production.Product
ORDER BY Name

SELECT Name, ProductNumber, ReorderPoint
FROM Production.Product
ORDER BY ProductNumber

SELECT ProductID, ProductName, UnitsInStock, UnitsOnOrder
FROM Products
WHERE UnitsOnOrder > 0
AND UnitsInStock < 10
ORDER BY UnitsOnOrder DESC

SELECT OrderDate, CustomerID
FROM Orders
WHERE OrderDate BETWEEN '12-10-1996' AND '12-20-1996'
ORDER BY OrderDate, CustomerID DESC

SELECT OrderID, Quantity
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002

SELECT OrderID, SUM(Quantity)
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT CustomerID, EmployeeID, COUNT(*)
FROM Orders
WHERE CustomerID BETWEEN 'A' AND 'AO'
GROUP BY CustomerID, EmployeeID

SELECT OrderID, AVG(Quantity)
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT OrderID, MIN(Quantity)
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT OrderID, MAX(Quantity)
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT OrderID, MIN(Quantity),MAX(Quantity)
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT OrderID, MIN(Quantity) AS Minimum, MAX(Quantity) AS Maximum
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT OrderID AS "Order Number", MIN(Quantity) Minimum, MAX(Quantity) Maximum
FROM [Order Details]
WHERE OrderID BETWEEN 11000 AND 11002
GROUP BY OrderID

SELECT COUNT(*)
FROM Employees
WHERE EmployeeID = 5

SELECT COUNT(*)
FROM Employees

SELECT COUNT(*)
FROM Customers

SELECT COUNT(Fax)
FROM Customers

SELECT COUNT(*)
FROM Customers
WHERE Fax IS NULL

SELECT ReportsTo, COUNT(*)
FROM Employees
GROUP BY ReportsTo

SELECT ReportsTo AS Manager, COUNT(*) AS Reports
FROM Employees
GROUP BY ReportsTo

SELECT ReportsTo AS Manager, COUNT(*) AS Reports
FROM Employees
WHERE EmployeeID != 5
GROUP BY ReportsTo

SELECT ReportsTo AS Manager, COUNT(*) AS Reports
FROM Employees
GROUP BY ReportsTo
HAVING COUNT(*) > 4

SELECT OrderID, SUM(Quantity) AS Total
FROM [Order Details]
GROUP BY OrderID

SELECT OrderID, SUM(Quantity) AS Total
FROM [Order Details]
GROUP BY OrderID
HAVING SUM(Quantity) > 300

SELECT SupplierID
FROM Products
WHERE UnitsInStock > 0

SELECT DISTINCT SupplierID
FROM Products
WHERE UnitsInStock > 0

SELECT COUNT(*)
FROM [Order Details]

SELECT COUNT(OrderID)
FROM [Order Details]

SELECT COUNT(DISTINCT OrderID)
FROM [Order Details]

INSERT INTO stores
VALUES
('TEST', 'Test Store', '1234 Anywhere Street', 'Here', 'NY', '00319')

SELECT *
FROM stores
WHERE stor_id = 'TEST'

INSERT INTO stores
(stor_id, stor_name, city, state, zip)
VALUES
('TST2', 'Test Store', 'Here', 'NY', '00319')

SELECT *
FROM stores
WHERE stor_id = 'TST2'

EXEC sp_help sales

INSERT INTO sales
(stor_id, ord_num, ord_date, qty, payterms, title_id)
VALUES
('TEST', 'TESTORDER', '01/01/1999', 10, 'NET 30', 'BU1032')


/* This next statement is going to use code to change the "current" database
** to Northwind. This makes certain, right in the code that we are going
** to the correct database.
*/
USE Northwind
/* This next statement declares our working table.
** This particular table is actually a variable we are declaring on the fly.
*/
DECLARE @MyTable Table
(
OrderID      int,
CustomerID   char(5)
)
/* Now that we have our table variable, we're ready to populate it with data
** from our SELECT statement. Note that we could just as easily insert the
** data into a permanent table (instead of a table variable).
*/
INSERT INTO @MyTable
SELECT OrderID, CustomerID
FROM Northwind.dbo.Orders
WHERE OrderID BETWEEN 10240 AND 10250
-- Finally, let's make sure that the data was inserted like we think
SELECT *
FROM @MyTable

SELECT *
FROM stores
WHERE stor_id = 'TEST'

UPDATE stores
SET city = 'There'
WHERE stor_id = 'TEST'

UPDATE stores
SET city = 'There', state = 'CA'
WHERE stor_id = 'TEST'

SELECT title_id, price
FROM titles
WHERE title_id LIKE 'BU%'

UPDATE titles
SET price = price * 1.1
WHERE title_id LIKE 'BU%'

SELECT title_id, price
FROM titles
WHERE title_id LIKE 'BU%'

UPDATE titles
SET price = price / 1.1
WHERE title_id LIKE 'BU%'

UPDATE titles
SET price = ROUND(price * 1.1, 2)
WHERE title_id LIKE 'BU%'

SELECT *
FROM stores
WHERE stor_id = 'TEST'

DELETE stores
WHERE stor_id = 'TEST'

DELETE sales
WHERE stor_id = 'TEST'

DELETE stores
WHERE stor_id = 'TEST'
DELETE stores
WHERE stor_id = 'TST2'
