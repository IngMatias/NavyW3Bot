using System.Collections.Generic;

namespace Library
{
    public class BattleshipAttack : AbstractAttack
    {
        public override List<string> AttackForms()
        {
            return new List<string> { "Acorazado:", "Lanzar misil" };
        }
        public override void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int selectedOption = this.TakeOption(clientP, clientR);

            if (selectedOption == 1)
            {
                (int,int) attack = this.TakeAttack(table,clientP,clientR);
                vessel.LaunchMissile(table,attack.Item1,attack.Item2);
            }
        }
    }
}