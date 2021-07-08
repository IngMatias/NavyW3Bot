namespace Library
{
    public abstract class AbstractPlayer : AttackerPlayer
    {
        public string Name {get; set; }
        public AbstractPlayer(string name, long id, IPrinter clientP)
        :base(id, clientP)
        {
            this.Name = name;
        }
    }
}