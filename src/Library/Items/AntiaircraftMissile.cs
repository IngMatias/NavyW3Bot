namespace Library
{
    public class AntiaircraftMissile : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            foreach (IItem item in vasselToAdd.Items)
            {
                if (item is AntiaircraftMissile)
                {
                    return false;
                }
            }
            return true;
        }
    }
}