// S - SRP: Esta interfaz define las operaciones que debe definir un IReader para poder comunicarse el cliente con el programa.

// O - OCP: Se aplica ya que si se quisiese agregar una comunicacion un con otra plataforma (Ej: Telegram)
//           no se deberia cambiar nada, simplemente se deberia agregar una clase que implemente esta interfaz 
//           a favor de telegram.

// L - LSP: Se aplica a la hora de utilizar un IReader, cualquier objeto que implemente esta interfaz podra ser 
//           sustituido por este tipo y no cambiara su funcionamiento.

// I - ISP: Esta interfaz define las operaciones minimas necesarias para que el cliente pueda comunicarse con el programa.

// D - DIP: No se aplica.

// Expert: Esta clase es experta en conocer las operaciones necesarias para que el cliente pueda comunicarse con el programa.

// Polymorphism: Cada objeto que implemente esta interfaz podra definir las operaciones siguiendo sus necesidasdes.

// Creator: No se utiliza.

namespace Library
{
    public interface IReader
    {
        public string Read();
        public string Read(IPrinter printer, object msg);
        public int ReadInt(int from, int until, IPrinter printer, object msg);
    }
}