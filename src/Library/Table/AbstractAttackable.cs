using System;

namespace Library
{
    public abstract class AbstractAttackable : AbstractField
    {
        protected AbstractAttackable(int x, int y)
        : base(x, y)
        {
        }
        public void AttackAt(int x, int y, AbstractAttacker attack)
        {
            if (this.IsAVessel(x, y))
            {
                (int, int) posicionVessel = this.GetLeftUp(x, y);

                int xAux = posicionVessel.Item1;
                int yAux = posicionVessel.Item2;

                if (y == yAux)
                {
                    // Actualizo la Posicion relativa al barco en attack.
                    attack.Position = x - xAux;
                }
                else
                {
                    // Actualizo la Posicion relativa al barco en attack.
                    attack.Position = y - yAux;
                }

                bool successfully = this.vessels[(xAux, yAux)].ReceiveAttack(this, attack);

                if (successfully)
                {
                    this.UpdateAt(x, y, Field.deadVessel);
                }
                else
                {
                    this.UpdateAt(x, y, Field.livedVessel);
                }
            }
            else
            {
                if (attack is MissileAttack)
                {
                    this.UpdateAt(x, y, Field.attackedWater);
                }
                else
                {
                    this.UpdateAt(x, y, Field.unattackableWater);
                }
            }
        }
        public void RandomAttack(AbstractAttacker attack)
        {
            Random random = new Random();
            int randomX = random.Next(0, this.XLength());
            int randomY = random.Next(0, this.YLength());
            this.AttackAt(randomX, randomY, attack);
        }
    }
}