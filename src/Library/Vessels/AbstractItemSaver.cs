using System.Collections.ObjectModel;
using System;

namespace Library
{
    public abstract class AbstractItemSaver
    {
        protected IItem[] _items;
        public ReadOnlyCollection<IItem> Items
        {
            get
            {
                return Array.AsReadOnly<IItem>(_items);
            }
        }
        public AbstractItemSaver(int size)
        {
            this._items = new IItem[size];
        }
        public int CountItem()
        {
            int i = 0;
            foreach (IItem item in this._items)
            {
                if (item != null)
                {
                    i++;
                }
            }
            return i;
        }
        public int Length()
        {
            return this._items.Length;
        }
        public bool AddItem(int position, IItem toAdd, AbstractTable table, IItemValidator validator)
        {
            if (validator.IsAddable(position, this, table))
            {
                this._items[position] = toAdd;
                return true;
            }
            return false;
        }
        public void RemoveItem(IItem toRemove)
        {
            int index = Array.IndexOf(this._items, toRemove);
            if (index != -1)
            {
                this._items[index] = null;
            }
        }
    }
}