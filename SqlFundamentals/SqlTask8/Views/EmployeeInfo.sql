CREATE VIEW EmployeeInfo AS
	SELECT 
		E.Id AS EmployeeId, 
		CASE 
			WHEN E.EmployeeName is null
				THEN CONCAT(P.FirstName, ' ', P.LastName)
			ELSE
				E.EmployeeName
		END AS EmployeeFullName,
		CONCAT(A.ZipCode, '_', A.State, ', ', A.City, '-', A.Street) AS EmployeeFullAddress,
		CONCAT(E.CompanyName, ' (', E.Position, ')') AS EmployeeCompanyInfo
	FROM Employee AS E
		LEFT JOIN Person AS P on E.PersonId = P.Id
		LEFT JOIN Address AS A ON E.AddressId = A.Id
		LEFT JOIN Company AS C ON E.CompanyName = C.Name
	ORDER BY E.CompanyName, A.City ASC OFFSET 0 ROWS