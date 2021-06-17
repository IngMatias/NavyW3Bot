using System;
using System.Collections.Generic;

namespace Library
{
    public class Round
    {
        private List<ITable> players;
        public List<ITable> Players 
        { 
            get
            {
                List<ITable> copy = new List<ITable>(); 
                foreach(ITable player in this.players)
                {
                    copy.Add(player);
                }
                return copy;
            }
        }
        public Round()
        {
            this.players = new List<ITable> ();
        }
        public void AddPlayer(ITable player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(ITable player)
        {
            this.players.Remove(player);
        }

        public void MaikingGame(IPrinter clientP, IReader clientR)
        {
            // Proximamente debe ser alterado por multijugador.
            foreach (ITable table in this.players)
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

            foreach(ITable player in players)
            {
                List<ITable> aux = this.Players;
                aux.Remove(player);
                phase.Execute(player, aux, clientP, clientR);
            }
            computerPhase.Execute(null, this.players, clientP, clientR);
        }
    }
}