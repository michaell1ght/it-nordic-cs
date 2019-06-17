using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using MihaZupan;
using Reminder.Domain;
using Reminder.Domain.EventArgs;
using Reminder.Storage.WebApi.Client;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			// read configuration

			IConfiguration config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", true, true)
				.Build();

			var storageWebApiUrl = config["storageWebApiUrl"];
			var telegramBotApiToken = config["telegramBot.ApiToken"];
			var telegramBotUseProxy = bool.Parse(config["telegramBot.UseProxy"]);
			var telegramBotProxyHost = config["telegramBot.Proxy.Host"];
			var telegramBotProxyPort = int.Parse(config["telegramBot.Proxy.Port"]);

			// create objects for DI

			var reminderStorage = new ReminderStorageWebApiClient(storageWebApiUrl);

			IWebProxy telegramProxy = null;
			if (telegramBotUseProxy)
			{
				telegramProxy = new HttpToSocks5Proxy(telegramBotProxyHost, telegramBotProxyPort);
			}

			var reminderReceiver = new TelegramReminderReceiver(telegramBotApiToken, telegramProxy);
			var reminderSender = new TelegramReminderSender(telegramBotApiToken, telegramProxy);

			// create and setup domain logic object

			var reminderDomain = new ReminderDomain(
				reminderStorage,
				reminderReceiver,
				reminderSender);

			reminderDomain.AddingSuccedded += ReminderDomain_AddingSuccedded;
			reminderDomain.SendingSucceded += ReminderDomain_SendingSucceded;
			reminderDomain.SendingFailed += ReminderDomain_SendingFailed;

			// run

			reminderDomain.Run();

			string hello = reminderReceiver.GetHelloFromBot();

			Console.WriteLine(
				$"Reminder application is running...\n" +
				$"{hello}\n" +
				"Press [Enter] to shutdown.");
			Console.ReadLine();
		}

		private static void ReminderDomain_AddingSuccedded(object sender, AddingSuccededEventArgs e)
		{
			Console.WriteLine(
				$"Reminder from contact ID {e.Reminder.ContactId} " +
				$"with the message \"{e.Reminder.Message}\" " +
				$"successfully scheduled on {e.Reminder.Date:s}");
		}

		private static void ReminderDomain_SendingSucceded(
			object sender,
			SendingSuccededEventArgs e)
		{
			Console.WriteLine(
				"Reminder {0:N} successfully send message text \"{1}\"",
				e.Reminder.Id,
				e.Reminder.Message);
		}

		private static void ReminderDomain_SendingFailed(object sender, SendingFailedEventArgs e)
		{
			Console.WriteLine(
				"Reminder {0:N} sending has failed. Exception:\n{1}",
				e.Reminder.Id,
				e.Exception);
		}
	}
}
