namespace Library
{
    public class ShowTableOfHandler : AbstractHandler
    {
        // EmoticTable
        public ShowTableOfHandler()
        : base(new StateHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command.StartsWith("show") && player.IsAttacking())
            {
                player.SendMessage(player.EmojiTable());
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}