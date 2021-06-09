using System.Collections.Generic;
using System.Collections.ObjectModel;

    // S - SRP: Esta clase se encarga de la responsabilidad de conocer todos los barcos del juego y
    // entregar una lista de todos ellos, esta funcion se piensa para no alterar el resto del codigo
    // al momento de agregar nuevos barcos.
    // Si se es estricto hay dos razones de cambio, si se desea agregar un nuevo barco y si se desea 
    // cambiar el metodo de eleccion entre ellos. No creemos que sea necesario romper esta unión, para
    // continuar respetando los otros patrones.

    // O - OCP: Se piensa la jerarquia VesselList - AbstractVessels - Vessel para permitir el agregado de nuevos
    // barcos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: No se encuentra una aplicacion del principio LSP.
    
    // I - ISP: EventList no respeta ISP, no hace uso de todas las operaciones de AbstractVessels.

    // D - DIP: VesselList depende de IEvent, que es una abstraccion, se cumple DIP.

    // Expert : Esta clase conoce todos los barcos, por eso su comportamiento es entregar una lista con todos ellos.

    // Polimorfismo : No se usa polimorfismo.

    // Creator : Esta clase aplica creator creando los AbstractVessels que retorna.

namespace Library
{
    public class VesselList
    {
        private List<AbstractVessels> vessels;
        public ReadOnlyCollection<AbstractVessels> Vessels
        {
            get
            {
                return vessels.AsReadOnly();
            }
        }
    }
}