using System;
using System.Collections.Generic;

namespace Library
{
    public class Frigate : AbstractVessel
    {
        public Frigate()
        : base(2, 1)
        {
            
        }
        public void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            AbstractAttacker missile3 = new MissileAttack();
            AbstractAttacker missile4 = new MissileAttack();
            table.AttackAt(x1, y1, missile1);
            table.AttackAt(x2, y2, missile2);
            table.RandomAttack(missile3);
            table.RandomAttack(missile4);
        }
        public override void Attack0(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x1 = Int32.Parse(clientR.Read()) - 1;
            int y1 = Int32.Parse(clientR.Read()) - 1;
            int x2 = Int32.Parse(clientR.Read()) - 1;
            int y2 = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table, x1, y1, x2, y2);
        }
        public override List<string> AttackForms()
        {
            return new List<string> { "Fragata:", "Lanzar misil" };
        }
        public override void Attack1(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            throw new NotImplementedException();
        }
    }
}