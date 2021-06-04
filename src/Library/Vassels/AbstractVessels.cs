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
            return true;
        }
        public int Large()
        {
            return 0;
        }
        public bool AddItem(IItem toAdd)
        {
            return true;
        }
        public bool RemoveItem(IItem toRemove)
        {
            return true;
        }
    }
}
