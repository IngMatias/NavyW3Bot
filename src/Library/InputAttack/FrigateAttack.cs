using System.Collections.Generic;

namespace Library
{
    public class FrigateAttack : AbstractAttack
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
                (int,int) attack1 = this.TakeAttack(table,clientP,clientR);
                (int,int) attack2 = this.TakeAttack(table,clientP,clientR);
                vessel.LaunchMissile(table,attack1.Item1,attack2.Item2,attack2.Item1,attack2.Item2);
            }
        }
    }
}