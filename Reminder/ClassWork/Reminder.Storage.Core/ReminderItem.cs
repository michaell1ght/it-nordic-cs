using System;

namespace Reminder.Storage.Core
{
	/// <summary>
	/// The single reminder item.
	/// </summary>
	public class ReminderItem
	{
		/// <summary>
		/// Gets the identifier.
		/// </summary>
		public Guid Id { get; } = Guid.NewGuid();

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

		/// <summary>
		/// Gets the value indicating whether the time for sending item came or not.
		/// </summary>
		public bool IsTimeToSend => Date.UtcDateTime < DateTimeOffset.UtcNow;
	}
}

