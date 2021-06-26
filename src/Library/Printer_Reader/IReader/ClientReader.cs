// S - SRP: Esta clase define los metodos necesarion para comunicarnos desde un cliente hacia el programa. Este podria ser 
//           Telegram, Twitter, WhatsApp, etc. Actualmente trabaja con la consola.

// O - OCP: No se utiliza.

// L - LSP: Esta clase es sustituible por IReader.

// I - ISP: Se aplica porque la interfaz implementada se utiliza en su totalidad, ninguna operacion esta de mas.

// D - DIP: esta clase solo depende de clases de alto nivel.

// Expert: es la clase experta en como interactuar con un cliente.

// Polymorphism: Se definen las operaciones de la interfaz orientado a el funcionamiento del cliente.

// Creator: No se utiliza.

using System;

namespace Library
{
    public class ClientReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public string Read(IPrinter printer, object msg)
        {
            printer.Print(msg);
            return this.Read();
        }
        public int ReadInt(int from, int until, IPrinter printer, object msg)
        {
            printer.Print(msg);
            int read;
            while (true)
            {
                try
                {
                    read = Int32.Parse(this.Read());
                    if (from <= read && read <= until)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    printer.Print("Debes ingresar un numero entero: ");
                }
                catch (OverflowException)
                {
                    printer.Print("El numero ingresado es demaciado grande: ");
                }
                catch (Exception)
                {

                }
                printer.Print("Debes ingresar un numero entre " + from + " y " + until + " :");
            }
            return read;
        }
    }
}