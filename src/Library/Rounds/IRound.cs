namespace Library
{
    public interface IRound
    {
        public void AddPlayer(AbstractTable player);
        public AbstractTable Execute(IPrinter clientP, IReader clientR);
    }
}