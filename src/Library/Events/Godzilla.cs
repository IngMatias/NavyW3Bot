using System.Collections.Generic;
using System;

// S - SRP: Esta clase tiene como encargo realizar el evento Godzilla.

// O - OCP: Se cumple con el principio ya que se puede agregar otro evento implementando la interfaz IEvent.

// L - LSP: Esta clase es un subtipo de IEvent.

// I - ISP: No aplica.

// D - DIP: Godzilla depende de AbstractTable y AbstractAttacker ambas son abstracciones 
//          por lo tanto cumple con DIP.

// Expert: No aplica.

// Polymorphism: No aplica.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class Godzilla : IEvent
    {
        public void DoEvent(List<AbstractTable> participants)
        {
            // Dependencias.
            AbstractAttacker godzilla = new GodzillaAttack();
            
            Random random = new Random();
            int radio = 3;
            int lengthX = participants[0].XLength();
            int lengthY = participants[0].YLength();
            int randomX = random.Next(radio, lengthX - radio);
            int randomY = random.Next(radio, lengthY - radio);

            List<AbstractVessel> vesselsToAttack = new List<AbstractVessel>();

            foreach (Table table in participants)
            {
                for (int y = randomY - radio; y <= randomY + radio; y++)
                {
                    for (int x = randomX - radio; x <= randomX + radio; x++)
                    {
                        if (table.IsAVessel(x, y) && vesselsToAttack.IndexOf(table.GetVessel((x, y))) == -1)
                        {
                            vesselsToAttack.Add(table.GetVessel((x, y)));
                        }
                    }
                }
            }
            foreach (AbstractVessel vessel in vesselsToAttack)
            {
                vessel.ReceiveAttack(null, godzilla);
            }
        }
    }
}