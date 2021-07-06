namespace Library
{
    public class AbstractCommunicationManager : AbstractIdManager
    {
        private IPrinter _clientP;
        public AbstractCommunicationManager(long id, IPrinter clientP)
        :base(id)
        {
            this._clientP = clientP;
        }
        public void SendMessage(object message)
        {
            this._clientP.Print(this, message);
        }
    }
}