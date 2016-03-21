/* 
 * Select the productname and unitprice for products 
 * that cost between $20.00 and $50.00 inclusive
 */

USE northwind
SELECT productname, unitprice 
 FROM products
 WHERE (unitprice BETWEEN 20.00 AND 50.00) 
GO
