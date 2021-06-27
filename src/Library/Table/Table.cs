
// S -  SRP: Esta clase define el tamaño del tablero.

// O -  OCP: Se cumple. Si se deseara añadir un tamaño diferente basta con crear una nueva clase.

// L -  LSP: Se cumple. Cualquier objeto que herede AbstractTable es y debe ser un subtipo de ella.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: No se aplica. 

//      Polymorphism: No se aplica.

//      Creator: No se aplica.

namespace Library
{
    public class Table : AbstractTable
    {
        public Table()
        : base(14, 26)
        {
        }
    }
}