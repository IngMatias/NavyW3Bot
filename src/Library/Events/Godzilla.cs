using System.Collections.Generic;
using System;

namespace Library
{
    public class Godzilla : IEvent
    {
        public void DoEvent(List<ITable> participants)
        {
            Random random = new Random();
            int radio = 3;
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
                        AbstractAttacker godzilla = new GodzillaAttack();
                        table.AttackAt(x, y, godzilla);
                    }
                }
            }
        }
    }
}