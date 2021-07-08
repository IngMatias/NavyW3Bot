
// S -  SRP: Tiene la responsabilidad de retornar el nombre de un evento.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce los nombres de cada evento, por lo tanto se encarga de retornarlo segun el evento.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class EventsToString : ToString
    {
        private Dictionary<System.Type, string> _eventsName = new Dictionary<System.Type, string> 
        {
            {new Godzilla().GetType(), "Godzilla"},
            {new Hurricane().GetType(), "Hurricane"},
            {new MeteorShower().GetType(), "Meteor Shower"},
            {new Volcano().GetType(), "Volcano"},
        };
        public EventsToString()
        {
            try
            {
                string language = File.ReadAllLines(@"..\..\language\LanguageConfig.txt")[0];
                string[] names = File.ReadAllLines(@"..\..\language\" + language + @"\Events.txt");

                this._eventsName = new Dictionary<System.Type, string>
                {
                    {new Godzilla().GetType(), names[0]},
                    {new Hurricane().GetType(), names[1]},
                    {new MeteorShower().GetType(), names[2]},
                    {new Volcano().GetType(), names[3]},
                };
            }
            catch (Exception)
            {
                // En caso de cualquier problema, el lenguage se mantendra en ingles.
            }
        }
        public string ToString(object toName)
        {
            return this._eventsName[toName.GetType()];
        }
    }
}