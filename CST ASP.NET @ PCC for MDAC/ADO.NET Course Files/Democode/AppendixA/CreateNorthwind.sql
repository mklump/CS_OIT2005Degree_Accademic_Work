CREATE DATABASE [Northwind]  ON (NAME = N'Northwind', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\northwnd.mdf' , SIZE = 4, FILEGROWTH = 10%) LOG ON (NAME = N'Northwind_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\data\northwnd.ldf' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE Latin1_General_CI_AS
GO

exec sp_dboption N'Northwind', N'autoclose', N'false'
GO

exec sp_dboption N'Northwind', N'bulkcopy', N'true'
GO

exec sp_dboption N'Northwind', N'trunc. log', N'true'
GO

exec sp_dboption N'Northwind', N'torn page detection', N'true'
GO

exec sp_dboption N'Northwind', N'read only', N'false'
GO

exec sp_dboption N'Northwind', N'dbo use', N'false'
GO

exec sp_dboption N'Northwind', N'single', N'false'
GO

exec sp_dboption N'Northwind', N'autoshrink', N'false'
GO

exec sp_dboption N'Northwind', N'ANSI null default', N'false'
GO

exec sp_dboption N'Northwind', N'recursive triggers', N'false'
GO

exec sp_dboption N'Northwind', N'ANSI nulls', N'false'
GO

exec sp_dboption N'Northwind', N'concat null yields null', N'false'
GO

exec sp_dboption N'Northwind', N'cursor close on commit', N'false'
GO

exec sp_dboption N'Northwind', N'default to local cursor', N'false'
GO

exec sp_dboption N'Northwind', N'quoted identifier', N'false'
GO

exec sp_dboption N'Northwind', N'ANSI warnings', N'false'
GO

exec sp_dboption N'Northwind', N'auto create statistics', N'true'
GO

exec sp_dboption N'Northwind', N'auto update statistics', N'true'
GO
