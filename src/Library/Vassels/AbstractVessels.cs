using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

    // S - SRP: Esta clase abstracta se encarga de la responsabilidad de implementar un barco
    // general del que heredaran todos los barcos, para crear un nuevo barco se debe heredar esta clase.
    // Si se es estricto hay dos o mas responsabilidades, por ejemplo conocer los items y manejarlos,
    // asi como tambien conocer y manejar el estado del barco. 
    // Sin embargo no creemos que sea necesario romper esta unión.

    // O - OCP: Se piensa la jerarquia AbstractVessels - Vessel para permitir la implementacion de nuevos
    // barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Se habla de LSP en las subclases.

    // I - ISP: AbstractVessels utiliza todas las operaciones de IItem, pero no las de Table.

    // D - DIP: AbstractVessels depende de Table, que no es una abstraccion, no se cumple DIP.

namespace Library
{
    public abstract class AbstractVessels
    {
        private List<IItem> items;
        public ReadOnlyCollection<IItem> Items
        {
            get
            {
                return items.AsReadOnly();
            }
        }
        protected int[] state;
        public IList<int> State
        {
            get
            {
                return Array.AsReadOnly(state);
            }
        }
        public AbstractVessels()
        {
            this.items = new List<IItem> ();
        }
        public void InitState(int health)
        {
            for (int i= 0; i < this.state.Length; i++)
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
        public int Length()
        {
            return State.Count;
        }
        public bool AddItem(Table table, IItem toAdd)
        {
            if (toAdd.IsAddable(table, this))
            {
                this.items.Add(toAdd);
                return true;
            }
            return false;
        }
        public void RemoveItem(IItem toRemove)
        {
            this.items.Remove(toRemove);
        }
        public void ReceiveAttack(AbstractAttacker attack)
        {

        }
    }
}