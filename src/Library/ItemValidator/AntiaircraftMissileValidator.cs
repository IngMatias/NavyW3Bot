namespace Library
{
    public class AntiaircraftMissileValidator : IItemValidator
    {
        public bool IsAddable(AbstractVessels vasselToAdd, ITable table)
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