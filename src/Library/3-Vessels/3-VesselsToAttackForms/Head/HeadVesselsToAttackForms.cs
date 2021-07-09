using System.Collections.Generic;

namespace Library
{
    public abstract class HeadVesselsToAttackForms : AbstractVesselsToAttackForms
    {
        public HeadVesselsToAttackForms()
        :base(new BattleshipToAttackForms())
        {
        }
        public override List<string> ToString(AbstractVessel vessel, string lang)
        {
            return this.SendNext(vessel, lang);
        }
    }
}