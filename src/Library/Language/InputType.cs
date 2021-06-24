using System.Collections.Generic;

namespace Library
{
    public class InputType
    {
        private Dictionary<System.Type,InputAbstractAttack> _inputForm;

        InputAbstractAttack inputBattleshipAttack = new InputBattleshipAttack();
        InputAbstractAttack inputFrigateAttack = new InputFrigateAttack();
        InputAbstractAttack inputHeavyCruiserAttack = new InputHeavyCruiserAttack();
        InputAbstractAttack inputLightCruiserAttack= new InputLightCruiserAttack();
        InputAbstractAttack inputSubmarineAttack = new InputSubmarineAttack();
        public InputType()
        {
            this._inputForm = new Dictionary<System.Type, InputAbstractAttack>
            {
                {new Battleship().GetType(), inputBattleshipAttack},
                {new Frigate().GetType(), inputFrigateAttack},
                {new HeavyCruiser().GetType(), inputHeavyCruiserAttack},
                {new LightCruiser().GetType(), inputLightCruiserAttack},
                {new Submarine().GetType(), inputSubmarineAttack},
            };
        }
        public InputAbstractAttack AttackFormsOf(AbstractVessel vessel)
        {
            return this._inputForm[vessel.GetType()];
        }
    }
}