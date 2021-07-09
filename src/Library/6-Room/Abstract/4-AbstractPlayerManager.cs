using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractPlayerManager : AbstractRoomStateManager
    {
        protected List<AbstractPlayer> _players;
        protected AbstractPlayerManager(AbstractPlayer host, int id)
        : base(host, id)
        {
            this._players = new List<AbstractPlayer>();
            this._players.Add(host);
        }
        public void AddPlayer(AbstractPlayer newPlayer)
        {
            if (!this.IsStarted())
            {
                this._players.Add(newPlayer);
            }
        }
        protected AbstractPlayer GetNext(AbstractPlayer player)
        {
            if (player == null)
            {
                return this._players[0];
            }

            int nextPlayer = this._players.IndexOf(player) + 1;

            if (nextPlayer != (nextPlayer % this._players.Count))
            {
            }

            return this._players[nextPlayer];
        }
        protected AbstractPlayer GetPlayerByName(string maybeName)
        {
            foreach (AbstractPlayer player in this._players)
            {
                if(player.Name.ToLower().Equals(maybeName))
                {
                    return player;
                }
            }
            return null;
        }
        public string TableOf(string name)
        {
            return this.GetPlayerByName(name).ToEmojiTable();
        }
        public bool IsAPLayer(string name)
        {
            return this.GetPlayerByName(name) != null;
        }
        public void AttackByNameWithOneMissile(AbstractPlayer playing, string name, int vessel, int x, int y)
        {
            this.GetPlayerByName(name).ReciveOneMissile(playing.GetListOfVessels()[vessel],x,y);
        }
        public void AttackByNameWithLoad(AbstractPlayer playing, string name, int vessel, int x, int y)
        {
            this.GetPlayerByName(name).ReciveLoad(playing.GetListOfVessels()[vessel],x,y);
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