using System;

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
        public int ReadInt(int from, int until, IPrinter printer, string msg)
        {
            printer.Print(msg);
            int read;
            while (true)
            {
                try
                {
                    read = Int32.Parse(Console.ReadLine());
                    if (from <= read && read <= until)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    printer.Print("Debes ingresar un numero enterio: ");
                }
                catch (OverflowException)
                {
                    printer.Print("El numero ingresado es demaciado grande: ");
                }
                catch (Exception)
                {

                }
                printer.Print("Debes ingresar un numero entre "+from+" y "+until+" :");
            }
            return read;
        }
    }
}