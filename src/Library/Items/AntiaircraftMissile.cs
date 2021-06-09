    
    // S - SRP: Esta clase se encarga de la responsabilidad de determinar cuando
    // es posible aagregar el Misil Antiaereo a un tablero y a un barco determinado.

    // O - OCP: Se piensa la jerarquia ItemList - IItem - Item para permitir el agregado de nuevos
    // items sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: AntiaircraftMissile puede ser intercambiado por cualquier otro item y puede recibir 
    // los mismos mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: AntiaircraftMissile no respeta ISP, no hace uso de todas las operaciones de Table,
    // ni de AbstractVessels.
    
    // D - DIP: AntiaircraftMissile depende de Table, que no es una abstraccion, no se cumple DIP.

namespace Library
{
    public class AntiaircraftMissile : IItem
    {
        public bool IsAddable(Table table, AbstractVessels vasselToAdd)
        {
            foreach (IItem item in vasselToAdd.Items)
            {
                if (item is AntiaircraftMissile)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ReceiveAttack(AbstractAtacker attack)
        {
            return true;
        }
    }
}