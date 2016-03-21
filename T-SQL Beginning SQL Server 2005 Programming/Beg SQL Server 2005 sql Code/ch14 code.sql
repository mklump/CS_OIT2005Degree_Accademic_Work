UPDATE checking
SET Balance = Balance - 1000
WHERE Account = 'Sally'
UPDATE savings
SET Balance = Balance + 1000
WHERE Account = 'Sally'

UPDATE Employees
SET HourlyRate = 6.75
WHERE HourlyRate < 6.75
ALTER TABLE Employees
ADD ckWage CHECK (HourlyRate >= 6.75)
GO
