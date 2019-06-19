using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using Reminder.Storage.SqlServer.ADO.Tests.Properties;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
	public class SqlReminderStorageInit
	{
		private readonly string _connectionString;

		public SqlReminderStorageInit(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void InitializeDatabase()
		{
			RunSqlScript(Resources.Schema);
			RunSqlScript(Resources.SPs);
			RunSqlScript(Resources.Data);
		}

		private void RunSqlScript(string script)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var cmd = sqlConnection.CreateCommand();
				cmd.CommandType = CommandType.Text;

				IEnumerable<string> sqlInstructions = SplitSqlInstructions(script)
					.Where(s => !string.IsNullOrWhiteSpace(s));

				foreach (var sqlInstruction in sqlInstructions)
				{
					cmd.CommandText = sqlInstruction;
					cmd.ExecuteNonQuery();
				}
			}
		}

		private string[] SplitSqlInstructions(string script)
		{
			return Regex.Split(script, @"\bGO\b");
		}

		private SqlConnection GetOpenedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();

			return sqlConnection;
		}
	}
}
