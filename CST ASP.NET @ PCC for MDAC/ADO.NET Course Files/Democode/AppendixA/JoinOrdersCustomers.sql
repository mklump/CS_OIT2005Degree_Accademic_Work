/* 
 * Join the orders and customers tables, using the customerid
 * for the join condition.
 */

USE northwind
SELECT orderid, orderdate, companyname
  FROM orders JOIN customers
  ON orders.customerid = customers.customerid
GO