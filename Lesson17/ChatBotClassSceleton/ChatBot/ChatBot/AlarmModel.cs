using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    class AlarmModel
    {
        Guid _alarmId;
        DateTimeOffset AlarmDate;
        string AlarmMessage;
        TimeSpan TimeToAlarm;
        public bool IsOutdated { get; private set; }

        public AlarmModel(DateTimeOffset alarmDate, string alarmMessage)
        {
            _alarmId =Guid.NewGuid();
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
            TimeToAlarm = DateTime.Now - AlarmDate;
            IsOutdated = TimeToAlarm >= TimeSpan.Zero;
        }
    }
}
