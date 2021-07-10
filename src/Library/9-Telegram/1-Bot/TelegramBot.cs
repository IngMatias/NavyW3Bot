
// Para el uso de ITelegramBotClient.
using Telegram.Bot;

namespace Library
{
    public class TelegramBot
    {
        private const string TELEGRAM_TOKEN = "1863846699:AAGdX9nWtOtK4OuZ-NLfPXd8Cx3qiwBUOOY";
        private ITelegramBotClient bot;
        private static TelegramBot instance;
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
        private TelegramBot()
        {
            this.bot = new TelegramBotClient(TELEGRAM_TOKEN);
        }
        public ITelegramBotClient Client
        {
            get
            {
                return this.bot;
            }
        }
    }
}
