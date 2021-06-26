// S - SRP: Esta clase define los metodos para que un tablero reciba un ataque.

// O - OCP: Se cumple. Si se deseara añadir un comportamiento al tablero, se debería crear una nueva clase abtracta con el
//           comportamiento definido a esta nueva clase y hacer que AbstractVesselSaver lo herede.
//           Recordar que Table es una clase compuesta por:
//           AbstractVesselSaver -> AbstractField -> AbstractAttackable -> AbstractTable -> Table
//           AbstractVesselSaver es la última clase en la cadena, si esta clase hereda un comportamiento, todas las clases
//           que hereden a esta úlitma tambien habrán heredado el nuevo comportamiento, haciendo que se cumpla el principio.

// L - LSP: Se cumple. Cualquier objeto Table puede ser sustituido por el tipo AbstractAttackable, mas si esto se hiciera no se
//           contaría con todos los comportamientos de las clases que heredan a esta.

// I - ISP: No se aplica.

// D - DIP: Se aplica DIP, esto se puede ver en el diseño de Table (clase de bajo nivel), esta depende de abstracciones
//           no de clases de bajo nivel.

// Expert: Esta clase es la experta en la interaccion de los tableros con los barcos, esta clase conoce todas las formas
//          en las que un tablero puede ser atacado. 

// Polymorphism: No se aplica.

// Creator: No se aplica.

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