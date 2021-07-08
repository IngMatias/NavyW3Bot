namespace Library
{
    public abstract class AbstractRoomIdManager
    {
        public int Id { get; private set; }
        protected AbstractRoomIdManager(int id)
        {
            this.Id = id;
        }

    }
}