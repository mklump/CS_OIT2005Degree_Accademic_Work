CREATE PROCEDURE dbo.SummarizeOrders

AS

/* Does the OrderSummary table already exist? */
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
		WHERE TABLE_NAME = 'OrderSummary')

	/* Empty the OrderSummary table */
	DELETE FROM OrderSummary

ELSE
	/* Create the OrderSummary table */
	CREATE TABLE OrderSummary
	(
	Orders int,
	ProductName nvarchar(40)
	)


/* Populate the OrderSummary table */
INSERT OrderSummary
	SELECT SUM(od.quantity), p.ProductName
		FROM "Order Details" AS od 
			INNER JOIN Products AS p
			ON od.ProductID = p.ProductID
		GROUP BY p.ProductName
