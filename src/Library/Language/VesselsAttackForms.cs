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
                new List<string> {"Lang-Lanzar Misil"},
                new List<string> {"Lang-Lanzar Misil"},
                new List<string> {"Lang-Lanzar Misil"},
                new List<string> {"Lang-Lanzar Misil"},
                new List<string> {"Lang-Lanzar Misil", "Lang-Lanzar Carga"},
                new List<string> {},
                new List<string> {"Lang-Lanzar Misil", "Lang-Lanzar Carga"},
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