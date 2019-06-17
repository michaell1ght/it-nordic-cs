using Reminder.Domain.Model;

namespace Reminder.Domain.EventArgs
{
	public class AddingSuccededEventArgs: System.EventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public AddingSuccededEventArgs(AddReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}
