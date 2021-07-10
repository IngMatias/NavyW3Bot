namespace Library
{
    public class AttackedWaterToInt : AbstractFieldInterfaceToInt
    {
        public AttackedWaterToInt()
        :base(new DeadVesselToInt())
        {
        }

        public override int Convert(IField field)
        {
            if (field is IAttackedWater)
            {
                return 1;
            }
            else
            {
                return this.SendNext(field);
            }
        }
    }
}