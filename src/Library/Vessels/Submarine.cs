using System;
using System.Collections.Generic;

namespace Library
{
    public class Submarine : AbstractVessel
    {
        public Submarine()
        : base(4, 1)
        {
            
        }
        public void LaunchMissile(AbstractTable table, int x, int y)
        {
            AbstractAttacker missile = new MissileAttack();
            table.AttackAt(x, y, missile);
        }
        public void ThrowLoad(AbstractTable table, int x, int y)
        {
            AbstractAttacker load = new LoadAttack();
            table.AttackAt(x, y, load);
        }

        public override List<string> AttackForms()
        {
            return new List<string> { "Submarine:", "Lanzar misil", "Lanzar carga" };
        }
        public override void Attack0(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table, x, y);
        }
        public override void Attack1(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.ThrowLoad(table, x, y);
        }
    }
}