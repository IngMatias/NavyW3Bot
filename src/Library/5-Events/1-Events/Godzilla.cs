
// S -  SRP: Esta clase tiene como responsabilidad realizar un evento.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IEvent pero no se
//      modifica el codigo existente para agregar un evento.

// L -  LSP: Esta clase es un subtipo de IEvent.

// I -  ISP: No se utiliza.

// D -  DIP: Godzilla depende de AbstractTable, una abstraccion, y GodzillaAttack que no es una.

//      Expert: No aplica.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: Esta clase usa al patron para crear instancias de GodzillaAttack, ya que las usa de manera cercana.

using System.Collections.Generic;
using System;

namespace Library
{
    public class Godzilla : IEvent
    {
        public void DoEvent(List<AbstractTable> participants)
        {
            if (participants.Count > 0)
            {
                Random random = new Random();
                int radio = 3;
                int lengthX = participants[0].XLength();
                int lengthY = participants[0].YLength();
                int randomX = random.Next(radio, lengthX - radio);
                int randomY = random.Next(radio, lengthY - radio);

                List<(int, int)> attackedVessels = new List<(int, int)>();

                foreach (Table table in participants)
                {
                    for (int y = randomY - radio; y <= randomY + radio; y++)
                    {
                        for (int x = randomX - radio; x <= randomX + radio; x++)
                        {
                            if (table.IsAVessel(x, y) && attackedVessels.IndexOf(table.GetLeftUp(x, y)) == -1)
                            {
                                attackedVessels.Add(table.GetLeftUp(x, y));

                                AbstractAttacker gozilla = new GodzillaAttack();
                                gozilla.X = table.GetLeftUp(x, y).Item1;
                                gozilla.Y = table.GetLeftUp(x, y).Item2;

                                table.DestroyAttack(gozilla);
                            }
                            if (!(table.IsOrWasAVessel(x, y)))
                            {
                                table.AttackAt(x,y,new GodzillaAttack());
                            }
                        }
                    }
                }
            }
        }
    }
}