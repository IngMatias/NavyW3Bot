using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractRoom : AbstractPlayerManager
    {
        private AbstractPlayer _playing;
        public AbstractPlayer Playing {get; private set;}
        protected AbstractRoom(AbstractPlayer host, int id)
        :base(host, id)
        {
            this._playing = null;
        }
        public void StartGame()
        {
            this.Start();
            this.Playing = this.GetNext(null);
            this.NextStateAll();
        }
        public void NextAttack()
        {
            try
            {
                this.Playing = this.GetNext(this._playing);
            }
            catch(EventException)
            {
                Console.WriteLine("Debio haber ocurrido un evento.");
            }
        }
        public bool IsPlaying(AbstractPlayer maybePlaying)
        {
            return maybePlaying == this._playing;
        }
    }
}