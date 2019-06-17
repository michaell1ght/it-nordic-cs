using Microsoft.VisualStudio.TestTools.UnitTesting;
using MihaZupan;
using Reminder.Receiver.Telegram;
using System.Net;

namespace Reminder.Receiver.Telegram.Tests
{
	[TestClass]
	public class TelegramReminderReceiverTests
	{
		private const string _token = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";

		[TestMethod]
		public void GetHelloFromBot_With_Proxy_Returns_Not_Empty_String()
		{
			// use proxy if needed
			IWebProxy proxy = 
				new HttpToSocks5Proxy("proxy.golyakov.net", 1080);			

			TelegramReminderReceiver reminderReceiver = 
				new TelegramReminderReceiver(_token, proxy);

			string description = reminderReceiver.GetHelloFromBot();

			Assert.IsNotNull(description);
		}
	}
}
