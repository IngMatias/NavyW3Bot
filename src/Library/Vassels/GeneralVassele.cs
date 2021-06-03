using System.Collections.Generic;

namespace Library
{
    public abstract class GeneralVassele
    {
        private List<item> items;
        private int[] state;
        public bool IsAlive()
        {
            return true;
        }
        public int Large()
        {
            return 0;
        }
        public bool AddItem(item toAdd)
        {
            return true;
        }
    }
}
