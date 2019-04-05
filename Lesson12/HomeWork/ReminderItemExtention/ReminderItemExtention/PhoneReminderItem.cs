using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItemExtention
{
    class PhoneReminderItem : ReminderItem
    {
        string PhoneNumber;

        public PhoneReminderItem(string phoneNumber, DateTimeOffset alarmDate, string alarmMessage)
            : base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties(Type type)
        {
            base.WriteProperties(type);
            Console.WriteLine($" PhoneNumber : {PhoneNumber}\n");
        }
    }
}
