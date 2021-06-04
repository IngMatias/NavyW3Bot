namespace Library
{
    public class AntiaircraftMissile : IItem
    {
        public bool IsAddable(Player player, AbstractVessels vasselToAdd)
        {
            foreach(IItem item in vasselToAdd.Items)
            {
                if (item.Equals(this.GetType()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
