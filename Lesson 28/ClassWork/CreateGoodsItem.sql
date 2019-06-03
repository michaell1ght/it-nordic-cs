USE LifeHeroTour;
GO
DROP PROCEDURE dbo.CreateGoodsItem
GO
CREATE PROCEDURE dbo.CreateGoodsItem(
	@categoryName AS VARCHAR(50),
	@goodsItemName AS NVARCHAR(100),
	@goodsItemId AS INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @guid AS UNIQUEIDENTIFIER
	SET @guid = dbo.GetCategoryId(@categoryName)

	SET XACT_ABORT ON
	BEGIN TRANSACTION

	BEGIN TRY
		IF(@guid IS NULL)
			EXEC dbo.CreateCategory 
				@categoryName=@categoryName, 
				@guid = @guid OUTPUT
		INSERT INTO dbo.Goods (CategoryId,[Name]) 
			VALUES (@guid,@goodsItemName)
		SET @goodsItemId = SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
		IF(XACT_STATE() = -1)
			ROLLBACK TRANSACTION
			THROW
	END CATCH

	IF(XACT_STATE() = 1)
		COMMIT TRANSACTION
END
GO

SELECT * FROM dbo.Category
SELECT * FROM dbo.Goods

EXEC dbo.CreateGoodsItem 'TV', 'Panasonic 300', 0
EXEC dbo.CreateGoodsItem 'Printers', 'EPSON 300', 0
EXEC dbo.CreateGoodsItem 'Radio', 'EPSON 400', 0

DELETE FROM dbo.Goods
WHERE CategoryId='245AF17F-733F-452A-B28B-BEB592C2AD8D';
DELETE FROM dbo.Category
WHERE Id = '245AF17F-733F-452A-B28B-BEB592C2AD8D';