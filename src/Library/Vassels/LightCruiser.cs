
    // S - SRP: Esta clase  se encarga de la responsabilidad de implementar el Crucero Ligero.
    // Si se es estricto de puede detectar que hay dos razones de cambio, si se desea cambiar
    // el tamaño del barco, o la forma en la que ataca.
    // Sin embargo no creemos que sea necesario romper esta unión.

    // O - OCP: Se piensa la jerarquia AbstractVessels - Vessel para permitir la implementacion de nuevos
    // barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: LightCruiser puede ser intercambiado por cualquier otro barco y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: LightCruiser no respeta ISP, no hace uso de todas las operaciones de Table.

    // D - DIP: LightCruiser depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo LaunchMissile es polimorfico en todos los barcos que lo tienen. Asi como ThrowLoad.

    // Creator : No se usa Creator.

namespace Library
{
    public class LightCruiser : AbstractVessels
    {
        public LightCruiser()
        :base()
        {
            this.state = new int[5];
            this.InitState(1);
        }
        public void LaunchMissile(Table table, int x, int y)
        {
            AbstractAttacker missile = new MissileAttack();
            table.AttackAt(x, y,missile);
        }
        public void ThrowLoad(Table table, int x, int y)
        {
            AbstractAttacker load = new LoadAttack();
            table.AttackAt(x, y,load);
        }
    }
}