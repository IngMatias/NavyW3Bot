using System;
using System.Collections.Generic;

namespace Library
{
    public class ComputerPhase : IPhase
    {
        private List<string> eventsName = new List<string>
        {
            "Godzilla",
            "Hurricane",
            "MeteorShower",
            "Volcano",
        };
        private List<IEvent> events = new List<IEvent>
            {
                new Godzilla(),
                new Hurricane(),
                new MeteorShower(),
                new Volcano(),
            };
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            Random random = new Random();
            int rnd = random.Next(0, 15);
            foreach (AbstractTable table in enemies)
            {
                if (0 <= rnd && rnd <= this.events.Count)
                {
                    this.events[rnd].DoEvent(enemies);
                }
            }
            return new List<int>();
        }
    }
}