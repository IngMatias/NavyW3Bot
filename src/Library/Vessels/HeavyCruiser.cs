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
        public void LaunchMissile(AbstractTable table, int x, int y)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            table.AttackAt(x, y, missile1);
            table.AttackAt(x, y, missile2);
        }
        public override void Attack0(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table, x, y);
        }
        public override List<string> AttackForms()
        {
            return new List<string> { "Crucero Pesado:", "Lanzar misil" };
        }
        public override void Attack1(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            throw new NotImplementedException();
        }
    }
}