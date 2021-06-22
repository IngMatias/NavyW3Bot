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
        public string Name()
        {
            return "Battleship";
        }
        public List<string> AttackForms()
        {
            return new List<string> { "LaunchMissile" };
        }
        public override void LaunchMissile(AbstractTable table, int x, int y)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            AbstractAttacker missile3 = new MissileAttack();
            table.AttackAt(x, y, missile1);
            table.RandomAttack(missile2);
            table.RandomAttack(missile3);
        }
    }
}