using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.InMemory;
using Reminder.Domain.Model;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTests
	{
		[TestMethod]
		public void Check_That_Reminder_Calls_Internal_Delegate()
		{
			var reminderStorage = new ReminderStorage();

			using (var reminderDomain = new ReminderDomain(
				reminderStorage,
				TimeSpan.FromMilliseconds(100),
				TimeSpan.FromMilliseconds(100)))
			{
				bool delegateWasCalled = false;

				reminderDomain.SendReminder += (reminder) =>
				{
					delegateWasCalled = true;
				};

				reminderDomain.AddReminder(
					new AddReminderModel
					{
						Date = DateTimeOffset.Now
					});

				reminderDomain.Run();

				Thread.Sleep(300);

				Assert.IsTrue(delegateWasCalled);
			}
		}

		[TestMethod]
		public void Check_That_On_SendReminder_Exception_SendingFailed_Event_Raised()
		{
			var reminderStorage = new ReminderStorage();
			using (var reminderDomain = new ReminderDomain(
				reminderStorage,
				TimeSpan.FromMilliseconds(100),
				TimeSpan.FromMilliseconds(100)))
			{
				reminderDomain.SendReminder += (reminder) =>
				{
					throw new Exception();
				};

				bool eventHandlerCalled = false;

				reminderDomain.SendingFailed += (s, e) =>
				{
					eventHandlerCalled = true;
				};

				reminderDomain.AddReminder(
					new AddReminderModel
					{
						Date = DateTimeOffset.Now
					});

				reminderDomain.Run();

				Thread.Sleep(300);

				Assert.IsTrue(eventHandlerCalled);
			}
		}

		public void Check_That_On_SendReminder_OK_SendingSuccedded_Event_Raised()
		{
			var reminderStorage = new ReminderStorage();
			using (var reminderDomain = new ReminderDomain(
				reminderStorage,
				TimeSpan.FromMilliseconds(100),
				TimeSpan.FromMilliseconds(100)))
			{
				bool eventHandlerCalled = false;

				reminderDomain.SendingSucceded += (s, e) =>
				{
					eventHandlerCalled = true;
				};

				reminderDomain.AddReminder(
					new AddReminderModel
					{
						Date = DateTimeOffset.Now
					});

				reminderDomain.Run();

				Thread.Sleep(300);

				Assert.IsTrue(eventHandlerCalled);
			}
		}
	}
}