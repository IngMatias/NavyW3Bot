using System.Collections.ObjectModel;

namespace Library
{
    public abstract class InputAbstractAttack
    {
        protected (int, int) TakeAttack(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(1, table.XLength(), clientP, "En que posicion X desea atacar: ");
            int y = clientR.ReadInt(1, table.YLength(), clientP, "En que posicion Y desea atacar: ");
            return (x - 1, y - 1);
        }
        protected int TakeAttackOption(AbstractVessel vessel ,IPrinter clientP, IReader clientR)
        {
            // Dependencias.
            UtilTakeOption util = new UtilTakeOption();
            VesselsToString vesselName = new VesselsToString();
            VesselsAttackForms attackForms = new VesselsAttackForms();

            clientP.Print(vesselName.NameOf(vessel));
            return util.TakeOption(attackForms.AttackFormsOf(vessel).AsReadOnly(), clientP, clientR);
        }
        public abstract void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR);
    }
}