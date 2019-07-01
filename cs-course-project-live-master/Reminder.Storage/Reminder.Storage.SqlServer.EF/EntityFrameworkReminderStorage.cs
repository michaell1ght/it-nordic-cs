using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.EF.Context;

namespace Reminder.Storage.SqlServer.EF
{
    public class EntityFrameworkReminderStorage : IReminderStorage
    {
        private static readonly LoggerFactory MyConsoleLoggerFactory =
            new LoggerFactory(new[]
            {
#pragma warning disable CS0618 // Ензу щк 
                new ConsoleLoggerProvider(
                    (category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information,
                    true)

#pragma warning restore CS0618 // Тип или член устарел
            });

        private readonly DbContextOptionsBuilder<ReminderStorageContext> _builder;

        public EntityFrameworkReminderStorage(
            string connectionString,
            bool enableLogging = false)
        {
            _builder = new DbContextOptionsBuilder<ReminderStorageContext>()
                .UseSqlServer(connectionString);
            if (enableLogging)
            {
                _builder
                    .UseLoggerFactory(MyConsoleLoggerFactory)
                    .EnableSensitiveDataLogging(true);
            }
        }

        public int Count
        {
            get
            {
                using (var context = new ReminderStorageContext(_builder.Options))
                {
                    return context.ReminderItems.Count();
                }
            }
        }

        public Guid Add(ReminderItemRestricted reminder)
        {
            var dto = new ReminderItemDto();
            using (var context = new ReminderStorageContext(_builder.Options))
            {

                context.ReminderItems.Add(dto);
                context.SaveChanges();
                return dto.Id;
            }
        }

        public ReminderItem Get(Guid id)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                return context.ReminderItems.
                    FirstOrDefault(ri => ri.Id == id)
                    ?.ToReminderItem();
            }
        }

        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                if(count==0 && startPostion == 0)
                {
                    return context.ReminderItems
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }
                if(count == 0)
                {
                    return context.ReminderItems
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }
                return context.ReminderItems
                    .OrderBy(r => r.Id)
                    .Skip(startPostion)
                    .Take(count)
                    .Select(r => r.ToReminderItem())
                    .ToList();
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                if (count == 0 && startPostion == 0)
                    return context.ReminderItems
                        .Where(r => r.Status == status)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                if (count == 0)
                {
                    return context.ReminderItems
                        .Where(r => r.Status == status)
                        .OrderBy(r => r.Id)
                        .Skip(startPostion)
                        .Select(r => r.ToReminderItem())
                        .ToList();
                }
                return context.ReminderItems
                    .Where(r => r.Status == status)
                    .OrderBy(r => r.Id)
                    .Skip(startPostion)
                    .Take(count)
                    .Select(r => r.ToReminderItem())
                    .ToList();
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                return context.ReminderItems
                    .Where(r => r.Status == status)
                    .Select(r => r.ToReminderItem())
                    .ToList();
            }
        }

        public bool Remove(Guid id)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var dto = context.ReminderItems.FirstOrDefault(r => r.Id == id);
                if(dto == null)
                {
                    return false;
                }

                context.ReminderItems.Remove(dto);
                context.SaveChanges();
                return true;
            }
        }

        public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                List<ReminderItemDto> dtos = context.ReminderItems
                    .Where(d => ids.Contains(d.Id))
                    .ToList();

                foreach(var dto in dtos)
                {
                    dto.Status = status;
                }

                context.SaveChanges();
            }
        }

        public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                ReminderItemDto dto = context.ReminderItems.Find(id);
                dto.Status = status;
                context.SaveChanges();
            }
        }
    }
}
