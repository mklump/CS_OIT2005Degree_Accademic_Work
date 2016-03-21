/* 
 * Retrieve information for employees who reside in the US 
 */

USE northwind
SELECT lastname, city 
  FROM employees
  WHERE country = 'USA'
GO
