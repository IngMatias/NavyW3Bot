using System.Collections.Generic;

namespace Library
{
    public class Game : IRound
    {
        private List<AbstractTable> _players;
        public Game()
        {
            this._players = new List<AbstractTable> ();
        }
        public void AddPlayer(AbstractTable player)
        {
            this._players.Add(player);
        }
        private List<AbstractTable> Enemies(AbstractTable enemiesOf)
        {
            List<AbstractTable> toReturn = new List<AbstractTable> ();
            foreach (AbstractTable player in this._players)
            {
                if (player != enemiesOf)
                {
                    toReturn.Add(player);
                }
            }
            return toReturn;
        }
        public AbstractTable Execute(IPrinter clientP, IReader clientR)
        {
            // Dependencias.
            IPhase vesselsPositioningPhase = new VesselsPositioningPhase();
            IPhase itemPositioningPhase = new ItemPositioningPhase();
            IPhase playerPhase = new AttackPhase();
            IPhase eventPhase = new EventPhase();
            
            // Se distribuyen los barcos.
            foreach (AbstractTable player in this._players)
            {
                vesselsPositioningPhase.Execute(player, null, clientP, clientR);
            }

            // Se distribuyen los items.
            foreach (AbstractTable player in this._players)
            {
                itemPositioningPhase.Execute(player, null, clientP, clientR);
            }
            
            // Se juega la partida.
            while (this._players.Count > 1)
            {
                foreach (AbstractTable player in this._players)
                {
                    playerPhase.Execute(player, this.Enemies(player), clientP, clientR);
                    foreach (AbstractTable enemy in this.Enemies(player))
                    {
                        if (enemy.IsEmpty())
                        {
                            this._players.Remove(enemy);
                        }
                    }
                }

                // Ejecucion del evento.
                eventPhase.Execute(null, this._players, clientP, clientR);
            }

            return this._players[0];
        }

    }
}