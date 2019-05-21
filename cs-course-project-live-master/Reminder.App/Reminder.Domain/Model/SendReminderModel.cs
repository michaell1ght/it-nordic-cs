using System;

namespace Reminder.Domain.Model
{
	/// <summary>
	/// Reminder model for delegate/event arguments of a domain class.
	/// </summary>
	public class SendReminderModel
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets contact identifier in the target sending system.
		/// </summary>
		public string ContactId { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		public string Message { get; set; }
	}
}

