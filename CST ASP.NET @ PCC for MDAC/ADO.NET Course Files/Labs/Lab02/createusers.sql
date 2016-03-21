/* 
 * Create SQL Server login accounts 
 */

USE northwind
EXEC sp_addlogin 'JohnK', 'JohnK', 'Northwind'
GO
EXEC sp_addlogin 'AmyJ', 'AmyJ', 'Northwind'
GO
