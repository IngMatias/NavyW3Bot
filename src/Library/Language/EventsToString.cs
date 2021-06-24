using System.Collections.Generic;

namespace Library
{
    public class EventsToString
    {
        private Dictionary<System.Type, string> _eventsName;
        public EventsToString()
        {
            List<string> names = new List<string>
            {
                "Lang-Godzilla",
                "Lang-Hurricane",
                "Lang-MeteorShower",
                "Lang-Volcano",
            };
            this._eventsName = new Dictionary<System.Type, string>
            {
                {new Godzilla().GetType(), names[0]},
                {new Hurricane().GetType(), names[1]},
                {new MeteorShower().GetType(), names[2]},
                {new Volcano().GetType(), names[3]},
            };
        }
        public string NameOf(IEvent catastrophe)
        {
            return this._eventsName[catastrophe.GetType()];
        }
    }
}