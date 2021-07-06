
// S -  SRP: Tiene la responsabilidad de retornar el nombre de un evento.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce los nombres de cada evento, por lo tanto se encarga de retornarlo segun el evento.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System.Collections.Generic;

namespace Library
{
    public class EventsToString : INameOf
    {
        private Dictionary<System.Type, string> _eventsName;
        public EventsToString()
        {
            List<string> names = new List<string>
            {
                "Godzilla",
                "Hurricane",
                "MeteorShower",
                "Volcano",
            };
            this._eventsName = new Dictionary<System.Type, string>
            {
                {new Godzilla().GetType(), names[0]},
                {new Hurricane().GetType(), names[1]},
                {new MeteorShower().GetType(), names[2]},
                {new Volcano().GetType(), names[3]},
            };
        }
        public string NameOf(object toName)
        {
            return this._eventsName[toName.GetType()];
        }
    }
}