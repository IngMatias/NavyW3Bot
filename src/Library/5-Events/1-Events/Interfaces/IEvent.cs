
// S -  SRP: Esta interface tiene como responsabilidad definir el tipo IEvent.

// O -  OCP: Esta clase cumple con el principio, ya que si se quiere agregar un nuevo evento basta con
//      implementar esta interface.

// L -  LSP: Cualquier clase que implemente IEvent es y debe ser un subtipo.

// I -  ISP: No se utiliza.

// D -  DIP: El metodo definido en esta interface depende solamente de abstracciones.

//      Expert: No aplica.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: No aplica.

using System.Collections.Generic;

namespace Library
{
    public interface IEvent
    {
        public void DoEvent(List<AbstractTable> participants);
    }
}