namespace Library
{
    public class SateliteLock : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            foreach(AbstractVessels vassel in table.GetVessels())
            {
                foreach(IItem item in vassel.Items)
                {
                    if (item.Equals(this.GetType()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
