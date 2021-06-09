using System;
using System.Collections.Generic;

    // S - SRP: Esta clase se encarga de la responsabilidad de accionar sobre el tablero de la manera
    // que lo haria una Lluvia de meteoros ejerciendo el daño correspondiente.
    // Ademas conoce la cantidad de meteoros por tablero que deben ser lanzados, lo que ayuda si se
    // desea realizar una actualizacion para nivelar el juego.

    // O - OCP: Se piensa la jerarquia EventList - IEvent - Evento para permitir el agregado de nuevos
    // eventos sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: MeteorShower puede ser intercambiado por cualquier otro evento y puede recibir los mismos
    // mensajes, sin embargo se comporta de distinta manera, naturalmente.
    // Se revisa cuidadosamente no generar efectos colaterales.

    // I - ISP: MeteorShower no respeta ISP, no hace uso de todas las operaciones de Table.
    
    // D - DIP: MeteorShower depende de Table, que no es una abstraccion, no se cumple DIP.

    // Expert : Esta clase conoce la cantidad de meteoros por tablero que deben ser lanzados, por eso
    // se le adjudica el comportamiento de lanzarlos a todos los tableros.

    // Polimorfismo : El metodo DoEvent es polimorfico en todos los IEvents.

    // Creator : No se usa Creator.

namespace Library
{
    public class MeteorShower : IEvent
    {
        private int times = 10;
        public void DoEvent(List<Table> participants)
        {
            Random random = new Random();
            foreach (Table table in participants)
            {
                for (int i = 0; i < this.times; i++)
                {
                    AbstractAttacker meteor = new MeteorAttack();
                    table.RandomAttack(meteor);
                }
            }
        }
    }
}