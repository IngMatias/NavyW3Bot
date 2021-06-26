// S - SRP: Esta clase tiene la responsabilidad de definir un tipo de embaracion.

// O - OCP: No se aplica.

// L - LSP: Esta tipo puede ser sustituido por el tipo AbstractVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio ya que depende solo de clases de alto nivel (clases abstractas).

// Expert: Esta clase es responsable de saber las espesificaciones de la embarcacion, tales como sus dimenciones y el tipo de ataque que realiza.

// Polymorphism: Se utiliza al sobre escribir el metodo LaunchMissile, ThrowLoad y ReceiveAtack.

// Creator: No se utiliza.

using System;
using System.Collections.Generic;

namespace Library
{
    public class Submarine : AbstractVessel
    {
        public Submarine()
        : base(4, 1)
        {
        }
        public override void LaunchMissile(AbstractTable table, int x, int y)
        {
            AbstractAttacker missile = new MissileAttack();
            table.AttackAt(x, y, missile);
        }
        public override void ThrowLoad(AbstractTable table, int x, int y)
        {
            AbstractAttacker load = new LoadAttack();
            table.AttackAt(x, y, load);
        }
        public override bool ReceiveAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            if (!(attack is MissileAttack))
            {
                return base.ReceiveAttack(table, attack);
            }
            return false;
        }
    }
}