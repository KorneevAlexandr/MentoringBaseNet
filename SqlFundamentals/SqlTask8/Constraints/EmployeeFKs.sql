GO
ALTER TABLE Employee
   ADD CONSTRAINT FK_Employee_Address FOREIGN KEY (AddressId) REFERENCES Address (Id);
GO

GO
ALTER TABLE Employee
   ADD CONSTRAINT FK_Employee_Person FOREIGN KEY (PersonId) REFERENCES Person (Id);
GO