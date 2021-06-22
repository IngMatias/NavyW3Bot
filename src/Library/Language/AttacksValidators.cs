using System.Collections.Generic;

namespace Library
{
    public class AttacksValidators
    {
        public Dictionary<System.Type, IAttackValidator> AttackValidator;
        public AttacksValidators()
        {
            this.AttackValidator = new Dictionary<System.Type, IAttackValidator>
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
            return this.AttackValidator[item.GetType()];
        }
    }
}