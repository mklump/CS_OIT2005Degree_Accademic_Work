CREATE PROCEDURE dbo.GetProductsInRange

	(
		@Min money,
		@Max money
	)

AS
	SELECT ProductID, ProductName, UnitPrice
	FROM   Products
	WHERE  (UnitPrice BETWEEN @Min AND @Max) AND UnitsInStock <> 0
	
	RETURN

