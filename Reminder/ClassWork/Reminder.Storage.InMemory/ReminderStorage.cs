using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	/// <summary>
	/// In-memory implementation of the IReminderStorage interface.
	/// </summary>
	public class ReminderStorage : IReminderStorage
	{
		internal readonly Dictionary<Guid, ReminderItem> Reminders;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ReminderStorage()
		{
			Reminders = new Dictionary<Guid, ReminderItem>();
		}

		/// <summary>
		/// Gets the number of the items in the storage.
		/// </summary>
		public int Count => Reminders.Count();

		/// <summary>
		/// Adds a new item to the storage.
		/// </summary>
		public void Add(ReminderItem item)
		{
			Reminders.Add(item.Id, item);
		}

		/// <summary>
		/// Removes the item from the storage by its ID.
		/// </summary>
		public bool Remove(Guid id)
		{
			return Reminders.Remove(id);
		}

		/// <summary>
		/// Clears the storage.
		/// </summary>
		public void Clear()
		{
			Reminders.Clear();
		}

		/// <summary>
		/// Gets the single item by its ID.
		/// </summary>
		public ReminderItem Get(Guid id)
		{
			if (Reminders.ContainsKey(id))
				return Reminders[id];

			return null;
		}

		/// <summary>
		/// Gets the list of the items with pagination.
		/// </summary>
		public List<ReminderItem> Get(int count = 0, int startPostion = 0)
		{
			var reminders = Reminders.Values
				.Skip(startPostion);

			if (count != 0)
				reminders = reminders.Take(count);

			return reminders.ToList();
		}

		/// <summary>
		/// Gets the list of the items by status with pagination.
		/// </summary>
		public List<ReminderItem> Get(ReminderItemStatus status, int count = 0, int startPosition = 0)
		{
			var reminders = Reminders.Values
				.Where(x => x.Status == status)
				.Skip(startPosition);

			if (count != 0)
				reminders = reminders.Take(count);

			return reminders.ToList();
		}

		/// <summary>
		/// Updates the status of the items by their IDs.
		/// </summary>
		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			foreach (Guid id in Reminders.Keys.Where(x => ids.Contains(x)))
			{
				Reminders[id].Status = status;
			}
		}

		/// <summary>
		/// Updates the status of the single item by its ID.
		/// </summary>
		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
			if (Reminders.ContainsKey(id))
				Reminders[id].Status = status;
		}
	}
}