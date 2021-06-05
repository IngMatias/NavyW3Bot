using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public void InitState(int health)
        {
            for (int i= 0; i < this.state.Length; i++)
            {
                this.state[i] = health;
            }
        }
        public AbstractVessels()
        {
            this.items = new List<IItem> ();
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
    }
}