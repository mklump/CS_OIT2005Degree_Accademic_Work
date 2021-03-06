if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetCustomerOrders]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetCustomerOrders]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_GetCustomers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_GetCustomers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_UpdateCustomer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_UpdateCustomer]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE  PROCEDURE dbo.usp_GetCustomerOrders
@CustomerID nchar(5),
@CompanyName nchar(40) OUTPUT,
@Phone nchar(24) OUTPUT
as
Select CustomerID, OrderID, OrderDate, ShippedDate, ShipName from Orders 
where CustomerID = @CustomerID

Select @CompanyName = CompanyName, @Phone = Phone from Customers
where CustomerID = @CustomerID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure dbo.usp_GetCustomers
as
Select CustomerID, ContactName from Customers
order by ContactName

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


Create PROCEDURE dbo.usp_UpdateCustomer
@CustomerID nchar(5),
@CompanyName nchar(40),
@Phone nchar(24)
as
Update Customers set CompanyName = @CompanyName, Phone = @Phone
where CustomerID = @CustomerID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

