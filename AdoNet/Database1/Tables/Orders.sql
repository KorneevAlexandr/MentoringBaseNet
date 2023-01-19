CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	Status INT,
	CreatedDate DATETIME,
	UpdatedData DATETIME,
	ProductId INT
);