
namespace Library
{
    public class Armor : IItem
    {
        public int Position {get ;set; }

        public bool IsAddable(Player player, AbstractVessels vasselToAdd)
        {
            return (vasselToAdd.State[this.Position]) != 0;
        }
    }
}
