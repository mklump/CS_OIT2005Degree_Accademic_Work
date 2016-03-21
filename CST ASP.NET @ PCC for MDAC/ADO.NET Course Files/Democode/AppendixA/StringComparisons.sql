/* 
 * Retrieve company names that contain the word restaurant 
 */

USE northwind
SELECT companyname
  FROM customers
  WHERE companyname LIKE '%Restaurant%'
GO
