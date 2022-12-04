CREATE PROCEDURE InsertEmployee
	@companyName NVARCHAR(50),
	@street NVARCHAR(50),
	@employeeName NVARCHAR(100) = null,
	@firstName NVARCHAR(50) = '',
	@lastName NVARCHAR(50) = '',
	@position NVARCHAR(30) = null,
	@city NVARCHAR(20) = null,
	@state NVARCHAR(50) = null,
	@zipCode NVARCHAR(50) = null
AS

DECLARE @isRollBack BIT;
DECLARE @currentPersonId INT;
DECLARE @currentAddressId INT;

SET @isRollBack = 0;

IF coalesce(TRIM(@employeeName), '') = '' AND
   coalesce(TRIM(@firstName), '') = '' AND
   coalesce(TRIM(@lastName), '') = ''
	BEGIN
		SET @isRollBack = 1;
	END

IF LEN(@companyName) > 20
	BEGIN
		SET @companyName = LEFT(@companyName, 20);
	END

IF @isRollBack = 0
BEGIN
	BEGIN TRY
	BEGIN TRANSACTION

		IF NOT EXISTS (SELECT * FROM Company WHERE Name = @companyName)
			BEGIN
				INSERT INTO Address VALUES (@street, @city, @state, @zipCode);
				SET @currentAddressId = (SELECT SCOPE_IDENTITY());

				INSERT INTO Company VALUES (@companyName, @currentAddressId);
			END
		ELSE
			BEGIN
				SET @currentAddressId = (SELECT AddressId FROM Company WHERE Name = @companyName);
			END

		INSERT INTO Person VALUES (@firstName, @lastName);
		SET @currentPersonId = (SELECT SCOPE_IDENTITY());

		INSERT INTO Employee VALUES (@currentAddressId, @currentPersonId, @companyName, @position, @employeeName);

	END TRY
		BEGIN CATCH
			PRINT('Something went wrong');
			ROLLBACK TRANSACTION;
			RETURN;
		END CATCH

	COMMIT TRANSACTION;
END
ELSE
BEGIN
	PRINT('Incorrect input data');
END
