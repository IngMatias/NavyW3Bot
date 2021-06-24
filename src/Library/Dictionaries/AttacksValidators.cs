using System.Collections.Generic;

namespace Library
{
    public class AttacksValidators
    {
        private Dictionary<System.Type, IAttackValidator> _attackValidator;

        // Vessels.
        private IItem _antiAircraft = new AntiaircraftMissile();
        private IItem _armor = new Armor();
        private IItem _hackers = new Hackers();
        private IItem _kong = new Kong();
        private IItem _sateliteLock = new SateliteLock();

        // AttackValidators.
        private IAttackValidator _antiAircraftValidator = new AntiaircraftMissileAttackValidator();
        private IAttackValidator _armorValidators = new ArmorAttackValidator();
        private IAttackValidator _hackersValidators = new HackersAttackValidator();
        private IAttackValidator _kongValidator = new KongAttackValidator();
        private IAttackValidator _sateliteLock = new SateliteLockAttackValidator();


        public AttacksValidators()
        {
            this._attackValidator = new Dictionary<System.Type, IAttackValidator>
            {
                {_antiAircraft.GetType(), _antiAircraftValidator},
                {_armor.GetType(), _armorValidators },
                {_hackers.GetType(), _hackersValidators},
                {_kong.GetType(), _kongValidator},
                {_sateliteLock.GetType(), _sateliteLock},
            };
        }
        public IAttackValidator ValidatorOf(IItem item)
        {
            return this._attackValidator[item.GetType()];
        }
    }
}