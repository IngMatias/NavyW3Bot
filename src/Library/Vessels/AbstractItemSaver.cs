using System.Collections.ObjectModel;
using System;

namespace Library
{
    public abstract class AbstractItemSaver
    {
        protected IItem[] items;
        public ReadOnlyCollection<IItem> Items
        {
            get
            {
                return Array.AsReadOnly<IItem>(items);
            }
        }
        public AbstractItemSaver(int size)
        {
            this.items = new IItem[size];
        }
        public int Length()
        {
            return this.items.Length;
        }
        public bool AddItem(int position, IItem toAdd, AbstractTable table, IItemValidator validator)
        {
            if (validator.IsAddable(position, this, table))
            {
                this.items[position] = toAdd;
                return true;
            }
            return false;
        }
        public void RemoveItem(IItem toRemove)
        {
            int index = Array.IndexOf(this.items, toRemove);
            if (index != -1)
            {
                this.items[index] = null;
            }
        }
    }
}