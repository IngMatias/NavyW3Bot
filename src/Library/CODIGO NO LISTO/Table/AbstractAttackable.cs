
// S -  SRP: Esta clase define los metodos para que un tablero reciba un ataque.

// O -  OCP: Se cumple. Si se deseara añadir un comportamiento de recepcion de ataques diferente basta con crear una nueva clase.

// L -  LSP: Se cumple. Cualquier objeto que herede esta clase es y debe ser un subtipo de esta.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: Esta clase no conoce la representacion del tablero aunque la altera. 

//      Polymorphism: No se aplica.

//      Creator: No se aplica.

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

                bool successfully = this.vessels[(xAux, yAux)].ReceiveAttackAt(this, attack);

                if (successfully)
                {
                    this.UpdateAt(x, y, new DeadVessel());
                }
                else
                {
                    this.UpdateAt(x, y, new LivedVessel());
                }
            }
            else
            {
                if (attack is MissileAttack)
                {
                    this.UpdateAt(x, y, new AttackedWater());
                }
                else
                {
                    this.UpdateAt(x, y, new UnattackableWater());
                }
            }
        }
        public void DestroyAttack(AbstractAttacker attack)
        {
            bool deleted = this.GetVessel((attack.X, attack.Y)).ReceiveDestruction(this, attack);
            if (deleted)
            {
                this.RemoveVessel(attack.X, attack.Y, new DeadVessel());
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