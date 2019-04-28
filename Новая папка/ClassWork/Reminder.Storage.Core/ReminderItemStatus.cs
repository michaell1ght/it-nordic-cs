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
		Awaiting,

		/// <summary>
		/// Reminder's time has come. Now it is the queue for sending.
		/// </summary>
		Ready,

		/// <summary>
		/// Reminder was sent successfully.
		/// </summary>
		Sent,

		/// <summary>
		/// Something goes wrong while sending attempt.
		/// </summary>
		Failed
	}
}
