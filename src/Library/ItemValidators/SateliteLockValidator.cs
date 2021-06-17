namespace Library
{
    public class SateliteLockValidator : IItemValidator
    {
        public SateliteLockValidator()
        {
            
        }
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, ITable table)
        {
            foreach (AbstractVessel vassel in table.GetVessels())
            {
                foreach (IItem item in vassel.Items)
                {
                    if (item is SateliteLock)
                    {
                        return false;
                    }
                }
            }
            return vesselToAdd.Items[position] == null;
        }
    }
}