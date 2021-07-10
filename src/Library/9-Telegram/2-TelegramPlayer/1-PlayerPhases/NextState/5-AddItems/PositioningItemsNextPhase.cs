namespace Library
{
    public class PositioningItemsNextPhase : AbstractNextPhase
    {
        public PositioningItemsNextPhase()
        :base(new NotAttackNextPhase())
        {
        }
        public override IPhase NextPhase(IPhase phase)
        {
            if (phase is PositioningVesselsPhase)
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