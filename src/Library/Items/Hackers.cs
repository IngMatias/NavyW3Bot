namespace Library
{
    public class Hacker : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            if (vasselToAdd is Puntoon)
            {
                return true;
            }
            return false;
        }
    }
}