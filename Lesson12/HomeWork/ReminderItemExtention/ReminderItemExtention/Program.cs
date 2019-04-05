using System;
using System.Collections.Generic;

namespace ReminderItemExtention
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem baseReminder = new ReminderItem(DateTimeOffset.UtcNow, "I am baseReminder");
            PhoneReminderItem phoneReminder = new PhoneReminderItem ("88005553535",DateTimeOffset.MinValue, "I am phoneReminder");
            ChatReminderItem chatReminder = new ChatReminderItem("Michail", "c# chat", DateTimeOffset.MaxValue, "I am chatReminder");
            List<ReminderItem> reminderList = new List<ReminderItem>();

            reminderList.Add(baseReminder);
            reminderList.Add(phoneReminder);
            reminderList.Add(chatReminder);

            foreach(ReminderItem reminderListElement in reminderList)
            {
                reminderListElement.WriteProperties(reminderListElement.GetType());
            }
                Console.ReadLine();
        }
    }
}

