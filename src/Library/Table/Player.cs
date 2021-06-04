using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class Player
    {
        private List<AbstractVessels> vessels;
        public ReadOnlyCollection<AbstractVessels> Vessels
        {
            get
            {
                return this.vessels.AsReadOnly();
            }
        }

    }
}
