/* Retrieve the product ID, product name, and unit price
   for products costing more than $50 and less than $100.
   Retrieve products in order of descending price */
USE northwind
SELECT productid, productname, unitprice
  FROM products
  WHERE unitprice > 50.00 AND unitprice < 100.00
  ORDER BY unitprice DESC
GO
