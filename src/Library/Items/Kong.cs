
    // S - SRP: Esta clase se encarga de la responsabilidad de determinar cuando
    // es posible aagregar Kong a un tablero y a un barco determinado.

    // O - OCP: Se piensa la jerarquia ItemList - IItem - Item para permitir el agregado de nuevos
    // items sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Kong puede ser intercambiado por cualquier otro item y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: Kong no respeta ISP, no hace uso de todas las operaciones de Table,
    // ni de AbstractVessels.

    // D - DIP: Kong depende de Table, que no es una abstraccion, no se cumple DIP.

namespace Library
{
    public class Kong : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            if (vasselToAdd.Items.Count == 0 && vasselToAdd.Length() < 4)
            {
                return true;
            }
            return false;
        }
        public bool ReceiveAttack(AbstractAtacker attack)
        {
            return true;
        }
    }
}