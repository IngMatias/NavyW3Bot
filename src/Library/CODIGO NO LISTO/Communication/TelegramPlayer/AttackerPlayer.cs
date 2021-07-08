namespace Library
{
    public abstract class AttackerPlayer : ItemsManager
    {
        public AttackerPlayer(long id, IPrinter clientP)
        : base(id, clientP)
        {

        }
        public void ReciveAttack(IOneMissile vessel, int x, int y)
        {
            vessel.LaunchMissile(this._table,x,y);
        }
    }
}