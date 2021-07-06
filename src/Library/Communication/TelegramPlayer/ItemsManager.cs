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
            vessel.AddItem(position, toAdd, this._table, ItemsValidators.Of(toAdd));
        }
    }
}
