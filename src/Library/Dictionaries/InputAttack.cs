
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

        // Vassels.
        private AbstractVessel _battleship = new Battleship();
        private AbstractVessel _frigate = new Frigate();
        private AbstractVessel _heavyCruiser = new HeavyCruiser();
        private AbstractVessel _lightCruiser = new LightCruiser();
        private AbstractVessel _submarine = new Submarine();

        // Inputs.
        private InputAbstractAttack _inputBattleship = new InputBattleshipAttack();
        private InputAbstractAttack _inputFrigate = new InputFrigateAttack();
        private InputAbstractAttack _inputHeavyCruiser = new InputHeavyCruiserAttack();
        private InputAbstractAttack _inputLightCruiser = new InputLightCruiserAttack();
        private InputAbstractAttack _inputSubmarine = new InputSubmarineAttack();
        public InputAttack()
        {
            this._attackForms = new Dictionary<System.Type, InputAbstractAttack>
            {
                {_battleship.GetType(), _inputBattleship},
                {_frigate.GetType(), _inputFrigate},
                {_heavyCruiser.GetType(),_inputHeavyCruiser},
                {_lightCruiser.GetType(), _inputLightCruiser},
                {_submarine.GetType(), _inputSubmarine},
            };
        }
        public InputAbstractAttack AttackForm(AbstractVessel vessel)
        {
            return this._attackForms[vessel.GetType()];
        }
    }
}