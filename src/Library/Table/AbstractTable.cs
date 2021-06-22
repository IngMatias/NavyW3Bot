using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Library
{
    public abstract class AbstractTable : AbstractAttackable
    {

        public AbstractTable(int x, int y)
        : base(x, y)
        {

        }
        public string StringTable()
        {
            StringBuilder toReturn = new StringBuilder();
            for (int j = 0; j < this.YLength(); j++)
            {
                for (int i = 0; i < this.XLength(); i++)
                {
                    toReturn.Append((int)this.At(i, j));
                }
                toReturn.Append("\n");
            }
            return toReturn.ToString();
        }

        public string StringVessels()
        {
            ItemsToString itemsName = new ItemsToString();
            VesselsToString vesselsName = new VesselsToString();
            StringBuilder toReturn = new StringBuilder();

            int vesselIndex = 1;
            int itemIndex = 1;

            foreach (AbstractVessel vessel in this.GetVessels())
            {
                toReturn.Append(vesselIndex +" "+ vesselsName.NameOf(vessel) + "\n");
                foreach (IItem item in vessel.Items)
                {
                    if (item != null)
                    {
                        toReturn.Append("    " + itemIndex + itemsName.NameOf(item) + "\n");
                    }
                    else
                    {
                        toReturn.Append("    " + itemIndex + "Vacio" + "\n");
                    }
                    itemIndex ++;
                }
                toReturn.Append("\n");
                vesselIndex ++;
            }
            return toReturn.ToString();
        }
    }
}