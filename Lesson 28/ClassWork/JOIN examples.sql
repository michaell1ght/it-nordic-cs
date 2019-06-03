SELECT * 
FROM dbo.Category
FULL JOIN dbo.Goods
	On dbo.Goods.CategoryId = dbo.Category.Id

SELECT * 
FROM dbo.Category
INNER JOIN dbo.Goods
	On dbo.Goods.CategoryId = dbo.Category.Id

SELECT C.* 
FROM dbo.Category AS C
LEFT JOIN dbo.Goods AS G
	On G.CategoryId = C.Id
WHERE G.CategoryId IS NULL