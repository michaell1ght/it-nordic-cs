using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;

namespace Reminder.Storage.Sql.Tests
{
	[TestClass]
	public class SqlReminderStorageTests
	{
		private const string _connectionString =
			@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ReminderTests;Integrated Security=true;";

		[TestInitialize]
		public void TestInitialize()
		{
			var dbInit = new SqlReminderStorageInit(_connectionString);
			dbInit.InitializeDatabase();
		}

		[TestMethod]
		public void Method_Add_Returns_Not_Empty_Guid()
		{
			var storage = new SqlReminderStorage(_connectionString);

			Guid actual = storage.Add(new Core.ReminderItemRestricted
			{
				ContactId = "TestContactId",
				Date = DateTimeOffset.Now.AddHours(1),
				Message = "Test Message",
				Status = Core.ReminderItemStatus.Awaiting
			});

			Assert.AreNotEqual(Guid.Empty, actual);
		}

		[TestMethod]
		public void Get_By_Id_Method_Returns_Just_Added_Item()
		{
			var storage = new SqlReminderStorage(_connectionString);

			DateTimeOffset expectedDate = DateTimeOffset.Now;
			string expectedContactId = "TEST_CONTACT_ID";
			string expectedMessage = "TEST_MESSAGE_TEXT";
			ReminderItemStatus expectedStatus = ReminderItemStatus.Awaiting;

			Guid id = storage.Add(new ReminderItemRestricted
			{
				ContactId = expectedContactId,
				Date = expectedDate,
				Message = expectedMessage,
				Status = expectedStatus
			});

			Assert.AreNotEqual(Guid.Empty, id);

			var actualItem = storage.Get(id);

			Assert.IsNotNull(actualItem);
			Assert.AreEqual(id, actualItem.Id);
			Assert.AreEqual(expectedDate, actualItem.Date);
			Assert.AreEqual(expectedContactId, actualItem.ContactId);
			Assert.AreEqual(expectedMessage, actualItem.Message);
			Assert.AreEqual(expectedStatus, actualItem.Status);
		}

		[TestMethod]
		public void Get_By_Id_Method_Returns_Not_Null_Item_With_Proper_Fields()
		{
			Guid expectedGuid = Guid.Parse("00000000-0000-0000-0000-111111111111");
			DateTimeOffset expectedDate = DateTimeOffset.Parse("2020-01-01 00:00:00 +00:00");
			string expectedContactId = "ContactId_1";
			string expectedMessage = "Message_1";
			ReminderItemStatus expectedStatus = ReminderItemStatus.Awaiting;

			var storage = new SqlReminderStorage(_connectionString);
			var actualItem = storage.Get(expectedGuid);

			Assert.IsNotNull(actualItem);
			Assert.AreEqual(expectedGuid, actualItem.Id);
			Assert.AreEqual(expectedContactId, actualItem.ContactId);
			Assert.AreEqual(expectedDate, actualItem.Date);
			Assert.AreEqual(expectedMessage, actualItem.Message);
			Assert.AreEqual(expectedStatus, actualItem.Status);
		}

		[TestMethod]
		public void Get_By_Id_Method_Returns_Null_If_Not_Found()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var actual = storage.Get(Guid.Empty);

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void Get_By_Id_Method_Returns_Russian_Message_After_Adding()
		{
			DateTimeOffset expectedDate = DateTimeOffset.Parse("2020-01-01 00:00:00 +00:00");
			string expectedContactId = "ContactId_1";
			string expectedMessage = "Сообщение на русском языке :)";
			ReminderItemStatus expectedStatus = ReminderItemStatus.Awaiting;

			var storage = new SqlReminderStorage(_connectionString);
			Guid justAddedReminderId = storage.Add(new ReminderItemRestricted
			{
				ContactId = expectedContactId,
				Date = expectedDate,
				Message = expectedMessage,
				Status = expectedStatus
			});
			var actualItem = storage.Get(justAddedReminderId);

			Assert.IsNotNull(actualItem);
			Assert.AreEqual(justAddedReminderId, actualItem.Id);
			Assert.AreEqual(expectedContactId, actualItem.ContactId);
			Assert.AreEqual(expectedDate, actualItem.Date);
			Assert.AreEqual(expectedMessage, actualItem.Message);
			Assert.AreEqual(expectedStatus, actualItem.Status);
		}

		[TestMethod]
		public void Remove_By_Id_Method_Returns_False_For_Not_Found_Reminder()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var actual = storage.Remove(Guid.Empty);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void Remove_By_Id_Method_Returns_True_When_Found_And_Removed()
		{
			var storage = new SqlReminderStorage(_connectionString);

			Guid id = Guid.Parse("00000000-0000-0000-0000-111111111111");
			var actual = storage.Remove(id);

			Assert.IsTrue(actual);

			var removedItem = storage.Get(id);

			Assert.IsNull(removedItem);
		}

		[TestMethod]
		public void Get_Method_Without_Parameters_Returns_All_Reminders()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var actual = storage.Get();

			Assert.IsNotNull(actual);
			Assert.AreEqual(8, actual.Count);
		}

		[TestMethod]
		public void Get_Method_With_Count_And_Start_Position_Returns_Limited_Number_Of_Reminders()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var actual = storage.Get(3, 2);

			Assert.IsNotNull(actual);
			Assert.AreEqual(3, actual.Count);
		}

		[TestMethod]
		public void Get_Method_With_Status_Only_Returns_All_Reminders_With_Requested_Status()
		{
			var storage = new SqlReminderStorage(_connectionString);

			List<ReminderItem> actual;

			actual = storage.Get(ReminderItemStatus.Awaiting);
			Assert.IsNotNull(actual);
			Assert.AreEqual(2, actual.Count);

			actual = storage.Get(ReminderItemStatus.Ready);
			Assert.IsNotNull(actual);
			Assert.AreEqual(1, actual.Count);

			actual = storage.Get(ReminderItemStatus.Sent);
			Assert.IsNotNull(actual);
			Assert.AreEqual(2, actual.Count);

			actual = storage.Get(ReminderItemStatus.Failed);
			Assert.IsNotNull(actual);
			Assert.AreEqual(3, actual.Count);
		}

		[TestMethod]
		public void UpdateStatus_Method_For_IDs_Collection_Updates_The_Status()
		{
			var storage = new SqlReminderStorage(_connectionString);

			List<Guid> expectedIds = new List<Guid>();
			expectedIds.Add(new Guid("00000000-0000-0000-0000-111111111111"));
			expectedIds.Add(new Guid("00000000-0000-0000-0000-222222222222"));
			expectedIds.Add(new Guid("00000000-0000-0000-0000-333333333333"));

			storage.UpdateStatus(expectedIds, ReminderItemStatus.Failed);

			var actual = storage.Get(ReminderItemStatus.Failed);
			Assert.IsNotNull(actual);

			var actualIds = actual.Select(x => x.Id).ToList();
			Assert.IsTrue(actualIds.Contains(expectedIds[0]));
			Assert.IsTrue(actualIds.Contains(expectedIds[1]));
			Assert.IsTrue(actualIds.Contains(expectedIds[2]));
		}

		[TestMethod]
		public void Remove_Method_Returns_True_When_Item_Deleted()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var actual = storage.Remove(new Guid("00000000-0000-0000-0000-111111111111"));

			Assert.IsTrue(actual);
		}

		[TestMethod]
		public void Remove_Method_Returns_False_When_Item_Not_Found()
		{
			var storage = new SqlReminderStorage(_connectionString);

			var actual = storage.Remove(Guid.Empty);

			Assert.IsFalse(actual);
		}
	}
}
