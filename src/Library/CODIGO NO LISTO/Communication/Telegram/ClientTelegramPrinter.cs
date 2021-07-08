
// S -  SRP: Esta clase implementa la impresion al cliente de cualquier informacion.

// O -  OCP: Basta con implementar IPrinter para crear una nueva forma de mostrar informacion.

// L -  LSP: Cualquier clase que implemente IPrinter debe ser un subtipo de IPrinter.

// I -  ISP: No se utiliza.

// D -  DIP: Esta clase depende de abstracciones.

//      Expert: No aplica.

//      Polymorphism: Print es polimorfico en todos los IPrinter.

//      Creator: No se utiliza.

namespace Library
{
    public class ClientTelegramPrinter : IPrinter
    {
        public void Print(AbstractCommunicationManager receptor, object toPrint)
        {
            TelegramBot client = TelegramBot.Instance;
            client.Client.SendTextMessageAsync(
                chatId: receptor.Id,
                text: toPrint.ToString()
            );
        }
    }
}