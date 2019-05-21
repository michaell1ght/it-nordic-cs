using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class SendingSuccededEventArgs: System.EventArgs
	{
		public SendReminderModel Reminder { get; set; }

		public SendingSuccededEventArgs(SendReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}
