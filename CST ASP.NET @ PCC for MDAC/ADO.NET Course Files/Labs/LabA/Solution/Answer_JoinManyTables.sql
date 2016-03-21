/* 
 * Select the productname, categoryname, and supplier companyname 
 * for each product. Order the result set by supplier companyname.
 */

USE northwind
SELECT productname, categoryname, companyname
  FROM products AS p
    JOIN categories AS c
      ON p.categoryid = c.categoryid 
    JOIN suppliers AS s
      ON p.supplierid = s.supplierid 
  ORDER BY companyname
GO

