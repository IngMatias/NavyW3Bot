using System;
using System.Collections.Generic;

namespace Library
{
    public class ItemList
    {
        private List<IItem> items;
        public IItem RandomItem()
        {
            return new Armor();
        }
    }
}

