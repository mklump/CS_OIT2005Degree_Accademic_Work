/* 
 * Select the productname and categoryname for each product.
 * Order the result set by categoryname.
 */

USE northwind
SELECT productname, categoryname
  FROM products AS p
    JOIN categories AS c
      ON p.categoryid = c.categoryid 
  ORDER BY categoryname
GO

