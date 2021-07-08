using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractRoomSaver : AbstractIdGetter
    {
        private Dictionary<int,Room> _rooms;
        protected AbstractRoomSaver()
        {
            this._rooms = new Dictionary<int, Room> ();
        }
        public int AddSession(AbstractPlayer newPlayer)
        {
            int newId = AbstractIdGetter.Id;
            this._rooms.Add(newId, new Room(newPlayer, newId));
            return newId;
        }
        public Room GetRoomById(int id)
        {
            return this._rooms[id];
        }
        public Room GetRoomByHost(AbstractPlayer maybeHost)
        {
            foreach(Room room in this._rooms.Values)
            {
                if (room.IsHost(maybeHost))
                {
                    return room;
                }
            }
            return null;
        }
        public Room GetRoomByPlaying(AbstractPlayer maybePlaying)
        {
            foreach(Room room in this._rooms.Values)
            {
                if (room.Playing == maybePlaying)
                {
                    return room;
                }
            }
            return null;
        }
        public void AddPlayer(AbstractPlayer newPlayer, int id)
        {
            this._rooms[id].AddPlayer(newPlayer);
        }
    }
}