using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractRoom : AbstractRoomCommunicationManager
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
            this._playing = this.GetNext(this._playing);
        }
        public bool IsPlaying(AbstractPlayer maybePlaying)
        {
            return maybePlaying == this._playing;
        }
    }
}