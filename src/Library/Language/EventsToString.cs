using System.Collections.Generic;

// S - SRP: Tiene la responsabilidad de mostrar el nombre de un evento.

// O - OCP:

// L - LSP: 

// I - ISP: 

// D - DIP: No se aplica.

// Expert: Esta clase conoce los tipos dentro del diccionario lo que le permite cumplir con su funcionalidad.

// Polymorphism: No se aplica.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class EventsToString
    {
        private Dictionary<System.Type, string> _eventsName;
        public EventsToString()
        {
            List<string> names = new List<string>
            {
                "Lang-Godzilla",
                "Lang-Hurricane",
                "Lang-MeteorShower",
                "Lang-Volcano",
            };
            this._eventsName = new Dictionary<System.Type, string>
            {
                {new Godzilla().GetType(), names[0]},
                {new Hurricane().GetType(), names[1]},
                {new MeteorShower().GetType(), names[2]},
                {new Volcano().GetType(), names[3]},
            };
        }
        public string NameOf(IEvent catastrophe)
        {
            return this._eventsName[catastrophe.GetType()];
        }
    }
}