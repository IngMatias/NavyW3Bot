namespace Library
{
    public class LivedVesselToInt : AbstractFieldInterfaceToInt
    {
        public LivedVesselToInt()
        :base(new LiveHiddenVesselToInt())
        {
        }

        public override int Convert(IField field)
        {
            if (field is ILivedVessel)
            {
                return 3;
            }
            else
            {
                return this.SendNext(field);
            }
        }
    }
}