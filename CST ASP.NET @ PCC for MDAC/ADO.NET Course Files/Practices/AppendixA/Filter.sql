/*
 * Retrieve the product name, unit price, and units-in-stock 
 * for selective products
 */

USE northwind
SELECT productname, unitprice, unitsinstock
  FROM products
  WHERE (productname LIKE 't%')
    AND (unitprice BETWEEN 5 AND 10)
    AND (unitsinstock >= 25)
GO

