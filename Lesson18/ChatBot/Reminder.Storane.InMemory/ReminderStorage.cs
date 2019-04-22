using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	public class ReminderStorage : IReminderStorage
	{
		private Dictionary<Guid, ReminderItem> _storage;

		public ReminderStorage()
		{
			_storage = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem reminderItem)
		{
			_storage.Add(reminderItem.Id, reminderItem);
		}

		public void Update(ReminderItem reminderItem)
		{
			///TODO: add custom exception throwing if not found
			_storage[reminderItem.Id] = reminderItem;
		}

		public ReminderItem Get(Guid id)
		{
			return _storage.ContainsKey(id)
				? _storage[id] 
				: null;
		}

		public List<ReminderItem> Get(int count, int startPosition)
		{
			throw new NotImplementedException();
		}

		public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> status, int count, int startPosition)
		{
			throw new NotImplementedException();
		}

	}
}
