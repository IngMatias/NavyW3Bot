// S - SRP: Tiene la responsabilidad de mostrar la forma de atacar de cada barco.

// O - OCP: Cumple con el principio. En el caso de necesitar cambiar la manera de como una clase muestra los ataques del 
//           barco no se tendrá que modificar esa clase, se deberá modificar esta. 

// L - LSP: No se utiliza.

// I - ISP: No se utiliza.

// D - DIP: No se cumple con el patron, esta clase no implementa ninguna clase alto nivel, todas las clases que hagan uso
//           de esta clase, tambien dependeran de ella. Se debe implementar una interfaz.

// Expert: Esta clase conoce el nombre y los tipos de ataque de cada barco.

// Polymorphism: No se aplica.

// Creator: Esta clase usa el patron ya que crea instancias de clases cercanas.

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