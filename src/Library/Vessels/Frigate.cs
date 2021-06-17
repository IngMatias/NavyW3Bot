using System;
using System.Collections.Generic;

// S - SRP: Esta clase  se encarga de la responsabilidad de implementar la Fragata.
// Si se es estricto de puede detectar que hay dos razones de cambio, si se desea cambiar
// el tamaño del barco, o la forma en la que ataca.
// Sin embargo no creemos que sea necesario romper esta unión.

// O - OCP: Se piensa la jerarquia AbstractVessels - Vessel para permitir la implementacion de nuevos
// barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

// L - LSP: Frigate no puede ser intercambiado por cualquier otro barco, no puede recibir 
// el mensaje de ThrowLoad,además se comporta de distinta manera, naturalmente.
// Se revisa cuidadosamente no generar efectos colaterales.

// I - ISP: Frigate no respeta ISP, no hace uso de todas las operaciones de Table.

// D - DIP: Frigate depende de Table, que no es una abstraccion, no se cumple DIP.

// Expert : En esta clase no se conoce.

// Polimorfismo : El metodo LaunchMissile es polimorfico en todos los barcos que lo tienen. Asi como ThrowLoad.

// Creator : Se usa Creator cuando se crea MissileAttack porque se usa de manera cercana.

namespace Library
{
    public class Frigate : AbstractVessels
    {
        public Frigate()
        :base(2,1)
        {
        }
        public void LaunchMissile(ITable table, int x1, int y1, int x2, int y2)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            AbstractAttacker missile3 = new MissileAttack();
            AbstractAttacker missile4 = new MissileAttack();
            table.AttackAt(x1, y1,missile1);
            table.AttackAt(x2, y2,missile2);
            table.RandomAttack(missile3);
            table.RandomAttack(missile4);
        }
        public override void Attack0(ITable table, IPrinter clientP ,IReader clientR)
        {
            int x1 = Int32.Parse(clientR.Read()) - 1;
            int y1 = Int32.Parse(clientR.Read()) - 1;
            int x2 = Int32.Parse(clientR.Read()) - 1;
            int y2 = Int32.Parse(clientR.Read()) - 1;
            this.LaunchMissile(table,x1,y1,x2,y2);
        }
        public override List<string> AttackForms()
        {
            return new List<string> {"Fragata:" , "Lanzar misil"};
        }
        public override void Attack1(ITable table, IPrinter clientP, IReader clientR)
        {
            throw new NotImplementedException();
        }
    }
}