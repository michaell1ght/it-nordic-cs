using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Client;
using System;

namespace Test.WebApi.Client.App
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new ReminderStorageWebApiClient("https://localhost:5001");
			var reminderItem = new ReminderItemRestricted
			{
				ContactId = "TestContactId",
				Date = DateTimeOffset.Now,
				Message = "Test Message"
			};

			Guid id = client.Add(reminderItem);

			Console.WriteLine("Adding done");

			var reminderItemFromStorage = client.Get(id);

			Console.WriteLine(
				"Reading done:\n" +
				$"{reminderItemFromStorage.Id}\n" +
				$"{reminderItemFromStorage.ContactId}\n" +
				$"{reminderItemFromStorage.Date}\n" +
				$"{reminderItemFromStorage.Message}\n");

			Console.ReadKey();
		}
	}
}
