using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractRoom : AbstractPlayerManager
    {
        private AbstractPlayer _playing;
        protected AbstractRoom(AbstractPlayer host, int id)
        :base(host, id)
        {
            this._playing = null;
        }
        public void StartGame()
        {   if (this._players.Count >= 2)
            {
                this.Start();
                this._playing = this.GetNext(null);
                this.NextStateAll();
            }

        }
        public void NextAttack()
        {
            try
            {
                this._playing = this.GetNext(this._playing);
            }
            catch(EventException)
            {
                this._playing = this.GetNext(null);
                MeteorShower meteor = new MeteorShower();
                List<AbstractTable> toAttack = new List<AbstractTable> {};
                foreach (AbstractPlayer player in this._players)
                {
                    toAttack.Add(player._table);
                }
                meteor.DoEvent(toAttack);
                this.SendAll("Ha ocurrido un evento.");
            }
        }
        public bool IsPlaying(AbstractPlayer maybePlaying)
        {
            return maybePlaying == this._playing;
        }
    }
}