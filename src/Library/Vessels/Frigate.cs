// S - SRP: Esta clase tiene la responsabilidad de definir un tipo de embaracion.

// O - OCP: No se aplica.

// L - LSP: Esta tipo puede ser sustituido por el tipo AbstractVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio ya que depende solo de clases de alto nivel (clases abstractas).

// Expert: Esta clase es responsable de saber las espesificaciones de la embarcacion, tales como sus dimenciones y el tipo de ataque que realiza.

// Polymorphism: Se utiliza al sobre escribir el metodo LaunchMissile.

// Creator: No se utiliza.

using System;
using System.Collections.Generic;

namespace Library
{
    public class Frigate : AbstractVessel
    {
        public Frigate()
        : base(2, 1)
        {
        }
        public override void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            AbstractAttacker missile3 = new MissileAttack();
            AbstractAttacker missile4 = new MissileAttack();
            table.AttackAt(x1, y1, missile1);
            table.AttackAt(x2, y2, missile2);
            table.RandomAttack(missile3);
            table.RandomAttack(missile4);
        }
    }
}