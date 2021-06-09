using System;
using System.Collections.Generic;

    // S - SRP: Esta clase  se encarga de la responsabilidad de implementar el Acorazado.
    // Si se es estricto de puede detectar que hay dos razones de cambio, si se desea cambiar
    // el tamaño del barco, o la forma en la que ataca.
    // Sin embargo no creemos que sea necesario romper esta unión.

    // O - OCP: Se piensa la jerarquia AbstractVessels - Vessel para permitir la implementacion de nuevos
    // barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Battleship no puede ser intercambiado por cualquier otro barco, no puede recibir 
    // el mensaje de ThrowLoad,además se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - Battleship: GameLogic no respeta ISP, no hace uso de todas las operaciones de Table.

    // D - DIP: Battleship depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo LaunchMissile es polimorfico en todos los barcos que lo tienen. Asi como ThrowLoad.

    // Creator : No se usa Creator.

namespace Library
{
    public class Battleship : AbstractVessels
    {
        public Battleship()
        : base()
        {
            this.state = new int[6];
            this.InitState(1);
        }
        public void LaunchMissile(Table table, int x, int y)
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