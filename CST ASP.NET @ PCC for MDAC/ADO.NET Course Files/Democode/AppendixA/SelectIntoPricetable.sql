/* 
 * Retrieve data from the products table, and insert the result set into a new temporary table named #pricetable
 */

USE northwind
SELECT productname AS products
       , unitprice AS price
       , (unitprice * 0.1) AS tax
  INTO #pricetable
  FROM products
GO
