namespace Library
{
    public class KongValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, ITable table)
        {
            if (vesselToAdd.Items.Count == 0 && vesselToAdd.Length() < 4)
            {
                return vesselToAdd.Items[position] == null;
            }
            return false;
        }
    }
}