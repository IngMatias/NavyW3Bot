using System.Collections.Generic;

// S - SRP: Esta interfaz tiene la responsabilidad de hacer un evento.

// O - 

// L - LSP: No aplica

// I - ISP: No aplica.

// D - DIP: Depende de AbstractTable la cual es una abstraccion por lo tanto cumple con DIP.

// Expert: No aplica.

// Polymorphism: La operacion DoEvent es polimorfica a todos los IEvent.

// Creator: No aplica.

namespace Library
{
    public interface IEvent
    {
        public void DoEvent(List<AbstractTable> participants);
    }
}