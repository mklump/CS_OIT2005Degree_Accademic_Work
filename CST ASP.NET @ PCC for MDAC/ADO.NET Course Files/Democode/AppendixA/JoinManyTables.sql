/* 
 * Join the orders, customers, and employees tables.
 * For each order, retrieve:
 *   the order id, 
 *   the lastname of the employee that took the order,
 *   the companyname that placed the order.
 */

USE northwind
SELECT orderid, lastname, companyname
  FROM orders AS o 
    JOIN customers AS c 
      ON o.customerid = c.customerid
    JOIN employees AS e 
      ON o.employeeid = e.employeeid
GO