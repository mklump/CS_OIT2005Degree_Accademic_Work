
CREATE TABLE MyTableKeyExample
(
Column1   intIDENTITY
PRIMARY KEY NONCLUSTERED,
Column2   int
)

USE Northwind
GO
DBCC SHOWCONTIG (@id, @IdxID)
GO
DBCC SHOWCONTIG scanning 'Order Details' table...

DBCC DBREINDEX ([Order Details], PK_Order_Details, 65)
