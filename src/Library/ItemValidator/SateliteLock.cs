namespace Library
{
    public class SateliteLockValidator : IItemValidator
    {
        public bool IsAddable(AbstractVessels vasselToAdd, ITable table)
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
            return true;
        }
    }
}