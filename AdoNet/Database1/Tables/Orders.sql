CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	Status INT,
	CreatedDate DATETIME,
	UpdatedDate DATETIME,
	ProductId INT
);