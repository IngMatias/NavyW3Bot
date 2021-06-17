
// S - SRP: Esta clase  se encarga de la responsabilidad de implementar el Ponton.

// O - OCP: Se piensa la jerarquia AbstractVessels - Vessel para permitir la implementacion de nuevos
// barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

// L - LSP: HeavyCruiser no puede ser intercambiado por cualquier otro barco, no puede recibir 
// el mensaje de LaunchMissile ni de ThrowLoad.

// I - ISP: Puntoon no respeta ISP, no hace uso de todas las operaciones de Table.

// D - DIP: Puntoon depende de Table, que no es una abstraccion, no se cumple DIP.

// Expert : En esta clase no se conoce.

// Polimorfismo : No se usa polimorfismo.

// Creator : No se usa Creator.

using System.Collections.Generic;

namespace Library
{
    public class Puntoon : AbstractVessels
    {
        public Puntoon()
        {
            this.state = new int[1];
            this.InitState(1);
            this.items = new IItem[1];
        }

        public override void Attack0(ITable table, IPrinter clientP, IReader clientR)
        {
            throw new System.NotImplementedException();
        }

        public override void Attack1(ITable table, IPrinter clientP, IReader clientR)
        {
            throw new System.NotImplementedException();
        }

        public override List<string> AttackForms()
        {
            return new List<string> ();
        }
    }
}