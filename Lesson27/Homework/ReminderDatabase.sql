CREATE DATABASE Reminder;
GO

USE Reminder;
GO

-- DROP TABLE dbo.ReminderItem
CREATE TABLE dbo.ReminderItem (
	Id UNIQUEIDENTIFIER NOT NULL,
	DateToSend DATETIMEOFFSET NOT NULL,
	ContactId INT NOT NULL,
	Message VARCHAR(100) NOT NULL,
	StatusId TINYINT NOT NULL,
);

GO
ALTER TABLE dbo.ReminderItem
ADD CONSTRAINT PK_ReminderItem PRIMARY KEY CLUSTERED (Id);
GO

-- DROP TABLE dbo.ReminderSendStatus
CREATE TABLE dbo.ReminderSendStatus (
	Id TINYINT NOT NULL,
	[Name] VARCHAR(30) NOT NULL
);

GO
ALTER TABLE dbo.ReminderSendingStatus
ADD CONSTRAINT PK_ReminderSendingStatus PRIMARY KEY CLUSTERED (Id);
GO

ALTER TABLE dbo.ReminderItem
ADD CONSTRAINT FK_ReminderItem_StatusId FOREIGN KEY (StatusId)
	REFERENCES dbo.ReminderSendStatus(Id)
GO
