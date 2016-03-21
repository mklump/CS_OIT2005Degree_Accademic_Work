/* 
 * Add 10 percent to the price of all products 
 */

USE northwind
UPDATE products
  SET unitprice = unitprice * 1.1
GO
