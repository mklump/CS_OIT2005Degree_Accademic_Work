/* 
 * Join the orders and employees tables, using the employeeid
 * for the join condition.
 */

USE northwind
SELECT orderid, orderdate, lastname
  FROM orders JOIN employees
  ON orders.employeeid = employees.employeeid
GO