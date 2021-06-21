using System.Collections.Generic;
using System;

namespace Library
{
    public class Godzilla : IEvent
    {
        public void DoEvent(List<AbstractTable> participants)
        {
            Random random = new Random();
            int radio = 3;
            int lengthX = participants[0].XLength();
            int lengthY = participants[0].YLength();
            int randomX = random.Next(radio, lengthX - radio);
            int randomY = random.Next(radio, lengthY - radio);

            List<AbstractVessel> vesselsToAttack = new List<AbstractVessel> ();

            foreach (Table table in participants)
            {
                for (int y = randomY - radio; y <= randomY + radio; y++)
                {
                    for (int x = randomX - radio; x <= randomX + radio; x++)
                    {
                        if (table.IsAVessel(x,y) && vesselsToAttack.IndexOf(table.GetVessel((x,y))) == -1)
                        {
                            vesselsToAttack.Add(table.GetVessel((x,y)));
                        }
                    }
                }
            }
            AbstractAttacker godzilla = new GodzillaAttack();
            foreach (AbstractVessel vessel in vesselsToAttack)
            {
                vessel.ReceiveAttack(null, godzilla);
            }
        }
    }
}