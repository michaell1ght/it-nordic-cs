using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItem
{
    class ReminderItem
    {
        DateTimeOffset AlarmDate;
        string AlarmMessage;
        TimeSpan TimeToAlarm;
        public bool IsOutdated { get; private set; }
        public ReminderItem (DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
            TimeToAlarm = DateTime.Now - AlarmDate;
            IsOutdated = TimeToAlarm >= TimeSpan.Zero;
        }

        public void WriteProperties()
        {
            Console.WriteLine($"AlarmDate : {AlarmDate}, AlarmMessage : {AlarmMessage}, TimeToAlarm : {TimeToAlarm}, IsOutdated : {IsOutdated}");
        }
    }
}
