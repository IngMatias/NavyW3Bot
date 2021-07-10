
// S -  SRP: Esta clase tiene como responsabilidad realizar un evento.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IEvent pero no se
//      modifica el codigo existente para agregar un evento.

// L -  LSP: Esta clase es un subtipo de IEvent.

// I -  ISP: No se utiliza.

// D -  DIP: Hurricane depende de AbstractTable, una abstraccion, y HurricaneAttack que no es una.

//      Expert: No aplica.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: Esta clase usa al patron para crear instancias de HurricaneAttack, ya que las usa de manera cercana.

using System.Collections.Generic;
using System;

namespace Library
{
    public class Hurricane : IEvent
    {
        public void DoEvent(List<AbstractTable> participants)
        {
            if (participants.Count > 0)
            {
                // Dependencias.
                AbstractAttacker hurricane = new HurricaneAttack();

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
                        table.AttackAt(randomX, y, hurricane);
                    }
                    for (int x = 0; x < lengthX; x++)
                    {
                        table.AttackAt(x, randomY, hurricane);
                    }
                }
            }
        }
    }
}