using System;
using System.Collections.Generic;

namespace Reminder.Storage.Core
{
	/// <summary>
	/// Describes a storage reminder storage interface.
	/// </summary>
	public interface IReminderStorage
	{
		/// <summary>
		/// Gets the number of the items in the storage.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Adds a new item to the storage.
		/// </summary>
		void Add(ReminderItem reminder);

		/// <summary>
		/// Removes the item from the storage by its ID.
		/// </summary>
		bool Remove(Guid id);

		/// <summary>
		/// Clears the storage.
		/// </summary>
		void Clear();

		/// <summary>
		/// Gets the single item by its ID.
		/// </summary>
		ReminderItem Get(Guid id);

		/// <summary>
		/// Gets the list of the items with pagination.
		/// </summary>
		List<ReminderItem> Get(int count = 0, int startPostion = 0);

		/// <summary>
		/// Gets the list of items by status with pagination.
		/// </summary>
		List<ReminderItem> Get(ReminderItemStatus status, int count = 0, int startPostion = 0);
		
		/// <summary>
		/// Updates the status of the items by their IDs.
		/// </summary>
		void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status);

		/// <summary>
		/// Updates the status of the single item by its ID.
		/// </summary>
		void UpdateStatus(Guid id, ReminderItemStatus status);
	}
}
