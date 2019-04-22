using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot
{
    interface IAlarmStorage
    {
        void UpdateAlarm();
        object GetAlarm();
        void DeleteAlarm();
    }
}
