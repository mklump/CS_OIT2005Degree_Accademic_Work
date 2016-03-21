CREATE PROCEDURE dbo.CountProducts

	(
		@Min money,
		@Max money
	)

AS
	SELECT COUNT(ProductID) AS ProductsCount
	FROM   Products
	WHERE  UnitPrice BETWEEN @Min AND @Max

