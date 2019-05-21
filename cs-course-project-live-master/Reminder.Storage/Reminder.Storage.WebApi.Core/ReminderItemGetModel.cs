using System;
using Reminder.Storage.Core;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemGetModel
	{
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the date and time the reminder item scheduled for sending.
		/// </summary>
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets contact identifier in the target sending system.
		/// </summary>
		public string ContactId { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the recipient.
		/// </summary>
		public ReminderItemStatus Status { get; set; }

		public ReminderItemGetModel()
		{
		}

		public ReminderItemGetModel(ReminderItem reminderItem)
		{
			Id = reminderItem.Id;
			Date = reminderItem.Date;
			ContactId = reminderItem.ContactId;
			Message = reminderItem.Message;
			Status = reminderItem.Status;
		}

		public ReminderItemGetModel(Guid id, ReminderItemRestricted reminderItemRestricted)
		{
			Id = id;
			Date = reminderItemRestricted.Date;
			ContactId = reminderItemRestricted.ContactId;
			Message = reminderItemRestricted.Message;
			Status = reminderItemRestricted.Status;
		}

		public ReminderItem ToReminderItem()
		{
			return new ReminderItem
			{
				Id = Id,
				Date = Date,
				ContactId = ContactId,
				Message = Message,
				Status = Status
			};
		}
	}
}
