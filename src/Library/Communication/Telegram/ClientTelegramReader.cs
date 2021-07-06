using System;
using System.Collections.Generic;
using Telegram.Bot;
// Se usa para MessageEventArgs.
using Telegram.Bot.Args;
// Se usa para Message.
using Telegram.Bot.Types;

namespace Library
{
    public class ClientTelegramReader : IReader
    {
        private static void SentToChain(object sender, MessageEventArgs messageEventArgs)
        {
            // Contenedor de jugadores de Telegram.
            TelegramPlayers players = TelegramPlayers.Instance;
            ITelegramBotClient client = TelegramBot.Instance.Client;

            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;

            string messageText = "";

            try
            {
                messageText = message.Text.ToLower();
            catch (NullReferenceException)
            {
                Console.WriteLine($"{chatInfo.FirstName} causo una excepcion.");
            }

            if (messageText != null)
            {
                // Primer punto de la cadena.
                StartHandler start = new StartHandler();

                Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");

                if (message.Text.StartsWith("/"))
                {
                    start.DoCommand(messageText.Substring(1, messageText.Length - 1), players.GetPlayer(chatInfo.Id));
                }
                else
                {

                }
            }
        }
        public void StartRead()
        {
            TelegramBot telegramBot = TelegramBot.Instance;
            ITelegramBotClient bot = telegramBot.Client;

            bot.OnMessage += SentToChain;

            bot.StartReceiving();
        }

        public void StopRead()
        {
            TelegramBot telegramBot = TelegramBot.Instance;
            ITelegramBotClient bot = telegramBot.Client;

            bot.StopReceiving();
        }
    }

}
}