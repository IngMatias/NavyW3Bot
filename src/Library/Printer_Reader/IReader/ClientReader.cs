
// S -  SRP: Esta clase implementa la lectura al cliente de cualquier informacion.

// O -  OCP: Basta con implementar IReader para crear una nueva forma de lectura de informacion.

// L -  LSP: Cualquier clase que implemente IReader debe ser un subtipo de IReader.

// I -  ISP: No se utiliza.

// D -  DIP: Esta clase depende de abstracciones.

//      Expert: No aplica.

//      Polymorphism: Read y ReadInt son polimorficos en todos los IReaders.

//      Creator: No se utiliza.

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