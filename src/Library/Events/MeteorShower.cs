using System.Collections.Generic;
using System;

// S - SRP: Esta clase tiene como encargo realizar el evento MeteorShower.

// O - OCP: Se cumple con el principio ya que se puede agregar otro evento implementando la interfaz IEvent.

// L - LSP: Esta clase es un subtipo de IEvent.

// I - ISP: No aplica.

// D - DIP: MeteorShower depende de AbstractTable y AbstractAttacker ambas son abstracciones 
//          por lo tanto cumple con DIP.

// Expert: No aplica.

// Polymorphism: La operacion DoEvent es polimorfica a todos los IEvent.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

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