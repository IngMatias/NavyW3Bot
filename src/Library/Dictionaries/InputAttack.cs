using System.Collections.Generic;

namespace Library
{
    public class InputAttack
    {
        private Dictionary<System.Type, InputAbstractAttack> _attackForms;

        // Se crean las variables de instancia para evitar que cada vez que se llame a la clase se creen instancias inecesariamente.

        // Vessels.
        private AbstractVessel _battleShip = new Battleship();
        private AbstractVessel _frigate = new Frigate();
        private AbstractVessel _heavyCruiser = new HeavyCruiser();
        private AbstractVessel _lightCruiser = new LightCruiser();
        private AbstractVessel _submarine = new Submarine();

        // InputsAbstract.
        private InputAbstractAttack _battleShipInput = new InputBattleshipAttack();
        private InputAbstractAttack _frigateInput = new InputFrigateAttack();
        private InputAbstractAttack _heavyCruiserInput = new InputHeavyCruiserAttack();
        private InputAbstractAttack _lightCruiserInput = new InputLightCruiserAttack();
        private InputAbstractAttack _submarineInput = new InputSubmarineAttack();
        public InputAttack()
        {
            this._attackForms = new Dictionary<System.Type, InputAbstractAttack>
            {
                {_battleShip.GetType(), _battleShipInput},
                {_frigate.GetType(), _frigateInput},
                {_heavyCruiser.GetType(), _heavyCruiserInput},
                {_lightCruiser.GetType(), _lightCruiserInput},
                {_submarine.GetType(), _submarineInput},
            };
        }
        public InputAbstractAttack AttackForm(AbstractVessel vessel)
        {
            return this._attackForms[vessel.GetType()];
        }
    }
}