
// S - SRP: Esta clase tiene la responsabilidad de definir un tipo de barco.

// O - OCP: Basta con definir una nueva clase para definir un nuevo tipo de barco.

// L - LSP: Esta clase es un subtipo de AbstractVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio ya que depende solo de clases de alto nivel (clases abstractas).

// Expert: No se utiliza.

// Polymorphism: No se utiliza.

// Creator: No se utiliza.

using System;
using System.Collections.Generic;

namespace Library
{
    public class Frigate : AbstractVessel, ITwoMissiles
    {
        public Frigate()
        : base(2, 1)
        {
        }
        public void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
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