namespace Library
{
    public class ArmorValidator : AbstractKongCheck, IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            if (!(KongCheck(vesselToAdd)))
            {
                throw new ThereIsAKongExeption();
            }
            
            if (vesselToAdd.Items[position] != null)
            {
                throw new NoEmptyPositionException();
            }

            return true;
        }
    }
}