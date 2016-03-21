CREATE PROCEDURE dbo.InsertProduct
  (
    @ProductName nvarchar(40),
    @CategoryID int,
    @SupplierID int
  )
AS
  INSERT INTO Products(ProductName, CategoryID, SupplierID)
         VALUES(@ProductName, @CategoryID, @SupplierID)
  RETURN @@IDENTITY  
