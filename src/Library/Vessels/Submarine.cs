
// S - SRP: Esta clase  se encarga de la responsabilidad de implementar el Submarino.
// Si se es estricto de puede detectar que hay dos razones de cambio, si se desea cambiar
// el tamaño del barco, o la forma en la que ataca.
// Sin embargo no creemos que sea necesario romper esta unión.

// L - LSP: Submarine puede ser intercambiado por cualquier otro barco y puede recibir 
// los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
// Se revisa cuidadosamente no generar efectos colaterales.

// I - ISP: Submarine no respeta ISP, no hace uso de todas las operaciones de Table.

// D - DIP: Submarine depende de Table, que no es una abstraccion, no se cumple DIP.

// Expert : En esta clase no se conoce.

// Polimorfismo : El metodo LaunchMissile es polimorfico en todos los barcos que lo tienen. Asi como ThrowLoad.
// En esta clase se usa Polimorfismo y tipos para separar el comportamiento al recibir un ataque de un misil.

// Creator : Se usa Creator cuando se crea MissileAttack y LoadAttack porque se usan de manera cercana.

using System;
using System.Collections.Generic;

namespace Library
{
    public class Submarine : AbstractVessels
    {
        public Submarine()
        {
            this.state = new int[4];
            this.InitState(1);
            this.items = new IItem[4];
        }
        public void LaunchMissile(ITable table, int x, int y)
        {
            AbstractAttacker missile = new MissileAttack();
            table.AttackAt(x, y,missile);
        }
        public void ThrowLoad(ITable table, int x, int y)
        {
            AbstractAttacker load = new LoadAttack();
            table.AttackAt(x, y,load);
        }

        public override List<string> AttackForms()
        {
            return new List<string> {"Submarine:","Lanzar misil", "Lanzar carga"};
        }
        public override void Attack0(ITable table, IPrinter clientP ,IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table,x,y);
        }
        public override void Attack1(ITable table, IPrinter clientP ,IReader clientR)
        {
            int x = Int32.Parse(clientR.Read()) - 1;
            int y = Int32.Parse(clientR.Read()) - 1;
            this.ThrowLoad(table,x,y);
        }
        public override bool ReceiveAttack(ITable table, AbstractAttacker attack)
        {
            if (attack is MissileAttack)
            {
                return false;
            }
            else
            {
                bool avoidAttack = false;
                foreach (IItem item in this.items)
                {
                    avoidAttack = item.ReceiveAttack(table, attack);
                    if (avoidAttack)
                    {
                        this.RemoveItem(item);
                        break;
                    }
                }
                if (!avoidAttack)
                {
                    this.state[attack.Position] -= 1;
                    if (this.state[attack.Position] == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}