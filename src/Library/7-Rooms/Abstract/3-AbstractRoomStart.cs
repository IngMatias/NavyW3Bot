using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractRoomStart : AbstractRoomSaver
    {        
        public bool Start(AbstractPlayer maybeHost)
        {
            AbstractRoom toStart = this.GetRoomByHost(maybeHost);
            if (toStart == null)
            {
                return false;
            }
            toStart.StartGame();
            return true;
        }
    }
}