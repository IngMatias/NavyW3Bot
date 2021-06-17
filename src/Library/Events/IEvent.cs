using System.Collections.Generic;

namespace Library
{
    public interface IEvent
    {
        public void DoEvent(List<AbstractTable> participants);
    }
}