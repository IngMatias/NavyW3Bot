// S - SRP: Tiene la responsabilidad de mostrar cada barco. Ademas quita una responsabilidad de la clase que necesite 
//           convertir a string un barco.

// O - OCP: Cumple con el principio. En el caso de necesitar cambiar la manera de como una clase transforma a string 
//           el barco no se tendrá que modificar esa clase, se deberá modificar esta. 

// L - LSP: No se utiliza,

// I - ISP: No se Utiliza.

// D - DIP: No se cumple con el patron, esta clase no implementa ninguna clase alto nivel, todas las clases que hagan uso
//           de esta clase, tambien dependeran de ella. Se debe implementar una interfaz.

// Expert: Esta clase conoce los nombres de cada tipo.

// Polymorphism: No se utiliza.

// Creator: No se utiliza.

using System.Collections.Generic;
namespace Library
{
    public class VesselsToString
    {
        private Dictionary<System.Type, string> _vesselToString;

        private List<string> names = new List<string>
            {
                "Acorazado",
                "Fragata",
                "Crucero Pesado",
                "Crucero Ligero",
                "Ponton",
                "Submarino"
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