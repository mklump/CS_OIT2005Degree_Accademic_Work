
CREATE TRIGGER OrderDetailNotDiscontinued
ON [Order Details]
FOR INSERT, UPDATE
AS
IF EXISTS
(
SELECT 'True'
FROM Inserted i
JOIN Products p
ON i.ProductID = p.ProductID
WHERE p.Discontinued = 1
)
BEGIN
RAISERROR('Order Item is discontinued. Transaction Failed.',16,1)
ROLLBACK TRAN
END
SELECT ProductID, ProductName FROM Products WHERE Discontinued = 1

INSERT [Order Details]
(OrderID, ProductID, UnitPrice, Quantity, Discount)
VALUES
(10000, 5, 21.35, 5, 0)

CREATE TRIGGER ProductIsRationed
ON Products
FOR UPDATE
AS
IF EXISTS
(
SELECT 'True'
FROM Inserted i
JOIN Deleted d
ON i.ProductID = d.ProductID
WHERE (d.UnitsInStock - i.UnitsInStock) > d.UnitsInStock / 2
AND d.UnitsInStock - i.UnitsInStock > 0
)
BEGIN
RAISERROR('Cannot reduce stock by more than 50%% at once.',16,1)
ROLLBACK TRAN
END
UPDATE Products
SET UnitsInStock = 2
WHERE ProductID = 8

ALTER TRIGGER ProductIsRationed
ON Products
FOR UPDATE
AS
IF UPDATE(UnitsInStock)
BEGIN
IF EXISTS
(
SELECT 'True'
FROM Inserted i
JOIN Deleted d
ON i.ProductID = d.ProductID
WHERE (d.UnitsInStock - i.UnitsInStock) > d.UnitsInStock / 2
AND d.UnitsInStock - i.UnitsInStock > 0
)
BEGIN
RAISERROR('Cannot reduce stock by more than 50%% at once.',16,1)
ROLLBACK TRAN
END
END

ALTER PROC spTestTriggerDebugging
AS
BEGIN
-- This one should work
UPDATE Products
SET UnitsInStock = UnitsInStock - 1
WHERE ProductID = 6;
-- This one shouldn't
UPDATE Products
SET UnitsInStock = UnitsInStock - 12
WHERE ProductID = 26;
