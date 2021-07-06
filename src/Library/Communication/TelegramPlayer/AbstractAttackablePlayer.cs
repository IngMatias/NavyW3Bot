namespace Library
{
    public abstract class AbstractAttackablePlayer : ItemsManager
    {
        public AbstractAttackablePlayer(long id, IPrinter clientP)
        : base(id, clientP)
        {

        }
        public void ReceiveAttack(int x, int y, AbstractAttacker attack)
        {
            this._table.AttackAt(x,y,attack);
        }
    }
}