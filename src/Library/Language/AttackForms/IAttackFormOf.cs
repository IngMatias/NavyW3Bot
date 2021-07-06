using System.Collections.Generic;

namespace Library
{
    public interface IAttackFormsOf
    {
        public List<string> AttackFormsOf(AbstractVessel vessel);
    }
}