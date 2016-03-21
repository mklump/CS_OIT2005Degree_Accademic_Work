use northwind
go

select
LastName + ', ' + FirstName as ManagerName
, ReportsTo as Manager
, count(*) as Reports
from Employees
group by ReportsTo, LastName, FirstName
having count(*) > 4
go

select
LastName + ', ' + FirstName as President_LastFirst
, ReportsTo as Manager
, count(*) as Reporting_Employees
from Employees
group by ReportsTo, LastName, FirstName
having
--NOT(0 = isnull(ReportsTo, 0))
0 = isnull(ReportsTo, 0)
go

select
OrderID
, sum(Quantity) as Total
from [Order Details]
group by OrderID
having SUM(Quantity) > 300

select distinct SupplierID
from Products
where UnitsInStock > 0

select count(distinct OrderID)
from [Order Details]

--Try IT Out: A Simple Join
SELECT p.ProductID, s.SupplierID, p.ProductName, s.CompanyName
FROM Products p
INNER JOIN Suppliers s
		ON p.SupplierID = s.SupplierID
WHERE p.ProductID < 4

IF (NULL = NULL)
	PRINT 'DB NULL does equal DB NULL'
ELSE
	PRINT '!!!DB NUll does not equal DB NULL!!!'

use pubs
go

--Try IT Out: More Complex JOINs
SELECT a.au_lname + ', ' + a.au_fname AS "Author", t.title
FROM authors a
JOIN titleauthor ta
	ON a.au_id = ta.au_id
JOIN titles t
	ON t.title_id = ta.title_id

--Try It Out: Outer JOINs
SELECT s.stor_name AS 'Store Name'
FROM discounts d
RiGHT JOIN stores s
			  ON d.stor_id = s.stor_id
WHERE d.stor_id is NULL

--Find the Orphan or Non-Matching Records
select c.CustomerID, c.CompanyName
from Orders o
right join Customers c
on c.CustomerID = o.CustomerID
where o.CustomerID is NULL

select count(*) as "No. Of Records" from Customers

--Dealing with More Complex Outer Joins
use Chapter4DB
select a.Address, va.AddressID, v.VendorID, V.VendorName
from VendorAddress va
full join Address a
	on va.AddressID = a.AddressID
full join Vendors v
	on va.VendorID = v.VendorID

--Alternate Inner Join
select * 
from Products, Suppliers
where Products.ProductID = Suppliers.SupplierID

--Alternate Outer Join
select discounttype, discount, s.stor_name
from stores s
right join discounts d
	on d.stor_id = s.stor_id
where s.stor_id is not null

--Alternate Cross Join
select v.VendorName, a.Address
from Vendors v, Address a

--Chapter 4: Excercies
use Northwind;

select s.CompanyName as SupplierName
from Suppliers s
join Products p
	on s.SupplierID = p.SupplierID
where p.ProductName = 'Chai';

--List every Territory in the Nortwind DB that does not have an Employee assigned to it
select TerritoryDescription
from Territories t
left join EmployeeTerritories et
	on t.TerritoryID = et.TerritoryID
where et.EmployeeID is null;
--End Chapter 4 Exercises 

--Insert Example: Every field and field type must be specified and correct
--unless DB NULLible, see chapter 2 for bulk Update
insert sales
	(stor_id, ord_num, ord_date, qty, payterms, title_id)
values
	('TEST', 'TESTORDER', '01/01/1999', 10, 'NET 30', 'BU1032')
--Check inserted values
select * 
from sales 
where stor_id = 'TEST'

exec sp_help sales --System stored procedure call for detailed help with any table

/* This next statement is going to use code to change the "current" database
** to Northwind. This makes certain, right in the code that we are going
** to the correct database.
*/
use NorthWind
/* This next statement declares our working table.
** This particular table is actually a variable we are declaring on the fly.
*/
declare @MyTable as Table
(
	OrderID		int,
	CustomerID	char(5)
)
/* Now that we have our table variable, we're ready to populate it with data
** from our SELECT statement. Note that we could just as easily insert the
** data into a permanent table (instead of a table variable).
*/
insert @MyTable
select OrderID, CustomerID
from Northwind.dbo.Orders
where OrderID between 10240 and 10250

-- Finally, let's make sure that the data was inserted like we think
select *
from @MyTable

--Chapter 3 UPDATE, DELETE keyword use for T-SQL querry
use pubs;

select *
from stores
where stor_id = 'TEST'

select title_id, cast(price as money) as price
from titles
where title_id like 'BU%'

update titles
set price = round(price * 1.10, 2)
where title_id like 'BU%'

DELETE stores
WHERE stor_id = 'TST2'
DELETE sales
WHERE stor_id = 'TEST'
-- Chapter 3 Exercises
--Write a query that outputs all of the columns and all of the rows from the authors table of the pubs database
use pubs;
SELECT *
FROM authors
WHERE state = 'UT'

insert authors(au_id, au_lname, au_fname, phone, address, city, state, zip, contract)
values('999-99-9999', 'firstname', 'lastname', '999-999-9999', '', '', '', '99999', 0)

delete authors
where au_id = '999-99-9999'
--END Chapter 3

RESTORE DATABASE [Northwind]
FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\NW05.bak'
WITH  FILE = 1,
NOUNLOAD,
STATS = 10
GO

use Northwind
go

-- Which employee in Northwind reports to which manager in the Nortwind?
select
e.FirstName + ' ' + e.LastName as 'Employee',
n.FirstName + ' ' + n.LastName as 'Manager'
from Employees e
inner join Employees n
	on e.ReportsTo = n.EmployeeID

-- Which employee from Northwind sold the most products as a total dollar amount?
select
	emp.FirstName + ' ' + emp.LastName as 'Sale Associate'
	, round( sum(ord.unitprice * ord.quantity * (1 - ord.discount)), 2 ) as 'Total Sales'
from Employees emp
inner join Orders o
	on o.EmployeeID = emp.EmployeeID
inner join [Order Details] as ord
	on o.OrderID = ord.OrderID
group by emp.FirstName, emp.LastName
order by 'Total Sales' desc

-- Create a view of Customers and the Products they have bought from the Northwind database.
alter view vwCustBoughtProducts
with encryption
as
select
distinct o.CustomerID,
o.CompanyName,
p.ProductName
from Customers o
join Orders r
	on o.CustomerID = r.CustomerID
join [Order Details] d
	on r.OrderID = d.OrderID
join Products p
	on d.ProductID = p.ProductID
go

select * from vwCustBoughtProducts
go

-- Rank sales persons based on payscale?
select
e.employeeid
, e.firstname + ' ' + e.lastname as 'Sales Associate'
, round( sum(od.unitprice * od.quantity * (1 - od.discount)), 2 )
as 'Pay Total' -- round the pay scale to the second decimal place
, rank() over( order by sum(od.unitprice * od.quantity * (1 - od.discount)) desc )
as 'Seller Rank'
from [order details] od
inner join orders o on od.orderid = o.orderid
inner join employees e on e.employeeid = o.employeeid
group by e.employeeid, e.firstname, e.lastname
order by sum(od.unitprice * od.quantity * (1 - od.discount)) desc

-- Write a common table expression that shows a "Who reports to who Hierarchy Level"
WITH cteEmployeeHierarchy(EmployeeID, LastName, FirstName, ReportsTo, HierarchyLevel) 
AS
(
-- Base Case
select
	EmployeeID
	, LastName
	, FirstName
	, ReportsTo
	, 1 as HierarchyLevel
from Employees
where ReportsTo IS NULL
UNION ALL
-- Recurrsive Step
SELECT e.EmployeeID
, e.LastName
, e.FirstName
, e.ReportsTo
, en.HierarchyLevel + 1 as HierarchyLevel
from Employees e
INNER JOIN EmployeeHierarchy en on
	e.ReportsTo = en.EmployeeID
)
SELECT *
FROM EmployeeHierarchy
order by FirstName, LastName, HierarchyLevel

use Northwind;
/* Write a common table expression that calculates the total inventory value
per individual item by its ProductName and the number of items in stock as
a funtion of (unitprice * units_in_stock) */
SELECT
	p.ProductID
	, p.ProductName
	, (od.Quantity * od.UnitPrice) as 'Order Details Subtotal'
	, (p.UnitPrice * p.UnitsInStock) as 'Products Subtotal'
	, (SUM(od.Quantity * od.UnitPrice) + SUM(p.UnitPrice * p.UnitsInStock)) as 'TotalValue'
FROM [Order Details] od
INNER JOIN Products p on
	p.ProductID = od.ProductID
WHERE	p.Discontinued = 0 AND
	p.UnitsInStock > 0 AND
	p.UnitPrice > 0
GROUP BY
	p.ProductID, p.ProductName
	, od.Quantity, od.UnitPrice
	, p.UnitPrice, p.UnitsInStock
ORDER BY p.ProductName desc

-- Create a store procedure sp_GetHierarchy
use northwind;
drop procedure sp_GetHierarchy;

ALTER PROCEDURE sp_GetHierarchy
	@intEmployeeID	integer
AS
WITH cteEmployeeHierarchy(EmployeeID, LastName, FirstName, ReportsTo, HierarchyLevel) 
AS
(
-- Base Case
select
	EmployeeID
	, LastName
	, FirstName
	, ReportsTo
	, 1 as HierarchyLevel
from Employees
where ReportsTo IS NULL
UNION ALL
-- Recurrsive Step
SELECT e.EmployeeID
, e.LastName
, e.FirstName
, e.ReportsTo
, en.HierarchyLevel + 1 as HierarchyLevel
from Employees e
INNER JOIN cteEmployeeHierarchy en on
	e.ReportsTo = en.EmployeeID
)
SELECT *
FROM cteEmployeeHierarchy
WHERE EmployeeID = @intEmployeeID
order by FirstName, LastName, HierarchyLevel
go


-- More Advanced T-SQL queries...
exec sp_GetHierarchy 2
go

-- makeDbSystemUnderTest.sql
-- creates DB, table (populates with some Dev data), and sp_to_test

use master -- Sets the master database context, and must be changed
go -- Executes all of the SQL statements that came after the last go statement

if exists (select * from sys.sysdatabases where name = 'dbSystemUnderTest')
 drop database dbSystemUnderTest
go

create database dbSystemUnderTest
go

use dbSystemUnderTest
go

create table tblUserLogin
(
userID char(3) primary key not null,
userName varchar(35) not null,
userPassword varchar(16) null,
userEnabled char(1) not null default 'Y'
)
go -- Not required but good style, to many go statement will cause unesseccary starts and stops

-- "Dev data"
insert into tblUserLogin values('001','test',null,'Y')
insert into tblUserLogin values('002','dummy','secret','Y')
insert into tblUserLogin values('003','admin','admin','Y')
go

-- xp - extented procedure
-- sp - stored procedure, better performace will result in not using this declaration
-- usp - user defined stored procedure

create procedure usp_IsValidLogin
 @uName varchar(35),
 @uPassword varchar(16)
as
if exists (select * from tblUserLogin where userName = @uName and userPassword = @uPassword)
 return 1 -- SQL does not have a boolean type, returning anything else other 0 is always true where 0 itself is all that is false
else
 return 0
go

-- manual testing possible
-- but this would not be much fun
declare @result int
exec @result = usp_IsValidLogin 'dummy', 'secret' -- execute stored procedure and get result
if @result = 1
 print 'Pass'
else
 print 'FAIL'
-- etc., etc.

-- Another manual SQL test case
declare @caseResult int
exec @caseResult = usp_IsValidLogin 'test', ''
if @caseResult = 1
 print 'Pass'
else
 print 'FAIL'

-- Day 1, Hour 2 - Building blocks

-- SQL test automation is fairly complex.  To understand it you must understand the individual building block techniques used.  Experiment with each of the following 7 techniques.

-- 1. Determine if a database exists:

if exists (select * from sys.sysdatabases where name='databaseName') -- sys.sysdatabases is a view where the data cannot be modified and sysdatabases is acutally the database and can be modified itself
 print 'DB Exists'
else
 print 'DB does not exist'

-- 2. Determine if a table or stored procedure exists:

if exists (select name from sys.sysobjects where name='objectName')
 print 'Exists'
else
 print 'Does not exist'

-- 3. Creating tables and inserting rows:

-- <examples will depend on class background>


-- 4. while loops:

declare @count int
set @count = 10
while (@count > 5)
begin
 print 'Count is ' + cast(@count as varchar(2))
 set @count = @count - 1
end


-- 5. Cursors:

create table tblDummy
(
dummyid char(2) primary key not null,
dummyvalue varchar(12) not null
)
insert into tblDummy values('01','foo')
insert into tblDummy values('02','bar')
insert into tblDummy values('03','biz')

declare myCursor cursor static -- acts the same as an array indexer
  for select dummyid, dummyvalue
  from tblDummy

declare @dummyid char(2), @dummyvalue varchar(12)

open myCursor

fetch first 
 from myCursor 
 into @dummyid, @dummyvalue

print @dummyid + ' ' + @dummyvalue

fetch next
 from myCursor 
 into @dummyid, @dummyvalue

print @dummyid + ' ' + @dummyvalue

close myCursor -- clean up
deallocate myCursor

-- drop table tblDummy


-- 6. Reading an existing text file:

-- first create file D:\junk.txt that has at least 2 lines of text

-- enable OLE automation
sp_configure 'show advanced options', 1
go
reconfigure
go
sp_configure 'Ole Automation Procedures', 1
go
reconfigure
go

declare @fsoHandle int, @fileID int
declare @line varchar(80)

exec sp_OACreate 'Scripting.FileSystemObject', @fsoHandle out -- create object
exec sp_OAMethod @fsoHandle, 'OpenTextFile', @fileID out, 'd:\junk.txt', 1, 0

exec sp_OAMethod @fileID, 'ReadLine', @line out
print @line

exec sp_OAMethod @fileID, 'ReadLine', @line out
print @line

exec sp_OADestroy @fileID
exec sp_OADestroy @fsoHandle

-- 7. Writing to a text file:

declare @fsoHandle int, @fileID int

exec sp_OACreate 'Scripting.FileSystemObject', @fsoHandle out -- create object
exec sp_OAMethod @fsoHandle, 'OpenTextFile', @fileID out, 'd:\junk.txt', 2, 1 -- writing; create
exec sp_OAMethod @fileID, 'WriteLine', null, 'Hello!'
exec sp_OAMethod @fileID, 'WriteLine', null, 'Goodbye'
exec sp_OADestroy @fileID
exec sp_OADestroy @fsoHandle
-- disable OLE automation
sp_configure 'show advanced options', 1
go
reconfigure
go
sp_configure 'Ole Automation Procedures', 0
go
reconfigure
go       

-- Create/Manage SQL Server Login...
use [master]
go

if exists(select name from sys.syslogins where name='testLogin')
	drop login testLogin
go

-- =================================================
-- Create SQL Login Must Change Password template
-- =================================================

CREATE LOGIN testLogin 
	WITH PASSWORD = N'temp1234' 
	MUST_CHANGE,
	CHECK_EXPIRATION = ON,
	CHECK_POLICY = ON;
GO
-- ======================
-- Drop Login template
-- ======================

DROP LOGIN testLogin
GO

select L.Name [LoginName], U.Name [UserName]
from sys.syslogins L
join sys.sysusers U
on L.sid = U.sid
GO
