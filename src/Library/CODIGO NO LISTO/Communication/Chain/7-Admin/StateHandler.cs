using System;

namespace Library
{
    public class StateHandler : AbstractHandler
    {
        public StateHandler()
        :base(new NullHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.StartsWith("state"))
            {
                Console.WriteLine(player.State);
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}