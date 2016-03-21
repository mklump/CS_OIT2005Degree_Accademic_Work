/* 
 * Retrieve suppliers that have a null fax 
 */

USE northwind
SELECT companyname, fax
  FROM suppliers
  WHERE fax IS NULL
GO
