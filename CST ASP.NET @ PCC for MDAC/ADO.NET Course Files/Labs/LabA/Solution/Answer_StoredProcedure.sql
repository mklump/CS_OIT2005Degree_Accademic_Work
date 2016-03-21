/* 
 * Create a stored procedure to perform these tasks:
 *   Increase the unitprice by 5 percent, for all current products.
 *   Increase the unitsinstock by 10, for all current products.
 *   Select all products.
 */

CREATE PROCEDURE update_products_info
  AS

UPDATE products
  SET unitprice = unitprice * 1.05
  WHERE discontinued = 0

UPDATE products
  SET unitsinstock = unitsinstock + 10
  WHERE discontinued = 0

SELECT * 
  FROM products

GO
