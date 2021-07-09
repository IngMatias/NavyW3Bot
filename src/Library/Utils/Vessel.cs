using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class Vessel
    {
        private List<AbstractVessel> _vessels;
        public Vessel()
        {
            this._vessels = new List<AbstractVessel> 
            {
                new Battleship(),
                // new Frigate(),
                new HeavyCruiser(),
                // new LightCruiser(),
                // new Puntoon(),
                new Submarine(),
            };
        }
        public AbstractVessel Next(ReadOnlyCollection<AbstractVessel> alreadyAdd)
        {
            bool added = false;
            foreach (AbstractVessel vesselToAdd in _vessels)
            {
                added = false;
                foreach (AbstractVessel vesselAdded in alreadyAdd)
                {
                    if (vesselToAdd.GetType().Equals(vesselAdded.GetType()))
                    {
                        added = true;
                    }
                }
                if (!added)
                {
                    return vesselToAdd;
                }
            }
            return null;
        }
    }
}