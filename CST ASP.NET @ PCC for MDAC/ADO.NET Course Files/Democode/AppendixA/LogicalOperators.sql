/* 
 * Retrieve products that start with T or have a product ID
 * of 46, and cost more than $10 
 */

USE northwind
SELECT productid, productname, supplierid, unitprice
  FROM products
  WHERE (productname LIKE 'T%' OR productid = 46)
    AND (unitprice > 10.00)
GO
