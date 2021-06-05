namespace Library
{
    public class Hacker : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
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