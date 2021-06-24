using System.Collections.Generic;

namespace Library
{
    public class ItemsValidators
    {
        private Dictionary<System.Type, IItemValidator> _itemValidator;
        // Vessels.
        private IItem _antiAircraft = new AntiaircraftMissile();
        private IItem _armor = new Armor();
        private IItem _hackers = new Hackers();
        private IItem _kong = new Kong();
        private IItem _sateliteLock = new SateliteLock();

        // Validators.
        private IAttackValidator _antiAircraftValidator = new AntiaircraftMissileValidator();
        private IAttackValidator _armorValidators = new ArmorValidator();
        private IAttackValidator _hackersValidators = new HackersValidator();
        private IAttackValidator _kongValidator = new KongValidator();
        private IAttackValidator _sateliteLock = new SateliteLockValidator();

        public ItemsValidators()
        {
            this._itemValidator = new Dictionary<System.Type, IItemValidator>
            {
                {_antiAircraft.GetType(), _antiAircraftValidator},
                {_armor.GetType(), _armorValidators },
                {_hackers.GetType(), _hackersValidators},
                {_kong.GetType(), _kongValidator},
                {_sateliteLock.GetType(), _sateliteLock},
            };
        }
        public IItemValidator ValidatorOf(IItem item)
        {
            return this._itemValidator[item.GetType()];
        }
    }
}