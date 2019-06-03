USE LifeHeroTour;

GO;

--DROP TABLE dbo.Category
CREATE TABLE dbo.Category(
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY CLUSTERED (Id),
	CONSTRAINT UQ_Category_Name UNIQUE ([Name])
	);

SELECT * FROM dbo.Category;

INSERT INTO dbo.Category (Id, [Name]) 
	VALUES (NEWID(), 'Mobile Phones');

INSERT INTO dbo.Category (Id, [Name]) 
	VALUES (NEWID(), 'TV');

UPDATE dbo.Category
	SET [Name] = 'Mobile Phone'
	WHERE [Name] = 'Mobile Phones';

SELECT /*TOP 1*/ [Name], Id 
FROM dbo.Category
--WHERE [Name] LIKE 'Mobile%'
ORDER BY [Name] DESC;

DELETE FROM dbo.Category
WHERE [Name] LIKE 'Mob%'

