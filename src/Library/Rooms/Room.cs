using System;
using System.Collections.Generic;

namespace Library
{
    public class Room
    {
        private List<AbstractPlayer> _players;
        private AbstractPlayer _playing;
        private AbstractPlayer _host;
        public AbstractPlayer Host
        {
            get
            {
                return this._host;
            }
        }
        private int _id;
        private bool _isStarted;
        public Room(int id, AbstractPlayer host)
        {
            this._host = host;
            this._players = new List<AbstractPlayer> ();
            this._players.Add(host);
            
            this._id = id;
            this._isStarted = false;
        }
        public void AddPlayer(AbstractPlayer newPlayer)
        {
            this._players.Add(newPlayer);
        }
        public void StartGame()
        {
            this._isStarted = true;
            this._playing = this._players[0];

            foreach(AbstractPlayer player in this._players)
            {
                player.NextState();
            }
            this.SendAll("Ha comenzado el juego.");

        }
        public void SendAll(string message)
        {
            foreach(AbstractPlayer player in this._players)
            {
                player.SendMessage(message);
            }
        }
        public void NextAttack()
        {
            int playingInt = this._players.IndexOf(this._playing);
            int nextPlaying = (playingInt + 1) % this._players.Count;
            if (playingInt + 1 != nextPlaying)
            {
                Console.WriteLine("Evento");
            }
        }
    }
}