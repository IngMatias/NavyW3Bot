using System.Collections.Generic;
using System;

namespace Library
{
    public class MeteorShower : IEvent
    {
        private int _times = 10;
        public void DoEvent(List<AbstractTable> participants)
        {
            // Dependencias.
            AbstractAttacker meteor = new MeteorAttack();
            
            Random random = new Random();
            foreach (Table table in participants)
            {
                for (int i = 0; i < this._times; i++)
                {
                    table.RandomAttack(meteor);
                }
            }
        }
    }
}