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
    }
}