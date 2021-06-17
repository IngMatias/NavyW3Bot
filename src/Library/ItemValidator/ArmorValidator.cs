namespace Library
{
    public class ArmorValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractVessels vesselToAdd, ITable table)
        {
            return vesselToAdd.Items[position] == null; 
        }
    }
}