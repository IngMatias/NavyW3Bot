
// S -  SRP: Esta clase tiene la responsabilidad dado un barco retornar el objeto para recibir un ataque por el usuario.

// O -  OCP: No cumple OCP, si se quiere agregar un nuevo ataque es necesario modificar el codigo sin embargo 
//      una posible solucion podria ser aplicando el patron Cadena de Responsabilidad para cumplir OCP.

// L -  LSP: No se hallan relaciones de subtipo relacionadas con esta clase.

// I -  ISP: No se usan interfaces.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: Esta clase conoce el diccionario de formas de ataques, por ello tiene la responsabilidad 
//      de retornar el input del mismo.

//      Polymorphism: No es utilizado.

//      Creator: Esta clase usa el patron ya que guarda instancias de AbstractVessel e InputAbstractAttack.

using System.Collections.Generic;

namespace Library
{
    public class InputAttack
    {
        private Dictionary<System.Type, InputAbstractAttack> _attackForms;
        public InputAttack()
        {
            this._attackForms = new Dictionary<System.Type, InputAbstractAttack>
            {
                {new Battleship().GetType(), new InputBattleshipAttack()},
                {new Frigate().GetType(), new InputFrigateAttack()},
                {new HeavyCruiser().GetType(), new InputHeavyCruiserAttack()},
                {new LightCruiser().GetType(), new InputLightCruiserAttack()},
                {new Submarine().GetType(), new InputSubmarineAttack()},
            };
        }
        public InputAbstractAttack AttackForm(AbstractVessel vessel)
        {
            return this._attackForms[vessel.GetType()];
        }
    }
}