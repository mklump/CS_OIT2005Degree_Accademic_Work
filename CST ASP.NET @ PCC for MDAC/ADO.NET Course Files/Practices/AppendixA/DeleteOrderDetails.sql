/* 
 * Delete order details where the quantity is more than 50
 */
USE northwind
DELETE "order details"
  WHERE quantity > 50
GO

