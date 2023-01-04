CREATE TRIGGER InsertAddressFromEmployee
ON DATABASE
FOR Employee

AS
BEGIN
	INSERT INTO Company
	VALUES 
	(
		(SELECT CompanyName FROM inserted),
		(SELECT AddressId FROM inserted)
	);
END
