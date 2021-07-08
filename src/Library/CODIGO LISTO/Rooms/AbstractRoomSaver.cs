using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractRoomSaver : AbstractIdGetter
    {
        private Dictionary<int, Room> _rooms;
        protected AbstractRoomSaver()
        {
            this._rooms = new Dictionary<int, Room>();
        }
        public int Count()
        {
            return this._rooms.Count;
        }
        public int AddSession(AbstractPlayer newPlayer)
        {
            int newId = AbstractIdGetter.Id;
            this._rooms.Add(newId, new Room(newPlayer, newId));
            return newId;
        }
        protected Room GetRoomById(int id)
        {
            return this._rooms[id];
        }
        public void SendAllById(string message, int id)
        {
            this.GetRoomById(id).SendAll(message);
        }
        protected Room GetRoomByHost(AbstractPlayer maybeHost)
        {
            foreach (Room room in this._rooms.Values)
            {
                if (room.IsHost(maybeHost))
                {
                    return room;
                }
            }
            return null;
        }
        public void SendAllByHost(string message, AbstractPlayer host)
        {
            this.GetRoomByHost(host).SendAll(message);
        }
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
        protected Room GetRoomByPlaying(AbstractPlayer maybePlaying)
        {
            foreach (Room room in this._rooms.Values)
            {
                if (room.IsPlaying(maybePlaying))
                {
                    return room;
                }
            }
            return null;
        }
        public void ShowTableOf(AbstractPlayer player, string name)
        {
            Room room = this.GetRoomByPlaying(player);
            room.SendAll(room.TableOf(name));
        }
        public bool IsPlayingWith(AbstractPlayer player, string partner)
        {
            AbstractRoom find = GetRoomByPlaying(player);
            if (find!=null && find.IsAPLayer(partner))
            {
                return true;
            }
            return false;
        }
        public bool IsPlaying(AbstractPlayer player)
        {
            return this.GetRoomByPlaying(player) != null;
        }
        public void AttackByPlaying(AbstractPlayer player, string name, int vessel, int x, int y)
        {
            this.GetRoomByPlaying(player).AttackByName(player, name, vessel, x, y);
        }
        public void SendAllByPlaying(AbstractPlayer player, string message)
        {
            this.GetRoomByPlaying(player).SendAll(message);
        }
        public void NextAttackByPlaying(AbstractPlayer player)
        {
            this.GetRoomByPlaying(player).NextAttack();
        }
        public void AddPlayer(AbstractPlayer newPlayer, int id)
        {
            this._rooms[id].AddPlayer(newPlayer);
        }
    }
}