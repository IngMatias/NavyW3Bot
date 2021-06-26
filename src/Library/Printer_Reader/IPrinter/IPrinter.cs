// S - SRP: Esta clase define los metodos necesarion para comunicarnos desde el programa hacia un cliente. Este podria ser 
//           Telegram, Twitter, WhatsApp, etc.

// O - OCP: De querer implementar un cliente nuevo se debe crear un objeto que implemente esta interfaz, de esta manera no
//           se debe cambiar ninguna otra clase.

// L - LSP: Cualquier objeto que implemente esta interfaz será sustituible por el tipo IPrinter

// I - ISP: Esta interfaz define las operaciones minimas necesarias para que el programa se pueda comunicar con el cliente.

// D - DIP: No se aplica.

// Expert: Esta clase es la experta en conocer las operaciones necesarias para que el programa se pueda comunicar con el cliente.

// Polymorphism: Se definen las operaciones de la interfaz orientado a el funcionamiento del cliente, que serán definidas en cada 
//                clase que implemente la interfaz.

// Creator: No se utiliza.

namespace Library
{
    public interface IPrinter
    {
        public void Print(object ToPrint);
    }
}