using System.Collections.Generic;

namespace Library
{
    public class AttacksValidators
    {
        private Dictionary<System.Type, IAttackValidator> _attackValidator;
        public AttacksValidators()
        {
            this._attackValidator = new Dictionary<System.Type, IAttackValidator>
            {
                {new AntiaircraftMissile().GetType(), new AntiaircraftMissileAttackValidator() },
                {new Armor().GetType(), new ArmorAttackValidator() },
                {new Hackers().GetType(), new HackersAttackValidator() },
                {new Kong().GetType(), new KongAttackValidator() },
                {new SateliteLock().GetType(), new SateliteLockAttackValidator() },
            };
        }
        public IAttackValidator ValidatorOf(IItem item)
        {
            return this._attackValidator[item.GetType()];
        }
    }
}