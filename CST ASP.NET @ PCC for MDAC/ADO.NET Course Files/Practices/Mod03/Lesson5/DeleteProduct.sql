CREATE PROCEDURE dbo.DeleteProduct
  (
    @ProductID int
  )
AS
  DELETE FROM Products WHERE ProductID = @ProductID
