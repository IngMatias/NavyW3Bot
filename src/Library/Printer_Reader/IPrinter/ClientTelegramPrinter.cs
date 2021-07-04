
// S -  SRP: Esta clase implementa la impresion al cliente de cualquier informacion.

// O -  OCP: Basta con implementar IPrinter para crear una nueva forma de mostrar informacion.

// L -  LSP: Cualquier clase que implemente IPrinter debe ser un subtipo de IPrinter.

// I -  ISP: No se utiliza.

// D -  DIP: Esta clase depende de abstracciones.

//      Expert: No aplica.

//      Polymorphism: Print es polimorfico en todos los IPrinter.

//      Creator: No se utiliza.

using System;
using Telegram.Bot;

namespace Library
{
    public class ClientTelegramPrinter : IPrinter
    {
        private ITelegramBotClient _client;
        private long _id;
        public ClientTelegramPrinter(ITelegramBotClient client, long id)
        {
            this._client = client;
            this._id = id;
        }
        public void Print(object ToPrint)
        {
            this._client.SendTextMessageAsync(chatId: this._id, text: ToPrint.ToString());
        }
    }
}