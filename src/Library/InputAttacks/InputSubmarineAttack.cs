using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class InputSubmarineAttack : InputAbstractAttack
    {
        public override string Name()
        {
            return new Submarine().ToString();
        }
        public override ReadOnlyCollection<string> AttackForms()
        {
            return new List<string> { "Lanzar misil", "Lanzar carga" }.AsReadOnly();
        }
        public override void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int selectedOption = this.TakeAttackOption(clientP, clientR);
            if (selectedOption == 0)
            {
                (int, int) attack = this.TakeAttack(table, clientP, clientR);
                vessel.LaunchMissile(table, attack.Item1, attack.Item2);
            }
            if (selectedOption == 1)
            {
                (int, int) attack = this.TakeAttack(table, clientP, clientR);
                vessel.ThrowLoad(table, attack.Item1, attack.Item2);
            }
        }
    }
}