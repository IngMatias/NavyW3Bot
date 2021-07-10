using System;
using System.Collections.ObjectModel;

namespace Library
{
    public class HackersNextItem : AbstractNextItem
    {
        public HackersNextItem()
        :base(new KongNextItem())
        {
        }
        public override IItem NextItem(int random)
        {
            if (random == 2)
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