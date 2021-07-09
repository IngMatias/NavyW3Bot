namespace Library
{
    public abstract class HeadCommandsToString : AbstractCommandsTranslate
    {
        public HeadCommandsToString()
        :base(new StartCommandsToString())
        {
        }
        public override string Translate(string command, string lang)
        {
            return this.SendNext(command, lang);
        }
    }
}