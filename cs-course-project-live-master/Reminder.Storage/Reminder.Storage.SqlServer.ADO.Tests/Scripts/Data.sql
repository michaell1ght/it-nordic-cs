-- Fill some data

-- -##    1 - 2 - 3 - 4 - 5 - 6 - 7 - 8
---Status 0 - 0 - 1 - 2 - 2 - 3 - 3 - 3

INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-111111111111',
	'ContactId_1',
	'2020-01-01 00:00:00 +00:00',
	'Message_1',
	0,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-2222222222222',
	'ContactId_2',
	'2020-01-01 00:00:00 +00:00',
	'Message_2',
	0,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-3333333333333',
	'ContactId_3',
	'2020-01-01 00:00:00 +00:00',
	'Message_3',
	1,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-4444444444444',
	'ContactId_4',
	'2020-01-01 00:00:00 +00:00',
	'Message_4',
	2,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-5555555555555',
	'ContactId_5',
	'2020-01-01 00:00:00 +00:00',
	'Message_5',
	2,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-6666666666666',
	'ContactId_6',
	'2020-01-01 00:00:00 +00:00',
	'Message_6',
	3,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-7777777777777',
	'ContactId_7',
	'2020-01-01 00:00:00 +00:00',
	'Message_7',
	3,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')

GO
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-8888888888888',
	'ContactId_8',
	'2020-01-01 00:00:00 +00:00',
	'Message_8',
	3,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')