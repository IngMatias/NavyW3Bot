using System.Collections.Generic;

namespace Library
{
    public class EventList
    {
        private List<IEvent> events;
        public IEvent RandomEvent()
        {
            return new Godzilla();
        }
    }
}

