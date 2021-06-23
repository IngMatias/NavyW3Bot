namespace Library
{
    public class AntiaircraftMissileValidator : AbstractKongCheck, IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            if (!(KongCheck(vesselToAdd)))
            {
                throw new ThereIsAKongExeption();
            }
            foreach (IItem item in vesselToAdd.Items)
            {
                if (item is AntiaircraftMissile)
                {
                    throw new NoRepetitiveItemException();
                }
            }
            if (vesselToAdd.Items[position] != null)
            {
                throw new NoEmptyPositionException();
            }

            return true;
        }
    }
}