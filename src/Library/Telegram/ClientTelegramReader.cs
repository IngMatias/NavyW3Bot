using System;
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
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();
            if (messageText != null)
            {
                ITelegramBotClient client = TelegramBot.Instance.Client;
                long id = chatInfo.Id;

                IPrinter clientP = new ClientTelegramPrinter(client, id);
                StartHandler start = new StartHandler();
                
                start.DoCommand(messageText, clientP);
            }
        }
        public string Read()
        {
            TelegramBot telegramBot = TelegramBot.Instance;

            ITelegramBotClient bot = telegramBot.Client;

            bot.OnMessage += SentToChain;

            bot.StartReceiving();

            IPrinter consolP = new ConsolePrinter();
            IReader consoleR = new ConsoleReader();
            consolP.Print("Presione una tecla para terminar: ");
            consoleR.Read();

            bot.StartReceiving();

            return "";
        }
        public string Read(IPrinter printer, object msg)
        {
            throw new System.NotImplementedException();
        }

        public int ReadInt(int from, int until, IPrinter printer, object msg)
        {
            throw new System.NotImplementedException();
        }
    }
}