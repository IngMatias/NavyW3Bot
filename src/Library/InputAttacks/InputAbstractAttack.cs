using System.Collections.ObjectModel;

// S - SRP: Esta clase tiene la responsabilidad de atacar a una posicion ingresada por el jugador.

// O - OCP: Esta clase cumple con el principio, ya que si se quiere agregar una nueva forma de ataque basta con
//          heredar de esta clase.

// L - LSP: Cualquier clase que herede de InputAbstractAttack es y debe ser un subtipo.

// I - ISP: No aplica.

// D - DIP: Tanto TakeAttack como TakeAttackOption y Attack dependen de una clase abstracta por lo tanto cumplen con DIP.

// Expert: Esta clase conoce las cordenadas por lo tanto puede cumplir con su responsabilidad.

// Polymorphism: La operacion TakeAttack, TakeAttackOption y Attack son polimorficas.

// Creator : Esta clase usa al patron ya que crea instancias de clases cercanas.

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