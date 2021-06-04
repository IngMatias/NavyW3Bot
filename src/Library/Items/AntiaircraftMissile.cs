namespace Library
{
    public class AntiaircraftMissile : IItem
    {
        public bool IsAddable(AbstractVessels vessel)
        {
            return true;
        }
    }
}
