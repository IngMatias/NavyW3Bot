using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractAttackerVessel : AbstractStateManager
    {
        public AbstractAttackerVessel(int size, int health)
        : base(size, health)
        {
        }
        public virtual void LaunchMissile(AbstractTable table, int x, int y)
        {
            throw new NotImplementedException();
        }
        public virtual void ThrowLoad(AbstractTable table, int x, int y)
        {
            throw new NotImplementedException();
        }
        public virtual void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }
    }
}