namespace Library
{
    public abstract class HeadCommandsToString : AbstractCommandsToString
    {
        public HeadCommandsToString()
        :base(new StartCommandsToString())
        {
        }
        public override string ToString(string command, string lang)
        {
            return this.SendNext(command, lang);
        }
    }
}