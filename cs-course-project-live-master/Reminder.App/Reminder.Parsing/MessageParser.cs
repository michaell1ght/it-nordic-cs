using System;

namespace Reminder.Parsing
{
	public static class MessageParser
	{
		public static ParsedMessage Parse(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				return null;

			int firstSpacePosition = message.IndexOf(" ");
			if (firstSpacePosition <= 0)
				return null;


			string firstWord = message.Substring(0, firstSpacePosition);
			bool dateIsOk = DateTimeOffset.TryParse(firstWord, out var date);

			if (!dateIsOk)
				return null;

			return new ParsedMessage
			{
				Date = date,
				Message = message.Substring(firstSpacePosition).Trim()
			};
		}
	}
}
