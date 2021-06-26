// S - SRP: Esta clase tiene la responsabilidad de definir los metodos necesarios para que un barco pueda atacar.

// O - OCP: Esta clase no cumple con el principio, ya que si se quiere agregar una funcionalidad que cambie funcionamiento de como se ataca se debe
//           cambiar esta clase. En C# solo se puede heredar de una clase, esto nos limita a que no se pueda cumplir con el principio en este caso espesifico. 
//           Pero si se desease agregar otra funcionalidad a AbstractVessel que no fuera atacar, manejar items, o manejar el estado 
//           (ej: moverse por el tablero) si se cumpliria con el principio, ya que se debería extender la cadena de herencia de AbstractVessel
//           con una clase abtracta que bien podría llamarse AbstractMover.
//           Recordar que AbstractVessel esta compusta de la siguiente manera:
//           AbstractVessel -> AbstractAttackerVessel -> AbstractStateManager -> AbstractItemSaver.

// L - LSP: Cualquier barco que pueda atacar podra ser sustituida por el tipo AbstractAttackerVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio, ya que depende de abtracciones como AbstractTable (clase de alto nivel).

// Expert: No se utiliza.

// Polymorphism: Se definen metodos que luego pueden ser sobreescribidos.

// Creator: No se utiliza.

using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractAttackerVessel : AbstractStateManager
    {
        public AbstractAttackerVessel(int size, int health)
        : base(size, health)
        {
        }
        public virtual void LaunchMissile(AbstractTable table, int x, int y)
        {
            throw new NotImplementedException();
        }
        public virtual void ThrowLoad(AbstractTable table, int x, int y)
        {
            throw new NotImplementedException();
        }
        public virtual void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }
    }
}