using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractAttackerVessel : AbstractStateManager
    {
        public AbstractAttackerVessel(int size, int health)
        : base(size, health)
        {
            
        }
        public abstract List<string> AttackForms();
        public abstract void Attack0(AbstractTable table, IPrinter clientP, IReader clientR);
        public abstract void Attack1(AbstractTable table, IPrinter clientP, IReader clientR);

    }
}