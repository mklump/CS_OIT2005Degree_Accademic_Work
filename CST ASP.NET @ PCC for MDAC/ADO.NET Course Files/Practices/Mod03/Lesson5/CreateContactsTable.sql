CREATE PROCEDURE dbo.CreateContactsTable 
AS
  CREATE TABLE Contacts 
  (
    CustomerID nvarchar(5),
    EmployeeID int,
    Started datetime
  )
