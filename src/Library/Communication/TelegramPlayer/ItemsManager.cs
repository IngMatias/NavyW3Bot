namespace Library
{
    public class ItemsManager : TableManager
    {
        public ItemsManager(long id, IPrinter clientP)
        : base(id, clientP)
        {
        }
        public void AddItem(int position, IItem toAdd, AbstractVessel vessel)
        {
            vessel.AddItem(position, toAdd, this._table, ItemsValidators.Instance.Of(toAdd));
        }
        public int CountItems()
        {
            int count = 0;
            foreach (AbstractVessel vessel in this.Vessels)
            {
                foreach(IItem item in vessel.Items)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
