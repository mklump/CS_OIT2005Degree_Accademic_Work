/* 
 * Add 10 percent to the price of products that cost more than $50
 */

USE northwind
UPDATE products
  SET unitprice = unitprice * 1.1
  WHERE unitprice >= 50
GO

