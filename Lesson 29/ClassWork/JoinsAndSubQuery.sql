USE LiveHeroTour2
GO

--O.Id, , P.Price 

SELECT
	P.[Id] AS ProductId,
	P.[Name] AS ProductName, 
	P.[Price] AS ProductPrice, 
	OI.[NumberOfItems] AS ProductNumberOfItems,
	(P.[Price]* OI.[NumberOfItems]) AS TotalPrice
FROM dbo.[OrderItem] AS OI
JOIN dbo.Product AS P 
	ON OI.ProductId = P.Id
WHERE OrderId = 22;


SELECT (
(SELECT
	SUM(P.[Price] * OI.[NumberOfItems])
FROM dbo.[OrderItem] AS OI
JOIN dbo.Product AS P 
	ON OI.ProductId = P.Id
JOIN dbo.[Order] AS O
	ON O.Id =OI.OrderId
JOIN dbo.Customer AS C
	ON C.Id = O.CustomerId
WHERE C.ID = (
SELECT TOP 1 C.Id
FROM dbo.Customer AS C
WHERE C.[Name] Like('%Мария%')
)
)

/

(SELECT
	SUM(P.[Price] * OI.[NumberOfItems])
FROM dbo.[OrderItem] AS OI
JOIN dbo.Product AS P 
	ON OI.ProductId = P.Id
JOIN dbo.[Order] AS O
	ON O.Id =OI.OrderId
JOIN dbo.Customer AS C
	ON C.Id = O.CustomerId
)
)
