
// S -  SRP: Esta clase tiene la responsabilidad de conseguir la informacion para realizar un ataque.

// O -  OCP: Esta clase cumple con el principio, ya que si se quiere agregar un barco con nuevas formas de ataque
//      basta con heredar de esta clase.

// L -  LSP: Cualquier clase que herede de InputAbstractAttack es y debe ser un subtipo.

// I -  ISP: Se depende de operaciones de IPrinter e IReader de las que no se utilizan todas.

// D -  DIP: Se depende de no abstracciones como lo son: UtilTakeOption, VesselsToString, VesselsAttackForms.

//      Expert: No aplica.

//      Polymorphism: La operacion TakeAttack, TakeAttackOption y Attack son polimorficas.

//      Creator : Esta clase usa al patron ya que crea instancias que usa de manera cercana.

using System.Collections.ObjectModel;

namespace Library
{
    public abstract class InputAbstractAttack
    {
        protected (int, int) TakeAttack(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(1, table.XLength(), clientP, "En que posicion X desea atacar?: ");
            int y = clientR.ReadInt(1, table.YLength(), clientP, "En que posicion Y desea atacar?: ");
            return (x - 1, y - 1);
        }
        protected int TakeAttackOption(AbstractVessel vessel, IPrinter clientP, IReader clientR)
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