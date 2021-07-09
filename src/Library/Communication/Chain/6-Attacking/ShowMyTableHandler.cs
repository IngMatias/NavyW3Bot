namespace Library
{
    public class ShowMyTableHandler : AbstractHandler
    {
        // EmoticTable
        public ShowMyTableHandler()
        : base(new NullHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if(command == ("show") && player.IsAttacking())
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