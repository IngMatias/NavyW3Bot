
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
    public class Battleship : AbstractVessel, IOneMissile
    {
        public Battleship()
        : base(6, 1)
        {
        }
        public void LaunchMissile(AbstractTable table, int x, int y)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            AbstractAttacker missile3 = new MissileAttack();
            table.AttackAt(x, y, missile1);
            table.RandomAttack(missile2);
            table.RandomAttack(missile3);
        }
    }
}