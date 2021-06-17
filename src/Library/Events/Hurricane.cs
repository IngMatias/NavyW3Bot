using System.Collections.Generic;
using System;

namespace Library
{
    public class Hurricane : IEvent
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
                for (int y = 0; y < lengthY; y++)
                {
                    AbstractAttacker hurricane = new HurricaneAttack();
                    table.AttackAt(randomX, y, hurricane);
                }
                for (int x = 0; x < lengthX; x++)
                {
                    AbstractAttacker hurricane = new HurricaneAttack();
                    table.AttackAt(x, randomY, hurricane);
                }
            }
        }
    }
}