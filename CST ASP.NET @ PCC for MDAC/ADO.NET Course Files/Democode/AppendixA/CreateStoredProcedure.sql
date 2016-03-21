/* 
 * Create a stored procedure with a complex SELECT statement, 
 * which performs a join on the orders, customers, and employees tables 
 */

CREATE PROCEDURE orders_info_all
AS
SELECT orderid, companyname, lastname
  FROM orders AS o
   JOIN customers AS c ON o.customerid = c.customerid
   JOIN employees AS e ON o.employeeid = e.employeeid
GO
