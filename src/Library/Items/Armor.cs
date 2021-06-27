
// S -  SRP: Esta clase tiene una responsabilidad estructural.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la clase IItem pero no se
//      modifica el codigo existente para agregar un nuevo item.

// L -  LSP: Este Item puede ser intercambiado por cualquier otro Item, puede recibir los mismos 
//      mensajes.

// I -  ISP: No aplica.

// D -  DIP: Este Item no depende.

//      Expert: No se utiliza.

//      Polymorphism: No se utiliza..

//      Creator: No se utiliza.

namespace Library
{
    public class Armor : IItem
    {
    }
}