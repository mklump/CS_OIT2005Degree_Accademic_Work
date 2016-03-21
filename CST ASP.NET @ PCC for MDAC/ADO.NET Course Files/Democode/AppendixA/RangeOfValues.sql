/* 
 * Retrieve products costing between $10 and $18 inclusive 
 */

USE northwind
SELECT productname, unitprice
  FROM products
  WHERE unitprice BETWEEN 10 AND 18
GO
