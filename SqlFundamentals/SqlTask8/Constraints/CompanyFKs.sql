ALTER TABLE Company
   ADD CONSTRAINT FK_Company_Address FOREIGN KEY (AddressId) REFERENCES Address (Id);