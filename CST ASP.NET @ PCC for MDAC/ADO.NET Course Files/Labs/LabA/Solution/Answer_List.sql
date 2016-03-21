/* 
 * Select the companyname and country for customers 
 * that live in Germany, France, or the UK
 */

USE northwind
SELECT companyname, country
 FROM customers
 WHERE country IN ('Germany','France', 'UK') 
GO

