using System.Collections.Generic;

// S - SRP: Tiene la responsabilidad de mostrar cada barco.

// O - OCP:

// L - LSP: 

// I - ISP: 

// D - DIP: No se aplica.

// Expert: Esta clase conoce los tipos dentro del diccionario lo que le permite cumplir con su funcionalidad.

// Polymorphism: No se aplica.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.


namespace Library
{
    public class VesselsToString
    {
        private Dictionary<System.Type,string> _vesselToString;
        public VesselsToString()
        {
            List<string> names = new List<string> 
            {
                "Lang-Acorazado",
                "Lang-Fragata",
                "Lang-Crucero Pesado",
                "Lang-Crucero Ligero",
                "Lang-Ponton",
                "Lang-Submarino"
            };
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