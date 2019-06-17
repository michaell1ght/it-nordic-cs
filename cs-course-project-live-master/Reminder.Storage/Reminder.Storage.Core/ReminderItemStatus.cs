namespace Reminder.Storage.Core
{
	/// <summary>
	/// The status of the single reminder item.
	/// </summary>
	public enum ReminderItemStatus
	{
		/// <summary>
		/// Reminder queued and waits its time for sending.
		/// </summary>
		Awaiting = 0,

		/// <summary>
		/// Reminder's time has come. Now it is the queue for sending.
		/// </summary>
		Ready = 1,

		/// <summary>
		/// Reminder was sent successfully.
		/// </summary>
		Sent = 2,

		/// <summary>
		/// Something goes wrong while sending attempt.
		/// </summary>
		Failed = 3
	}
}
