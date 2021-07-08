
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
    public class CommandsToString : ToString
    {
        private Dictionary<string, string> _commandsToString;

        public CommandsToString()
        {
            try
            {
                string language = File.ReadAllLines(@"..\..\language\LanguageConfig.txt")[0];
                string[] names = File.ReadAllLines(@"..\..\language\" + language + @"\Commands.txt");

                this._commandsToString = new Dictionary<string, string> {};
            } catch (Exception)
            {
                // En caso de cualquier problema, el lenguage se mantendra en ingles.
            }
        }
        public string ToString(object toName)
        {
            return toName.ToString();
        }
    }
}