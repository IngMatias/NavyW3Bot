namespace Library
{
    public class HeadPreviousPhase : AbstractPreviousPhase
    {
        public HeadPreviousPhase()
        :base(new AttackPreviousPhase())
        {
        }
        public override IPhase PreviousPhase(IPhase phase)
        {
            return this.SendNext(phase);
        }
    }
}