using System;

    // S - SRP: Esta clase se encarga de la responsabilidad de manejar las impresiones del
    // bot que siempre seran por la consola.

    // O - OCP: Se piensa la jerarquia IPrinter - ConsolePrinter para permitir el agregado de nuevos
    // metodos de impresion sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: ConsolePrinter puede ser intercambiado por cualquier otro metodo de impresion y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: No se encuentra una aplicacion del principio ISP.
    
    // D - DIP: ConsolePrinter no tiene dependencias, cumple DIP.

namespace Library
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string ToPrint)
        {
            Console.WriteLine(ToPrint);
        }
    }
}