using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class Item
    {
        private static Item _instance;
        public static Item Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Item();
                }
                return _instance;
            }

        }
        private List<IItem> _items = new List<IItem> 
        {
            // new AntiaircraftMissile(),
            new Armor(),
            // new Hackers(),
            // new Kong(),
            // new SateliteLock(),
        };
        private Dictionary<AbstractPlayer, IItem> _nextItem;
        private Item()
        {   
            this._nextItem = new Dictionary<AbstractPlayer, IItem> {};
        }
        public IItem Next(AbstractPlayer player)
        {
            try
            {
                return this._nextItem[player];
            }
            catch (KeyNotFoundException)
            {
                this._nextItem.Add(player, this._items[new Random().Next(0,this._items.Count)]);
            }
            return this._nextItem[player];
        }
    }
}