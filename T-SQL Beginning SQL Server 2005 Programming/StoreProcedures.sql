--Fixes default database owner back to the default dbo owner
--from error message --> Database diagram support objects cannot be installed because this database does not have a valid owner.
EXEC sp_dbcmptlevel 'yourDB', '90';
go
ALTER AUTHORIZATION ON DATABASE::yourDB TO "yourLogin"
go
use [yourDB]
go
EXECUTE AS USER = N'dbo' REVERT
go

create procedure sp_InsertEmployee
	@fname as varchar(10),
	@lname as varchar(10)
as
set @fname = '$(fname)';
set @lname = '$(lname)';

insert employees(FirstName, LastName)
values(@fname, @lname)
go

alter procedure sp_InsertEmployee
	@LastName nvarchar(20)
   ,@FirstName nvarchar(10)
   ,@Title nvarchar(30) = NULL
   ,@TitleOfCourtesy nvarchar(25) = NULL
   ,@BirthDate datetime = NULL
   ,@HireDate datetime = NULL
   ,@Address nvarchar(60) = NULL
   ,@City nvarchar(15) = NULL
   ,@Region nvarchar(15) = NULL
   ,@PostalCode nvarchar(10) = NULL
   ,@Country nvarchar(15) = NULL
   ,@HomePhone nvarchar(24) = NULL
   ,@Extension nvarchar(4) = NULL
   ,@Photo image = NULL
   ,@Notes ntext = NULL
   ,@ReportsTo int = NULL
   ,@PhotoPath nvarchar(255) = NULL
as
INSERT INTO [Northwind].[dbo].[Employees]
   ([LastName]
   ,[FirstName]
   ,[Title]
   ,[TitleOfCourtesy]
   ,[BirthDate]
   ,[HireDate]
   ,[Address]
   ,[City]
   ,[Region]
   ,[PostalCode]
   ,[Country]
   ,[HomePhone]
   ,[Extension]
   ,[Photo]
   ,[Notes]
   ,[ReportsTo]
   ,[PhotoPath])
VALUES
(
	@LastName
   ,@FirstName
   ,@Title
   ,@TitleOfCourtesy
   ,@BirthDate
   ,@HireDate
   ,@Address
   ,@City
   ,@Region
   ,@PostalCode
   ,@Country
   ,@HomePhone
   ,@Extension
   ,@Photo
   ,@Notes
   ,@ReportsTo
   ,@PhotoPath
)
go

-- create a sproc that returns the supplierID if given a customerID
create procedure sp_GetSuppierIDbyCustomerID
	@CustomerID as int
as
SELECT s.SupplierID
FROM Customers c
inner join Orders o on
	o.CustomerID = c.CustomerID
inner join [Order Details] od on
	o.OrderID = od.OrderID
inner join Products p on
	od.ProductID = p.ProductID
inner join Suppliers s on
	p.SupplierID = s.SupplierID
WHERE
	c.CustomerID = @CustomerID
go

exec sp_GetSuppierIDbyCustomerID 10