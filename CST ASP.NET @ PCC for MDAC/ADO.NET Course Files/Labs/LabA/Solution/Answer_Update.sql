/* 
 * Update the products table. For all products currently offered by Northwind Traders, 
 * increase the reorderlevel by 10 items.
 */

USE northwind
UPDATE products
  SET reorderlevel = reorderlevel + 10
  WHERE discontinued = 0

SELECT * 
  FROM products

GO
