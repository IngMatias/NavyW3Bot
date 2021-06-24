using System;
using System.Collections.Generic;

namespace Library
{
    public class EventPhase : IPhase
    {
        private List<IEvent> _events = new List<IEvent> 
        {
            new Godzilla(),
            new Hurricane(),
            new MeteorShower(),
            new Volcano(),
        };
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            // Dependencias.
            EventsToString eventsName = new EventsToString();

            Random random = new Random();
            int rnd = random.Next(0, 15);
            foreach (AbstractTable table in enemies)
            {
                if (0 <= rnd && rnd <= this._events.Count)
                {
                    this._events[rnd].DoEvent(enemies);
                }
            }
            return new List<int>();
        }
    }
}