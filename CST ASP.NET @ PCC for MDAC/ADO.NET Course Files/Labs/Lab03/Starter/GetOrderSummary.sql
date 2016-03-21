CREATE PROCEDURE dbo.GetOrderSummary

AS
	SELECT * 
	FROM OrderSummary
	ORDER BY Orders
	
	RETURN

