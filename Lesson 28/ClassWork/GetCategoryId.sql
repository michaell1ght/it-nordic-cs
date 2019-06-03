USE LifeHeroTour;
GO
DROP FUNCTION IF EXISTS [dbo].[GetCategoryId]
GO
CREATE FUNCTION dbo.GetCategoryId (
	@categoryname AS VARCHAR(50)
)
RETURNS UNIQUEIDENTIFIER
AS 
BEGIN
	DECLARE @guid AS UNIQUEIDENTIFIER

	SELECT @guid = Id
	FROM dbo.Category
	WHERE [Name] = @categoryname
	IF(@guid IS NULL)
	BEGIN
		SELECT TOP 1 @guid = id
		FROM dbo.Category
		WHERE [Name] like @categoryname + '%'
	END
	RETURN(@guid)
END

SELECT dbo.GetCategoryId('Mobile Phone');
SELECT dbo.GetCategoryId('Mob');
SELECT dbo.GetCategoryId('asd');
