
// S -  SRP: Tiene la responsabilidad de retornar el nombre de un item.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce los nombres de cada item, por lo tanto se encarga de retornarlo segun el item.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class ItemsToString : ToString
    {
        private Dictionary<System.Type, string> _itemToString = new Dictionary<Type, string>
        {
            {new AntiaircraftMissile().GetType(), "Antiaircraft Missile"},
            {new Armor().GetType(), "Armor"},
            {new Hackers().GetType(), "Hackers"},
            {new Kong().GetType(), "Kong"},
            {new SateliteLock().GetType(), "Satelite Lock"},
        };
        public ItemsToString()
        {
            try
            {
                string language = File.ReadAllLines(@"..\..\language\LanguageConfig.txt")[0];
                string[] names = File.ReadAllLines(@"..\..\language\" + language + @"\Items.txt");

                this._itemToString = new Dictionary<System.Type, string>
                {
                {new AntiaircraftMissile().GetType(), names[0]},
                {new Armor().GetType(), names[1]},
                {new Hackers().GetType(), names[2]},
                {new Kong().GetType(), names[3]},
                {new SateliteLock().GetType(), names[4]},
                };
            }
            catch (Exception)
            {
                // En caso de cualquier problema, el lenguage se mantendra en ingles.
            }

        }
        public string ToString(object toName)
        {
            return this._itemToString[toName.GetType()];
        }
    }
}