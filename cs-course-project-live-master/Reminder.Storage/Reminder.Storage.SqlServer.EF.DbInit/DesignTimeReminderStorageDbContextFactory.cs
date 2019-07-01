using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage.SqlServer.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Reminder.Storage.SqlServer.EF.DbInit
{
    class DesignTimeReminderStorageDbContextFactory 
        : IDesignTimeDbContextFactory<ReminderStorageContext>
    {
        public ReminderStorageContext CreateDbContext(string[] args)
        {
            string connetctionString = ConnectionStringFactory.GetDbConnectionString();
            var migrationAssembly = typeof(Program)
                .GetTypeInfo()
                .Assembly.GetName()
                .Name;

            var builder = new DbContextOptionsBuilder<ReminderStorageContext>();
            builder.UseSqlServer(
                connetctionString,
                ob => ob.MigrationsAssembly(migrationAssembly));

            return new ReminderStorageContext(builder.Options);
        }
    }
}