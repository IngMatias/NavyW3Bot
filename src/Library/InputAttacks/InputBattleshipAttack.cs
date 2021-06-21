using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class InputBattleshipAttack : InputAbstractAttack
    {
        public override string Name()
        {
            return new Battleship().ToString();
        }
        public override ReadOnlyCollection<string> AttackForms()
        {
            return new List<string> { "Lanzar misil" }.AsReadOnly();
        }
        public override void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int selectedOption = this.TakeAttackOption(clientP, clientR);
            if (selectedOption == 0)
            {
                (int, int) attack = this.TakeAttack(table, clientP, clientR);
                vessel.LaunchMissile(table, attack.Item1, attack.Item2);
            }
        }
    }
}