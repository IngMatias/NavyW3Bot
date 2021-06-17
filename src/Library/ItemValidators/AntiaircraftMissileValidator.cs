namespace Library
{
    public class AntiaircraftMissileValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, ITable table)
        {
            foreach (IItem item in vesselToAdd.Items)
            {
                if (item is AntiaircraftMissile)
                {
                    return false;
                }
            }
            return vesselToAdd.Items[position] == null;
        }
    }
}