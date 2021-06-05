namespace Library
{
    public class Hacker : IItem
    {
        public bool IsAddable(Player player, AbstractVessels vasselToAdd)
        {
            AbstractVessels puntoon = new Puntoon();
            if (vasselToAdd.Equals(puntoon.GetType()))
            {
                return true;
            }
            return false;
        }
    }
}
