namespace Library
{
    public class SateliteLockValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractVessels vesselToAdd, ITable table)
        {
            foreach (AbstractVessels vassel in table.GetVessels())
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