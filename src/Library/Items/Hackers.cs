
    // S - SRP: Esta clase se encarga de la responsabilidad de determinar cuando
    // es posible aagregar el Hacker a un tablero y a un barco determinado.

    // O - OCP: Se piensa la jerarquia ItemList - IItem - Item para permitir el agregado de nuevos
    // items sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Hacker puede ser intercambiado por cualquier otro item y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: Hacker no respeta ISP, no hace uso de todas las operaciones de Table,
    // ni de AbstractVessels.

    // D - DIP: Hacker depende de Table, que no es una abstraccion, no se cumple DIP.

namespace Library
{
    public class Hackers : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            if (vasselToAdd is Puntoon)
            {
                return true;
            }
            return false;
        }
        public bool ReceiveAttack(Table table, AbstractAttacker attack)
        {
            return false;
        }
    }
}