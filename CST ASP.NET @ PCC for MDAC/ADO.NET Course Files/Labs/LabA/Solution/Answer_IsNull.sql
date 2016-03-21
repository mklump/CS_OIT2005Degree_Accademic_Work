/* 
 * Select the orderid, orderdate, and requireddate 
 * for orders that have not yet been shipped
 */

USE northwind
SELECT orderid, orderdate, requireddate 
  FROM orders
  WHERE shippeddate IS NULL
GO

