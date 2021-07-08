
// S -  SRP: Tiene la responsabilidad de retornar las formas de ataque segun el barco.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce la forma de ataque de cada barco, por lo tanto se encarga de retornarlas segun el barco.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class VesselsAttackForms : IAttackFormsOf
    {
        private string _launchMissile = "Launch Missile";
        private string _throwLoad = "Throw Load";
        private Dictionary<System.Type, List<string>> _attackForm;
        public VesselsAttackForms()
        {
            try
            {
                string language = File.ReadAllLines(@"..\..\language\LanguageConfig.txt")[0];
                string[] names = File.ReadAllLines(@"..\..\language\" + language + @"\AttackForms.txt");
                this._launchMissile = names[0];
                this._throwLoad = names[1];

            }
            catch (Exception)
            {

            }

            this._attackForm = new Dictionary<System.Type, List<string>>
            {
                {new Battleship().GetType(),new List<string> {_launchMissile}},
                {new Frigate().GetType(),new List<string> {_launchMissile}},
                {new HeavyCruiser().GetType(),new List<string> {_launchMissile}},
                {new LightCruiser().GetType(),new List<string> {_launchMissile, _throwLoad}},
                {new Puntoon().GetType(),new List<string> {}},
                {new Submarine().GetType(),new List<string> {_launchMissile, _throwLoad}},
            };
        }
        public List<string> AttackFormsOf(AbstractVessel vessel)
        {
            return this._attackForm[vessel.GetType()];
        }
    }
}