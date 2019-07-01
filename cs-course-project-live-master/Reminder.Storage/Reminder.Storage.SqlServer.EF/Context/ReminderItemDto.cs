using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.SqlServer.EF.Context
{
    public class ReminderItemDto
    {

        public Guid Id { get; set; }

        public string ContactId { get; set; }

        public DateTimeOffset TargetDate { get; set; }

        public string Message { get; set; }

        public ReminderItemStatus Status { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public ReminderItemDto()
        {

        }

        public ReminderItemDto(ReminderItemRestricted reminder)
        {
            ContactId = reminder.ContactId;
            TargetDate = reminder.Date;
            Message = reminder.Message;
            Status = reminder.Status;
        }

        public ReminderItem ToReminderItem()
        {
            return new ReminderItem
            {
                Id = Id,
                ContactId = ContactId,
                Date = TargetDate,
                Message = Message,
                Status = Status
            };
        }
    }
}
