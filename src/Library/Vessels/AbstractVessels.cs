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

    // Expert : Esta clase conoce los items de un barco, por lo tanto tiene el comportamiento de agregar y quitarlos.
    // Ademas de conocer el estado, por lo cual tiene la responsabilidad de inicializar y consultar dicho estado.

    // Polimorfismo : 

    // Creator : No se usa Creator.

namespace Library
{
    public abstract class AbstractVessels
    {
        protected List<IItem> items;
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
        public bool AddItem(ITable table, IItem toAdd, IItemValidator validator)
        {
            if (validator.IsAddable(this, table))
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
        public virtual bool ReceiveAttack(ITable table, AbstractAttacker attack)
        {
            bool avoidAttack = false;
            foreach (IItem item in this.items)
            {
                avoidAttack = item.ReceiveAttack(table, attack);
                if (avoidAttack)
                {
                    this.RemoveItem(item);
                    break;
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
        public abstract List<string> AttackForms();
        public abstract void Attack0(ITable table, IPrinter clientP ,IReader clientR);
        public abstract void Attack1(ITable table, IPrinter clientP ,IReader clientR);
        
    }
}