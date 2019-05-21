using System;
using System.ComponentModel.DataAnnotations;
using Reminder.Storage.Core;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemCreateModel
	{
		/// <summary>
		/// Gets or sets the date and time the reminder item scheduled for sending.
		/// </summary>
		[Required]
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets contact identifier in the target sending system.
		/// </summary>
		[Required]
		[MaxLength(50)]
		public string ContactId { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		[Required]
		[MaxLength(200)]
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the identifier of the recipient.
		/// </summary>
		[Required]
		[Range(0, 3)]
		public ReminderItemStatus Status { get; set; }

		public ReminderItemCreateModel()
		{
		}

		public ReminderItemCreateModel(ReminderItemRestricted reminderItemRestricted)
		{
			Date = reminderItemRestricted.Date;
			ContactId = reminderItemRestricted.ContactId;
			Message = reminderItemRestricted.Message;
			Status = reminderItemRestricted.Status;
		}

		public ReminderItemRestricted ToReminderItem()
		{
			return new ReminderItemRestricted
			{
				Date = Date,
				ContactId = ContactId,
				Message = Message,
				Status = Status
			};
		}
	}
}
