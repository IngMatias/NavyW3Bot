using System.Collections.Generic;

namespace Library
{
    public class Room
    {
        private List<Player> _players;
        private int _id;
        private bool _isStarted;
        public Room(int id)
        {
            this._id = id;
            this._isStarted = false;
        }
        public void AddPlayer(Player newPlayer)
        {
            this._players.Add(newPlayer);
        }
        public void StartGame()
        {
            this._isStarted = true;
        }
    }
}