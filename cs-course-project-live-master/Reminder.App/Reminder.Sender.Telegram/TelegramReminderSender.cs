using System;
using Telegram.Bot;
using Reminder.Sender.Core;
using System.Net;

namespace Reminder.Sender.Telegram
{
	public class TelegramReminderSender : IReminderSender
	{
		private TelegramBotClient botClient;

		public TelegramReminderSender(string accessToken, IWebProxy proxy = null)
		{
			botClient = proxy == null
				? new TelegramBotClient(accessToken)
				: new TelegramBotClient(accessToken, proxy);
		}

		public void Send(string contactId, string message)
		{
			var chatId = new global::Telegram.Bot.Types.ChatId(long.Parse(contactId));

			botClient.SendTextMessageAsync(
				chatId,
				message);
		}
	}
}
