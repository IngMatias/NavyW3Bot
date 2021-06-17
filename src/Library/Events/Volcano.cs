using System.Collections.Generic;
using System;

namespace Library
{
    public class Volcano : IEvent
    {
        public Volcano()
        {

        }
        public void DoEvent(List<ITable> participants)
        {
            Random random = new Random();
            int radio = 2;
            int lengthX = participants[0].XLength();
            int lengthY = participants[0].YLength();
            int randomX = random.Next(radio, lengthX - radio);
            int randomY = random.Next(radio, lengthY - radio);
            foreach (Table table in participants)
            {
                for (int y = randomY - radio; y <= randomY + radio; y++)
                {
                    for (int x = randomX - radio; x <= randomX + radio; x++)
                    {
                        AbstractAttacker lava = new LavaAttack();
                        table.AttackAt(x, y, lava);
                    }
                }
            }
        }
    }
}