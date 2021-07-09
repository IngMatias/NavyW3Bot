namespace Library
{
    public class AttackNextPhase : AbstractNextPhase
    {
        public AttackNextPhase()
        :base(new NullNextPhase())
        {
        }
        public override IPhase NextPhase(IPhase phase)
        {
            if (phase is AttackPhase)
            {
                return new WaitingForStartPhase();
            }
            else
            {
                return this.SendNext(phase);
            }
        }
    }
}