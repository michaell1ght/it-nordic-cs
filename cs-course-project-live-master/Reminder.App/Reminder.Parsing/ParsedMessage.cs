using System;

namespace Reminder.Parsing
{
	/// <summary>
	/// Parsed message for adding a new reminder to a domain.
	/// </summary>
	public class ParsedMessage
	{
		/// <summary>
		/// Gets or sets the date and time the reminder item scheduled for sending.
		/// </summary>
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		public string Message { get; set; }
	}
}