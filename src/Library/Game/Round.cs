/*using System;
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

        public void MaikingGame(IPrinter clientP, IReader clientR)
        {
            // Proximamente debe ser alterado por multijugador.
            foreach (AbstractTable table in this._players)
            {
                VesselList vessels = new VesselList();
                foreach (AbstractVessels vessel in vessels.Vessels)
                {
                    int x = Int32.Parse(clientR.Read()) -1 ;
                    int y = Int32.Parse(clientR.Read()) -1 ;
                    int orientation = Int32.Parse(clientR.Read()) -1 ;
                    table.AddVessel(x,y,vessel,orientation == 0);
                }
                Console.WriteLine(table.StringTable());
            }
        }

        public void DoRound(IPrinter clientP, IReader clientR)
        {
            IPhase phase = new PlayerPhase();
            IPhase computerPhase = new ComputerPhase();

            foreach (AbstractTable player in _players)
            {
                List<AbstractTable> aux = this.Players;
                aux.Remove(player);
                phase.Execute(player, aux, clientP, clientR);
            }
            computerPhase.Execute(null, this._players, clientP, clientR);
        }
    }
}
*/