USE Accounting

DELETE FROM Employees

SET IDENTITY_INSERT Employees ON

INSERT INTO Employees
(EmployeeID, FirstName, MiddleInitial, LastName, Title, SSN, Salary, PriorSalary, HireDate, ManagerEmpID, Department)
VALUES
(4, 'Howard', 'I', 'Kilroy', 'President', '00366725853', 60000, 0, '1/6/1994', 4, 'Sales')


INSERT INTO Employees
(EmployeeID, FirstName, LastName, Title, SSN, Salary, PriorSalary, HireDate, ManagerEmpID, Department)
VALUES
(2, 'Peter', 'Principle', 'Sales Manager', '99887766551', 40000, 0, '1/31/1997', 4, 'Sales')
INSERT INTO Employees
(EmployeeID, FirstName, MiddleInitial, LastName, Title, SSN, Salary, PriorSalary, HireDate, TerminationDate, ManagerEmpID, Department)
VALUES
(3, 'Steve', 'M', 'Smith', 'Sales Manager', '73983992134', 40000, 0, '4/7/1995', '1/31/1997', 4, 'Sales')

INSERT INTO Employees
(EmployeeID, FirstName, LastName, Title, SSN, Salary, PriorSalary, HireDate, ManagerEmpID, Department)
VALUES
(1, 'Joe', 'Dokey', 'Sales Representative', '12345678910', 30000, 0, '2/4/1998', 2, 'Sales')

INSERT INTO Employees
(EmployeeID, FirstName, MiddleInitial, LastName, Title, SSN, Salary, PriorSalary, HireDate, TerminationDate, ManagerEmpID, Department)
VALUES
(5, 'Mary', 'Q', 'Contrary', 'Sales Representative', '64883612992', 0, 30000, '4/7/1997', '6/15/1998', 2, 'Sales')

INSERT INTO Employees
(EmployeeID, FirstName, LastName, Title, SSN, Salary, PriorSalary, HireDate, ManagerEmpID, Department)
VALUES
(6, 'Billy', 'Bob', 'Sales Representative', '27495040362', 30000, 0, '9/1/1995', 2, 'Sales')

SET IDENTITY_INSERT Employees OFF


