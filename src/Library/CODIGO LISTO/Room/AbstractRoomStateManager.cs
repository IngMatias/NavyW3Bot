namespace Library
{
    public abstract class AbstractRoomStateManager : AbstractHostManager
    {
        public bool Started {get; private set;}
        protected AbstractRoomStateManager(AbstractPlayer host, int id)
        :base(host, id)
        {
        }
        protected void Start()
        {
            this.Started = true;
        }
    }
}