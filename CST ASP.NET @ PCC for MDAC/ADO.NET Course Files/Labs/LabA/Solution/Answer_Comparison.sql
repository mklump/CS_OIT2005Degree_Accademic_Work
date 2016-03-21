/* 
 * Select the productname and unitprice for product number 10
 */

USE northwind
SELECT productname, unitprice
  FROM products
  WHERE productid = 10
GO
