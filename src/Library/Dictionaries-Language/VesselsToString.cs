
// S -  SRP: Tiene la responsabilidad de retornar el nombre segun el barco.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce el nombre de cada barco, por lo tanto se encarga de retornarlos.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System.Collections.Generic;
namespace Library
{
    public class VesselsToString
    {
        private Dictionary<System.Type, string> _vesselToString;

        private List<string> names = new List<string>
            {
                "BetaL-Acorazado",
                "BetaL-Fragata",
                "BetaL-Crucero Pesado",
                "BetaL-Crucero Ligero",
                "BetaL-Ponton",
                "BetaL-Submarino"
            };

        public VesselsToString()
        {
            this._vesselToString = new Dictionary<System.Type, string>
            {
                {new Battleship().GetType(), names[0]},
                {new Frigate().GetType(), names[1]},
                {new HeavyCruiser().GetType(), names[2]},
                {new LightCruiser().GetType(), names[3]},
                {new Puntoon().GetType(), names[4]},
                {new Submarine().GetType(), names[5]},
            };
        }
        public string NameOf(AbstractVessel vessel)
        {
            return this._vesselToString[vessel.GetType()];
        }
    }
}