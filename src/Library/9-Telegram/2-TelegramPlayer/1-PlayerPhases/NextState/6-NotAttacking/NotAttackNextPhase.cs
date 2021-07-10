namespace Library
{
    public class NotAttackNextPhase : AbstractNextPhase
    {
        public NotAttackNextPhase()
        :base(new AttackNextPhase())
        {
        }
        public override IPhase NextPhase(IPhase phase)
        {
            if (phase is NotAttackPhase)
            {
                return new AttackPhase();
            }
            else
            {
                return this.SendNext(phase);
            }
        }
    }
}