namespace Library
{
    public class HackersValidator : IItemValidator
    {
        public HackersValidator()
        {
            
        }
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, ITable table)
        {
            if (vesselToAdd is Puntoon)
            {
                return vesselToAdd.Items[position] == null;
            }
            return false;
        }
    }
}