using System.Collections.ObjectModel;

namespace Library
{
    public abstract class InputAbstractAttack
    {
        public abstract string Name();
        public abstract ReadOnlyCollection<string> AttackForms();
        public (int, int) TakeAttack(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(1, table.XLength(), clientP, "En que posicion X desea atacar: ");
            int y = clientR.ReadInt(1, table.YLength(), clientP, "En que posicion Y desea atacar: ");
            return (x - 1, y - 1);
        }
        public int TakeAttackOption(IPrinter clientP, IReader clientR)
        {
            clientP.Print(this.Name());
            UtilTakeOption util = new UtilTakeOption();
            return util.TakeOption(this.AttackForms(), clientP, clientR);
        }
        public abstract void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR);
    }
}