namespace Library
{
    public class KongValidator : IItemValidator
    {
        public bool IsAddable(AbstractVessels vasselToAdd, ITable table)
        {
            if (vasselToAdd.Items.Count == 0 && vasselToAdd.Length() < 4)
            {
                return true;
            }
            return false;
        }
    }
}