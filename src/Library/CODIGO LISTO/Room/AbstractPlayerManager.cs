using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractPlayerManager : AbstractRoomStateManager
    {
        private List<AbstractPlayer> _players;
        protected AbstractPlayerManager(AbstractPlayer host, int id)
        : base(host, id)
        {
            this._players = new List<AbstractPlayer>();
            this._players.Add(host);
        }
        public void AddPlayer(AbstractPlayer newPlayer)
        {
            if (!this.Started)
            {
                this._players.Add(newPlayer);
            }
        }
        public AbstractPlayer GetNext(AbstractPlayer player)
        {
            if (player == null)
            {
                return this._players[0];
            }

            int nextPlayer = this._players.IndexOf(player) + 1;

            if (nextPlayer != (nextPlayer % this._players.Count))
            {
                throw new EventException();
            }

            return this._players[nextPlayer];
        }
        public void NextStateAll()
        {
            foreach(AbstractPlayer player in this._players)
            {
                player.NextState();
            }
        }
        public void SendAll(string message)
        {
            foreach(AbstractPlayer player in this._players)
            {
                player.SendMessage(message);
            }
        }
    }
}