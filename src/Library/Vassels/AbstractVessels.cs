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
        private int[] state;
        public IList<int> State
        {
            get
            {
                return Array.AsReadOnly(state);
            }
        }
        public bool IsAlive()
        {
            foreach(int i in State)
            {
                if (i != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int Large()
        {
            return State.Count;
        }

        public bool AddItem(Player player, IItem toAdd)
        {
            if (toAdd.IsAddable(player,this))
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
