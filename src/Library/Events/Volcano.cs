using System.Collections.Generic;
using System;

// S - SRP: Esta clase tiene como encargo realizar el evento Volcano.

// O - OCP: Se cumple con el principio ya que se puede agregar otro evento implementando la interfaz IEvent.

// L - LSP: Esta clase es un subtipo de IEvent.

// I - ISP: No aplica.

// D - DIP: Volcano depende de AbstractTable y AbstractAttacker ambas son abstracciones 
//          por lo tanto cumple con DIP.

// Expert: No aplica.

// Polymorphism: La operacion DoEvent es polimorfica a todos los IEvent.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class Volcano : IEvent
    {
        public void DoEvent(List<AbstractTable> participants)
        {
            // Dependencias.
            AbstractAttacker lava = new LavaAttack();

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
                        table.AttackAt(x, y, lava);
                    }
                }
            }
        }
    }
}