namespace Library
{
    public class ShowTableOfHandler : AbstractHandler
    {
        // EmoticTable
        public ShowTableOfHandler()
        : base(new NullHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.StartsWith("/show ") && player.IsAttacking())
            {
                player.SendMessage(player.Table);
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}