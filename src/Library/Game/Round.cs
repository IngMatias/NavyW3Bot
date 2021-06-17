using System;
using System.Collections.Generic;

namespace Library
{
    public class Round
    {
        private List<AbstractTable> players;
        public List<AbstractTable> Players
        {
            get
            {
                List<AbstractTable> copy = new List<AbstractTable>();
                foreach (AbstractTable player in this.players)
                {
                    copy.Add(player);
                }
                return copy;
            }
        }
        public Round()
        {
            this.players = new List<AbstractTable>();
        }
        public void AddPlayer(AbstractTable player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(AbstractTable player)
        {
            this.players.Remove(player);
        }

        public void MaikingGame(IPrinter clientP, IReader clientR)
        {
            // Proximamente debe ser alterado por multijugador.
            foreach (AbstractTable table in this.players)
            {
                // VesselList vessels = new VesselList();
                /*foreach (AbstractVessels vessel in vessels.Vessels)
                {
                    int x = Int32.Parse(clientR.Read()) -1 ;
                    int y = Int32.Parse(clientR.Read()) -1 ;
                    int orientation = Int32.Parse(clientR.Read()) -1 ;
                    table.AddVessel(x,y,vessel,orientation == 0);
                }
                Console.WriteLine(table.StringTable());*/
            }
        }

        public void DoRound(IPrinter clientP, IReader clientR)
        {
            IPhase phase = new PlayerPhase();
            IPhase computerPhase = new ComputerPhase();

            foreach (AbstractTable player in players)
            {
                List<AbstractTable> aux = this.Players;
                aux.Remove(player);
                phase.Execute(player, aux, clientP, clientR);
            }
            computerPhase.Execute(null, this.players, clientP, clientR);
        }
    }
}