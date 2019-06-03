USE LiveHeroTour2
GO

--1
SELECT O.Id
FROM [dbo].[Order] AS O
WHERE O.Discount = (
	SELECT MAX(O.Discount)
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate) = 2016
)

--2
SELECT O.Id
FROM [dbo].[Order] AS O
WHERE O.OrderDate =(
	SELECT MIN(O.OrderDate)
	FROM [dbo].[Order] AS O
	WHERE YEAR(O.OrderDate) = 2019
)

--3
SELECT * FROM dbo.Customer AS C
WHERE C.Id IN (
	SELECT O.CustomerId
	FROM [dbo].[Order] AS O
	WHERE O.Discount = (
		SELECT MAX(O.Discount)
		FROM [dbo].[Order] AS O
		WHERE YEAR(O.OrderDate) = 2016)
)

--4
SELECT * FROM dbo.Customer AS C
WHERE C.Id IN
(
	SELECT O.CustomerId
	FROM [dbo].[Order] AS O
	WHERE O.OrderDate = (
		SELECT MIN(O.OrderDate)
		FROM [dbo].[Order] AS O
		WHERE YEAR(O.OrderDate) = 2019
	)
)

SELECT * FROM Customer AS C
WHERE C.Id IN (
	SELECT O.CustomerId
	FROM [Order] AS O
	WHERE Discount IS NULL
)

--всех клиентов, у которых хотя бы 1 раз не было скидки