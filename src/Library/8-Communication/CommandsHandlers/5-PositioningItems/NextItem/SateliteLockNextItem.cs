using System;
using System.Collections.ObjectModel;

namespace Library
{
    public class SateliteLockNextItem : AbstractNextItem
    {
        public SateliteLockNextItem()
        :base(new NullNextItem())
        {
        }
        public override IItem NextItem(int random)
        {
            if (random == 4)
            {
                return new AntiaircraftMissile();
            }
            else
            {
                return this.SendNext(random);
            }
        }
    }
}