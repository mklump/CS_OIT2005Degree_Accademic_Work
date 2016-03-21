
SELECT *
FROM Products
INNER JOIN Suppliers
ON Products.SupplierID = Suppliers.SupplierID

SELECT Products.*, CompanyName
FROM Products
INNER JOIN Suppliers
ON Products.SupplierID = Suppliers.SupplierID

SELECT Products.*, SupplierID
FROM Products
INNER JOIN Suppliers
ON Products.SupplierID = Suppliers.SupplierID

SELECT Products.*, Suppliers.SupplierID
FROM Products
INNER JOIN Suppliers
ON Products.SupplierID = Suppliers.SupplierID

SELECT p.*, s.SupplierID
FROM Products p
INNER JOIN Suppliers s
ON p.SupplierID = s.SupplierID

SELECT p.*, Suppliers.SupplierID
FROM Products p
INNER JOIN Suppliers s
ON p.SupplierID = s.SupplierID

SELECT p.ProductID, s.SupplierID, p.ProductName, s.CompanyName
FROM Products p
INNER JOIN Suppliers s
ON p.SupplierID = s.SupplierID
WHERE p.ProductID < 4

SELECT DISTINCT c.CustomerID, c.CompanyName
FROM Customers c
INNER JOIN Orders o
ON c.CustomerID = o.CustomerID

SELECT COUNT(*) AS "No. Of Records" FROM Customers

SELECT a.au_lname + ', ' + a.au_fname AS "Author", t.title
FROM authors a
JOIN titleauthor ta
ON a.au_id = ta.au_id
JOIN titles t
ON t.title_id = ta.title_id

SELECT discounttype, discount, s.stor_name
FROM discounts d
JOIN stores s
ON d.stor_id = s.stor_id

SELECT discounttype, discount, s.stor_name
FROM discounts d
LEFT OUTER JOIN stores s
ON d.stor_id = s.stor_id

SELECT discounttype, discount, s.stor_name
FROM discounts d
RIGHT OUTER JOIN stores s
ON d.stor_id = s.stor_id

SELECT s.stor_name AS "Store Name"
FROM discounts d
RIGHT OUTER JOIN stores s
ON d.stor_id = s.stor_id
WHERE d.stor_id IS NULL

IF (NULL=NULL)
PRINT 'It Does'
ELSE
PRINT 'It Doesn''t'

SELECT DISTINCT c.CustomerID, c.CompanyName
FROM Customers c
INNER JOIN Orders o
ON c.CustomerID = o.CustomerID

SELECT COUNT(*) AS "No. Of Records" FROM Customers

USE Northwind
SELECT c.CustomerID, CompanyName
FROM Customers c
LEFT OUTER JOIN Orders o
ON c.CustomerID = o.CustomerID
WHERE o.CustomerID IS NULL

SELECT c.CustomerID, CompanyName
FROM Orders o
RIGHT OUTER JOIN Customers c
ON c.CustomerID = o.CustomerID
WHERE o.CustomerID IS NULL

SELECT v.VendorName
FROM Vendors v

SELECT v.VendorName
FROM Vendors v
LEFT OUTER JOIN VendorAddress va
ON v.VendorID = va.VendorID

SELECT *
FROM VendorAddress

SELECT v.VendorName, va.VendorID
FROM Vendors v
LEFT OUTER JOIN VendorAddress va
ON v.VendorID = va.VendorID

SELECT v.VendorName, a.Address
FROM Vendors v
LEFT OUTER JOIN VendorAddress va
ON v.VendorID = va.VendorID
JOIN Address a
ON va.AddressID = a.AddressID

SELECT v.VendorName, a.Address
FROM Vendors v
LEFT OUTER JOIN VendorAddress va
ON v.VendorID = va.VendorID
LEFT OUTER JOIN Address a
ON va.AddressID = a.AddressID

SELECT v.VendorName, a.Address
FROM VendorAddress va
JOIN Address a
ON va.AddressID = a.AddressID
RIGHT OUTER JOIN Vendors v
ON v.VendorID = va.VendorID

SELECT v.VendorName, a.Address
FROM VendorAddress va
JOIN Address a
ON va.AddressID = a.AddressID
RIGHT OUTER JOIN Vendors v
ON v.VendorID = va.VendorID

SELECT a.Address, va.AddressID
FROM VendorAddress va
FULL JOIN Address a
ON va.AddressID = a.AddressID

SELECT a.Address, va.AddressID, v.VendorID, v.VendorName
FROM VendorAddress va
FULL JOIN Address a
ON va.AddressID = a.AddressID
FULL JOIN Vendors v
ON va.VendorID = v.VendorID

SELECT v.VendorName, a.Address
FROM Vendors v
CROSS JOIN Address a

SELECT *
FROM Products
INNER JOIN Suppliers
ON Products.SupplierID = Suppliers.SupplierID

SELECT *
FROM Products, Suppliers
WHERE Products.SupplierID = Suppliers.SupplierID

SELECT discounttype, discount, s.stor_name
FROM discounts d
LEFT OUTER JOIN stores s
ON d.stor_id = s.stor_id

SELECT discounttype, discount, s.stor_name
FROM discounts d, stores s
WHERE d.stor_id *= s.stor_id

SELECT discounttype, discount, s.stor_name
FROM discounts d, stores s
WHERE d.stor_id =* s.stor_id

SELECT v.VendorName, a.Address
FROM Vendors v
CROSS JOIN Address a

SELECT v.VendorName, a.Address
FROM Vendors v, Address a

USE Northwind
go

SELECT CompanyName AS Name, Address, City, Region, PostalCode, Country
FROM Customers
UNION
SELECT CompanyName, Address, City, Region, PostalCode, Country
FROM Suppliers
UNION
SELECT FirstName + ' ' + LastName, Address, City, Region, PostalCode, Country
FROM Employees
Order By Name ASC

CREATE TABLE UnionTest1
(
idcol   int       IDENTITY,
col2    char(3),
)
CREATE TABLE UnionTest2
(
idcol   int       IDENTITY,
col4    char(3),
)
INSERT INTO UnionTest1
VALUES
('AAA')
INSERT INTO UnionTest1
VALUES
('BBB')
INSERT INTO UnionTest1
VALUES
('CCC')
INSERT INTO UnionTest2
VALUES
('CCC')
INSERT INTO UnionTest2
VALUES
('DDD')
INSERT INTO UnionTest2
VALUES
('EEE')
SELECT col2
FROM UnionTest1
UNION
SELECT col4
FROM UnionTest2
PRINT 'Divider Line--------------------------'
SELECT col2
FROM UnionTest1
UNION ALL
SELECT col4
FROM UnionTest2
DROP TABLE UnionTest1
DROP TABLE UnionTest2
