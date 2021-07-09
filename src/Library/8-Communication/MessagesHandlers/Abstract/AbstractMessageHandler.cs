namespace Library
{
    public abstract class AbstractMessageHandler
    {
        protected AbstractMessageHandler _next;
        protected AbstractMessageHandler(AbstractMessageHandler next)
        {
            this._next = next;
        }
        public abstract string Message(IMessage message, string lang);
        public string SendNext(IMessage message, string lang)
        {
            return this._next.Message(message, lang);
        }
    }
}