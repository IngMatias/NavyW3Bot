using System;

    // S - SRP: Esta clase se encarga de la responsabilidad de manejar las lecturas del
    // bot, que siempre seran por la consola, lo que podria tratarse como un administrador.

    // O - OCP: Se piensa la jerarquia IReader - ConsoleReader para permitir el agregado de nuevos
    // metodos de lectura sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: ConsoleReader puede ser intercambiado por cualquier otro metodo de lectura y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: ConsoleReader depende de ConsolePrinter por lo cual debe hacer uso de su unica operacion.

    // D - DIP: ConsoleReader no tiene dependencias, cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : Los metodos Read son polimorfico en todos los IPrinter.
    
    // Creator : No se usa Creator.

namespace Library
{
    public class ConsoleReader : IReader
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