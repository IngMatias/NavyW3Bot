
// S -  SRP: Tiene la responsabilidad de retornar las formas de ataque segun el barco.

// O -  OCP: No se utiliza.

// L -  LSP: No se utiliza.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: Esta clase conoce la forma de ataque de cada barco, por lo tanto se encarga de retornarlas segun el barco.

//      Polymorphism: No se aplica.

//      Creator: Esta clase usa al patron ya que crea instancias que se guardan.

using System.Collections.Generic;
namespace Library
{
    public class VesselsAttackForms
    {
        private Dictionary<System.Type, List<string>> _attackForm;
        public VesselsAttackForms()
        {
            List<List<string>> names = new List<List<string>>
            {
                new List<string> {"Lanzar Misil"},
                new List<string> {"Lanzar Misil"},
                new List<string> {"Lanzar Misil"},
                new List<string> {"Lanzar Misil"},
                new List<string> {"Lanzar Misil", "Lanzar Carga"},
                new List<string> {},
                new List<string> {"Lanzar Misil", "Lanzar Carga"},
            };
            this._attackForm = new Dictionary<System.Type, List<string>>
            {
                {new Battleship().GetType(), names[0]},
                {new Frigate().GetType(), names[1]},
                {new HeavyCruiser().GetType(), names[2]},
                {new LightCruiser().GetType(), names[3]},
                {new Puntoon().GetType(), names[4]},
                {new Submarine().GetType(), names[5]},
            };
        }
        public List<string> AttackFormsOf(AbstractVessel vessel)
        {
            return this._attackForm[vessel.GetType()];
        }
    }
}