using System;

    // S - SRP: Esta clase se encarga de la responsabilidad de manejar la lectura del
    // bot, como puede ser la recepcion de comandos, en primera instancia se utiliza la 
    // consola pero luego podria ser Telegram, WhatsApp, etc.

    // O - OCP: Se piensa la jerarquia IReader - ClientReader para permitir el agregado de nuevos
    // metodos de lectura sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: ClientReader puede ser intercambiado por cualquier otro metodo de lectura y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: ClientReader depende de ClientPrinter por lo cual debe hacer uso de su unica operacion.

    // D - DIP: ClientReader tiene dependencias desconocidas.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : Los metodos Read son polimorfico en todos los IPrinter.

    // Creator : No se usa Creator.

namespace Library
{
    public class ClientReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public string Read(IPrinter printer, string msg)
        {
            printer.Print(msg);
            return Console.ReadLine();
        }
    }
}