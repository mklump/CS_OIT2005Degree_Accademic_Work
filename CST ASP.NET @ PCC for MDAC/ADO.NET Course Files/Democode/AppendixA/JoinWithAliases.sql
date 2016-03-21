/* 
 * Join the orders and customers tables, using the customerid
 * for the join condition. Use aliases for the orders and customers tables.
 */

USE northwind
SELECT orderid, orderdate, companyname
  FROM orders AS o  JOIN  customers AS c
  ON o.customerid = c.customerid
GO