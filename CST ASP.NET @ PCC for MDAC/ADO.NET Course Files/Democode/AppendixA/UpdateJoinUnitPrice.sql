/* 
 * Increase the unitprice of all products supplied by US-based suppliers
 */

USE northwind
UPDATE products
  SET unitprice = unitprice + 2
  FROM products JOIN suppliers
    ON products.supplierid = suppliers.supplierid
  WHERE suppliers.country = 'USA'
GO
