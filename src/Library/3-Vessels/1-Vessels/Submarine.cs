
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
        public override bool ReceiveAttackAt(AbstractAttackable table, AbstractAttacker attack)
        {
            if (!(attack is MissileAttack))
            {
                return base.ReceiveAttackAt(table, attack);
            }
            return false;
        }
    }
}