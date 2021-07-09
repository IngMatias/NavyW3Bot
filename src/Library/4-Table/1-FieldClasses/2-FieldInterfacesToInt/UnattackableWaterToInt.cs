namespace Library
{
    public class UnattackableWaterToInt : AbstractFieldInterfaceToInt
    {
        public UnattackableWaterToInt()
        :base(new NullFieldInterfaceToInt())
        {
        }

        public override int Convert(IField field)
        {
            if (field is IUnattackableWater)
            {
                return 5;
            }
            else
            {
                return this.SendNext(field);
            }
        }
    }
}