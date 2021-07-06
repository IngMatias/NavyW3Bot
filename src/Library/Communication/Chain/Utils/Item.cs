using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class Item
    {
        private static List<IItem> _items = new List<IItem> 
        {
            new AntiaircraftMissile(),
            new Armor(),
            new Hackers(),
            new Kong(),
            new SateliteLock(),
        };
        public static IItem Next()
        {
            return _items[new Random().Next(0,_items.Count)];
        }
    }
}