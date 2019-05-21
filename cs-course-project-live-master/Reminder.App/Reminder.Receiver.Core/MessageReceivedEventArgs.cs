using System;

namespace Reminder.Receiver.Core
{
	public class MessageReceivedEventArgs: EventArgs
	{
		public string Message { get; set; }

		public string ContactId { get; set; }

		public MessageReceivedEventArgs(string contactId, string message)
		{
			ContactId = contactId;
			Message = message;
		}
	}
}
