using System.Collections.Generic;

    // S - SRP: Esta interface se encarga de la responsabilidad de definir un tipo Evento.
    // En el caso de querer agregar un nuevo evento solo hace falta implementar esta interface y
    // agregar dicha clase a la EventList.
    
    // O - OCP: Se piensa la jerarquia EventList - IEvent - Evento para permitir el agregado de nuevos
    // eventos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Todos los subtipos de IEvent deben implementar el metodo DoEvent, lo que hace que puedan
    // reibir el mensaje correspondiente en cualquier caso, aunque se comporten de manera distinta.
    // Se debe revisar cuidadosamente los efectos colaterales.

    // I - ISP: No se encuentra una aplicacion del principio ISP.
    
    // D - DIP: IEvent depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo DoEvent es polimorfico en todos los IEvents.

    // Creator : No se usa Creator.
    
namespace Library
{
    public interface IEvent
    {
        public void DoEvent(List<ITable> participants);
    }
}