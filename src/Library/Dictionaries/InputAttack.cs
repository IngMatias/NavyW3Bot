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