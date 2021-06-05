using System;
using System.Collections.Generic;

namespace Library
{
    public class Volcano : IEvent
    {
        // Se obvserva poder generalizar este codigo como una explocion de radio r = 2.
        public void DoEvent(List<Table> participants)
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
                        table.RemoveVessel(x,y);
                    }
                }
            }

        }
    }
}
