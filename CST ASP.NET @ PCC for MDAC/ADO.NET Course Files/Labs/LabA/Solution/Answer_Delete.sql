/* 
 * Delete all "order details" that have a quantity greater than 50
 */

USE northwind
DELETE "order details"
  WHERE quantity > 50

SELECT * 
  FROM "order details"
  ORDER BY quantity 

GO
