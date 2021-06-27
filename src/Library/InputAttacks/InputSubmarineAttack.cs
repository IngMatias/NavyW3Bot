
// S -  SRP: Esta clase tiene la responsabilidad de seleccionar entre las formas de ataque.

// O -  OCP: Esta clase no cumple con el principio, ya que si se quiere agregar una nueva forma de ataque
//      se debe modificar el codigo de esta clase.

// L -  LSP: Cualquier clase que herede de InputAbstractAttack es y debe ser un subtipo.

// I -  ISP: Se depende de operaciones de IPrinter e IReader de las que no se utilizan todas.

// D -  DIP: Se depende solo de abstracciones.

//      Expert: No aplica.

//      Polymorphism: La operacion Attack es polimorfica.

//      Creator : No se usa.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class InputSubmarineAttack : InputAbstractAttack
    {
        public override void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int selectedOption = this.TakeAttackOption(vessel, clientP, clientR);
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