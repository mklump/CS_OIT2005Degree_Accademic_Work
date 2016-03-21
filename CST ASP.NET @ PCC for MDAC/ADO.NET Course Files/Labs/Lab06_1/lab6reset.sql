/* Script to reset the SQL Server for Lab 6 by removing stored procedures */

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

