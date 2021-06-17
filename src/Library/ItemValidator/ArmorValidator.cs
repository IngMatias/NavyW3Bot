namespace Library
{
    public class ArmorValidator : IItemValidator
    {
        public bool IsAddable(AbstractVessels vasselToAdd, ITable table)
        {
            return true; 
            // Esta es la condicion para poder agreagar una armadura:
            // Que no haya otra en el mismo lugar.
            // (vasselToAdd.State[itemToAdd.Position]) != 0;
        }
    }
}