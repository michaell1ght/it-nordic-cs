using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory.Tests
{
	[TestClass]
	public class ReminderStorageTests
	{
		[TestMethod]
		public void Add_Method_Adds_Single_Reminder()
		{
			var reminder = new ReminderItem
			{
				Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
				Message = "Test",
				Status = ReminderItemStatus.Awaiting
			};

			var storage = new ReminderStorage();
			storage.Add(reminder);

			Assert.AreEqual(1, storage.Reminders.Count);
		}

		[TestMethod]
		public void Get_By_Id_Method_Returns_Null_For_Empty_Storage()
		{
			var storage = new ReminderStorage();

			var actual = storage.Get(Guid.Empty);

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void Get_By_Id_Method_Returns_Single_Reminder()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2",
					Status = ReminderItemStatus.Awaiting
				}
			};

			var id = reminders[3].Id;

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			var actual = storage.Get(id);

			Assert.IsNotNull(actual);
			Assert.AreEqual(id, actual.Id);
		}

		[TestMethod]
		public void Remove_By_Id_Method_Returns_False_For_Empty_Storage()
		{
			var storage = new ReminderStorage();

			var actual = storage.Remove(Guid.Empty);

			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void Remove_By_Id_Method_Returns_True_When_Found_And_Removed()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1"
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1"
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2"
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2"
				}
			};

			var id = reminders[3].Id;

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			var actual = storage.Remove(id);

			Assert.IsTrue(actual);
			Assert.IsNull(storage.Get(id));
		}

		[TestMethod]
		public void Get_Method_Without_Parameters_Returns_All_Reminders()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2",
					Status = ReminderItemStatus.Awaiting
				}
			};

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			var actual = storage.Get();

			Assert.IsNotNull(actual);
			Assert.AreEqual(4, actual.Count);
		}

		[TestMethod]
		public void Get_Method_With_Count_Only_Returns_Limited_Number_Of_Reminders()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2",
					Status = ReminderItemStatus.Awaiting
				}
			};

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			var actual = storage.Get(2);

			Assert.IsNotNull(actual);
			Assert.AreEqual(2, actual.Count);
		}

		[TestMethod]
		public void Get_Method_With_Count_And_Start_Position_Returns_Limited_Number_Of_Reminders()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2",
					Status = ReminderItemStatus.Awaiting
				}
			};

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			var actual = storage.Get(2, 2);

			Assert.IsNotNull(actual);
			Assert.AreEqual(2, actual.Count);
		}


		[TestMethod]
		public void Get_Method_With_Status_Only_Returns_All_Reminders_With_Requested_Status()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1",
					Status = ReminderItemStatus.Ready
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2",
					Status = ReminderItemStatus.Ready
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2",
					Status = ReminderItemStatus.Sent
				}
			};

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			List<ReminderItem> actual;

			actual = storage.Get(ReminderItemStatus.Awaiting);
			Assert.IsNotNull(actual);
			Assert.AreEqual(1, actual.Count);

			actual = storage.Get(ReminderItemStatus.Ready);
			Assert.IsNotNull(actual);
			Assert.AreEqual(2, actual.Count);

			actual = storage.Get(ReminderItemStatus.Sent);
			Assert.IsNotNull(actual);
			Assert.AreEqual(1, actual.Count);

			actual = storage.Get(ReminderItemStatus.Failed);
			Assert.IsNotNull(actual);
			Assert.AreEqual(0, actual.Count);
		}

		[TestMethod]
		public void UpdateStatus_Method_With_Status_Only_Returns_All_Reminders_With_Requested_Status()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(1)),
					Message = "Actual 1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 1",
					Status = ReminderItemStatus.Ready
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(2)),
					Message = "Actual 2",
					Status = ReminderItemStatus.Ready
				},
				new ReminderItem {
					Date = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(-1)),
					Message = "Outdated 2",
					Status = ReminderItemStatus.Sent
				}
			};

			var storage = new ReminderStorage();
			foreach (var reminder in reminders)
				storage.Add(reminder);

			IEnumerable<Guid> selectedReminderIds = storage
				.Get(ReminderItemStatus.Awaiting)
				.Select(x => x.Id);

			storage.UpdateStatus(selectedReminderIds, ReminderItemStatus.Failed);

			var actual = storage.Get(ReminderItemStatus.Failed);
			Assert.IsNotNull(actual);
			Assert.AreEqual(1, actual.Count);
		}
	}
}
