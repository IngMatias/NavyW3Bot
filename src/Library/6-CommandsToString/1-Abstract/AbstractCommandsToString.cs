namespace Library
{
    public abstract class AbstractCommandsToString
    {
        private AbstractCommandsToString _next;
        public AbstractCommandsToString(AbstractCommandsToString next)
        {
            this._next = next;
        }
        public abstract string ToString(string command, string lang);
        public string SendNext(string command, string lang)
        {
            return this._next.ToString(command, lang);
        }
    }
}