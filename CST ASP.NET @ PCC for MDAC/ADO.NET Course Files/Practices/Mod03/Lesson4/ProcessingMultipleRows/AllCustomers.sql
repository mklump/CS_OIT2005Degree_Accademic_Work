CREATE PROCEDURE dbo.AllCustomers
AS
	SELECT     *
	FROM         Customers
	ORDER BY CompanyName
