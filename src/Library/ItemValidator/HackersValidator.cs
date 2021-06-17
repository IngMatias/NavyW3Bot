namespace Library
{
    public class HackersValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractVessels vesselToAdd, ITable table)
        {
            if (vesselToAdd is Puntoon)
            {
                return vesselToAdd.Items[position] == null;
            }
            return false;
        }
    }
}