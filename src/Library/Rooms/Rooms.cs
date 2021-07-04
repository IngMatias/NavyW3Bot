using System.Collections.Generic;

namespace Library
{
    public class Rooms
    {
        private Dictionary<int,Room> _rooms;
        private int _id = 0; 
        private static Rooms _instance;

        public int AddSession()
        {
            Room newSession = new Room(this._id);
            this._rooms.Add(this._id, newSession);
            this._id += 1;
            return this._id -1;
        }
        public Room GetSession(int id)
        {
            return this._rooms[id];
        }
        public void AddPlayer(Player newPlayer, int id)
        {
            this._rooms[id].AddPlayer(newPlayer);
        }
        public static Rooms Instance()
        {
            if (_instance == null)
            {
                _instance = new Rooms();
            }
            return _instance;
        }
    }
}