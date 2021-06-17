using System;
using System.Collections.Generic;

namespace Library
{
    public class ItemList
    {
        private List<IItem> items = new List<IItem> {
                                                        new AntiaircraftMissile(),
                                                        new Armor(),
                                                        new Hackers(),
                                                        new Kong(),
                                                        new SateliteLock(),
                                                    };
        public IItem RandomItem()
        {
            Random rnd = new Random();
            return this.items[rnd.Next(0,this.items.Count)];
        }
    }
}