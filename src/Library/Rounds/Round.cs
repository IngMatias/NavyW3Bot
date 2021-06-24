using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        private List<AbstractTable> _players;
        public List<AbstractTable> Players
        {
            get
            {
                List<AbstractTable> copy = new List<AbstractTable>();
                foreach (AbstractTable player in this._players)
                {
                    copy.Add(player);
                }
                return copy;
            }
        }
        public Round()
        {
            this._players = new List<AbstractTable>();
        }
        public void AddPlayer(AbstractTable player)
        {
            this._players.Add(player);
        }
        public void RemovePlayer(AbstractTable player)
        {
            this._players.Remove(player);
        }

        public void DoRound(IPrinter clientP, IReader clientR)
        {
            IPhase attack = new AttackPhase();
            IPhase item   = new ItemPositioningPhase();
            IPhase vessels= new VasselsPositioningPhase();

            foreach (AbstractTable player in _players)
            {
                vessels.Execute(player,null,clientP,clientR);
            }

            bool someoneIsAlive = true;
            while(!(someoneIsAlive))
            {
                foreach (AbstractTable player in _players)
                {
                    List<AbstractTable> enemies = new List<AbstractTable>{};
                    foreach (AbstractTable enemie in _players)
                    {
                        if (player != enemie)
                        {
                            enemies.Add(enemie);
                        }
                    }

                    item.Execute(player,null,clientP,clientR);
                    attack.Execute(player,enemies,clientP,clientR);
                }
                foreach (AbstractTable player in _players)
                {
                    if (player.IsEmpty())
                    {
                        this.RemovePlayer(player);
                    }
                }

                if (_players.Count < 2)
                {
                    someoneIsAlive = false;
                }
            }
            // Falta desarrollar
            clientP.Print("El ganador es: "+ _players[0].StringTable());
        }
    }
}
