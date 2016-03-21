/*
 * Retrieve the product ID, product name, units-in-stock, and reorder level
 * for products that have fallen below the reorder threshold
 */

USE northwind
SELECT productid, productname, unitsinstock, reorderlevel
  FROM products
  WHERE unitsinstock < reorderlevel
GO

