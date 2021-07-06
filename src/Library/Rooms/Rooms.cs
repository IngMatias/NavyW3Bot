using System.Collections.Generic;

namespace Library
{
    public class Rooms
    {
        private Dictionary<int,Room> _rooms;
        private int _id = 0; 
        private static Rooms _instance;
        public static Rooms Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Rooms();
                }
                return _instance;
            }
        }
        private Rooms()
        {
            this._rooms = new Dictionary<int, Room> ();
        }
        public int AddSession(AbstractPlayer newPlayer)
        {
            Room newSession = new Room(this._id, newPlayer);
            this._rooms.Add(this._id, newSession);
            this._id += 1;
            return this._id -1;
        }
        public Room GetRoom(int id)
        {
            return this._rooms[id];
        }
        public Room GetRoomByHost(AbstractPlayer maybeHost)
        {
            foreach(Room room in this._rooms.Values)
            {
                if (room.Host == maybeHost)
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