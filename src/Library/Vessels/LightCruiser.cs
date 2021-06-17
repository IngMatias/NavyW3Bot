using System;
using System.Collections.Generic;

namespace Library
{
    public class LightCruiser : AbstractVessel
    {
        public LightCruiser()
        : base(5, 1)
        {
            
        }
        public void LaunchMissile(ITable table, int x, int y)
        {
            AbstractAttacker missile = new MissileAttack();
            table.AttackAt(x, y, missile);
        }
        public void ThrowLoad(ITable table, int x, int y)
        {
            AbstractAttacker load = new LoadAttack();
            table.AttackAt(x, y, load);
        }
        public override void Attack0(ITable table, IPrinter clientP, IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table, x, y);
        }
        public override void Attack1(ITable table, IPrinter clientP, IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.ThrowLoad(table, x, y);
        }
        public override List<string> AttackForms()
        {
            return new List<string> { "Crucero Ligero:", "Lanzar misil", "Lanzar carga" };
        }

    }
}