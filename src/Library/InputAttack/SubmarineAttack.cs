using System.Collections.Generic;

namespace Library
{
    public class SubmarineAttack : AbstractAttack
    {
        public override List<string> AttackForms()
        {
            return new List<string> { "Acorazado:", "Lanzar misil", "Lanzar carga"};
        }
        public override void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int selectedOption = this.TakeOption(clientP, clientR);

            if (selectedOption == 1)
            {
                (int,int) attack = this.TakeAttack(table,clientP,clientR);
                vessel.LaunchMissile(table,attack.Item1,attack.Item2);
            }
            if (selectedOption == 2)
            {
                (int,int) attack = this.TakeAttack(table,clientP,clientR);
                vessel.ThrowLoad(table,attack.Item1,attack.Item2);
            }
        }
    }
}