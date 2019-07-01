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

		public int Count
		{
			get
			{
				using (var sqlConnection = GetOpenedSqlConnection())
				{
					var cmd = sqlConnection.CreateCommand();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "dbo.GetReminderItemsCount";
					return (int)cmd.ExecuteScalar();
				}
			}
		}

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

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (!reader.HasRows || !reader.Read())
						return null;

					int idColumnIndex = reader.GetOrdinal("Id");
					int contactIdColumnIndex = reader.GetOrdinal("ContactId");
					int dateColumntIndex = reader.GetOrdinal("TargetDate");
					int messageColumntIndex = reader.GetOrdinal("Message");
					int statusIdColumntIndex = reader.GetOrdinal("StatusId");

					var result = new ReminderItem();
					result.Id = reader.GetGuid(idColumnIndex);
					result.ContactId = reader.GetString(contactIdColumnIndex);
					result.Date = reader.GetDateTimeOffset(dateColumntIndex);
					result.Message = reader.GetString(messageColumntIndex);
					result.Status = (ReminderItemStatus)reader.GetByte(statusIdColumntIndex);

					return result;
				}
			}
		}

		public List<ReminderItem> Get(int count = 0, int startPostion = 0)
		{
			var result = new List<ReminderItem>();

			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.GetReminderItemsWithPaging";

				cmd.Parameters.AddWithValue("@startPosition", startPostion);
				if (count > 0)
					cmd.Parameters.AddWithValue("@count", count);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;

					int idColumnIndex = reader.GetOrdinal("Id");
					int contactIdColumnIndex = reader.GetOrdinal("ContactId");
					int dateColumntIndex = reader.GetOrdinal("TargetDate");
					int messageColumntIndex = reader.GetOrdinal("Message");
					int statusIdColumntIndex = reader.GetOrdinal("StatusId");

					while (reader.Read())
					{
						var reminderItem = new ReminderItem();
						reminderItem.Id = reader.GetGuid(idColumnIndex);
						reminderItem.ContactId = reader.GetString(contactIdColumnIndex);
						reminderItem.Date = reader.GetDateTimeOffset(dateColumntIndex);
						reminderItem.Message = reader.GetString(messageColumntIndex);
						reminderItem.Status = (ReminderItemStatus)reader.GetByte(statusIdColumntIndex);
						result.Add(reminderItem);
					}
					return result;
				}
			}
		}

		public List<ReminderItem> Get(ReminderItemStatus status, int count, int startPostion)
		{
			var result = new List<ReminderItem>();

			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.GetReminderItemsByStatusWithPaging";

				cmd.Parameters.AddWithValue("@statusId", (byte)status);
				cmd.Parameters.AddWithValue("@startPosition", startPostion);
				if (count > 0)
					cmd.Parameters.AddWithValue("@count", count);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;

					int idColumnIndex = reader.GetOrdinal("Id");
					int contactIdColumnIndex = reader.GetOrdinal("ContactId");
					int dateColumntIndex = reader.GetOrdinal("TargetDate");
					int messageColumntIndex = reader.GetOrdinal("Message");
					int statusIdColumntIndex = reader.GetOrdinal("StatusId");

					while (reader.Read())
					{
						var reminderItem = new ReminderItem();
						reminderItem.Id = reader.GetGuid(idColumnIndex);
						reminderItem.ContactId = reader.GetString(contactIdColumnIndex);
						reminderItem.Date = reader.GetDateTimeOffset(dateColumntIndex);
						reminderItem.Message = reader.GetString(messageColumntIndex);
						reminderItem.Status = (ReminderItemStatus)reader.GetByte(statusIdColumntIndex);
						result.Add(reminderItem);
					}
					return result;
				}
			}
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			var result = new List<ReminderItem>();

			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.GetReminderItemsByStatus";

				cmd.Parameters.AddWithValue("@statusId", (byte)status);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;

					int idColumnIndex = reader.GetOrdinal("Id");
					int contactIdColumnIndex = reader.GetOrdinal("ContactId");
					int dateColumntIndex = reader.GetOrdinal("TargetDate");
					int messageColumntIndex = reader.GetOrdinal("Message");
					int statusIdColumntIndex = reader.GetOrdinal("StatusId");

					while (reader.Read())
					{
						var reminderItem = new ReminderItem();
						reminderItem.Id = reader.GetGuid(idColumnIndex);
						reminderItem.ContactId = reader.GetString(contactIdColumnIndex);
						reminderItem.Date = reader.GetDateTimeOffset(dateColumntIndex);
						reminderItem.Message = reader.GetString(messageColumntIndex);
						reminderItem.Status = (ReminderItemStatus)reader.GetByte(statusIdColumntIndex);
						result.Add(reminderItem);
					}
					return result;
				}
			}
		}

		public bool Remove(Guid id)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.RemoveReminderItem";

				cmd.Parameters.AddWithValue("@reminderId", id);

				return (bool)cmd.ExecuteScalar();
			}
		}

		public void UpdateStatus(IEnumerable<Guid> ids, ReminderItemStatus status)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();

				// create temp table
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "CREATE TABLE #ReminderItem([Id] UNIQUEIDENTIFIER NOT NULL)";
				cmd.ExecuteNonQuery();

				// fill it with ids
				using (SqlBulkCopy copy = new SqlBulkCopy(sqlConnection))
				{
					copy.BatchSize = 1000;
					copy.DestinationTableName = "#ReminderItem";

					DataTable tempTable = new DataTable("#ReminderItem");
					tempTable.Columns.Add("Id", typeof(Guid));

					foreach (Guid id in ids)
					{
						DataRow row = tempTable.NewRow();
						row["Id"] = id;
						tempTable.Rows.Add(row);
					}

					copy.WriteToServer(tempTable);
				}

				// run query to bulk update

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "[dbo].[UpdateReminderItemsBulk]";

				cmd.Parameters.AddWithValue("@statusId", (byte)status);
				cmd.ExecuteNonQuery();

				// drop temp table
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "DROP TABLE #ReminderItem";
				cmd.ExecuteNonQuery();
			}
		}

		public void UpdateStatus(Guid id, ReminderItemStatus status)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "dbo.UpdateReminderItem";

				cmd.Parameters.AddWithValue("@reminderId", id);
				cmd.Parameters.AddWithValue("@statusId", (byte)status);

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
