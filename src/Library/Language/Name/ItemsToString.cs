
// S -  SRP: Tiene la responsabilidad de retornar el nombre de un item.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce los nombres de cada item, por lo tanto se encarga de retornarlo segun el item.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System.Collections.Generic;

namespace Library
{
    public class ItemsToString : INameOf
    {
        private static ItemsToString _instance;
        public static ItemsToString Instance
        {
            get
            {
                if (_instance  == null)
                {
                    _instance = new ItemsToString();
                }
                return _instance;
            }
        }
        private Dictionary<System.Type, string> _itemToString;
        private ItemsToString()
        {
            List<string> names = new List<string>
            {
                "Misil Antiaereo",
                "Armadura",
                "Hackers",
                "Kong",
                "Bloqueo Satelital"
            };
            this._itemToString = new Dictionary<System.Type, string>
            {
                {new AntiaircraftMissile().GetType(), names[0]},
                {new Armor().GetType(), names[1]},
                {new Hackers().GetType(), names[2]},
                {new Kong().GetType(), names[3]},
                {new SateliteLock().GetType(), names[4]},
            };
        }
        public string NameOf(object toName)
        {
            return this._itemToString[toName.GetType()];
        }
    }
}