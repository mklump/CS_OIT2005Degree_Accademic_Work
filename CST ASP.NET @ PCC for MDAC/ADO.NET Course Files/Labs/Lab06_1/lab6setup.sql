/* Script to setup the SQL Server for Lab 6 by creating stored procedures */

USE Northwind

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCustomers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOrderDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOrderDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCustomers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOrderDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOrderDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SelectCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SelectCustomers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SelectOrderDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SelectOrderDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SelectOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SelectOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCustomers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOrderDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOrderDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOrders]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteCustomers
(
	@Original_CustomerID nchar(5),
	@Original_City nvarchar(15),
	@Original_CompanyName nvarchar(40),
	@Original_ContactName nvarchar(30),
	@Original_Phone nvarchar(24)
)
AS
	SET NOCOUNT OFF;
DELETE FROM Customers WHERE (CustomerID = @Original_CustomerID) AND (City = @Original_City OR @Original_City IS NULL AND City IS NULL) AND (CompanyName = @Original_CompanyName) AND (ContactName = @Original_ContactName OR @Original_ContactName IS NULL AND ContactName IS NULL) AND (Phone = @Original_Phone OR @Original_Phone IS NULL AND Phone IS NULL)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteOrderDetails
(
	@Original_OrderID int,
	@Original_ProductID int,
	@Original_Quantity smallint,
	@Original_UnitPrice money
)
AS
	SET NOCOUNT OFF;
DELETE FROM [Order Details] WHERE (OrderID = @Original_OrderID) AND (ProductID = @Original_ProductID) AND (Quantity = @Original_Quantity) AND (UnitPrice = @Original_UnitPrice)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteOrders
(
	@Original_OrderID int,
	@Original_CustomerID nchar(5),
	@Original_EmployeeID int,
	@Original_OrderDate datetime
)
AS
	SET NOCOUNT OFF;
DELETE FROM Orders WHERE (OrderID = @Original_OrderID) AND (CustomerID = @Original_CustomerID OR @Original_CustomerID IS NULL AND CustomerID IS NULL) AND (EmployeeID = @Original_EmployeeID OR @Original_EmployeeID IS NULL AND EmployeeID IS NULL) AND (OrderDate = @Original_OrderDate OR @Original_OrderDate IS NULL AND OrderDate IS NULL)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.InsertCustomers
(
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@City nvarchar(15),
	@Phone nvarchar(24)
)
AS
	SET NOCOUNT OFF;
INSERT INTO Customers(CustomerID, CompanyName, ContactName, City, Phone) VALUES (@CustomerID, @CompanyName, @ContactName, @City, @Phone)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.InsertOrderDetails
(
	@OrderID int,
	@ProductID int,
	@UnitPrice money,
	@Quantity smallint
)
AS
	SET NOCOUNT OFF;
INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity) VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.InsertOrders
(
	@OrderDate datetime,
	@EmployeeID int,
	@CustomerID nchar(5)
)
AS
	SET NOCOUNT OFF;
INSERT INTO Orders(OrderDate, EmployeeID, CustomerID) VALUES (@OrderDate, @EmployeeID, @CustomerID);
	SELECT OrderID, OrderDate, EmployeeID, CustomerID FROM Orders WHERE (OrderID = @@IDENTITY)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.SelectCustomers
(
	@EmployeeID int
)
AS
	SET NOCOUNT ON;
SELECT DISTINCT Customers.CustomerID, Customers.CompanyName, Customers.ContactName, Customers.City, Customers.Phone FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID WHERE (Orders.EmployeeID = @EmployeeID) ORDER BY Customers.CompanyName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.SelectOrderDetails
(
	@EmployeeID int
)
AS
	SET NOCOUNT ON;
SELECT [Order Details].OrderID, [Order Details].ProductID, [Order Details].UnitPrice, [Order Details].Quantity FROM [Order Details] INNER JOIN Orders ON [Order Details].OrderID = Orders.OrderID WHERE (Orders.EmployeeID = @EmployeeID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.SelectOrders
(
	@EmployeeID int
)
AS
	SET NOCOUNT ON;
SELECT OrderID, OrderDate, EmployeeID, CustomerID FROM Orders WHERE (EmployeeID = @EmployeeID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UpdateCustomers
(
	@CustomerID nchar(5),
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@City nvarchar(15),
	@Phone nvarchar(24),
	@Original_CustomerID nchar(5),
	@Original_City nvarchar(15),
	@Original_CompanyName nvarchar(40),
	@Original_ContactName nvarchar(30),
	@Original_Phone nvarchar(24)
)
AS
	SET NOCOUNT OFF;
UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName, ContactName = @ContactName, City = @City, Phone = @Phone WHERE (CustomerID = @Original_CustomerID) AND (City = @Original_City OR @Original_City IS NULL AND City IS NULL) AND (CompanyName = @Original_CompanyName) AND (ContactName = @Original_ContactName OR @Original_ContactName IS NULL AND ContactName IS NULL) AND (Phone = @Original_Phone OR @Original_Phone IS NULL AND Phone IS NULL)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UpdateOrderDetails
(
	@OrderID int,
	@ProductID int,
	@UnitPrice money,
	@Quantity smallint,
	@Original_OrderID int,
	@Original_ProductID int,
	@Original_Quantity smallint,
	@Original_UnitPrice money
)
AS
	SET NOCOUNT OFF;
UPDATE [Order Details] SET OrderID = @OrderID, ProductID = @ProductID, UnitPrice = @UnitPrice, Quantity = @Quantity WHERE (OrderID = @Original_OrderID) AND (ProductID = @Original_ProductID) AND (Quantity = @Original_Quantity) AND (UnitPrice = @Original_UnitPrice)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UpdateOrders
(
	@OrderDate datetime,
	@Param1 int,
	@CustomerID nchar(5),
	@Original_OrderID int,
	@Original_CustomerID nchar(5),
	@Original_EmployeeID int,
	@Original_OrderDate datetime,
	@OrderID int
)
AS
	SET NOCOUNT OFF;
UPDATE Orders SET OrderDate = @OrderDate, EmployeeID = @Param1, CustomerID = @CustomerID WHERE (OrderID = @Original_OrderID) AND (CustomerID = @Original_CustomerID OR @Original_CustomerID IS NULL AND CustomerID IS NULL) AND (EmployeeID = @Original_EmployeeID OR @Original_EmployeeID IS NULL AND EmployeeID IS NULL) AND (OrderDate = @Original_OrderDate OR @Original_OrderDate IS NULL AND OrderDate IS NULL);
	SELECT OrderID, OrderDate, EmployeeID, CustomerID FROM Orders WHERE (OrderID = @OrderID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

