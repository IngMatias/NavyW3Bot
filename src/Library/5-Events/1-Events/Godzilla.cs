using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace Library
{
    public class Godzilla : IEvent
    {
        public void DoEvent(ReadOnlyCollection<AbstractPlayer> participants)
        {
            if (participants.Count > 0)
            {
                Random random = new Random();
                int radio = 3;
                int lengthX = participants[0].XLength();
                int lengthY = participants[0].YLength();
                int randomX = random.Next(radio, lengthX - radio);
                int randomY = random.Next(radio, lengthY - radio);
                AbstractAttacker gozilla = new GodzillaAttack();

                List<(int, int)> attackedVessels = new List<(int, int)>();

                foreach (AbstractPlayer participant in participants)
                {
                    for (int y = randomY - radio; y <= randomY + radio; y++)
                    {
                        for (int x = randomX - radio; x <= randomX + radio; x++)
                        {
                            if (attackedVessels.IndexOf((x, y)) == -1)
                            {
                                
                                attackedVessels.AddRange(participant.DestroyAttack(gozilla));
                            }
                            if (!(participant.Table.IsOrWasAVessel(x,y)))
                            {
                                participant.AttackAt(x,y,gozilla);
                            }
                        }
                    }
                }
            }
        }
    }
}