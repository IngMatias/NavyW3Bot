namespace Library
{
    public class LivedVesselToEmoji : AbstractFieldInterfaceToEmoji
    {
        public LivedVesselToEmoji()
        :base(new LiveHiddenVesselToEmoji())
        {
        }

        public override string Convert(IField field)
        {
            if (field is ILivedVessel)
            {
                return "\U0001F198";
            }
            else
            {
                return this.SendNext(field);
            }
        }
    }
}