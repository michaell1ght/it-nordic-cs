SELECT T.Name, SUM(T.Total) 
FROM 
	(
	SELECT
		C.[Name],
		(1 - ISNULL(O.[Discount],0)) * SUM(P.[Price] * OI.[NumberOfItems]) AS Total
	FROM dbo.[OrderItem] AS OI
	JOIN dbo.Product AS P 
		ON OI.ProductId = P.Id
	JOIN dbo.[Order] AS O
		ON O.Id =OI.OrderId
	JOIN dbo.Customer AS C
		ON C.Id = O.CustomerId
	GROUP BY O.Discount, C.[Name]
	) AS T
GROUP BY T.[Name]