
    // S - SRP: Esta clase se encarga de la responsabilidad de manejar la logica del
    // juego, como puede ser el sistema de turnos y aliansas y los comandos recibidos durante el juego.
    // Si se es estricto hay mas de dos razones de cambio, si se desea cambiar la cantidad
    // maxima de tableros por alianza, o si se desea cambiar la sala de espera.
    // Sin embargo no creemos que sea necesario romper esta unión.

    // O - OCP: No se encuentra una aplicacion del principio OCP.
    
    // L - LSP: No se encuentra una aplicacion del principio LSP.

    // I - ISP: GameLogic no respeta ISP, no hace uso de todas las operaciones de Table.

    // D - DIP: GameLogic depende se abstracciones, cumple DIP.

    // Expert : Esta clase conoce los participantes y como estan aliados, por eso tiene la responsabilidad
    // de ejecutar el juego.

    // Polimorfismo : No se usa Polimorfismo.

    // Creator : Se usa Creator para la creacion de los Table.

using System.Collections.Generic;

namespace Library
{
    public class GameLogic
    {
        private List<Table> participants;
        private List<(Table, Table)> alliances;
        public void WaitingRoom()
        {

        }
        public void MakeStart()
        {

        }
        public void MakeAlliance(Table t1, Table t2)
        {

        }
        public void BreakAlliance(Table t)
        {

        }
        public void DoRandomEvent()
        {

        }
        public void Game(IPrinter clientP, IReader clientR)
        {

        }
    }
}