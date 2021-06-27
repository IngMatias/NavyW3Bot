
// S -  SRP: Esta clase define el tipo IPhase.

// O -  OCP: Implementando IPhase podemos permitir el agregado de nuevas fases 
//      sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.
           
// L -  LSP: Cualquier clase que implemente IPhase es y debe ser un subtipo de IPhase.

// I -  ISP: No aplica.

// D -  DIP: Se depende solo de abstracciones.

//      Expert: No aplica.

//      Polymorphism: El metodo Excecute es polimorfico en todos los IPhase.

//      Creator: No se aplica.

using System.Collections.Generic;

namespace Library
{
    public interface IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR);
    }
}