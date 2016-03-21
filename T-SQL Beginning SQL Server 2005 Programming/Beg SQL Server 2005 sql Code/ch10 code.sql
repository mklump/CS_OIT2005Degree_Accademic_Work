
USE Accounting
GO
CREATE VIEW CustomerPhoneList_vw
AS
SELECT CustomerName, Contact, Phone
FROM Customers
Command(s) completed successfully.
SELECT * FROM CustomerPhoneList_vw
SELECT * FROM Customers
SELECT CustomerName, Contact, Phone
FROM Customers
SELECT * FROM CustomerPhoneList_vw
USE Accounting
GO
CREATE VIEW Employees_vw
AS
SELECT   EmployeeID,
FirstName,
MiddleInitial,
LastName,
Title,
HireDate,
TerminationDate,
ManagerEmpID,
Department
FROM Employees
SELECT *
FROM Employees_vw
CREATE VIEW CurrentEmployees_vw
AS
SELECT   EmployeeID,
FirstName,
MiddleInitial,
LastName,
Title,
HireDate,
ManagerEmpID,
Department
FROM Employees
WHERE TerminationDate IS NULL
SELECT   EmployeeID,
FirstName,
LastName,
TerminationDate
FROM Employees
EmployeeID           FirstName            LastName        TerminationDate

SELECT   EmployeeID,
FirstName,
LastName
FROM CurrentEmployees_vw

USE Northwind
GO
CREATE VIEW CustomerOrders_vw
AS
SELECT   cu.CompanyName,
o.OrderID,
o.OrderDate,
od.ProductID,
p.ProductName,
od.Quantity,
od.UnitPrice,
od.Quantity * od.UnitPrice AS ExtendedPrice
FROM     Customers AS cu
INNER JOIN   Orders AS o
ON cu.CustomerID = o.CustomerID
INNER JOIN   [Order Details] AS od
ON o.OrderID = od.OrderID
INNER JOIN   Products AS p
ON od.ProductID = p.ProductID

SELECT *
FROM CustomerOrders_vw
SELECT CompanyName, ExtendedPrice
FROM CustomerOrders_vw
WHERE OrderDate = '9/3/1996'

USE Northwind
GO
CREATE VIEW YesterdaysOrders_vw
AS
SELECT   cu.CompanyName,
o.OrderID,
o.OrderDate,
od.ProductID,
p.ProductName,
od.Quantity,
od.UnitPrice,
od.Quantity * od.UnitPrice AS ExtendedPrice
FROM     Customers AS cu
INNER JOIN   Orders AS o
ON cu.CustomerID = o.CustomerID
INNER JOIN   [Order Details] AS od
ON o.OrderID = od.OrderID
INNER JOIN   Products AS p
ON od.ProductID = p.ProductID
WHERE CONVERT(varchar(12),o.OrderDate,101) =
CONVERT(varchar(12),DATEADD(day,-1,GETDATE()),101)

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

SELECT CompanyName, OrderID, OrderDate FROM YesterdaysOrders_vw

WHERE CONVERT(varchar(12),o.OrderDate,101) =
CONVERT(varchar(12),DATEADD(day,-1,GETDATE()),101)

CREATE VIEW OregonShippers_vw
AS
SELECT   ShipperID,
CompanyName,
Phone
FROM     Shippers
WHERE Phone LIKE '(503)%'
OR Phone LIKE '(541)%'
OR Phone LIKE '(971)%'
WITH CHECK OPTION

UPDATE OregonShippers_vw
SET Phone = '(333) 555 9831'
WHERE ShipperID = 1

UPDATE Shippers
SET Phone = '(333) 555 9831'
WHERE ShipperID = 1
(1 row(s) affected)
INSERT INTO OregonShippers_vw
VALUES
('My Freight Inc.', '(555) 555-5555')

SELECT dbo.Orders.OrderDate,
dbo.Customers.CompanyName,
dbo.Products.ProductName,
dbo.[Order Details].ProductID,
dbo.[Order Details].UnitPrice,
dbo.[Order Details].Quantity,
dbo.[Order Details].Quantity * dbo.[Order Details].UnitPrice AS ExtendedPrice
FROM   dbo.Customers INNER JOIN
dbo.Orders ON dbo.Customers.CustomerID = dbo.Orders.CustomerID INNER JOIN
dbo.[Order Details] ON dbo.Orders.OrderID = dbo.[Order Details].OrderID INNER JOIN
dbo.Products ON dbo.[Order Details].ProductID = dbo.Products.ProductID

EXEC sp_helptext [Alphabetical list of products]
ALTER VIEW CustomerOrders_vw
WITH ENCRYPTION
AS
SELECT   cu.CompanyName,
o.OrderDate,
od.ProductID,
p.ProductName,
od.Quantity,
od.UnitPrice,
od.Quantity * od.UnitPrice AS ExtendedPrice
FROM     Customers AS cu
INNER JOIN   Orders AS o
ON cu.CustomerID = o.CustomerID
INNER JOIN   [Order Details] AS od
ON o.OrderID = od.OrderID
INNER JOIN   Products AS p
ON od.ProductID = p.ProductID

EXEC sp_helptext CustomerOrders_vw

SELECT sc.text FROM syscomments sc
JOIN sysobjects so
ON sc.id = so.id
WHERE so.name = 'CustomerOrders_vw'

ALTER VIEW CustomerOrders_vw
WITH SCHEMABINDING
AS
SELECT   cu.CompanyName,
o.OrderID,
o.OrderDate,
od.ProductID,
p.ProductName,
od.Quantity,
od.UnitPrice
FROM     dbo.Customers AS cu
INNER JOIN   dbo.Orders AS o
ON cu.CustomerID = o.CustomerID
INNER JOIN   dbo.[Order Details] AS od
ON o.OrderID = od.OrderID
INNER JOIN   dbo.Products AS p
ON od.ProductID = p.ProductID

CREATE UNIQUE CLUSTERED INDEX ivCustomerOrders
ON CustomerOrders_vw(CompanyName, OrderID, ProductID)

SELECT * FROM CustomerOrders_vw
USE NorthwindBulk
GO
CREATE VIEW CustomerOrders_vw
WITH SCHEMABINDING
AS
SELECT   cu.CompanyName,
o.OrderID,
o.OrderDate,
od.ProductID,
p.ProductName,
od.Quantity,
od.UnitPrice
FROM     dbo.Customers AS cu
INNER JOIN   dbo.Orders AS o
ON cu.CustomerID = o.CustomerID
INNER JOIN   dbo.[Order Details] AS od
ON o.OrderID = od.OrderID
INNER JOIN   dbo.Products AS p
ON od.ProductID = p.ProductID
GO

CREATE UNIQUE CLUSTERED INDEX ivCustomerOrders
ON CustomerOrders_vw(CompanyName, OrderID, ProductID)

USE NorthwindBulk
SELECT * FROM CustomerOrders_vw

