using System.Collections.Generic;
using System;

namespace Library
{
    public abstract class AbstractStateManager : AbstractItemSaver
    {
        protected int[] state;
        public IList<int> State
        {
            get
            {
                return Array.AsReadOnly(state);
            }
        }
        public AbstractStateManager(int size, int health)
        : base(size)
        {
            this.state = new int[size];
            this.InitState(health);
        }
        public void InitState(int health)
        {
            for (int i = 0; i < this.state.Length; i++)
            {
                this.state[i] = health;
            }
        }
        public bool IsAlive()
        {
            foreach (int i in State)
            {
                if (i != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool ReceiveAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            AttacksValidators validator = new AttacksValidators();

            bool avoidAttack = false;
            foreach (IItem item in this.items)
            {
                if (item != null)
                {
                    avoidAttack = validator.ValidatorOf(item).AvoidAttack(table, attack);
                    if (avoidAttack)
                    {
                        this.RemoveItem(item);
                        break;
                    }
                }
            }
            if (!avoidAttack)
            {
                this.state[attack.Position] -= 1;
                if (this.state[attack.Position] == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}