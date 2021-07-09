
// S -  SRP: Esta clase define la lectura al cliente de cualquier informacion.

// O -  OCP: Basta con implementar IReader para crear una nueva forma de mostrar informacion.

// L -  LSP: Cualquier clase que implemente IReader debe ser un subtipo de IReader.

// I -  ISP: No se utiliza.

// D -  DIP: Esta clase depende de abstracciones.

//      Expert: No aplica.

//      Polymorphism: Print es polimorfico en todos los IPrinter.

//      Creator: No se utiliza.

namespace Library
{
    public interface IReader
    {
        public void StartRead();
        public void StopRead();
    }
}