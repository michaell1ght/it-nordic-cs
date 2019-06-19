DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
GO
CREATE PROCEDURE [dbo].[AddReminderItem] (
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT,
	@reminderId AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE
		@now AS DATETIMEOFFSET,
		@tempReminderId AS UNIQUEIDENTIFIER
	
	SELECT 
		@now = SYSDATETIMEOFFSET(),
		@tempReminderId = NEWID(); 

	INSERT INTO [dbo].[ReminderItem](
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId],
		[CreatedDate],
		[UpdatedDate])
	VALUES (
		@tempReminderId,
		@contactId,
		@targetDate,
		@message,
		@statusId,
		@now,
		@now)
	
	SET @reminderId = @tempReminderId
END
GO

DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemById]
GO
CREATE PROCEDURE dbo.GetReminderItemById(
	@ReminderId AS UNIQUEIDENTIFIER
)
AS BEGIN
	SELECT [Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM dbo.ReminderItem
	WHERE Id = @reminderId
END
GO

DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemListByStatus]
GO
CREATE PROCEDURE dbo.GetReminderItemListByStatus(
	@statusId AS TINYINT
)
AS BEGIN
	SELECT [Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId]
	FROM dbo.ReminderItem
	WHERE StatusId = @statusId
END
GO

DROP PROCEDURE IF EXISTS [dbo].[UpdateReminderItemStatusById]
GO
CREATE PROCEDURE dbo.UpdateReminderItemStatusById(
	@reminderId AS UNIQUEIDENTIFIER,
	@statusId AS INT
)
AS BEGIN
	UPDATE dbo.ReminderItem
		SET StatusId = @statusId,
			UpdatedDate = SYSDATETIMEOFFSET()
	WHERE Id= @reminderId
END
GO

DROP PROCEDURE if EXISTS [dbo].[GetReminderItemsCount]
GO
CREATE PROCEDURE [dbo].[GetReminderItemsCount]
AS BEGIN

	SELECT COUNT(*) 
	FROM [dbo].[ReminderItem]
END
GO

DROP PROCEDURE IF EXISTS [dbo].[RemoveReminderItem]
GO
CREATE PROCEDURE [dbo].[RemoveReminderItem](
	@reminderId AS UNIQUEIDENTIFIER)
AS BEGIN
	SET NOCOUNT ON

	DELETE FROM [dbo].[ReminderItem]
	WHERE Id= @reminderId
	
	SELECT CAST(@@ROWCOUNT AS BIT)
END
GO

DROP PROCEDURE IF EXISTS dbo.UpdateReninderItemsBulk
GO
CREATE PROCEDURE dbo.UpdateReninderItemsBulk(
	@statusId as TINYINT)
AS BEGIN
UPDATE R
	SET R.StatusId = @statusId,
		R.UpdatedDate = SYSDATETIMEOFFSET()
	FROM dbo.ReminderItem AS R
	INNER JOIN #ReminderItem AS T
		ON T.Id= R.Id
END
GO