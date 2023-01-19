ALTER TABLE Orders
	ADD CONSTRAINT FK_Orders_Products FOREIGN KEY (ProductId)
	REFERENCES Products (Id);