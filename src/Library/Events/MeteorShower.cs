using System.Collections.Generic;
using System;

namespace Library
{
    public class MeteorShower : IEvent
    {
        private int times = 10;
        public void DoEvent(List<ITable> participants)
        {
            Random random = new Random();
            foreach (Table table in participants)
            {
                for (int i = 0; i < this.times; i++)
                {
                    AbstractAttacker meteor = new MeteorAttack();
                    table.RandomAttack(meteor);
                }
            }
        }
    }
}