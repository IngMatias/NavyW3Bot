using System.Collections.Generic;

    // S - SRP: Esta clase se encarga de la responsabilidad de conocer todos los eventos del juego y
    // elegir aleatoriamente uno de ellos, esta funcion se piensa para no alterar el resto del codigo
    // al momento de agregar nuevos eneventos.
    // Si se es estricto hay dos razones de cambio, si se desea agregar un nuevo evento y si se desea 
    // cambiar el metodo de eleccion entre ellos. No creemos que sea necesario romper esta unión, para
    // continuar respetando los otros patrones.

    // O - OCP: Se piensa la jerarquia EventList - IEvent - Evento para permitir el agregado de nuevos
    // eventos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: No se encuentra una aplicacion del principio LSP.
    
    // I - ISP: EventList no respeta ISP, no hace uso de todas las operaciones de IEvent.

    // D - DIP: EventList depende de IEvent, que es una abstraccion, se cumple DIP.

    // Expert
    // Polymorphism
    // Creator

namespace Library
{
    public class EventList
    {
        private List<IEvent> events;
        public IEvent RandomEvent()
        {
            return new Godzilla();
        }
    }
}