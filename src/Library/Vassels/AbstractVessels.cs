using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractVessels
    {
        private List<IItem> items;
        private int[] state;
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
