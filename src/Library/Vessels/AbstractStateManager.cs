// S - SRP: Esta clase tiene la responsabilidad de definir los metodos necesarios para manejar la vida de un barco.

// O - OCP: Esta clase no cumple con el principio, ya que si se quiere agregar una funcionalidad que cambie funcionamiento de como se maneja el
//           estado del barco, se debe cambiar esta clase. En C# solo se puede heredar de una clase, esto nos limita a que no se pueda cumplir
//           con el principio en este caso espesifico. 
//           Pero si se desease agregar otra funcionalidad a AbstractVessel que no fuera atacar, manejar items, o manejar el estado 
//           (ej: moverse por el tablero) si se cumpliria con el principio, ya que se debería extender la cadena de herencia de AbstractVessel
//           con una clase abtracta que bien podría llamarse AbstractMover.
//           Recordar que AbstractVessel esta compusta de la siguiente manera:
//           AbstractVessel -> AbstractAttackerVessel -> AbstractStateManager -> AbstractItemSaver.

// L - LSP: Cualquier barco que pueda atacar podra ser sustituida por el tipo AbstractAttackerVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio, ya que depende de abtracciones como AbstractTable (clase de alto nivel).

// Expert: No se utiliza.

// Polymorphism: Se definen metodos que luego pueden ser sobreescribidos. ReceiveAttack es un ejemplo, no todos los barcos recibiran 
//                ataques de igual manera, aunque la mayoria si, por eso de defie el metodo, pro se podibilita la sobreescritura.

// Creator: No se utiliza.

using System.Collections.Generic;
using System;

namespace Library
{
    public abstract class AbstractStateManager : AbstractItemSaver
    {
        protected int[] state;
        public IList<int> State
        {
            get
            {
                return Array.AsReadOnly(state);
            }
        }
        public AbstractStateManager(int size, int health)
        : base(size)
        {
            this.state = new int[size];
            this.InitState(health);
        }
        protected void InitState(int health)
        {
            for (int i = 0; i < this.state.Length; i++)
            {
                this.state[i] = health;
            }
        }
        public bool IsAlive()
        {
            foreach (int i in State)
            {
                if (i != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool ReceiveAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            // Dependencias.
            AttacksValidators validator = new AttacksValidators();

            bool avoidAttack = false;
            foreach (IItem item in this._items)
            {
                if (item != null)
                {
                    avoidAttack = validator.ValidatorOf(item).AvoidAttack(table, attack);
                    if (avoidAttack)
                    {
                        this.RemoveItem(item);
                        break;
                    }
                }
            }
            if (!avoidAttack)
            {
                this.state[attack.Position] -= 1;
                if (this.state[attack.Position] == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}