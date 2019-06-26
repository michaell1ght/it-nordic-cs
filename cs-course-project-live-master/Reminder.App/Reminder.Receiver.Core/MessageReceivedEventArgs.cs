using System;

namespace Reminder.Receiver.Core
{
	public class MessageReceivedEventArgs: EventArgs
	{
		public string Message { get; private set; }

		public string ContactId { get; private set; }

		public MessageReceivedEventArgs(string contactId, string message)
		{
			ContactId = contactId;
			Message = message;
		}
	}
}
