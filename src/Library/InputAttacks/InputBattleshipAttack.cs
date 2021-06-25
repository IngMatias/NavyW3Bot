using System.Collections.Generic;
using System.Collections.ObjectModel;

// S - SRP: Esta clase tiene la responsabilidad de atacar con el acorazado a una posicion ingresada por el jugador

// O - OCP: Se cumple con el principio ya que se puede agregar otra forma de atacar heredando de InputAbstractAttack.

// L - LSP: Cualquier clase que herede de InputAbstractAttack es y debe ser un subtipo.

// I - ISP: No aplica.

// D - DIP: El metodo Attack depende de una clase abstracta por lo tanto cumple con DIP.

// Expert: Esta clase conoce las cordenadas por lo tanto puede cumplir con su responsabilidad.

// Polymorphism: La operacion Attack es polimorfica.

// Creator : No se utiliza.

namespace Library
{
    public class InputBattleshipAttack : InputAbstractAttack
    {
        public override void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR)
        {
            int selectedOption = this.TakeAttackOption(vessel, clientP, clientR);
            if (selectedOption == 0)
            {
                (int, int) attack = this.TakeAttack(table, clientP, clientR);
                vessel.LaunchMissile(table, attack.Item1, attack.Item2);
            }
        }
    }
}