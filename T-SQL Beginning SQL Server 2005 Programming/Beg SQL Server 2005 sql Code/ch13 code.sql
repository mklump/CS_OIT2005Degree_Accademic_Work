
USE Accounting
DECLARE @Counter  int
SET @Counter = 1
WHILE @Counter <= 10
BEGIN
INSERT INTO Orders
VALUES (1, DATEADD(mi,@Counter,GETDATE()), 1)
SET @Counter = @Counter + 1
END
SELECT *
FROM Orders
WHERE OrderDate = GETDATE()
SELECT *
FROM Orders
WHERE CONVERT(varchar(12), OrderDate, 101) = CONVERT(varchar(12), GETDATE(), 101)
CREATE FUNCTION dbo.DayOnly(@Date datetime)
RETURNS varchar(12)
AS
BEGIN
RETURN CONVERT(varchar(12), @Date, 101)
END
SELECT *
FROM Orders
WHERE dbo.DayOnly(OrderDate) = dbo.DayOnly(GETDATE())
USE pubs
SELECT Title, Price,
(SELECT AVG(Price) FROM Titles) AS Average, Price - (SELECT AVG(Price) FROM Titles)
AS Difference
FROM Titles
WHERE Type='popular_comp'

CREATE FUNCTION dbo.AveragePrice()
RETURNS money
WITH SCHEMABINDING
AS
BEGIN
RETURN (SELECT AVG(Price) FROM dbo.Titles)
END
GO
CREATE FUNCTION dbo.PriceDifference(@Price money)
RETURNS money
AS
BEGIN
RETURN @Price - dbo.AveragePrice()
END
USE pubs
SELECT Title,
Price,
dbo.AveragePrice() AS Average,
dbo.PriceDifference(Price) AS Difference
FROM Titles
WHERE Type='popular_comp'

USE pubs
GO
CREATE FUNCTION dbo.fnAuthorList()
RETURNS TABLE
AS
RETURN (SELECT au_id,
au_lname + ', ' + au_fname AS au_name,
address AS address1,
city + ', ' + state + ' ' + zip AS address2
FROM authors)
GO
SELECT *
FROM dbo.fnAuthorList()

--CREATE our view
CREATE VIEW vSalesCount
AS
SELECT au.au_id,
au.au_lname + ', ' + au.au_fname AS au_name,
au.address,
au.city + ', ' + au.state + ' ' + zip AS address2,
SUM(s.qty) As SalesCount
FROM authors au
JOIN titleauthor ta
ON au.au_id = ta.au_id
JOIN sales s
ON ta.title_id = s.title_id
GROUP BY au.au_id,
au.au_lname + ', ' + au.au_fname,
au.address,
au.city + ', ' + au.state + ' ' + zip
GO
SELECT au_name, address, Address2 FROM vSalesCount
WHERE SalesCount > 25
USE pubs
GO
CREATE FUNCTION dbo.fnSalesCount(@SalesQty bigint)
RETURNS TABLE
AS
RETURN (SELECT au.au_id,
au.au_lname + ', ' + au.au_fname AS au_name,
au.address,
au.city + ', ' + au.state + ' ' + zip AS Address2
FROM authors au
JOIN titleauthor ta
ON au.au_id = ta.au_id
JOIN sales s
ON ta.title_id = s.title_id
GROUP BY au.au_id,
au.au_lname + ', ' + au.au_fname,
au.address,
au.city + ', ' + au.state + ' ' + zip
HAVING SUM(qty) > @SalesQty
)
GO
SELECT *
FROM dbo.fnSalesCount(25)

SELECT DISTINCT p.pub_name, a.au_name
FROM dbo.fnSalesCount(25) AS a
JOIN titleauthor AS ta
ON a.au_id = ta.au_id
JOIN titles AS t
ON ta.title_id = t.title_id
JOIN publishers AS p
ON t.pub_id = p.pub_id

Use Northwind
SELECT Emp.EmployeeID, Emp.LastName, Emp.FirstName, Emp.ReportsTo
FROM Employees AS Emp
JOIN Employees AS Mgr
ON Mgr.EmployeeID = Emp.ReportsTo
WHERE Mgr.LastName = 'Fuller'
AND Mgr.FirstName = 'Andrew'

CREATE FUNCTION dbo.fnGetReports
(@EmployeeID AS int)
RETURNS @Reports TABLE
(
EmployeeID    int         NOT NULL,
ReportsToID   int         NULL
)
AS
BEGIN
/* Since we'll need to call this function recursively - that is once for each reporting
** employee (to make sure that they don't have reports of their own), we need a holding
** variable to keep track of which employee we're currently working on. */
DECLARE @Employee AS int
/* This inserts the current employee into our working table. The significance here is
** that we need the first record as something of a primer due to the recursive nature
** of the function - this is how we get it. */
INSERT INTO @Reports
SELECT EmployeeID, ReportsTo
FROM Employees
WHERE EmployeeID = @EmployeeID
/* Now we also need a primer for the recursive calls we're getting ready to start making
** to this function. This would probably be better done with a cursor, but we haven't
** gotten to that chapter yet, so.... */
SELECT @Employee = MIN(EmployeeID)
FROM Employees
WHERE ReportsTo = @EmployeeID
/* This next part would probably be better done with a cursor but we haven't gotten to
** that chapter yet, so we'll fake it. Notice the recursive call to our function! */
WHILE @Employee IS NOT NULL
BEGIN
INSERT INTO @Reports
SELECT *
FROM fnGetReports(@Employee)
SELECT @Employee = MIN(EmployeeID)
FROM Employees
WHERE EmployeeID > @Employee
AND ReportsTo = @EmployeeID
END
RETURN
END
GO
SELECT * FROM fnGetReports(2)

SELECT * FROM fnGetReports(5)

DECLARE @EmployeeID int
SELECT @EmployeeID = EmployeeID
FROM Employees
WHERE LastName = 'Fuller'
AND FirstName = 'Andrew'

SELECT Emp.EmployeeID, Emp.LastName, Emp.FirstName, Mgr.LastName AS ReportsTo
FROM Employees AS Emp
JOIN dbo.fnGetReports(@EmployeeID) AS gr
ON gr.EmployeeID = Emp.EmployeeID
JOIN Employees AS Mgr
ON Mgr.EmployeeID = gr.ReportsToID

USE Accounting
SELECT OBJECTPROPERTY(OBJECT_ID('DayOnly'), 'IsDeterministic')

ALTER FUNCTION DayOnly(@Date datetime)
RETURNS varchar(12)
WITH SCHEMABINDING
AS
BEGIN
RETURN CONVERT(varchar(12), @Date, 101)
END

USE Pubs
GO
CREATE FUNCTION dbo.AveragePrice()
RETURNS money
WITH SCHEMABINDING
AS
BEGIN
RETURN (SELECT AVG(Price) FROM dbo.Titles)
END
SELECT OBJECTPROPERTY(OBJECT_ID('AveragePrice'), 'IsDeterministic')


