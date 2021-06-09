using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class VesselList
    {
        private List<AbstractVessels> vessels;
        public ReadOnlyCollection<AbstractVessels> Vessels
        {
            get
            {
                return vessels.AsReadOnly();
            }
        }
    }
}