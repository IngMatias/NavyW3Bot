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
            // Lanzar excepcion
        }
        public virtual void ThrowLoad(AbstractTable table, int x, int y)
        {
            // Lanzar excepcion
        }
        public virtual void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
        {
            // Lanzar excepcion
        }


    }
}