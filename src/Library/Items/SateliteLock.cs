namespace Library
{
    public class SateliteLock : IItem
    {
        public bool IsAddable(Player player, AbstractVessels vasselToAdd)
        {
            foreach(AbstractVessels vassel in player.Vessels)
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
