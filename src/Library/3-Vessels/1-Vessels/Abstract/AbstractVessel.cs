
// S - SRP: Esta clase tiene la responsabilidad de definir el barco abstracto.

// O -  OCP: Si se aplica, para agregar una abstraccion diferente basta con implementar una nueva clase.

// L -  LSP: Cualquier clase que herede esta debe ser y es un subtipo de esta clase.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase solo depende de abstracciones.

//      Expert: No se aplica.

//      Polymorphism: No se aplica.

//      Creator: No se utiliza.

namespace Library
{
    public abstract class AbstractVessel : AbstractVesselAttacker
    {
        protected AbstractVessel(int size, int health)
        : base(size, health)
        {
        }
    }
}