namespace Library
{
    public class KongValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            if (vesselToAdd.CountItem() == 0 && vesselToAdd.Length() < 4)
            {
                return vesselToAdd.Items[position] == null;
            }
            return false;
        }
    }
}