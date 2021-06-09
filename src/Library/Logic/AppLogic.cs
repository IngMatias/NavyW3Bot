    
    // S - SRP: Esta clase se encarga de la responsabilidad de manejar la logica del
    // bot, como puede ser el menú y los comandos recibidos que no incluyen el juego.
    // Si se es estricto hay mas de dos razones de cambio, si se desea cambiar el mensaje
    // de bienvenida, o el de despedida asi como la forma en la que los scores se muestran.
    // Sin embargo no creemos que sea necesario romper esta unión.

    // O - OCP: No se encuentra una aplicacion del principio OCP.

    // L - LSP: No se encuentra una aplicacion del principio LSP.

    // I - ISP: No se encuentra una aplicacion del principio ISP.
    
    // D - DIP: AppLogic depende se abstracciones, cumple DIP.

namespace Library
{
    public class AppLogic
    {
        public void ShowMenuAndTakeOption(IPrinter clientP, IReader clientR)
        {

        }
        public string Welcome()
        {
            return "";
        }
        public string ByeBye()
        {
            return "";
        }
        public string Scores()
        {
            return "";
        }
    }
}