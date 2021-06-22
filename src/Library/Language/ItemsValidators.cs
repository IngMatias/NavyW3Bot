using System.Collections.Generic;

namespace Library
{
    public class ItemsValidators
    {
        public Dictionary<System.Type, IItemValidator> ItemValidator;
        public ItemsValidators()
        {
            this.ItemValidator = new Dictionary<System.Type, IItemValidator>
            {
                {new AntiaircraftMissile().GetType(), new AntiaircraftMissileValidator() },
                {new Armor().GetType(), new ArmorValidator() },
                {new Hackers().GetType(), new HackersValidator() },
                {new Kong().GetType(), new KongValidator() },
                {new SateliteLock().GetType(), new SateliteLockValidator() },
            };
        }
        public IItemValidator ValidatorOf(IItem item)
        {
            return this.ItemValidator[item.GetType()];
        }
    }
}