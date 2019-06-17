using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Reminder.Storage.Core;

namespace Reminder.Storage.Sql
{
	public class SqlReminderStorage : IReminderStorage
	{
		private readonly string _connectionString;

		public SqlReminderStorage(string connectionString)
		{
			_connectionString = connectionString;
		}

		public int Count => throw new NotImplementedException();

		public Guid Add(ReminderItemRestricted reminder)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.AddReminderItem";

				cmd.Parameters.AddWithValue("@contactId", reminder.ContactId);
				cmd.Parameters.AddWithValue("@targetDate", reminder.Date);
				cmd.Parameters.AddWithValue("@message", reminder.Message);
				cmd.Parameters.AddWithValue("@statusId", (byte)reminder.Status);

				var outputIdParameter = new SqlParameter("@reminderId", System.Data.SqlDbType.UniqueIdentifier, 1);
				outputIdParameter.Direction = System.Data.ParameterDirection.Output;
				cmd.Parameters.Add(outputIdParameter);

				cmd.ExecuteNonQuery();

				return (Guid)outputIdParameter.Value;
			}
		}

		public ReminderItem Get(Guid id)
        {
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetReminderItemById";

                cmd.Parameters.AddWithValue("@reminderId", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(!reader.HasRows || !reader.Read())
                    {
                        return null;
                    }

                    var result = new ReminderItem();
                    result.Id = id;
                    result.ContactId = reader.GetString(reader.GetOrdinal("ContactId"));
                    result.Date = reader.GetDateTimeOffset(reader.GetOrdinal("TargetDate"));
                    result.Message = reader.GetString(reader.GetOrdinal("Message"));
                    result.Status = (ReminderItemStatus)reader.GetByte(reader.GetOrdinal("StatusId"));

                    return result;
                }
            }
        }
        
        public List<ReminderItem> Get(int count = 0, int startPostion = 0)
		{
            throw new NotImplementedException();
        }

        public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
		{
			throw new NotImplementedException();
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
            var result = new List<ReminderItem>();
            using (var sqlConnection = GetOpenedSqlConnection())
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.GetReminderItemListByStatus";

                cmd.Parameters.AddWithValue("@statusId", (byte)status);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    int idColumnIndex = reader.GetOrdinal("Id");
                    int contactIdColumnIndex = reader.GetOrdinal("ContactId");
                    int dateColumnIndex = reader.GetOrdinal("TargetDate");
                    int messageColumnIndex = reader.GetOrdinal("Message");
                    int statusColumnIndex = reader.GetOrdinal("StatusId");


                    while (reader.Read())
                    {

                        var item = new ReminderItem
                        {
                            Id = reader.GetGuid(idColumnIndex),
                            ContactId = reader.GetString(contactIdColumnIndex),
                            Date = reader.GetDateTimeOffset(dateColumnIndex),
                            Message = reader.GetString(messageColumnIndex),
                            Status = (ReminderItemStatus)reader.GetByte(statusColumnIndex)
                        };

                    result.Add(item);

                    }
                    return result;
                }
            }
        }

		public bool Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
        {
                using (var sqlConnection = GetOpenedSqlConnection())
                {
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.AddReminderItem";

                    cmd.Parameters.AddWithValue("@reminderId", id);
                    cmd.Parameters.AddWithValue("@statusId", status);

                    cmd.ExecuteNonQuery();
                }
        }

        private SqlConnection GetOpenedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();

			return sqlConnection;
		}
	}
}
