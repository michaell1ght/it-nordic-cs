using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
	public interface IReminderStorage
	{
		/// <summary>
		/// Adds new reminderItem to collection.
		/// </summary>
		void Add(ReminderItem reminderItem);

		/// <summary>
		/// Updates existing reminder item.
		/// </summary>
		void Update(ReminderItem reminderItem);

		/// <summary>
		/// Gets the reminderItem by identifier.
		/// </summary>

		ReminderItem Get(Guid id);

		List<ReminderItem> GetList(
			IEnumerable<ReminderItemStatus> status,
			int count, 
			int startPosition);
	}
}
