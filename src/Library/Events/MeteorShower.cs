
// S -  SRP: Esta clase tiene como responsabilidad realizar un evento.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IEvent pero no se
//      modifica el codigo existente para agregar un evento.

// L -  LSP: Esta clase es un subtipo de IEvent.

// I -  ISP: No se utiliza.

// D -  DIP: MeteorShower depende de AbstractTable, una abstraccion, y MeteorAttack que no es una.

//      Expert: Esta clase conoce la cantidad de meteoros que debe lanzar, por lo tanto se encarga de lanzarlos.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: Esta clase usa al patron para crear instancias de MeteorAttack, ya que las usa de manera cercana.

using System.Collections.Generic;
using System;

namespace Library
{
    public class MeteorShower : IEvent
    {
        private int _times = 10;
        public void DoEvent(List<AbstractTable> participants)
        {
            // Dependencias.
            AbstractAttacker meteor = new MeteorAttack();

            Random random = new Random();
            foreach (Table table in participants)
            {
                for (int i = 0; i < this._times; i++)
                {
                    table.RandomAttack(meteor);
                }
            }
        }
    }
}