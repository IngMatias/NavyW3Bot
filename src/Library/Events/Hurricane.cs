using System;
using System.Collections.Generic;

    // S - SRP: Esta clase se encarga de la responsabilidad de accionar sobre el tablero de la manera
    // que lo haria un Huracan ejerciendo el daño correspondiente.

    // O - OCP: Se piensa la jerarquia EventList - IEvent - Evento para permitir el agregado de nuevos
    // eventos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Hurricane puede ser intercambiado por cualquier otro evento y puede recibir los mismos
    // mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: Hurricane no respeta ISP, no hace uso de todas las operaciones de Table.

    // D - DIP: Hurricane depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo DoEvent es polimorfico en todos los IEvents.

    // Creator : Se usa Creator cuando se crea HurricaneAttack porque se usa de manera cercana.

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