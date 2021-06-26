// S - SRP: Esta interfaz define las operaciones que definen una Phase (fase).

// O - OCP: Se cumple. Si se deseara añadir una fase se tiene que crear una clase que implemente esta interfaz, asi, ninguna
//           otra se ve afectada.
           
// L - LSP: Se cumple. Cualquier objeto que implemente IPhase puede ser substituido por este tipo y no cambiar su funcionamiento.

// I - ISP: No se utiliza.

// D - DIP: No se utiliza.

// Expert: No se utiliza.

// Polymorphism: Se define una operacion que será sobreescrita en cada clase que implemente la interfaz.

// Creator: No se aplica.

using System.Collections.Generic;

namespace Library
{
    public interface IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR);
    }
}