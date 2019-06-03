USE LifeHeroTour;
GO
CREATE PROCEDURE dbo.CreateCategory(
	@categoryName AS VARCHAR(50),
	@guid AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @tempGuid AS UNIQUEIDENTIFIER
	SET @tempGuid = NEWID()
	
	INSERT INTO dbo.Category (Id, [Name])
	VALUES (@tempGuid, @categoryName)

	SET @guid = @tempGuid

END
GO

DELETE FROM dbo.Category WHERE [Name] = 'test'
DECLARE @guid AS UNIQUEIDENTIFIER
EXEC dbo.CreateCategory @categoryName = 'test', @guid = @guid OUTPUT
PRINT CONVERT(VARCHAR(50), @guid)
SELECT * FROM dbo.Category