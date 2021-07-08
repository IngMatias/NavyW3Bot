
// S -  SRP: Tiene la responsabilidad de retornar el nombre segun el barco.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce el nombre de cada barco, por lo tanto se encarga de retornarlos.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class VesselsToString : ToString
    {
        private Dictionary<System.Type, string> _vesselToString = new Dictionary<Type, string>
        {
                {new Battleship().GetType(), "Battleship"},
                {new Frigate().GetType(), "Frigate"},
                {new HeavyCruiser().GetType(), "Heavy Cruiser"},
                {new LightCruiser().GetType(), "Light Cruiser"},
                {new Puntoon().GetType(), "Puntoon"},
                {new Submarine().GetType(), "Submarine"},
        };

        public VesselsToString()
        {
            try
            {
                string language = File.ReadAllLines(@"..\..\language\LanguageConfig.txt")[0];
                string[] names = File.ReadAllLines(@"..\..\language\" + language + @"\Vessels.txt");

                this._vesselToString = new Dictionary<System.Type, string>
                {
                    {new Battleship().GetType(), names[0]},
                    {new Frigate().GetType(), names[1]},
                    {new HeavyCruiser().GetType(), names[2]},
                    {new LightCruiser().GetType(), names[3]},
                    {new Puntoon().GetType(), names[4]},
                    {new Submarine().GetType(), names[5]},
                };
            } catch (Exception)
            {
                // En caso de cualquier problema, el lenguage se mantendra en ingles.
            }
        }
        public string ToString(object toName)
        {
            return this._vesselToString[toName.GetType()];
        }
    }
}