namespace Library
{
    public abstract class AbstractVessel : AbstractAttackerVessel
    {
        protected AbstractVessel(int size, int health)
        : base(size, health)
        {
        }
    }
}