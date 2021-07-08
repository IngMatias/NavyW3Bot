
// Para el uso de ITelegramBotClient.
using Telegram.Bot;
// 
using Telegram.Bot.Args;
//
using Telegram.Bot.Types;

namespace Library
{
    // Esta clase es un Singleton de TelegramBot
    public class TelegramBot
    {
        private const string TELEGRAM_TOKEN = "1863846699:AAGdX9nWtOtK4OuZ-NLfPXd8Cx3qiwBUOOY";
        // Esta es la instancia para guardar el Singleton.
        private static TelegramBot instance;
        private ITelegramBotClient bot;
        private TelegramBot()
        {
            this.bot = new TelegramBotClient(TELEGRAM_TOKEN);
        }
        private User BotInfo
        {
            get
            {
                return this.Client.GetMeAsync().Result;
            }
        }
        public int BotId
        {
            get
            {
                return this.BotInfo.Id;
            }
        }
        public ITelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }
        public static TelegramBot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TelegramBot();
                }
                return instance;
            }
        }
    }
}
