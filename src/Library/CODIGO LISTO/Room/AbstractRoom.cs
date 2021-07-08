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
        }
        public void StartGame()
        {
            this.Start();
            this._playing = this.GetNext(null);
            this.NextStateAll();
        }
        public void NextAttack()
        {
            this._playing = this.GetNext(this._playing);
        }
    }
}