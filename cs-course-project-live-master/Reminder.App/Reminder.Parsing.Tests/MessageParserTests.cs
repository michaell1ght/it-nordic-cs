using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reminder.Parsing.Tests
{
	[TestClass]
	public class MessageParserTests
	{
		[TestMethod]
		public void Valid_Message_With_DateTimeOffset_And_Text_Parsed_Ok()
		{
			const string message = "2019-12-31T23:59:59 Test Message";

			DateTimeOffset expectedDate = DateTimeOffset.Parse("2019-12-31T23:59:59");
			string expectedMessage = "Test Message";

			var actual = MessageParser.Parse(message);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expectedDate, actual.Date);
			Assert.AreEqual(expectedMessage, actual.Message);
		}
	}
}
