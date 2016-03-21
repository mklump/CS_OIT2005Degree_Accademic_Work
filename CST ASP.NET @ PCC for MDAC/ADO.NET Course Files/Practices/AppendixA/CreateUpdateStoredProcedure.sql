/* 
 * Create a stored procedure to increase the cost of all products 
 * in the products table by 10 percent
 */

CREATE PROCEDURE increase_product_prices
AS
UPDATE products
  SET unitprice = unitprice * 1.1
GO
