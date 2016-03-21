CREATE PROCEDURE dbo.CategoriesAndProducts
AS
	SELECT * FROM Categories ORDER BY CategoryName
	SELECT * FROM Products ORDER BY ProductName
