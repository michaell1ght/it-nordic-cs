using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reminder.Receiver.Core;
using Reminder.Sender.Core;
using Reminder.Storage.Core;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTests
	{
		public Mock<IReminderReceiver> receiverMock = new Mock<IReminderReceiver>();
		public Mock<IReminderSender> senderMock = new Mock<IReminderSender>();

		[TestMethod]
		public void When_SendReminder_OK_SendingSuccedded_Event_Raised()
		{
			var reminderStorage = GetMockedReminderStorage();
			using (var reminderDomain = new ReminderDomain(
				reminderStorage,
				receiverMock.Object,
				senderMock.Object,
				TimeSpan.FromMilliseconds(100),
				TimeSpan.FromMilliseconds(100)))
			{
				bool eventHandlerCalled = false;

				reminderDomain.SendingSucceded += (s, e) =>
				{
					eventHandlerCalled = true;
				};

				reminderStorage.Add(
					new ReminderItemRestricted
					{
						Date = DateTimeOffset.Now
					});

				reminderDomain.Run();

				Thread.Sleep(300);

				Assert.IsTrue(eventHandlerCalled);
			}
		}

		public IReminderStorage GetMockedReminderStorage()
		{
			var list = new List<ReminderItem>();

			Mock<IReminderStorage> storageMock = new Mock<IReminderStorage>();

			storageMock
				.Setup(x => x.Add(It.IsAny<ReminderItemRestricted>()))
				.Callback<ReminderItemRestricted>((ri) =>
				{
					ReminderItem item = new ReminderItem
					{
						ContactId = ri.ContactId,
						Date = ri.Date,
						Message = ri.Message,
						Status = ri.Status
					};

					list.Add(item);
				});

			storageMock
				.Setup(x => x.Get(It.IsAny<ReminderItemStatus>()))
				.Returns<ReminderItemStatus>((status) =>
				{
					return list
						.Where(x => x.Status == status)
						.ToList();
				});

			storageMock
				.Setup(x => x.UpdateStatus(It.IsAny<Guid>(), It.IsAny<ReminderItemStatus>()))
				.Callback<Guid, ReminderItemStatus>((id, status) =>
				{
					foreach (ReminderItem item in list.Where(x => x.Id == id))
						item.Status = status;
				});

			storageMock
				.Setup(x => x.UpdateStatus(It.IsAny<IEnumerable<Guid>>(), It.IsAny<ReminderItemStatus>()))
				.Callback<IEnumerable<Guid>, ReminderItemStatus>((ids, status) =>
				{
					foreach (ReminderItem item in list.Where(x =>ids.Contains(x.Id)))
						item.Status = status;
				});

			return storageMock.Object;
		}
	}
}