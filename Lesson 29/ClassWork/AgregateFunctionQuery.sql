USE LiveHeroTour2
GO

---¹2
SELECT Count(Distinct(ORDR.id)) FROM OrderItem as OITM
JOIN [Order] AS ORDR ON
ORDR.Id = OITM.OrderId;

---¹3
SELECT MAX(O.Id) FROM [Order] AS O;

---¹4
SELECT AVG(O.Discount) FROM [Order] AS O;

---¹6
SELECT MIN(O.OrderDate)AS MinOrderDate, MAX(O.OrderDate) AS MaxOrderDate FROM [Order] AS O
WHERE YEAR(O.OrderDate) = 2018;

---¹7
SELECT MAX(LEN(P.Name)) FROM Product AS P;