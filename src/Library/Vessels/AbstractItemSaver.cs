// S - SRP: Esta clase tiene la responsabilidad de definir los metodos necesarios para que un barco pueda manejar el uso de items.

// O - OCP: Esta clase no cumple con el principio, ya que si se quiere agregar una funcionalidad que cambie funcionamiento de como se tratan 
//           a los items se debe cambiar esta clase. En C# solo se puede heredar de una clase, esto nos limita a que no se pueda cumplir con
//           el principio en este caso espesifico. 
//           Pero si se desease agregar otra funcionalidad a AbstractVessel que no fuera atacar, manejar items, o manejar el estado 
//           (ej: moverse por el tablero) si se cumpliria con el principio, ya que se debería extender la cadena de herencia de AbstractVessel
//           con una clase abtracta que bien podría llamarse AbstractMover.
//           Recordar que AbstractVessel esta compusta de la siguiente manera:
//           AbstractVessel -> AbstractAttackerVessel -> AbstractStateManager -> AbstractItemSaver.  

// L - LSP: Cualquier barco que pueda utilizar items podra ser sustituida por el tipo AbstractItemSaver.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio, ya que depende de abtracciones como IItem (clase de alto nivel).

// Expert: Esta clase es experta en saber el funcionamiento y el los items de los barcos.

// Polymorphism: No se utiliza.

// Creator: No se utiliza.

using System.Collections.ObjectModel;
using System;

namespace Library
{
    public abstract class AbstractItemSaver
    {
        protected IItem[] _items;
        private bool _blocked = false;
        public ReadOnlyCollection<IItem> Items
        {
            get
            {
                return Array.AsReadOnly<IItem>(_items);
            }
        }
        public AbstractItemSaver(int size)
        {
            this._items = new IItem[size];
        }
        public int CountItem()
        {
            int i = 0;
            foreach (IItem item in this._items)
            {
                if (item != null)
                {
                    i++;
                }
            }
            return i;
        }
        public int Length()
        {
            return this._items.Length;
        }
        public void Block()
        {
            this._blocked = false;
        }
        public void Unblock()
        {
            this._blocked = true;
        }
        public bool AddItem(int position, IItem toAdd, AbstractTable table, IItemValidator validator)
        {
            if (this._blocked)
            {
                throw new BlockedVesselException();
            }
            if (validator.IsAddable(position, this, table))
            {
                this._items[position] = toAdd;
                return true;
            }
            return false;
        }
        public void RemoveItem(IItem toRemove)
        {
            int index = Array.IndexOf(this._items, toRemove);
            if (index != -1)
            {
                this._items[index] = null;
            }
        }
    }
}