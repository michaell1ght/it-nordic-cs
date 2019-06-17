using System;

namespace Reminder.Receiver.Core
{
	public interface IReminderReceiver
	{
		event EventHandler<MessageReceivedEventArgs> MessageReceived;

		void Run();
	}
}
