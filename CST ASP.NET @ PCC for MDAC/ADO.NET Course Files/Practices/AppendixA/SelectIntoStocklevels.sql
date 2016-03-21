/* 
 * Create a new table named stocklevels, and populate 
 * the table with:
 *    the name of each product, 
 *    the unitsinstock, and 
 *    the difference between the unitsinstock and reorderlevel values.
 */

USE northwind
SELECT productname AS product
       , unitsinstock AS currentstocklevel
       , (unitsinstock - reorderlevel) AS abovereorderlevel
  INTO #stocklevels
  FROM products
GO
