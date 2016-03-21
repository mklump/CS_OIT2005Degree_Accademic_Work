/* 
 * Retrieve suppliers in Japan or Italy 
 */

USE northwind
SELECT companyname, country
  FROM suppliers
  WHERE country IN ('Japan', 'Italy')
GO
