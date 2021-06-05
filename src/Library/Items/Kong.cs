namespace Library
{
    public class Kong : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            if (vasselToAdd.Items.Count == 0 && vasselToAdd.Length() < 4)
            {
                return true;
            }
            return false;
        }
    }
}
