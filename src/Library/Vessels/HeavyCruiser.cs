using System;
using System.Collections.Generic;

namespace Library
{
    public class HeavyCruiser : AbstractVessel
    {
        public HeavyCruiser()
        : base(3, 2)
        {

        }
        public string Name()
        {
            return "HeavyCruiser";
        }
        public List<string> AttackForms()
        {
            return new List<string> { "LaunchMissile" };
        }
        public override void LaunchMissile(AbstractTable table, int x, int y)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            table.AttackAt(x, y, missile1);
            table.AttackAt(x, y, missile2);
        }
    }
}