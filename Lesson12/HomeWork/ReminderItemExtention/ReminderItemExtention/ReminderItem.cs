﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItemExtention
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

        public virtual void WriteProperties(Type type)
        {
            Console.WriteLine($"Class: {type}\n AlarmDate : {AlarmDate}\n AlarmMessage : {AlarmMessage}\n TimeToAlarm : {TimeToAlarm}\n IsOutdated : {IsOutdated}\n");
        }
    }
}
