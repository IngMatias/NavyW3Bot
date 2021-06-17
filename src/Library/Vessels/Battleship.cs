using System;
using System.Collections.Generic;

namespace Library
{
    public class Battleship : AbstractVessel
    {
        public Battleship()
        : base(6, 1)
        {
            
        }
        public void LaunchMissile(ITable table, int x, int y)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            AbstractAttacker missile3 = new MissileAttack();
            table.AttackAt(x, y, missile1);
            table.RandomAttack(missile2);
            table.RandomAttack(missile3);
        }
        public override void Attack0(ITable table, IPrinter clientP, IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table, x, y);
        }
        public override List<string> AttackForms()
        {
            return new List<string> { "Acorazado:", "Lanzar misil" };
        }
        public override void Attack1(ITable table, IPrinter clientP, IReader clientR)
        {
            throw new NotImplementedException();
        }
    }
}