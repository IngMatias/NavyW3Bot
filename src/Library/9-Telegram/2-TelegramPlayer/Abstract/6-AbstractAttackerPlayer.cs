namespace Library
{
    public abstract class AbstractAttackablePlayer : AbstractItemsManager
    {
        public AbstractAttackablePlayer(long id, IPrinter clientP)
        : base(id, clientP)
        {
        }
        public void ReciveOneMissile(AbstractVessel vessel, int x, int y)
        {
            vessel.LaunchMissile(this._table,x,y);
        }
        public void ReciveTwoMissile(AbstractVessel vessel, int x1, int y1, int x2, int y2)
        {
            vessel.LaunchMissile(this._table,x1,y1,x2,y2);
        }
        public void ReciveLoad(AbstractVessel vessel, int x, int y)
        {
            vessel.ThrowLoad(this._table,x,y);
        }
    }
}