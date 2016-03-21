/* 
 * Select the companyname for customers that contain the  
 * word 'market' in the companyname
 */

USE northwind
SELECT companyname 
  FROM customers 
  WHERE companyname LIKE '%market%'
GO