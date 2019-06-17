-- drop foreign key
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReminderItem]') AND type in (N'U'))
	ALTER TABLE [dbo].[ReminderItem] DROP CONSTRAINT IF EXISTS [FK_ReminderItem_StatusId]
GO
--
-- (Re-)create [dbo].[ReminderItem]
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReminderItem]') AND type in (N'U'))
	DROP TABLE [dbo].[ReminderItem]
GO
CREATE TABLE [dbo].[ReminderItem] (
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[ContactId] VARCHAR(50) NOT NULL, -- According to the model's restriction in ReminderItemCreateModel.cs
	[TargetDate] DATETIMEOFFSET NOT NULL,
	[Message] NVARCHAR(200) NOT NULL, -- -- According to the model's restriction in ReminderItemCreateModel.cs
	[StatusId] TINYINT NOT NULL,
	[CreatedDate] DATETIMEOFFSET NOT NULL,
	[UpdatedDate] DATETIMEOFFSET NOT NULL,
	CONSTRAINT PK_ReminderItem PRIMARY KEY CLUSTERED (Id)
);
GO
--
-- (Re-)create [dbo].[ReminderItemStatus]
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReminderItemStatus]') AND type in (N'U'))
	DROP TABLE [dbo].[ReminderItemStatus]
GO
CREATE TABLE [dbo].[ReminderItemStatus] (
	Id TINYINT NOT NULL,
	[Name] VARCHAR(30),
	CONSTRAINT PK_ReminderItemStatus PRIMARY KEY CLUSTERED (Id)
);
GO
--
-- Create foreign key
ALTER TABLE [dbo].[ReminderItem] WITH CHECK 
	ADD CONSTRAINT [FK_ReminderItem_StatusId] FOREIGN KEY([StatusId])
		REFERENCES [dbo].[ReminderItemStatus] ([Id]);
ALTER TABLE [dbo].[ReminderItem]
	CHECK CONSTRAINT [FK_ReminderItem_StatusId];
GO
--
-- Fill the vocabulary according to the ReminderItemStatus.cs
INSERT INTO [ReminderItemStatus] (Id, [Name]) VALUES (0, 'Awaiting')
INSERT INTO [ReminderItemStatus] (Id, [Name]) VALUES (1, 'Ready')
INSERT INTO [ReminderItemStatus] (Id, [Name]) VALUES (2, 'Sent')
INSERT INTO [ReminderItemStatus] (Id, [Name]) VALUES (3, 'Failed')