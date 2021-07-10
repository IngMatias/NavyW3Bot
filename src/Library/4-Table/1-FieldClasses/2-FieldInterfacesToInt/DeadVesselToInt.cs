namespace Library
{
    public class DeadVesselToInt : AbstractFieldInterfaceToInt
    {
        public DeadVesselToInt()
        :base(new LivedVesselToInt())
        {
        }

        public override int Convert(IField field)
        {
            if (field is IDeadVessel)
            {
                return 2;
            }
            else
            {
                return this.SendNext(field);
            }
        }
    }
}