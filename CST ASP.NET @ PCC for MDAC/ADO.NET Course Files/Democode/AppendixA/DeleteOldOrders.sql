/* 
 * Delete orders that are at least six months old
 */

USE northwind
DELETE orders
  WHERE DATEDIFF (MONTH, shippeddate, GETDATE()) >= 6
GO
