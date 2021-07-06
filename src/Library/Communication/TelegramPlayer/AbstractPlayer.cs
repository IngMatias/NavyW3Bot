namespace Library
{
    public abstract class AbstractPlayer : ItemsManager
    {
        public AbstractPlayer(long id, IPrinter clientP)
        :base(id, clientP)
        {

        }
    }
}