using System;
using System.Linq;
using System.Threading;
using Reminder.Domain.EventArgs;
using Reminder.Domain.Model;
using Reminder.Storage.Core;

namespace Reminder.Domain
{
	public class ReminderDomain : IDisposable
	{
		private readonly TimeSpan _awaitingRemindersCheckingPeriod;
		private readonly TimeSpan _readyRemindersSendingPeriod;

		private readonly IReminderStorage _storage;

		private Timer _awaitingRemindersCheckTimer;
		private Timer _readyRemindersSendTimer;

		public Action<SendReminderModel> SendReminder { get; set; }

		public event EventHandler<SendingSuccededEventArgs> SendingSucceded;
		public event EventHandler<SendingFailedEventArgs> SendingFailed;

		public ReminderDomain(IReminderStorage storage)
		{
			_storage = storage;
		}

		public ReminderDomain(
			IReminderStorage storage,
			TimeSpan awaitingRemindersCheckingPeriod,
			TimeSpan readyRemindersSendingPeriod) : this(storage)
		{
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_readyRemindersSendingPeriod = readyRemindersSendingPeriod;
		}

		public void Run()
		{
			_awaitingRemindersCheckTimer = new Timer(
				CheckAwaitingReminders,
				null,
				TimeSpan.Zero,
				_awaitingRemindersCheckingPeriod);

			_readyRemindersSendTimer = new Timer(
				SendReadyReminders,
				null,
				TimeSpan.Zero,
				_readyRemindersSendingPeriod);
		}

		public void AddReminder(AddReminderModel addReminderModel)
		{
			_storage.Add(
				new ReminderItem
				{
					Date = addReminderModel.Date,
					ContactId = addReminderModel.ContactId,
					Message = addReminderModel.Message,
					Status = ReminderItemStatus.Awaiting
				});
		}

		public void CheckAwaitingReminders(object dummy)
		{
			var ids = _storage
				.Get(ReminderItemStatus.Awaiting)
				.Where(r => r.IsTimeToSend)
				.Select(r => r.Id);

			_storage.UpdateStatus(
				ids,
				ReminderItemStatus.Ready);
		}

		public void SendReadyReminders(object dummy)
		{
			var sendReminderModels = _storage
				.Get(ReminderItemStatus.Ready)
				.Where(r => r.IsTimeToSend)
				.Select(r =>
					new SendReminderModel
					{
						Id = r.Id,
						Message = r.Message,
						ContactId = r.ContactId
					})
				.ToList();

			foreach (SendReminderModel sendReminder in sendReminderModels)
			{
				try
				{
					SendReminder?.Invoke(sendReminder);

					_storage.UpdateStatus(
						sendReminder.Id,
						ReminderItemStatus.Sent);

					SendingSucceded?.Invoke(
						this,
						new SendingSuccededEventArgs(
							sendReminder));
				}
				catch (Exception exception)
				{
					_storage.UpdateStatus(
						sendReminder.Id,
						ReminderItemStatus.Failed);

					SendingFailed?.Invoke(
						this,
						new SendingFailedEventArgs(
							sendReminder,
							exception));
				}
			}
		}

		public void Dispose()
		{
			_awaitingRemindersCheckTimer?.Dispose();
			_readyRemindersSendTimer?.Dispose();
		}
	}
}
