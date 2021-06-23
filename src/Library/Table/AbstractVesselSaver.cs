using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Library
{
    public abstract class AbstractVesselSaver
    {
        protected Dictionary<(int, int), AbstractVessel> vessels;
        public ReadOnlyCollection<AbstractVessel> GetVessels()
        {
            return this.vessels.Values.ToList<AbstractVessel>().AsReadOnly();
        }
        public AbstractVessel GetVessel((int, int) key)
        {
            return this.vessels[key];
        }
        protected AbstractVesselSaver()
        {
            this.vessels = new Dictionary<(int, int), AbstractVessel>();
        }
        protected bool AddVessel(int up, int left, AbstractVessel vessel)
        {
            this.vessels.Add((up, left), vessel);
            return true;
        }
        protected bool RemoveVessel((int, int) key)
        {
            this.vessels.Remove(key);
            return true;
        }
    }
}