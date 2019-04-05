using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderItemExtention
{
    class ChatReminderItem : ReminderItem
    {
        string ChatName;
        string AccountName;

        public ChatReminderItem (string accountName, string chatName, DateTimeOffset alarmDate, string alarmMessage) 
            : base (alarmDate, alarmMessage)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties(Type type)
        {
            base.WriteProperties(type);
            Console.WriteLine($" ChatName : {ChatName} \n AccountName : {AccountName}\n");
        }
    }
}
