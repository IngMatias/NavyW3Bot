namespace Library
{
    public class SateliteLockValidator : AbstractKongCheck, IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            if (!(KongCheck(vesselToAdd)))
            {
                throw new ThereIsAKongExeption();
            }

            foreach (AbstractVessel vassel in table.GetVessels())
            {
                foreach (IItem item in vassel.Items)
                {
                    if (item is SateliteLock)
                    {
                        throw new NoRepetitiveItemException();
                    }
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