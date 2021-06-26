// S - SRP: Esta clase tiene la responsabilidad de definir un barco.
//           Recordar que AbstractVessel esta compusta de la siguiente manera:
//           AbstractVessel -> AbstractAttackerVessel -> AbstractStateManager -> AbstractItemSaver.

// O - OCP: Se cumple el principio, ya que si se desease agregar otra funcionalidad a AbstractVessel que no fuera atacar, manejar items, 
//           o manejar el estado (ej: moverse por el tablero) se debería extender la cadena de herencia de AbstractVessel
//           con una clase abtracta que bien podría llamarse AbstractMover.
//           Recordar que AbstractVessel esta compusta de la siguiente manera:
//           AbstractVessel -> AbstractAttackerVessel -> AbstractStateManager -> AbstractItemSaver.

// L - LSP: Cualquier barco que puede ser sustituido por el tipo AbstractVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio, ya que depende de abtracciones.

// Expert: No se utiliza.

// Polymorphism: No se utliza.

// Creator: No se utiliza.

namespace Library
{
    public abstract class AbstractVessel : AbstractAttackerVessel
    {
        protected AbstractVessel(int size, int health)
        : base(size, health)
        {
        }
    }
}