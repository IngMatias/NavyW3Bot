using System;
using System.Collections.Generic;

    // S - SRP: Esta clase se encarga de la responsabilidad de accionar sobre el tablero de la manera
    // que lo haria Godzilla ejerciendo el daño correspondiente.

    // O - OCP: Se piensa la jerarquia EventList - IEvent - Evento para permitir el agregado de nuevos
    // eventos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: Godzilla puede ser intercambiado por cualquier otro evento y puede recibir los mismos
    // mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: Godzilla no respeta ISP, no hace uso de todas las operaciones de Table.

    // D - DIP: Godzilla depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo DoEvent es polimorfico en todos los IEvents.

    // Creator : Se usa Creator cuando se crea GodzillaAttack porque se usa de manera cercana.

namespace Library
{
    public class Godzilla : IEvent
    {
        // Se obvserva poder generalizar este codigo como una explocion cuadrada de radio r = 3.
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