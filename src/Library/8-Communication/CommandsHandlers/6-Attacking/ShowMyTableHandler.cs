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
            if(command == ("show") && player.Phase is AttackPhase)
            {
                player.SendMessage(player.ToEmojiTable());
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}