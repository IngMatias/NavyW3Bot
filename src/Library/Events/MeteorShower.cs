using System;
using System.Collections.Generic;

namespace Library
{
    public class MeteorShower : IEvent
    {
        private int times = 10;
        public void DoEvent(List<Table> participants)
        {
            Random random = new Random();
            foreach (Table table in participants)
            {
                for (int i = 0; i < this.times; i++)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        table.RandomMissile();
                    }
                    else
                    {
                        table.RandomLoad();
                    }
                }
            }
        }
    }
}