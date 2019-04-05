using System;

namespace ReminderItem
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem reminder1 = new ReminderItem(DateTimeOffset.UtcNow, "milliseconds means a lot");
            ReminderItem reminder2 = new ReminderItem(DateTimeOffset.MaxValue, "I will never remind you anything =(");

            reminder1.WriteProperties();
            reminder2.WriteProperties();
            Console.ReadLine();
        }
    }
}
