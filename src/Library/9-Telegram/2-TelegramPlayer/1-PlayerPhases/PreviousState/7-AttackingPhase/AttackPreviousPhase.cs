namespace Library
{
    public class AttackPreviousPhase : AbstractPreviousPhase
    {
        public AttackPreviousPhase()
        :base(new NullPreviousPhase())
        {
        }
        public override IPhase PreviousPhase(IPhase phase)
        {
            if (phase is AttackPhase)
            {
                return new NotAttackPhase();
            }
            else
            {
                return this.SendNext(phase);
            }
        }
    }
}