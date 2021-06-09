
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

    // Creator : No se usa Creator.

namespace Library
{
    public class Submarine : AbstractVessels
    {
        public Submarine()
        :base()
        {
            this.state = new int[4];
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
        public void ReceiveAttack(MissileAttack attack)
        {

        }
    }
}