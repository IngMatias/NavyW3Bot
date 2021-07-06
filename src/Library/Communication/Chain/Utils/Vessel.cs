using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class Vessel
    {
        private Vessel()
        {
        }
        private static List<AbstractVessel> _vessels = new List<AbstractVessel> 
        {
            new Battleship(),
            new Frigate(),
            /*new HeavyCruiser(),
            new LightCruiser(),
            new Puntoon(),
            new Submarine(),*/
        };
        public static AbstractVessel Next(ReadOnlyCollection<AbstractVessel> alreadyAdd)
        {
            foreach (AbstractVessel vessel in _vessels)
            {
                if (alreadyAdd.IndexOf(vessel) == -1)
                {
                    return vessel;
                }
            }
            return null;
        }
    }
}