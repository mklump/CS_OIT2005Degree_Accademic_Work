CREATE PROCEDURE dbo.CountOrders

	(
		@CustomerID nchar(5),
		@CompanyName nvarchar(40) OUTPUT
	)

AS
	SET NOCOUNT ON

	DECLARE @OrdersCount int
	
	SELECT @CompanyName = Customers.CompanyName, @OrdersCount = COUNT(Orders.OrderID)
	FROM Customers INNER JOIN Orders 
          ON Customers.CustomerID = Orders.CustomerID
	WHERE (Customers.CustomerID = @CustomerID)
	GROUP BY Customers.CompanyName
	
	RETURN @OrdersCount
