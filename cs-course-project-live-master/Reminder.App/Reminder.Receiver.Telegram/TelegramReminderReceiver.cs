using System;
using Telegram.Bot;
using Reminder.Receiver.Core;
using System.Net;

namespace Reminder.Receiver.Telegram
{
	public class TelegramReminderReceiver: IReminderReceiver
	{
		private TelegramBotClient botClient;

		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		public TelegramReminderReceiver(string accessToken, IWebProxy proxy = null)
		{
			botClient = proxy == null
				? new TelegramBotClient(accessToken)
				: new TelegramBotClient(accessToken, proxy);
		}

		public string GetHelloFromBot()
		{
			global::Telegram.Bot.Types.User user = botClient.GetMeAsync().Result;
			return $"'Hello' from Telegram bot {user}";
		}

		public void Run()
		{
			botClient.OnMessage += BotClient_OnMessage;
			botClient.StartReceiving();
		}

		private void BotClient_OnMessage(
			object sender,
			global::Telegram.Bot.Args.MessageEventArgs e)
		{
			if(e.Message.Type == global::Telegram.Bot.Types.Enums.MessageType.Text)
			{
				OnMessageReceived(
					this,
					new MessageReceivedEventArgs(
						e.Message.Chat.Id.ToString(),
						e.Message.Text));
			}
		}

		protected virtual void OnMessageReceived(object sender, MessageReceivedEventArgs e)
		{
			MessageReceived?.Invoke(sender, e);
		}
	}
}
