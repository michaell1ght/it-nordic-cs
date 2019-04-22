using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Constructor_Validly_Sets_Id_Property()
		{
			//Preparing
			Guid expected = new Guid("80BD6187-EC3C-4B56-9063-3BEA1C1F8D1B");
			
			//Running
			var reminderItem = new ReminderItem(
			expected,
			DateTimeOffset.MinValue,
			null,
			null);

			//Testing
			Assert.AreEqual(expected, reminderItem.Id);
		}

		[TestMethod]
		public void Constructor_Validly_Sets_Date_Property()
		{
			//Preparing
			var expected = DateTimeOffset.Now;
			//Running
			var reminderItem = new ReminderItem(
			Guid.Empty,
			expected,
			null,
			null);

			//Testing
			Assert.AreEqual(expected, reminderItem.Date);
		}

		[TestMethod]
		public void Constructor_Validly_Sets_Message_Property()
		{
			//Preparing
			var expected = "hello world";

			//Running
			var reminderItem = new ReminderItem(
			Guid.Empty,
			DateTimeOffset.MinValue,
			expected,
			null);

			//Testing
			Assert.AreEqual(expected, reminderItem.Message);
		}

		[TestMethod]
		public void Constructor_Validly_Sets_contactid_Property()
		{
			//Preparing
			var expected = "123456";

			//Running
			var reminderItem = new ReminderItem(
			Guid.Empty,
			DateTimeOffset.MinValue,
			null,
			expected);

			//Testing
			Assert.AreEqual(expected, reminderItem.ContactId);
		}

		[TestMethod]
		public void TimeToSend_Is_In_1000ms_Range()
		{
			//Preparing
			var time500ms = TimeSpan.FromMilliseconds(1000);

			//Running
			var reminderItem = new ReminderItem(
			Guid.Empty,
			DateTimeOffset.UtcNow.AddMilliseconds(1000),
			null,
			null);

			var actual = reminderItem.TimeToSend;

			//Testing
			Assert.IsTrue(actual< time500ms);
			Assert.IsTrue(actual > TimeSpan.Zero);
		}

		[TestMethod]
		public void TimeToSend_Is_Less_Than_Zero_For_Past_Date()
		{
			//Preparing

			//Running
			var reminderItem = new ReminderItem(
			Guid.Empty,
			DateTimeOffset.UtcNow.AddDays(-1),
			null,
			null);

			var actual = reminderItem.TimeToSend;

			//Testing
			Assert.IsTrue(actual < TimeSpan.Zero);
		}
	}
}
