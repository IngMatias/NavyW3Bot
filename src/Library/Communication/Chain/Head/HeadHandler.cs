using System;

namespace Library
{
    public class HeadHandler : AbstractHandler
    {
        public HeadHandler()
        :base(new StartHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            this.SendNext(command, player);
        }
    }
}