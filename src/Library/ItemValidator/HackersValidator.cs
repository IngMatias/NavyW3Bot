namespace Library
{
    public class HackersValidator : IItemValidator
    {
        public bool IsAddable(AbstractVessels vasselToAdd, ITable table)
        {
            if (vasselToAdd is Puntoon)
            {
                return true;
            }
            return false;
        }
    }
}