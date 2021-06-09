
    // S - SRP: Esta clase  se encarga de la responsabilidad de implementar el Crucero Pesado.
    // Si se es estricto de puede detectar que hay dos razones de cambio, si se desea cambiar
    // el tamaño del barco, o la forma en la que ataca.
    // Sin embargo no creemos que sea necesario romper esta unión.
    
    // O - OCP: Se piensa la jerarquia AbstractVessels - Vessel para permitir la implementacion de nuevos
    // barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: HeavyCruiser no puede ser intercambiado por cualquier otro barco, no puede recibir 
    // el mensaje de ThrowLoad,además se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: HeavyCruiser no respeta ISP, no hace uso de todas las operaciones de Table.

    // D - DIP: HeavyCruiser depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo LaunchMissile es polimorfico en todos los barcos que lo tienen. Asi como ThrowLoad.

    // Creator : Se usa Creator cuando se crea MissileAttack porque se usa de manera cercana.

namespace Library
{
    public class HeavyCruiser : AbstractVessels
    {
        public HeavyCruiser()
        :base()
        {
            this.state = new int[3];
            this.InitState(2);
        }
        public void LaunchMissile(Table table, int x, int y)
        {
            AbstractAttacker missile1 = new MissileAttack();
            AbstractAttacker missile2 = new MissileAttack();
            table.AttackAt(x, y,missile1);
            table.AttackAt(x, y,missile2);
        }
    }
}