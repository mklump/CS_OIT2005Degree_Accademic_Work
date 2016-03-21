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

SET ARITHABORT ON

CREATE UNIQUE CLUSTERED INDEX ivCustomerOrders
ON CustomerOrders_vw(CompanyName, OrderID, ProductID)
